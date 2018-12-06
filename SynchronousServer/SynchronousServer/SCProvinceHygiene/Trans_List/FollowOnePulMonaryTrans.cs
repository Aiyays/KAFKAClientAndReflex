using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene.Trans_List
{
    /// <summary>
    /// 肺结核第一次随访
    /// </summary>
    public class FollowOnePulMonaryTrans
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string TransOKAndNo(string key) => key.Equals("1") ? "掌握" : key.Equals("2") ? "未掌握" : key;

        public static Model.TransModel Trans(Model.TransModel modelTest)
        {

            try
            {
                switch (modelTest.Key)
                {
                    case "ProductCode":
                        modelTest.Value = modelTest.BasicInfo["ProductCode"].ToString();
                        return modelTest;
                    /// <summary>
                    /// 服药后不良反应及处理
                    /// </summary>
                    case "tbFirstVisit_AdverseDrugReactions":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("adverseReaction") ? TransOKAndNo(modelTest.KafkaData["adverseReaction"].ToString()) : "-1";
                        return modelTest;
                    /// <summary>
                    /// 单独的居室(1 有，2 无)
                    /// </summary>
                    case "tbFirstVisit_AlongBedroom":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("separateRoom") ? modelTest.KafkaData["separateRoom"].ToString() : "-1";
                        return modelTest;
                    /// <summary>
                    /// 通风情况(1 良好，2 一般，4 差)
                    /// </summary>
                    case "tbFirstVisit_AreationType":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("ventilationCondition") ? modelTest.KafkaData["ventilationCondition"].ToString() : "-1";
                        modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                        return modelTest;
                    /// <summary>
                    /// 密切接触者检查
                    /// </summary>
                    case "tbFirstVisit_ContactsExam":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("closeContact") ? TransOKAndNo(modelTest.KafkaData["closeContact"].ToString()) : "-1";
                        return modelTest;
                    /// <summary>
                    /// 医生ID
                    /// </summary>
                    case "tbFirstVisit_DoctorID":
                        modelTest.Value = modelTest.userInfo.DoctEmployeID;
                        return modelTest;
                    /// <summary>
                    /// 医生名称
                    /// </summary>
                    case "tbFirstVisit_DoctorName":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("dname") ? modelTest.KafkaData["dname"].ToString() : modelTest.Value;
                        return modelTest;

                    /// <summary>
                    /// 服药记录卡的填写
                    /// </summary>
                    case "tbFirstVisit_DrugCardFill":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("recordCard") ? TransOKAndNo(modelTest.KafkaData["recordCard"].ToString()) : "-1";
                        return modelTest;

                    /// <summary>
                    /// 服药方法及药品存放
                    /// </summary>
                    case "tbFirstVisit_DrugCardStore":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("deposit") ? TransOKAndNo(modelTest.KafkaData["deposit"].ToString()) : "-1";
                        return modelTest;

                    /// <summary>
                    /// 耐药情况(1 耐药，2 非耐药，4未检测)
                    /// </summary>
                    case "tbFirstVisit_DrugFastType":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("drugResistance") ? modelTest.KafkaData["drugResistance"].ToString() : "-1";
                        modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                        return modelTest;

                    /// <summary>
                    /// 不规律服药危害
                    /// </summary>
                    case "tbFirstVisit_DrugHarm":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("irregular") ? TransOKAndNo(modelTest.KafkaData["irregular"].ToString()) : "-1";
                        return modelTest;

                    /// <summary>
                    /// 随访时间
                    /// </summary>
                    case "tbFirstVisit_FollowUpDate":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("followDate") ? modelTest.KafkaData["followDate"] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long a) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;

                    /// <summary>
                    /// 
                    /// </summary>
                    case "tbFirstVisit_ID": return modelTest;
                    /// <summary>
                    /// 生活习惯及注意事项
                    /// </summary>
                    case "tbFirstVisit_LivingPrecautions":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("mattersNeedingAttention") ? TransOKAndNo(modelTest.KafkaData["mattersNeedingAttention"].ToString()) : "-1";
                        return modelTest;
                    /// <summary>
                    /// 下次目标饮酒量
                    /// </summary>
                    case "tbFirstVisit_NextDailyAlcohol":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("nextDrink") ? modelTest.KafkaData["nextDrink"].ToString() : "-1";
                        return modelTest;

                    /// <summary>
                    /// 下次目标吸烟量
                    /// </summary>
                    case "tbFirstVisit_NextSmoking":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("nextSmoke") ? TransOKAndNo(modelTest.KafkaData["nextSmoke"].ToString()) : "-1";

                        return modelTest;


                    /// <summary>
                    /// 下次随访时间
                    /// </summary>
                    case "tbFirstVisit_NextFollowUpDate":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("nextFollowDate") ? modelTest.KafkaData["nextFollowDate"] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long b) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;

                    /// <summary>
                    /// 外出期间如何坚持服药
                    /// </summary>
                    case "tbFirstVisit_OutdoorMedication":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("insist") ? TransOKAndNo(modelTest.KafkaData["insist"].ToString()) : "-1";
                        return modelTest;
                    /// <summary>
                    /// 患者类型(1 初治，2 复治)
                    /// </summary>
                    case "tbFirstVisit_PatientType":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("patientType") ? modelTest.KafkaData["patientType"].ToString() : "-1";
                        return modelTest;

                    /// <summary>
                    /// 取药时间
                    /// </summary>
                    case "tbFirstVisit_PecipeDate":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("localTime") ? modelTest.KafkaData["localTime"] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long c) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();

                        return modelTest;
                    /// <summary>
                    /// 取药地点
                    /// </summary>
                    case "tbFirstVisit_RecipePlace":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("local") ? modelTest.KafkaData["local"].ToString() : "-1";
                        return modelTest;
                    /// <summary>
                    /// 痰菌情况(1 阳性，2 阴性，4 未查痰)
                    /// </summary>
                    case "tbFirstVisit_SputumType":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("sputumBacteria") ? modelTest.KafkaData["sputumBacteria"].ToString() : "-1";
                        modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                        return modelTest;

                    /// <summary>
                    /// 督导人员选择(1 医生，2 家属，4 自服药，8 其他)
                    /// </summary>
                    case "tbFirstVisit_Supervisor":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("supervisoryStaff") ? modelTest.KafkaData["supervisoryStaff"].ToString() : "-1";
                        modelTest.Value = Math.Pow(2, int.Parse(modelTest.Value.ToString()) - 1);
                        return modelTest;
                    /// <summary>
                    /// 症状(1 没有症状，2 咳嗽咳痰，4 低热盗汗，8 咯血或血痰，16 胸痛消瘦，32 恶心纳差，64 头痛失眠，128 视物模糊，256 皮肤瘙痒、皮疹，512 耳鸣、听力下降，1024 其他)
                    /// </summary>
                    case "tbFirstVisit_Symptom":
                            modelTest.Value = modelTest.KafkaData.ContainsKey("symptomsSigns") ? modelTest.KafkaData["symptomsSigns"].ToString() : "-1";
                            try
                            {
                                Double modelInt = 0;
                                //循环求和
                                foreach (var item in modelTest.Value.ToString().Split(','))
                                    modelInt += item.Equals("0") ? 1 : Math.Pow(2, int.Parse(item));
                                modelTest.Value = modelInt.ToString();
                            }
                            catch (Exception ex)
                            {
                                CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, modelTest.Key);
                            }
                            return modelTest;


                    /// <summary>
                    /// 结核病基本信息ID
                    /// </summary>
                    case "tbFirstVisit_TbBaseID":

                        return modelTest;
                    /// <summary>
                    /// 肺结核治疗疗程
                    /// </summary>
                    case "tbFirstVisit_TbTreatment":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("courseOfTreatment") ? TransOKAndNo(modelTest.KafkaData["courseOfTreatment"].ToString()) : "-1";
                        return modelTest;

                    /// <summary>
                    /// 治疗期间复诊查痰
                    /// </summary>
                    case "tbFirstVisit_TreatementSputum":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("visit") ? TransOKAndNo(modelTest.KafkaData["visit"].ToString()) : "-1";
                        return modelTest;

                    /// <summary>
                    /// 随访方式(1 门诊，2 家庭)
                    /// </summary>
                    case "tbFirstVisit_WayUp":

                        modelTest.Value = modelTest.KafkaData.ContainsKey("followUpMode") ? modelTest.KafkaData["followUpMode"].ToString() : "-1";
                        return modelTest;
                    /// <summary>
                    ///化疗方案
                    /// </summary>
                    case "tbDrugUse_ChemotherapyRegimen":

                        return modelTest;
                    /// <summary>
                    ///药品剂型(1 固定剂量复合制剂，2 散装药，4 板式组合，8注射剂)
                    /// </summary>
                    case "tbDrugUse_Dosage":

                        modelTest.Value = modelTest.KafkaData.ContainsKey("pharmaceuticalFormulation") ? modelTest.KafkaData["pharmaceuticalFormulation"].ToString() : "-1";
                        try
                        {
                            Double modelInt = 0;
                            //循环求和
                            foreach (var item in modelTest.Value.ToString().Split(','))
                                modelInt += Math.Pow(2, int.Parse(item) - 1);
                            modelTest.Value = modelInt.ToString();
                        }
                        catch (Exception ex)
                        {
                            CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, modelTest.Key);
                        }
                        return modelTest;

                    /// <summary>
                    ///用法(1 每日，2 间歇)
                    /// </summary>
                    case "tbDrugUse_Usage":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("usages") ? modelTest.KafkaData["usages"].ToString() : "-1";
                        return modelTest;

                    /// <summary>
                    ///日饮酒量
                    /// </summary>
                    case "examLifestyle_DailyAlcoholIntake":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("smoke") ? modelTest.KafkaData["smoke"].ToString() : "-1";
                        return modelTest;
                    /// <summary>
                    ///日吸烟量
                    /// </summary>
                    case "examLifestyle_Smoking":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("drink") ? modelTest.KafkaData["drink"].ToString() : "-1";

                        return modelTest;

                    /// <summary>
                    ///其他 
                    /// </summary>
                    case "otherJson":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("other") ? new JObject() {
                            { "Symptom", modelTest.KafkaData["other"].ToString()}
                        } : new JObject();
                        return modelTest;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonTool.SqlServer_Control.Log_WriteLine(ex.Message+modelTest.userInfo.CardID,modelTest.Key);
            }
            return modelTest;
        }


    }
}
