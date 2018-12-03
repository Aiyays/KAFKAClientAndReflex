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
    /// 名称转换成省公卫的名称
    /// </summary>
    public class NameTranslation
    {
   
    
        /// <summary>
        /// 糖尿病转换
        /// </summary>
        /// <returns></returns>
        public static Model.TransModel FollowBgmTrans(Model.TransModel modelTest)
        {

            switch (modelTest.Key)
            {
                /**
                * 随访日期
                */
                case "followdate":
                    modelTest.Key = "CmDiab_FollowUpDate";
                    modelTest.Value = (modelTest.Value is null) ? "" :
                      (modelTest.Value.ToString().Equals("") ? "" :
                       Int64.TryParse(modelTest.Value.ToString(), out long a) ?
                       CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                    return modelTest;
                /**
                 *  随访方式 Integer 公卫：1 门诊 2 家庭 4 电话"家庭医生：公司(1.门诊,2.家庭,3.电话 )
                 */
                case "followway":
                    modelTest.Key = "CmDiab_WayUp";
                    modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                    return modelTest;
                /**
                 * 症状
                 */
                case "symptom":
                    modelTest.Key = "CmDiab_Symptom";
                    try
                    {
                        Double modelInt = 0;
                        //循环求和
                        foreach (var item in modelTest.Value.ToString().Split(','))
                            modelInt += item.Equals("1") ? 1 : Math.Pow(2, 7 + int.Parse(item));
                        modelTest.Value = modelInt.ToString();
                    }
                    catch (Exception ex)
                    {
                        //异常记录
                    }
                    return modelTest;

                /**
                 * 症状其他
                 */
                //case "symptomOther":
                //    modelTest.Key = "Other";
                //    modelTest.Value = new JObject()
                //    {


                //    }.ToString();
                //    return modelTest/*"Other"*/;
                /**
                 * 血压收缩
                 */
                case "signBpmS":
                    modelTest.Key = "Body_RightSbp";
                    return modelTest;
                /**
                 * 血压舒张
                 */
                case "signBpmD":
                    modelTest.Key = "Body_RightDbp";
                    return modelTest;
                /**
                 * 体重
                 */
                case "signWeightL":
                    modelTest.Key = "Body_Weight";
                    return modelTest;
                /**
                * 体质指数L
                */
                case "signExponentL":
                    modelTest.Key = "Body_Bmi";
                    return modelTest;

                /**
                 * 足背动脉搏动1 触及正常（传值为2） 2 减弱 （传值为4） 3 消失 （传值为8）
                 * 足背动脉搏动
                 * 足背动脉搏动侧位 1 双侧 2 左侧 3右侧
                 * 公司接收:{"type":"1","value":"0"} 
                 */
                case "signAcrotarsiumArtery":
                    //足背动脉搏动侧位^足背动脉搏动
                    modelTest.Key = "Body_DorsalisPulseResult^Body_DorsalisPedisArteryPulse";
                    try
                    {
                        //实体化足背动脉搏动和足背动脉搏动侧位 
                        JObject jObject = JObject.Parse(modelTest.Value.ToString());
                        //加载足背动脉搏动侧位
                        modelTest.Value = FunctionTool.FollowBgm_signAcrotarsiumArtery(jObject["value"].ToString()) + "^";
                        //加载足背动脉搏动
                        modelTest.Value = modelTest.Value.ToString() + Math.Pow(2, int.Parse(jObject["type"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, JsonConvert.SerializeObject(modelTest));
                        //异常记录
                    }
                    return modelTest;
                /**
                 * 体征其他
                 */
                case "signOther":
                    modelTest.Key = "CmDiab_ExamBodyOther";
                    return modelTest;
                /**
                 * 日吸烟量
                 */
                case "lifeSmokeL":
                    modelTest.Key = "Lifestyle_Smoking";
                    return modelTest;
                /**
                 * 日饮酒量
                 */
                case "lifeWineL":
                    modelTest.Key = "Lifestyle_DailyAlcoholIntake";
                    return modelTest;
                /**
                 * 运动次／周
                 */
                case "lifeSportsOneL":
                    modelTest.Key = "Lifestyle_ExerciseWeekTimes";
                    return modelTest;
                /**
                 * 运动分钟／次
                 */
                case "lifeSportsOneR":
                    modelTest.Key = "Lifestyle_EachExerciseTime";
                    return modelTest;

                /**
                 * 主食
                 */
                case "lifeStapleFoodL":
                    modelTest.Key = "CmDiab_Staple";

                    return modelTest;

                /**
                 * 心理调整 良好差 公卫1 2 4公司1 2 3  
                 */
                case "lifePsychology":
                    modelTest.Key = "CmDiab_PsychologicalAdjustment";
                    modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                    return modelTest;
                /**
                 * 遵医行为 良好 一般 差 公卫：1 2 4 公司：1 2 3 
                 */
                case "lifeCompliance":
                    modelTest.Key = "CmDiab_ComplianceBehavior";
                    modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                    return modelTest;
                /**
                 * 空腹血糖值
                 */
                case "auxiliaryBgm":
                    modelTest.Key = "Labora_FastingBloodGlucose";
                    return modelTest;
                /**
                 * 糖化血红蛋白
                 */
                case "auxiliaryGlhgb":
                    modelTest.Key = "Labora_GlycatedHemoglobin";
                    return modelTest;
                /**
                 * 糖化血红蛋白日期
                 */
                case "auxiliaryGlhgbDate":
                    modelTest.Key = "Labora_ExamDate";
                    return modelTest;
                /**
                 * 铺助检查其他
                 */
                //case "auxiliaryOther":
                //    modelTest.Key = "Labora_OtherLaboratory";
                //    return modelTest;
                /**
                 * 服药依从性
                 */
                case "compliance":
                    modelTest.Key = "CmDiab_MedicationCompliance";
                    return modelTest;
                /**
                 * 药物不良反应
                 */
                case "drugDverseReaction":
                    modelTest.Key = "CmDiab_AdverseDrugReactions";
                    return modelTest;
                /**
                 * 药物不良反应具体------------------------------------------------------------------------>
                 */
                case "drugDverseReactionOther":
                    return modelTest;
                /**
                 * 低血糖反应
                 */
                case "hypoglycemia":
                    modelTest.Key = "CmDiab_LowBloodSugarReactions";
                    modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                    return modelTest;
                /**
                 * 此次随访分类
                 */
                case "followclass":
                    modelTest.Key = "CmDiab_FuClassification";
                    modelTest.Value = Math.Pow(2, int.Parse(modelTest.Value.ToString()) - 1).ToString();
                    return modelTest;


                /**
                 * 下次随访时间
                 */
                case "nextDate":
                    modelTest.Key = "CmDiab_NextFollowUpDate";
                    modelTest.Value = (modelTest.Value is null) ? "" :
                        (modelTest.Value.ToString().Equals("") ? "" :
                         Int64.TryParse(modelTest.Value.ToString(), out long b) ?
                       CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();

                    return modelTest;
                /**
                 * 随访医生
                 */
                case "doctorName":
                    modelTest.Key = "CmDiab_DoctorName";
                    return modelTest;

                /**
                 * 随访结局
                 */
                case "followEnding":
                    modelTest.Key = "CmDiab_FollowUpRemarks";

                    return modelTest;
                /**
                 * 身高
                 */
                case "height":
                    modelTest.Key = "Body_Height";
                    return modelTest;
                /**
                 * 左眼视力
                 */
                case "leftEye":
                    modelTest.Key = "Organ_LeftEye";
                    return modelTest;
                /**
                 * 右眼视力
                 */
                case "rightEye":
                    modelTest.Key = "Organ_RightEye";
                    return modelTest;
                /**
                 * 左眼纠正视力
                 */
                case "leftEyeVc":
                    modelTest.Key = "Organ_LeftEyeVc";
                    return modelTest;
                /**
                 * 右眼纠正视力
                 */
                case "rightEyeVc":
                    modelTest.Key = "Organ_RightEyeVc";
                    return modelTest;
                /**
                 * 听力:1 听见 2 听不清或无法听见
                 */
                case "hearing":
                    modelTest.Key = "Organ_Hearing";

                    return modelTest;
                /**
                 * 运动能力:1 可顺利完成 2 无法独立完成其中任何一个动作
                 */
                case "motorFunction":
                    modelTest.Key = "Organ_MotorFunction";
                    return modelTest;
                /**
                 * 餐后血糖
                 */
                case "pbg":
                    modelTest.Key = "Labora_PostprandialBloodGlucose";
                    return modelTest;
                /**
                 * 辅助检查
                 */
                case " laboratory":
                    modelTest.Key = "Labora_OtherLaboratory";
                    return modelTest;

                /**
                * 药品使用
                */
                case "healthyDrug":
                    modelTest.Key = "Drug";
                    JArray list = new JArray();
                    try
                    {
                        List<JObject> test = JsonConvert.DeserializeObject<List<JObject>>(modelTest.Value.ToString());
                        foreach (var jObject in test)
                        {
                            list.Add(new Dictionary<string, object>() {
                                {"CmDrugName", jObject.ContainsKey("drugName")?jObject["drugName"]??"":"" },
                                {"DailyTimes", jObject.ContainsKey("usages")?jObject["usages"]??"":"" },
                                {"EachDose",  jObject.ContainsKey("amount")?jObject["amount"]??"":"" },
                                {"Remark", jObject.ContainsKey("unit")?jObject["unit"]??"":"" },
                                { "Remark1",jObject.ContainsKey("medicationTime")?jObject["medicationTime"]??"":"" }
                            });
                        }
                        modelTest.Value = list;
                    }
                    catch (Exception ex)
                    {
                        CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, JsonConvert.SerializeObject(modelTest));
                    }
                    return modelTest;

                default:
                    return null;

            }

        }
    }
}
