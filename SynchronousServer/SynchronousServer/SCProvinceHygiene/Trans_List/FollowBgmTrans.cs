using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene.Trans_List
{
    /// <summary>
    /// 糖尿病字段转换
    /// </summary>
    public class FollowBgmTrans
    {
        /// <summary>
        /// 糖尿病转换
        /// </summary>
        /// <returns></returns>
        public static Model.TransModel Trans(Model.TransModel modelTest)
        {

            try
            {
                switch (modelTest.Key)
                {

                    /**
                     *  操作用户ID
                     */
                    case "CmDiab_UserID":
                        modelTest.Value = modelTest.userInfo.DoctEmployeID;
                        return modelTest;

                    /**
                     *个人ID
                  */
                    case "OrgID":


                        modelTest.Value = modelTest.BasicInfo["ThirdParty_HID"].ToString(); ;
                        return modelTest;


                    /**
                 *个人ID
                 */
                    case "CmDiab_PersonID":

                        modelTest.Value = modelTest.userInfo.PersonID;
                        return modelTest;

                    /**
                    * 随访日期
                    */
                    case "CmDiab_FollowUpDate":
                        modelTest.Key = "followdate";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long a) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;
                    /**
                     *  随访方式 Integer 公卫：1 门诊 2 家庭 4 电话"家庭医生：公司(1.门诊,2.家庭,3.电话 )
                     */
                    case "CmDiab_WayUp":
                        modelTest.Key = "followway";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                        return modelTest;
                    /**
                     * 症状
                     */
                    case "CmDiab_Symptom":
                        modelTest.Key = "symptom";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
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
                            CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, modelTest.Value + "symptom");
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
                    case "Body_RightSbp":

                        modelTest.Key = "signBpmS";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                    * ProductCode
                    */
                    case "ProductCode":
                        modelTest.Value = modelTest.BasicInfo["ProductCode"].ToString();
                        return modelTest;
                    /**
                     * 血压舒张
                     */
                    case "Body_RightDbp":
                        modelTest.Key = "signBpmD";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";

                        return modelTest;
                    /**
                     * 体重
                     */
                    case "Body_Weight":
                        modelTest.Key = "signWeightL";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";

                        return modelTest;
                    /**
                    * 体质指数L
                    */
                    case "Body_Bmi":
                        modelTest.Key = "signExponentL";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;

                    /**
                * 足背动脉搏动1 触及正常（传值为2） 2 减弱 （传值为4） 3 消失 （传值为8）
                * 足背动脉搏动
                * 足背动脉搏动侧位 1 双侧 2 左侧 3右侧
                * 公司接收:{"type":"1","value":"0"} 
                */

                    case "Body_DorsalisPulseResult":
                        modelTest.Key = "signAcrotarsiumArtery";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? JObject.Parse(modelTest.KafkaData[modelTest.Key].ToString())["value"] : "";

                        return modelTest;


                    case "Body_DorsalisPedisArteryPulse":
                        modelTest.Key = "signAcrotarsiumArtery";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? Math.Pow(2, int.Parse(JObject.Parse(modelTest.KafkaData[modelTest.Key].ToString())["type"].ToString())).ToString() : "";
                        return modelTest;
                    /**
                     * 体征其他
                     */
                    case "CmDiab_ExamBodyOther":
                        modelTest.Key = "signOther";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";

                        return modelTest;
                    /**
                     * 日吸烟量
                     */
                    case "Lifestyle_Smoking":
                        modelTest.Key = "lifeSmokeL";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";

                        return modelTest;
                    /**
                     * 日饮酒量
                     */
                    case "Lifestyle_DailyAlcoholIntake":
                        modelTest.Key = "lifeWineL";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 运动次／周
                     */
                    case "Lifestyle_ExerciseWeekTimes":
                        modelTest.Key = "lifeSportsOneL";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 运动分钟／次
                     */
                    case "Lifestyle_EachExerciseTime":
                        modelTest.Key = "lifeSportsOneR";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;

                    /**
                     * 主食
                     */
                    case "CmDiab_Staple":
                        modelTest.Key = "lifeStapleFoodL";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;

                    /**
                     * 心理调整 良好差 公卫1 2 4公司1 2 3  
                     */
                    case "CmDiab_PsychologicalAdjustment":
                        modelTest.Key = "lifePsychology";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                        return modelTest;
                    /**
                     * 遵医行为 良好 一般 差 公卫：1 2 4 公司：1 2 3 
                     */
                    case "CmDiab_ComplianceBehavior":
                        modelTest.Key = "lifeCompliance";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                        return modelTest;
                    /**
                     * 空腹血糖值
                     */
                    case "Labora_FastingBloodGlucose":
                        modelTest.Key = "auxiliaryBgm";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 糖化血红蛋白
                     */
                    case "Labora_GlycatedHemoglobin":
                        modelTest.Key = "auxiliaryGlhgb";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 糖化血红蛋白日期
                     */
                    case "Labora_ExamDate":
                        modelTest.Key = "auxiliaryGlhgbDate";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 铺助检查其他
                     */
                    case "Labora_OtherLaboratory":
                        modelTest.Key = "auxiliaryOther";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 服药依从性
                     */
                    case "CmDiab_MedicationCompliance":
                        modelTest.Key = "compliance";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 药物不良反应
                     */
                    case "CmDiab_AdverseDrugReactions":
                        modelTest.Key = "drugDverseReaction";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 药物不良反应具体------------------------------------------------------------------------>
                     */
                    case "drugDverseReactionOther":
                        return modelTest;
                    /**
                     * 低血糖反应
                     */
                    case "CmDiab_LowBloodSugarReactions":
                        modelTest.Key = "hypoglycemia";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = modelTest.Value.Equals("3") ? "4" : modelTest.Value;
                        return modelTest;
                    /**
                     * 此次随访分类
                     */
                    case "CmDiab_FuClassifications":
                        modelTest.Key = "followclass";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = Math.Pow(2, int.Parse(modelTest.Value.ToString()) - 1).ToString();
                        return modelTest;


                    /**
                     * 下次随访时间
                     */
                    case "CmDiab_NextFollowUpDate":
                        modelTest.Key = "nextDate";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                           (modelTest.Value.ToString().Equals("") ? "" :
                            Int64.TryParse(modelTest.Value.ToString(), out long b) ?
                          CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;
                    /**
                     * 随访医生
                     */
                    case "CmDiab_DoctorName":
                        modelTest.Key = "doctorName";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;

                    /**
                     * 随访结局
                     */
                    case "CmDiab_FollowUpRemarks":
                        modelTest.Key = "followEnding";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 身高
                     */
                    case "Body_Height":
                        modelTest.Key = "height";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 左眼视力
                     */
                    case "Organ_LeftEye":
                        modelTest.Key = "leftEye";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 右眼视力
                     */
                    case "Organ_RightEye":
                        modelTest.Key = "rightEye";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 左眼纠正视力
                     */
                    case "Organ_LeftEyeVc":
                        modelTest.Key = "leftEyeVc";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 右眼纠正视力
                     */
                    case "Organ_RightEyeVc":
                        modelTest.Key = "rightEyeVc";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 听力:1 听见 2 听不清或无法听见
                     */
                    case "Organ_Hearing":
                        modelTest.Key = "hearing";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 运动能力:1 可顺利完成 2 无法独立完成其中任何一个动作
                     */
                    case "Organ_MotorFunction":
                        modelTest.Key = "motorFunction";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        return modelTest;
                    /**
                     * 餐后血糖
                     */
                    case "Labora_PostprandialBloodGlucose":
                        modelTest.Key = "pbg";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";

                        return modelTest;
                    /**
                     * 辅助检查
                     */
                    case " Labora_OtherLaboratory":
                        modelTest.Key = "laboratory";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";

                        return modelTest;
                    /**
                     * 
                     * 胰岛素
                     */
                    case "Insulindrug":

                        return modelTest;

                    /**
                    * 药品使用
                    */
                    case "Drug":
                        modelTest.Key = "healthyDrug";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        JArray list = new JArray();
                        try
                        {
                            JArray test = JArray.Parse(modelTest.Value.ToString());
                            foreach (JObject jObject in test)
                            {
                                list.Add(new JObject {
                                {"CmDrugName", jObject.ContainsKey("drugName")?jObject["drugName"]??"":"" },
                                {"DailyTimes", jObject.ContainsKey("usages")?jObject["usages"]??"":"" },
                                {"EachDose",  jObject.ContainsKey("amount")?jObject["amount"]??"":"" },
                                {"Remark", jObject.ContainsKey("unit")?jObject["unit"]??"":"" },
                                {"Remark1",jObject.ContainsKey("medicationTime")?jObject["medicationTime"]??"":"" }
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
                        return modelTest;

                }

            }
            catch (Exception ex)
            {
                return modelTest;
            }
        }



    }
}
