using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene.Trans_List
{
   public class FollowOneBabyTrans
    {
        public static Model.TransModel Trans(Model.TransModel modelTest) {
            try
            {
                switch (modelTest.Key) {
                    case "ProductCode":
                        modelTest.Value = modelTest.BasicInfo["ProductCode"].ToString();
                        return modelTest;
                    //1腹部:1 未见异常 2 异常
                    case "ChildExam0To1_Abdomen":
                        modelTest.Value = modelTest.KafkaData["belly"].ToString();
                        return modelTest;
                    //1外生殖器/肛门:1 未见异常 2 异常
                    case "ChildExam0To1_AnusGenitals":
                        modelTest.Value = modelTest.KafkaData["anus"].ToString();
                        return modelTest;
                    //1前囟:1 闭合 2 未闭
                    case "ChildExam0To1_Bregma":
                        modelTest.Value = modelTest.KafkaData["bregmatic"].ToString();
                        return modelTest;
                    //*前囟长X宽
                    case "ChildExam0To1_BregmaWh":
                        modelTest.Value = modelTest.KafkaData["bregmaticW"].ToString() + "*" + modelTest.KafkaData["bregmaticH"].ToString();
                        return modelTest;
                    //
                    case "ChildExam0To1_BusinessID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();
                        return modelTest;
                    //户外活动
                    case "ChildExam0To1_OutdoorActivities":
                        modelTest.Value = modelTest.KafkaData["activity"].ToString();
                        return modelTest;
                    //服用维生素D
                    case "ChildExam0To1_VitaminD":
                        modelTest.Value = modelTest.KafkaData["vd"].ToString();
                        return modelTest;
                    //1心肺:1 未见异常 2 异常
                    case "ChildExam0To1_Cardiopulmonary":
                        modelTest.Value = modelTest.KafkaData["pneumonia"].ToString();///////////////
                        return modelTest;
                    //1面色: 1 红润 2 黄染 4 其他
                    case "ChildExam0To1_Complexion":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["face"].ToString());
                        return modelTest;
                    //1发育评估:采用2的N次幂之和的方式，不同年龄阶段内容不同，具体请参照基层系统
                    case "ChildExam0To1_DevelopmentAssessment":
                        modelTest.Value = modelTest.KafkaData["growth"].ToString();
                        return modelTest;
                    //1耳外观:1 未见异常 2 异常
                    case "ChildExam0To1_EarAppearance":
                        modelTest.Value = modelTest.KafkaData["ear"].ToString();
                        return modelTest;
                    //1眼外观:1 未见异常 2 异常
                    case "ChildExam0To1_EyeAppearance":
                        modelTest.Value = modelTest.KafkaData["eye"].ToString();
                        return modelTest;
                    //30两次随访间患病情况:1 未患病 2 患病(满月随访使用2的N次幂之和)
                    case "ChildExam0To1_FollowUpPrevalence":
                        modelTest.Value = modelTest.KafkaData["sick"].ToString();////////////////////
                        return modelTest;
                    //1腹泻次数
                    case "ChildExam0To1_Diarrhea":
                        modelTest.Value = modelTest.KafkaData["diarrhea"].ToString();
                        return modelTest;
                    //1肺炎次数
                    case "ChildExam0To1_Poeumonia":
                        modelTest.Value = modelTest.KafkaData["pneumonia"].ToString();
                        return modelTest;
                    //1外伤次数
                    case "ChildExam0To1_Trauma":
                        modelTest.Value = modelTest.KafkaData["trauma"].ToString();
                        return modelTest;
                    //其他伤害其他
                    case "ChildExam0To1_PrevalenceOther":
                        modelTest.Value = modelTest.KafkaData["other"].ToString();
                        return modelTest;
                    //1四肢:1 未见异常 2 异常
                    case "ChildExam0To1_FourLimbs":
                        modelTest.Value = modelTest.KafkaData["limb"].ToString();
                        return modelTest;
                    //33指 导:1 科学喂养 2 生长发育 3 疾病预防 4 预防意外伤害 5 口腔保健 6 其他
                    case "ChildExam0To1_Guide":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["guidance"].ToString());
                        return modelTest;
                    //头围
                    case "ChildExam0To1_HeadSize":
                        modelTest.Value = modelTest.KafkaData["head"].ToString();
                        return modelTest;
                    //0听力:1 通过 2 未通过
                    case "ChildExam0To1_Hearing":
                        modelTest.Value = modelTest.KafkaData["hearing"].ToString();
                        return modelTest;
                    //0身长评估:1上2中4下
                    case "ChildExam0To1_Height":
                        modelTest.Value = modelTest.KafkaData["heighttype"].ToString();/////////////////////////////////???
                        return modelTest;
                    //满月儿童检查ID
                    case "ChildExam0To1_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();//////////////////????
                        return modelTest;
                    //1颈部包块:1 有 2 无
                    case "ChildExam0To1_NeckBagPiece":
                        modelTest.Value = modelTest.KafkaData["neck"].ToString();
                        return modelTest;
                    //1口腔:出牙数量
                    case "ChildExam0To1_Oral":
                        modelTest.Value = modelTest.KafkaData["oral"].ToString();
                        return modelTest;
                    //其他
                    case "ChildExam0To1_Other":
                        modelTest.Value = modelTest.KafkaData[""].ToString(); ////////////////////???
                        return modelTest;
                    //1可疑佝偻病体征:采用2的N次幂之和的方式，不同年龄阶段内容不同，具体请参照基层系统
                    case "ChildExam0To1_Rickets":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["sign"].ToString());
                        return modelTest;
                    //1皮肤:1 未见异常 2 异常
                    case "ChildExam0To1_Skin":
                        modelTest.Value = modelTest.KafkaData["skin"].ToString();
                        return modelTest;
                    //0可疑佝偻病症状:采用2的N次幂之和的方式，不同年龄阶段内容不同，具体请参照基层系统
                    case "ChildExam0To1_Symptome":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["disease"].ToString());
                        return modelTest;
                    //中医药健康管理服务:1 中医饮食调养指导 2 中医起居调摄指导 4 传授摸腹、捏脊方法 8 其他
                    case "ChildExam0To1_TraditionalManagement":
                        modelTest.Value = modelTest.KafkaData[""].ToString();        ///////????
                        return modelTest;
                    //脐部:1 未脱 2 脱落 4 脐带有渗出 8 其他
                    case "ChildExam0To1_Umbilication":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["navel"].ToString());
                        return modelTest;
                    //0体重评估:1上2中4下
                    case "ChildExam0To1_Weight":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["weighttype"].ToString());////////////////????
                        return modelTest;

                    //A15668AE0F0498409994259E17329DC2个人ID
                    case "ChildExamMaster_ChildID":
                        modelTest.Value = modelTest.userInfo.PersonID;/////////////////////////
                        return modelTest;
                    //DB42E8423067C945A5BE45F5FAEB06C4 随访医生ID
                    case "ChildExamMaster_DoctorID":
                        modelTest.Value =modelTest.userInfo.DoctEmployeID;
                        return modelTest;
                    //李海阳 随访医生姓名
                    case "ChildExamMaster_DoctorName":
                        modelTest.Value = modelTest.KafkaData["dname"].ToString();
                        return modelTest;
                    //2016-01-01随访日期
                    case "ChildExamMaster_FollowUpDate":
                        modelTest.Value = modelTest.KafkaData["followdate"].ToString();
                        return modelTest;
                    //2随访类型:1 新生儿随访 2 满月儿童随访 3 三月儿童随访 4 六月儿童随访 5 八月儿童随访 6 一岁儿童随访 7 一岁半儿童随访 8 二岁儿童随访 9 二岁半儿童随访 10 三岁儿童随访 11 四岁儿童随访 12 五岁儿童随访 13 六岁儿童随访
                    case "ChildExamMaster_FollowUpKind":
                        string age = "2";
                        switch (modelTest.KafkaData["agetype"].ToString())
                        {
                            case "1":
                                age = "2";
                                break;
                            case "3":
                                age = "3";
                                break;
                            case "6":
                                age = "4";
                                break;
                            case "8":
                                age = "5";
                                break;
                        }
                        modelTest.Value = age;  /////////////////////
                        return modelTest;
                    // ID
                    case "ChildExamMaster_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();  /////////////????
                        return modelTest;
                    //0随访月龄
                    case "ChildExamMaster_Months":
                        modelTest.Value = modelTest.KafkaData["agetype"].ToString();      /////////////////
                        return modelTest;
                    //2016-01-02下次随访日期
                    case "ChildExamMaster_NextFollowUpDate":
                        modelTest.Value = modelTest.KafkaData["nextFollowDate"].ToString();
                        return modelTest;
                    //DB42E8423067C945A5BE45F5FAEB06C4
                    case "ChildExamMaster_OperatorID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();         ///////////////////????
                        return modelTest;
                    //李海阳
                    case "ChildExamMaster_OperatorName":
                        modelTest.Value = modelTest.KafkaData["dname"].ToString();
                        return modelTest;
                    //备注
                    case "ChildExamMaster_Remark":
                        modelTest.Value = modelTest.KafkaData[""].ToString();     ///////////////????
                        return modelTest;


                    //23.5
                    case "ExamBody_Height":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["height"].ToString());
                        return modelTest;
                    //
                    case "ExamBody_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();///////////////////????
                        return modelTest;
                    //6
                    case "ExamBody_Weight":
                        modelTest.Value = modelTest.KafkaData["weight"].ToString();
                        return modelTest;
                    //32血红蛋白质
                    case "ExamLaboratory_Hemoglobin":
                        modelTest.Value = modelTest.KafkaData["hb"].ToString();
                        return modelTest;
                    //
                    case "ExamLaboratory_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();
                        return modelTest;
                    ////DB42E8423067C945A5BE45F5FAEB06C4
                    //case "Ticket_EmployeeID":
                    //    modelTest.Value = modelTest.KafkaData[""].ToString();
                    //    return modelTest;
                    ////AB5EC46E84F34EFD82673A55D0F97972
                    //case "Ticket_OrgId":
                    //    modelTest.Value = modelTest.KafkaData[""].ToString();
                    //    return modelTest;
                    ////攀枝花市仁和区布德镇卫生院
                    //case "Ticket_OrgName":
                    //    modelTest.Value = modelTest.KafkaData[""].ToString();
                    //    return modelTest;
                    ////2
                    //case "Ticket_OrgType":
                    //    modelTest.Value = modelTest.KafkaData[""].ToString();
                    //    return modelTest;
                    ////["510411106"]
                    //case "Ticket_RegionCodeList":
                    //    modelTest.Value = modelTest.KafkaData[""].ToString();
                    //    return modelTest;
                    ////李海阳
                    //case "Ticket_UserName":
                    //    modelTest.Value = modelTest.KafkaData[""].ToString();
                    //    return modelTest;
                    case "OtherOptionText":
                        JArray OtherArray = new JArray();
                        if (modelTest.KafkaData["guidance"].ToString().Contains("6"))    //症状其它
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Guide",
                                "OtherText",modelTest.KafkaData["guidance"].ToString()
                            });
                        }

                        modelTest.Value = OtherArray;
                        return modelTest;
                    default:
                        return null;

                }
            }
            catch (Exception e )
            {

                CommonTool.SqlServer_Control.Log_WriteLine(e.ToString(), modelTest.KafkaData.ToString());
                return null;
            }
        }

        /// <summary>
        /// 将后台值转换成公卫二的阶层数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetSgwValue(string value)
        {
            double data = 0;
            try
            {
                if (!string.IsNullOrEmpty(value) || value != "")
                {
                    string[] ValueList = value.Split(',');
                    foreach (string item in ValueList)
                    {
                        data += Math.Pow(2, (Int32.Parse(value) - 1));
                    }
                }
            }
            catch (Exception e)
            {

                CommonTool.SqlServer_Control.Log_WriteLine(e.ToString(), value);
                //记录异常日志
                return "";
            }

            return data.ToString();
        }
        /// <summary>
        /// 判断是否为时间戳并转换成时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetSgwTime(string time)
        {
            string result = (time is null) ? "" :
                         (time.Equals("") ? "" :
                          Int64.TryParse(time, out long a) ?
                          CommonTool.ControlTime.GetDateTime(long.Parse(time) / 1000).ToString() : time).ToString();
            return DateTime.Parse(result);

        }
    }
}
