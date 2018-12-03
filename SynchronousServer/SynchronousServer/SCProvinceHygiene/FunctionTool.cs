using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCProvinceHygiene
{
    public static class FunctionTool
    {
        #region 拼装转换

        /// <summary>
        /// 足背动脉搏动侧位转换
        /// </summary> 1 双侧 2 左侧 3右侧
        /// <returns></returns>
        public static string FollowBgm_signAcrotarsiumArtery(string sample)
        {
            //选择器
            switch (sample)
            {
                case "双侧":
                    return "1";
                case "左侧":
                    return "2";
                case "右侧":
                    return "3";
                default:
                    return sample;
            }
        }

        #endregion

        #region 上传过程

        /// <summary>
        /// 家庭个人档案返回信息
        /// </summary>
        public class RetFamliyPesonInfo
        {

            /// <summary>
            /// 家庭ID
            /// </summary>
            public string FamilyID { get; set; }
            /// <summary>
            /// 区划编码
            /// </summary>
            public string RegionCode { get; set; }
            /// <summary>
            /// 个人ID
            /// </summary>
            public string PersonID { get; set; }

            /// <summary>
            /// 如果发生异常
            /// </summary>
            public string AbnormalInfo { get; set; }
        }

        /// <summary>
        /// 判断是否存在个人档案和家庭档案
        /// </summary>
        public static RetFamliyPesonInfo IsExceptpesonInfo(DataRow dr, string cardID, string name, string dateTime = null)
        {
            RetFamliyPesonInfo retFamliyPesonInfo = new RetFamliyPesonInfo();

            //请求次数
            int i = 0;
            pesonState:
            //判断是否存在个人信息
            JObject personInfo = SCProvince_Api.QueryInfomation(cardID, dr["ProductCode"].ToString(), dr["IISServerUrl"].ToString());
            try
            {
                //筛选是否请求成功
                if (personInfo.Count != 0 ? !personInfo.ContainsKey("Total") : true)
                {
                    i++;
                    if (i > 10)
                    {
                        retFamliyPesonInfo.AbnormalInfo = personInfo.ToString();
                        //记录请求失败
                        return retFamliyPesonInfo;
                    }
                    Thread.Sleep(1000);
                    //重新请求
                    goto pesonState;
                }
                else if (personInfo["Total"].ToString().Equals("0")) //判断是否存在个人ID
                {
                    int nub = 0;
                    famlyState:
                    //请求判断家庭的信息
                    JObject famliyInfo = SCProvince_Api.QueryFamilyInfo(cardID, dr["ProductCode"].ToString(), dr["IISServerUrl"].ToString());
                    if (famliyInfo.Count != 0 ? !famliyInfo.ContainsKey("Total") : true)
                    {
                        nub++;
                        if (nub > 10)
                        {
                            i = 0;
                            //记录请求失败
                            retFamliyPesonInfo.AbnormalInfo = famliyInfo.ToString();
                            //记录请求失败
                            return retFamliyPesonInfo;
                        }
                        Thread.Sleep(1000);
                        //重新请求
                        goto famlyState;
                    }
                    else if (famliyInfo["Total"].ToString().Equals("0"))
                    {

                        creatFamly:
                        JObject creatFamliy = SCProvince_Api.AddFamilyInfo(cardID, dr["ProductCode"].ToString(), dr["IISServerUrl"].ToString(), dr["RegionCode"].ToString(), dateTime is null ? DateTime.Now.ToString() : dateTime);
                        //创建家庭
                        if (creatFamliy.ContainsKey("result") ? creatFamliy["result"].ToString().Equals("1") : false)
                        {
                            retFamliyPesonInfo.FamilyID = creatFamliy["Msg"]["ID"].ToString();
                        }
                        else
                        {
                            nub++;
                            if (nub > 10)
                            {
                                i = 0;
                                //记录请求失败
                                retFamliyPesonInfo.AbnormalInfo = creatFamliy.ToString();
                                //记录请求失败
                                return retFamliyPesonInfo;
                            }
                            Thread.Sleep(1000);
                            //重新请求
                            goto creatFamly;
                        }
                    }
                    //创建个人信息
                    personInfo = SCProvince_Api.AddPersonInfo(dr["IISSrerverUrl"].ToString(), dr["ProductCode"].ToString(), cardID, name, retFamliyPesonInfo.FamilyID, dr["ReginCode"].ToString());
                }//判断是否有家庭存在

                retFamliyPesonInfo.RegionCode = personInfo["Msg"]["RegionCode"].ToString();
                retFamliyPesonInfo.FamilyID = personInfo["Msg"]["FamilyID"].ToString();
                retFamliyPesonInfo.PersonID = personInfo["Msg"]["ID"].ToString();
            }
            catch (Exception ex)
            {
                CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, "身份证号码:" + cardID);
                retFamliyPesonInfo.AbnormalInfo = ex.Message;
            }
            return retFamliyPesonInfo;
        }







        #endregion

        #region 统一上传


        /// <summary>
        /// 遍历一个Json直到最底层并返回一个拼装好的字符串
        /// </summary>
        /// <param name="object">需要遍历的Json传</param>
        /// <param name="objTrans">Json转换的方法</param>
        /// <param name="parentName">这是一个预值 用来判断是否存在上级</param>
        public static JObject UnifyTrans(JObject @object, UEEstimateModel userInfo, DataRow bascInfo, JObject kafkaObj, Func<TransModel, TransModel> objTrans, string parentName = "")
        {
            //取出
            string IsCoverfl_up = bascInfo["IsCoverfl_up"].ToString();
            //拒绝更新
            if (IsCoverfl_up.Equals("0")&&(!@object["ProductCode"].ToString().Equals("")))
                return @object;
            //循环遍历得到的参数
            foreach (var item in new JObject(@object))
            {
                try
                {
                    //创建实体
                    TransModel model = new TransModel() { Key = item.Key.Trim(), KafkaData = kafkaObj, Value = item.Value.ToString().Trim(), BasicInfo = bascInfo, userInfo = userInfo };
                    //判断是否有上级,我们的上级 用 A_B的方式代表
                    model.Key = parentName.Equals("") ? item.Key : parentName + "_" + item.Key;
                    //根据数据类型处理
                    if (item.Value.GetType().Name.Equals("JObject"))
                        model.Value = UnifyTrans(JObject.FromObject(item.Value), userInfo, bascInfo, kafkaObj, objTrans, model.Key);
                    //根据传入方法转换
                    else
                        model = objTrans(model);
                    //在这里判断为JArray直接合并 
                    if (item.Value.GetType().Name.Equals("JArray"))
                        ((JArray)@object[item.Key.Trim()]).Merge(model.Value);
                    else //赋值并返回
                        @object[item.Key.Trim()] = item.Value.ToString().Equals("") ? model.Value: IsCoverfl_up.Equals("2")? model.Value:item.Value.ToString();
                }
                catch (Exception ex)
                {
                    CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, "异常字段:" + item.Key);
                }
            }
            return @object;
        }

        /// <summary>
        /// 家庭个人信息 慢病等统一判断的部分
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        /// <param name="status">判断是否需要判断慢病</param>
        /// <returns></returns>
        public static Model.UEEstimateModel UnificationEstimate(Model.TransmitInfoModel transmitInfoModel, Model.SlowDisEnum @enum = SlowDisEnum.NULL)
        {
            //返回
            Model.UEEstimateModel retModel = new Model.UEEstimateModel()
            {
                Status = false,
            };
            try
            {
                //判断是否需要帮助建立个人
                string isAddPesonInfo = transmitInfoModel.BasicInfo["IsAddPesonInfo"].ToString();

                //接受到的数据
                JObject objInfo = JObject.Parse(transmitInfoModel.Data);
                //回执ID
                retModel.ReceptID = objInfo["id"].ToString();


                //医生查询------最后改变了医生的姓名
                JObject objDoct = SCProvince_Api.QueryDoctor(transmitInfoModel.BasicInfo["IISServerUrl"].ToString(), transmitInfoModel.BasicInfo["ProductCode"].ToString(), "王果"/* objInfo["doctorName"].ToString()*/);
                //医生在省公卫查询不到
                if (objDoct.ContainsKey("Total") ? (objDoct["Total"].ToString().Equals("0")) : true)
                {
                    //失败数据存数据库
                    CommonTool.SqlServer_Control.UpdateErro(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.Data, string.Format("医生{0}在省公卫平台中的该机构下查询不存在", objInfo["doctorName"].ToString()), transmitInfoModel.TableName);
                    //发送回执
                    retModel.Result = string.Format("医生{0}在省公卫平台中的该机构下查询不存在", objInfo["doctorName"].ToString());
                    //transmitInfoModel.SendReceMsg(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.TableName, objInfo["id"].ToString(), "0", string.Format("医生{0}在省公卫平台中的该机构下查询不存在", objInfo["doctorName"].ToString()), transmitInfoModel.BasicInfo["ZNJTYS_Aes"].ToString());
                    return retModel;
                }

                retModel.DoctEmployeID = objDoct["Msg"][0]["EMPLOYEEID"].ToString();
                //查询智能家庭医生个人信息
                JObject infoPeson_ZNJTYSObj = CommonTool.Znjtys_Api.QueryPersonInfo(transmitInfoModel.ZNJTYS_Hid, objInfo["ufid"].ToString(), transmitInfoModel.BasicInfo["ZNJTYS_Aes"].ToString());
                //病人身份证号码
                retModel.CardID = infoPeson_ZNJTYSObj["cardID"].ToString();
                retModel.Name = infoPeson_ZNJTYSObj["name"].ToString();
                //查询家庭
                JObject infoFamliy_SCPObj = SCProvince_Api.QueryFamilyInfo(retModel.CardID, transmitInfoModel.BasicInfo["ProductCode"].ToString(), transmitInfoModel.BasicInfo["IISServerUrl"].ToString());
                //判断是否存在家庭
                if (infoFamliy_SCPObj.ContainsKey("Total") ? (infoFamliy_SCPObj["Total"].ToString().Equals("0")) : true)
                {
                    infoFamliy_SCPObj = SCProvince_Api.AddFamilyInfo(retModel.CardID, transmitInfoModel.BasicInfo["ProductCode"].ToString(), transmitInfoModel.BasicInfo["IISServerUrl"].ToString(), transmitInfoModel.BasicInfo["RegionID"].ToString(), DateTime.Now.ToString());
                    retModel.FamilyID = infoFamliy_SCPObj["Msg"]["ID"].ToString();
                }
                else
                    retModel.FamilyID = infoFamliy_SCPObj["Msg"][0]["FamilyID"].ToString();

                //查询个人
                JObject infoPeson_SCPObj = SCProvince_Api.QueryInfomation(retModel.CardID, transmitInfoModel.BasicInfo["ProductCode"].ToString(), transmitInfoModel.BasicInfo["IISServerUrl"].ToString());
                //判断是否存在个人档案
                if (infoPeson_SCPObj.ContainsKey("Msg") ? (infoPeson_SCPObj["Msg"].ToString().Length < 10) : true)
                {
                    //判断医院是否给个人建档
                    if (isAddPesonInfo.Equals("0"))
                    {
                        retModel.Result = "个人档案在第三方平台不存在,且不允许建档";
                        return retModel;
                    }
                    //新建个人档案
                    infoPeson_SCPObj = SCProvince_Api.AddPersonInfo(transmitInfoModel.BasicInfo["IISServerUrl"].ToString(), transmitInfoModel.BasicInfo["ProductCode"].ToString(), retModel.CardID, retModel.Name, retModel.FamilyID, transmitInfoModel.BasicInfo["RegionCode"].ToString());
                    retModel.PersonID = infoPeson_SCPObj["Msg"]["ID"].ToString();
                }
                else
                    retModel.PersonID = infoPeson_SCPObj["Msg"][0]["ID"].ToString();
                //判断是否需要查询慢病
                if (!@enum.Equals(SlowDisEnum.NULL))
                {
                    //判断慢病
                    JObject objChronic = SCProvince_Api.QueryChronicDisease(transmitInfoModel.BasicInfo["IISServerUrl"].ToString(), transmitInfoModel.BasicInfo["ProductCode"].ToString(), transmitInfoModel.BasicInfo["RegionCode"].ToString(), retModel.CardID, @enum.ToString());
                    //慢病档案不存在或者查询失败
                    if (objChronic.ContainsKey("Total") ? objChronic["Total"].ToString().Equals("0") : true)
                    {
                        //失败数据存数据库
                        CommonTool.SqlServer_Control.UpdateErro(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.Data, string.Format("慢病档案中，证件号码{0}不存在糖尿病档案", retModel.CardID), transmitInfoModel.TableName);
                        retModel.Result = string.Format("家庭医生医院ID为{0}身份证号为{1}姓名为{2}的病人未存在慢病档案 ", transmitInfoModel.ZNJTYS_Hid, retModel.CardID, retModel.Name);
                        //发送回执
                        //transmitInfoModel.SendReceMsg(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.TableName, objInfo["id"].ToString(), "0", string.Format("医生{0}在省公卫平台中的该机构下查询不存在", objInfo["doctorName"].ToString()), transmitInfoModel.BasicInfo["ZNJTYS_Aes"].ToString());
                        return retModel;
                    }
                }
                retModel.Status = true;
            }
            catch (Exception ex)
            {
                CommonTool.SqlServer_Control.UpdateErro(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.Data, "发生异常" + ex.Message, transmitInfoModel.TableName);
                retModel.Result = string.Format("发生异常" + ex.Message, transmitInfoModel.ZNJTYS_Hid, retModel.CardID, retModel.Name);
                //CommonTool.
            }

            return retModel;
        }

        #endregion


    }
}
