using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene
{
    /// <summary>
    /// 分装区域
    /// </summary>
    public class FunctionalAssembly
    {
        /// <summary>
        /// 四川省公卫糖尿病的代码组装
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void Diabetes(Model.TransmitInfoModel transmitInfoModel)
        {
            ///拼装完成后 按照配置文件 发送给相应的IIS服务器
            ///从Kafka接受到的数据：Topic:"随意"， {"RecordID":"123","Type":"SCProvinceHygiene","State":"Diabetes","Data":"随意","UpJson":null}
            ///接受到的TransmitInfoModel{"ZNJTYS_Hid":"随意","RecordID":"123","Type":"SCProvinceHygiene","State":"Diabetes","Data":"随意","UpJson":null}
        }

        /// <summary>
        /// /**高血压*/
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowBpm(Model.TransmitInfoModel transmitInfoModel)
        {


        }

        /// <summary>
        /// 糖尿病
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowBgm(Model.TransmitInfoModel transmitInfoModel)
        {
            try
            {

                JObject @object = JObject.Parse(transmitInfoModel.Data);
                if (@object["doctorName"].ToString().Equals("杨明"))//-----------------==-----------------------
                {
                    return;
                }
                Model.UEEstimateModel controlModel = FunctionTool.UnificationEstimate(transmitInfoModel, Model.SlowDisEnum.糖尿病);
                //判断是否信息填充成功
                if (!controlModel.Status)
                {
                    //回执
                    transmitInfoModel.SendReceMsg(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.TableName, controlModel.ReceptID, "0", controlModel.Result, transmitInfoModel.BasicInfo["ZNJTYS_Aes"].ToString());
                    return;

                }
                JObject obj = null;
                //第三方平台拉取下来的Josn
                JObject dist_Obj = null;
                //判断是否需要更新
                JObject iSUpobj = SCProvince_Api.QueryBGM(transmitInfoModel.BasicInfo["IISServerUrl"].ToString(), transmitInfoModel.BasicInfo["RegionCode"].ToString(), controlModel.CardID, transmitInfoModel.BasicInfo["ProductCode"].ToString(), @object["followdate"].ToString());
                if (!iSUpobj["Total"].ToString().Equals("0"))
                {

                    string iD = iSUpobj["Msg"][0]["ID"].ToString();
                    dist_Obj = SCProvince_Api.QueryBgmRecordInfo(transmitInfoModel.BasicInfo["IISServerUrl"].ToString(), transmitInfoModel.BasicInfo["ProductCode"].ToString(), iD);
                    //将拉取到的数据 
                    string replObj = dist_Obj["Msg"].ToString().Replace("cmDiabetes", "CmDiab").Replace("examBody", "Body").Replace("examLaboratory", "Labora").Replace("examLifestyle", "Lifestyle").Replace("drugJson", "Drug").Replace("insulindrug", "Insulindrug").Replace("otherJson", "Other").Replace("examOrgan", "Organ");
                    //赋值替换
                    obj = JObject.Parse(replObj);
                    obj.Add("ProductCode", transmitInfoModel.BasicInfo["ProductCode"].ToString());
                }

                //判断是否需要更新
                obj = obj is null ? JObject.Parse(PreliminaryJson.FollowBgmTrans) : obj;
                //合并数据
                JObject ject = FunctionTool.UnifyTrans(obj, controlModel, transmitInfoModel.BasicInfo, @object, Trans_List.FollowBgmTrans.Trans);
                //在第三方平台新增或者修改
                JObject ret = SCProvince_Api.AddUpdateBgmInfo(transmitInfoModel.BasicInfo["IISServerUrl"].ToString(), ject);
                //上传成功
                if (ret["Msg"].ToString().Contains("成功"))
                    //记录到数据库
                    CommonTool.SqlServer_Control.DataBackup_WriteLine(dist_Obj is null ? "" : dist_Obj.ToString(), transmitInfoModel.Data, obj.ToString(), transmitInfoModel.ZNJTYS_Hid, DateTime.Now.ToString("yyyy-MM-dd"), ret.ToString(), "FollowBgm");
                //上传失败
                else//记录到数据库
                    CommonTool.SqlServer_Control.UpdateErro(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.Data, ret.ToString(), "FollowBgm");
            }
            catch (Exception ex)
            {
                //存到数据库
                CommonTool.SqlServer_Control.UpdateErro(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.Data, ex.Message + ":没有发送回执", transmitInfoModel.TableName);
                ////发送回执
                //transmitInfoModel.SendReceMsg(transmitInfoModel.ZNJTYS_Hid, transmitInfoModel.TableName, objInfo["id"].ToString(), "0", string.Format("医生{0}在省公卫平台中的该机构下查询不存在", objInfo["doctorName"].ToString()), transmitInfoModel.BasicInfo["ZNJTYS_Aes"].ToString());
            }
        }

        /// <summary>
        /// 健康体检表
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void HealthyUser(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 精神病随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowMentalPatient(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 中医药儿童管理
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void ChildrenChineseMedicine(Model.TransmitInfoModel transmitInfoModel)
        {
            Console.WriteLine(transmitInfoModel.TableName);
        }

        /// <summary>
        /// 产后42天随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowFortyTwo(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 新生儿随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowNewBaBy(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 第一次产前随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowOneAntenatal(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 一岁以内儿童
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowOneBaby(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 肺结核第一次随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowOnePulMonary(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 产后访视
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowPostPartum(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 肺结核随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowPulMonary(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 3岁以内儿童随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowThreeBaby(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 2-5次产前随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowTwoAntenatal(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 儿童两岁以内随访
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void FollowTwoBaby(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 老年人中医体质辨识
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void OldMan(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 个人基本信息表
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void UserInfo(Model.TransmitInfoModel transmitInfoModel)
        {

        }

        /// <summary>
        /// 签约
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void Contract(Model.TransmitInfoModel transmitInfoModel)
        {


        }

        /// <summary>
        /// 精神病信息补充表
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void MentalPatientPerinfo(Model.TransmitInfoModel transmitInfoModel)
        {

        }

    }
}
