using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene.Trans_List
{
  public  class FollowTwoBabyTrans
    {
        public static Model.TransModel Trans(Model.TransModel modelTest) {

            try
            {
                switch (modelTest.Key) {
                    case "ProductCode":
                        modelTest.Value = modelTest.BasicInfo["ProductCode"].ToString();
                        return modelTest;
                    //随访类型:1 新生儿随访 2 满月儿童随访 3 三月儿童随访 4 六月儿童随访 5 八月儿童随访 6 一岁儿童随访 7 一岁半儿童随访 8 二岁儿童随访 9 二岁半儿童随访 10 三岁儿童随访 11 四岁儿童随访 12 五岁儿童随访 13 六岁儿童随访
                    case "ChildExamMaster_FollowUpKind":
                        string age = "6";
                        switch (modelTest.KafkaData["agetype"].ToString())
                        {
                            case "12":
                                age = "6";
                                break;
                            case "18":
                                age = "7";
                                break;
                            case "24":
                                age = "8";
                                break;
                            case "30":
                                age = "9";
                                break;
                        }
                        modelTest.Value = age;
                        return modelTest;
                    //随访月龄
                    case "ChildExamMaster_Months":
                        modelTest.Value = modelTest.KafkaData["agetype"].ToString();
                        return modelTest;
                    //随访日期
                    case "ChildExamMaster_FollowUp":
                        modelTest.Value =GetSgwTime( modelTest.KafkaData["followdate"].ToString());
                        return modelTest;
                    //下次预约日期
                    case "ChildExamMaster_NextFollowUp":
                        modelTest.Value =GetSgwTime( modelTest.KafkaData["nextFollowDate"].ToString());
                        return modelTest;
                    //个人ID
                    case "ChildExamMaster_ChildID":
                        modelTest.Value = modelTest.userInfo.PersonID;/////////
                        return modelTest;
                    //随访医生ID
                    case "ChildExamMaster_DoctorID":
                        modelTest.Value = modelTest.userInfo.DoctEmployeID;////////////////
                        return modelTest;
                    //随访医生姓名
                    case "ChildExamMaster_DoctorName":
                        modelTest.Value = modelTest.KafkaData["dname"].ToString();
                        return modelTest;
                    //备注
                    case "ChildExamMaster_Remark":
                        modelTest.Value = modelTest.KafkaData[""].ToString();////////////
                        return modelTest;
                    //儿童随访主表ID
                    case "ChildExamMaster_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();/////////
                        return modelTest;
                    //体格检查ID
                    case "ExamBody_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();//////////
                        return modelTest;
                    //身高CM
                    case "ExamBody_Height":
                        modelTest.Value = modelTest.KafkaData["height"].ToString();
                        return modelTest;
                    //体重KG
                    case "ExamBody_Weight":
                        modelTest.Value = modelTest.KafkaData["weight"].ToString();
                        return modelTest;
                    //儿童检查ID
                    case "ChildExam1To2_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();/////////
                        return modelTest;
                    //体重评估:1上2中4下
                    case "ChildExam1To2_Weight":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["weighttype"].ToString());
                        return modelTest;
                    //身长评估:1上2中4下
                    case "ChildExam1To2_Height":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["heighttype"].ToString());
                        return modelTest;
                    //面色:1 红润 2 其他
                    case "ChildExam1To2_Complexion":
                        modelTest.Value = modelTest.KafkaData["face"].ToString();
                        return modelTest;
                    //皮肤:1 未见异常 2 异常
                    case "ChildExam1To2_Skin":
                        modelTest.Value = modelTest.KafkaData["skin"].ToString();
                        return modelTest;
                    //前囟长,宽
                    case "ChildExam1To2_BregmaWh":
                        modelTest.Value = modelTest.KafkaData["bregmaticW"].ToString() + "*" + modelTest.KafkaData["bregmaticH"].ToString();//////////
                        return modelTest;
                    //前囟:1 闭合 2 未闭
                    case "ChildExam1To2_Bregma":
                        modelTest.Value = modelTest.KafkaData["bregmatic"].ToString();
                        return modelTest;
                    //眼外观:1 未见异常 2 异常
                    case "ChildExam1To2_EyeAppearance":
                        modelTest.Value = modelTest.KafkaData["eye"].ToString();
                        return modelTest;
                    //耳外观:1 未见异常 2 异常
                    case "ChildExam1To2_EarAppearance":
                        modelTest.Value = modelTest.KafkaData["ear"].ToString();
                        return modelTest;
                    //听力:1 通过 2 未通过
                    case "ChildExam1To2_Hearing":
                        modelTest.Value = modelTest.KafkaData["hearing"].ToString();
                        return modelTest;
                    //出牙数
                    case "ChildExam1To2_TeethNumber":
                        modelTest.Value = modelTest.KafkaData["oral"].ToString();
                        return modelTest;
                    //龋齿数
                    case "ChildExam1To2_DentalCariesNumber":
                        modelTest.Value = modelTest.KafkaData["caries"].ToString();
                        return modelTest;
                    //心肺:1 未见异常 2 异常
                    case "ChildExam1To2_Cardiopulmonary":
                        modelTest.Value = modelTest.KafkaData["heartLung"].ToString();
                        return modelTest;
                    //腹部:1 未见异常 2 异常
                    case "ChildExam1To2_Abdomen":
                        modelTest.Value = modelTest.KafkaData["belly"].ToString();
                        return modelTest;
                    //四肢:1 未见异常 2 异常
                    case "ChildExam1To2_FourLimbs":
                        modelTest.Value = modelTest.KafkaData["limb"].ToString();
                        return modelTest;
                    //步态:1 未见异常 2 异常
                    case "ChildExam1To2_Gait":
                        modelTest.Value = modelTest.KafkaData["gait"].ToString();
                        return modelTest;
                    //可疑佝偻病体征:1 O型腿 2 X型腿
                    case "ChildExam1To2_Rickets":
                        modelTest.Value = modelTest.KafkaData["sign"].ToString();
                        return modelTest;
                    //外生殖器/肛门:1 未见异常 2 异常
                    case "ChildExam1To2_AnusGenitals":
                        modelTest.Value = modelTest.KafkaData[""].ToString();/////////////
                        return modelTest;
                    //户外活动
                    case "ChildExam1To2_OutdoorActivities":
                        modelTest.Value = modelTest.KafkaData["activity"].ToString();
                        return modelTest;
                    //服用维生素D
                    case "ChildExam1To2_VitaminD":
                        modelTest.Value = modelTest.KafkaData["vd"].ToString();
                        return modelTest;
                    //发育评估,按照2的N次幂之和方式
                    case "ChildExam1To2_DevelopmentAssessment":
                        modelTest.Value = modelTest.KafkaData["growth"].ToString();
                        return modelTest;
                    //两次随访间患病情况,按照2的N次幂之和方式
                    case "ChildExam1To2_FollowUpPrevalence":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["sick"].ToString());/////////////
                        return modelTest;
                    //肺炎次数
                    case "ChildExam1To2_Pneumonia":
                        modelTest.Value = modelTest.KafkaData["diarrhea"].ToString();
                        return modelTest;
                    //腹泻次数
                    case "ChildExam1To2_Diarrhea":
                        modelTest.Value = modelTest.KafkaData["diarrhea"].ToString();
                        return modelTest;
                    //外伤次数
                    case "ChildExam1To2_Trauma":
                        modelTest.Value = modelTest.KafkaData["trauma"].ToString();
                        return modelTest;
                    //其他
                    case "ChildExam1To2_PrevalenceOther":
                        modelTest.Value = modelTest.KafkaData["other"].ToString();
                        return modelTest;
                    //中医药健康管理服务:1 中医饮食调养指导 2 中医起居调摄指导 4 传授摸腹、捏脊方法 8 其他,(一岁半和两岁此选项为: 1 中医饮食调养指导 2 中医起居调摄指导 4 传授按揉迎香穴、足三里穴方法 8 其他,两岁半此选项为:1 中医饮食调养指导 2 中医起居调摄指导 4 传授按揉四神聪穴方法  8 其他 )
                    case "ChildExam1To2_TraditionalManagement":
                        modelTest.Value = modelTest.KafkaData[""].ToString();////////////
                        return modelTest;
                    //其他
                    case "ChildExam1To2_Other":
                        modelTest.Value = modelTest.KafkaData["guidanceOther"].ToString();////////////
                        return modelTest;
                    //指 导:1 科学喂养 2 生长发育 3 疾病预防 4 预防意外伤害 5 口腔保健 6 其他
                    case "ChildExam1To2_Guide":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["guidance"].ToString());
                        return modelTest;
                    //32血红蛋白质
                    case "ExamLaboratory_Hemoglobin":
                        modelTest.Value = modelTest.KafkaData["hb"].ToString();
                        return modelTest;
                    //
                    case "ExamLaboratory_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();/////////
                        return modelTest;
                        
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
            catch (Exception e)
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
