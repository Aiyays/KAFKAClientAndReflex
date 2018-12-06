using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene.Trans_List
{
    /// <summary>
    /// 新肺结核随访
    /// </summary>
    public class FollowPulMonaryTrans
    {
        public Model.TransModel Trans(Model.TransModel modelTest)
        {
            try
            {
                switch (modelTest.Key)
                {
                    case "ProductCode":
                        modelTest.Value = modelTest.BasicInfo["ProductCode"].ToString();
                        return modelTest;

                    /// <summary>
                    /// 其他
                    /// </summary>
                    case "otherText":

                        return modelTest;

                    ///<summary>
                    /// <summary>
                    ///化疗方案
                    /// </summary>
                    case "tbDrugUse_ChemotherapyRegimen":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("chemotherapyRegimen") ? modelTest.KafkaData["chemotherapyRegimen"].ToString() : "-1";
                        return modelTest;

                    ///<summary>
                    /// <summary>
                    ///  "药品剂型（1 固定剂量复合制剂，2 散装药，4 板式组合药,8 注射剂 注：不选传0）",
                    /// </summary>
                    case "tbDrugUse_Dosage":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("pharmaceuticalFormulation") ? modelTest.KafkaData["pharmaceuticalFormulation"].ToString() : "0";
                        try
                        {
                            Double modelInt = 0;
                            //循环求和
                            foreach (var item in modelTest.Value.ToString().Split(','))
                                modelInt += item.Equals("0") ? 0 : Math.Pow(2, int.Parse(item));
                            modelTest.Value = modelInt.ToString();
                        }
                        catch (Exception ex)
                        {
                            CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, modelTest.Key);
                        }
                        return modelTest;

                    ///<summary>
                    /// "漏服药次数
                    /// </summary>
                    case "tbDrugUse_MissedMedNum":
                        //modelTest.Value = modelTest.KafkaData.ContainsKey("") ? modelTest.KafkaData["medicationTimes2"].ToString() : "-1";
                        return modelTest;

                    ///<summary>
                    /// "用法（1 每日，2 间隔 注：不选传0）"
                    /// </summary>
                    case "tbDrugUse_Usage":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("usages") ? modelTest.KafkaData["usages"].ToString() : "0";
                        return modelTest;


                    /// <summary>
                    /// 药物不良反应（1 无，2 有）
                    /// </summary>
                    case "tbFollowUp2_AdverseDrugReactions":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("adverseReaction") ? modelTest.KafkaData["adverseReaction"].ToString() : "0";
                        return modelTest;

                    /// <summary>
                    /// 并发症或合并症（1 无，2 有）
                    /// </summary>
                    case "tbFollowUp2_Complication":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("complicationOther") ? modelTest.KafkaData["complicationOther"].ToString() : "0";
                        return modelTest;


                    /// <summary>
                    /// 医生ID
                    /// </summary>
                    case "tbFollowUp2_DoctorID":
                        modelTest.Value = modelTest.userInfo.DoctEmployeID;
                        return modelTest;

                    /// <summary>
                    /// 医生姓名
                    /// </summary>
                    case "tbFollowUp2_DoctorName":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("dname") ? modelTest.KafkaData["dname"].ToString() : "0";
                        return modelTest;

                    /// <summary>
                    /// 随访时间
                    /// </summary>
                    case "tbFollowUp2_FollowUpDate":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("followDate") ? modelTest.KafkaData["followDate"] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long c) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;

                    /// <summary>
                    /// 处理意见
                    /// </summary>
                    case "tbFollowUp2_FollowUpRemarks":
                        return modelTest;

                    /// <summary>
                    /// 
                    /// </summary>
                    case "tbFollowUp2_ID": return modelTest;

                    /// <summary>
                    /// 下次饮酒量
                    /// </summary>
                    case "tbFollowUp2_NextDailyAlcohol":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("nextDrink") ? modelTest.KafkaData["nextDrink"].ToString() : "0";
                        return modelTest;

                    /// <summary>
                    /// 下次随访日期
                    /// </summary>
                    case "tbFollowUp2_NextFollowUpDate":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("nextFollowDate") ? modelTest.KafkaData["nextFollowDate"] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long e) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;

                    /// <summary>
                    /// 下次吸烟数
                    /// </summary>
                    case "tbFollowUp2_NextSmoking":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("nextSmoke") ? modelTest.KafkaData["nextSmoke"].ToString() : "0";
                        return modelTest;
                    
                    /// <summary>
                    /// 个人ID
                    /// </summary>
                    case "tbFollowUp2_PersonID":
                        modelTest.Value = modelTest.userInfo.PersonID;
                        return modelTest;
                    
                    /// <summary>
                    /// 督导人员
                    /// </summary>
                    case "tbFollowUp2_Supervisor":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("supervisoryStaff") ? modelTest.KafkaData["supervisoryStaff"].ToString() : "0";
                        return modelTest;
                   
                        /// <summary>
                    /// 症状及体征（1 无，2 咳嗽咳痰，4 低热盗汗，8 咳血或血痰，16 胸痛消瘦，32 恶心纳差，64 关节疼痛，128 头痛失眠，256 视物模糊，512 皮肤瘙痒，1024 耳鸣，听力下降，2048 其他）
                    /// </summary>
                    case "tbFollowUp2_Symptom":
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
                    /// 
                    /// </summary>
                    case "tbFollowUp2_TbBaseID": return modelTest;

                    /// <summary>
                    /// 2周内随访结果
                    /// </summary>
                    case "tbFollowUp2_TranOut":
                        return modelTest;

                    /// <summary>
                    /// 治疗月序
                    /// </summary>
                    case "tbFollowUp2_TreatmentMonthOrder": return modelTest;

                    /// <summary>
                    /// 随访方式
                    /// </summary>
                    case "tbFollowUp2_WayUp":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("followUpMode") ? modelTest.KafkaData["followUpMode"].ToString() : "0";
                        return modelTest;

                    /// <summary>
                    /// 停止治疗时间
                    /// </summary>
                    case "tbFollowUp2_StopTreatDate":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("stopTime") ? modelTest.KafkaData["stopTime"] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long d) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;

                    /// <summary>
                    /// 停止治疗原因
                    /// </summary>
                    case "tbFollowUp2_StopTreatReason":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("stopTreatment") ? modelTest.KafkaData["stopTreatment"].ToString() : "0";
                        return modelTest;
                    /// <summary>
                    /// 应访视次数
                    /// </summary>
                    case "tbFollowUp2_ShouldFollowUpCnt":
                
                        return modelTest;
                    /// <summary>
                    /// 实际访视次数
                    /// </summary>
                    case "tbFollowUp2_ActualFollowUpCnt":

                        return modelTest;
                    /// <summary>
                    /// 应服药
                    /// </summary>
                    case "tbFollowUp2_ShouldMedicationCnt":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("visitingPatients") ? modelTest.KafkaData["visitingPatients"].ToString() : "0";
                        return modelTest;
                    /// <summary>
                    /// 实际服药
                    /// </summary>
                    case "tbFollowUp2_ActualMedicationCnt":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("actualMedication") ? modelTest.KafkaData["actualMedication"].ToString() : "0";
                        return modelTest;
                    /// <summary>
                    /// 服药率
                    /// </summary>
                    case "tbFollowUp2_MedicationRate":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("medicationRate") ? modelTest.KafkaData["medicationRate2"].ToString() : "0";
                        return modelTest;

                    /// <summary>
                    /// 评估医生ID
                    /// </summary>
                    case "tbFollowUp2_AppraiseDoctorID":
                        modelTest.Value = modelTest.userInfo.DoctEmployeID;
                        return modelTest;

                    /// <summary>
                    /// 评估医生名称
                    /// </summary>
                    case "tbFollowUp2_AppraiseDoctorName":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("evaluationDoctor") ? modelTest.KafkaData["evaluationDoctor"].ToString() : "0";
                        return modelTest;
                    default:   break;
                }


            }
            catch (Exception ex)
            {

            }




            return modelTest;

        }






    }
}
