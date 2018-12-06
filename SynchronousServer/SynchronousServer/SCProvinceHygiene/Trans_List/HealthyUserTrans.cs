using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene.Trans_List
{

   
    public class HealthyUserTrans
    {

        public static Model.TransModel Trans(Model.TransModel modelTest)
        {
            try
            {
                switch (modelTest.Key)
                {
                    case "ProductCode":
                        modelTest.Value = modelTest.BasicInfo["ProductCode"].ToString();
                        return modelTest;
                    case "DataSouceCode":
                        return modelTest;
                    case "MtID":
                        return modelTest;
                    //case "9F40DDD4B4B64C35B6BEF44624A5F26E",居民ID
                    case "Master_PersonID":
                        modelTest.Value = modelTest.userInfo.PersonID;
                        return modelTest;
                    //case "2018-01-19",体检日期   
                    case "Master_ExamDate":
                        modelTest.Value = GetSgwTime(modelTest.KafkaData["checkDate"].ToString()).ToString("yyyy-MM-dd");
                        return modelTest;
                    // 104,症状（1 无症状、2 头痛、4 头晕、8 心悸、
                    case "Master_Symptom":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["symptom"].ToString());
                       
                        return modelTest;
                    // 2,健康评价（如果存在异常，则保存异常信息，多个异常以\u0001分隔）
                    case "Master_Assessment":
                        modelTest.Value = modelTest.KafkaData["assessment"].ToString();
                        return modelTest;
                    //case "",健康评价异常情况，多个异常以\u0001分隔
                    case "Master_AssessmentAbnormal":
                        string value = "";
                        foreach (var item in JObject.FromObject(modelTest.KafkaData["assessmentAbnormal"]))
                        {
                            value += item.Value+"@\u0001";
                        }
                        modelTest.Value = value;
                        return modelTest;
                    // 2,健康指导（1纳入慢性病患者健康管理、2建议复查、4建议转诊）
                    case "Master_Guidance":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["guidance"].ToString());
                        return modelTest;
                    // 96,危险因素控制（1 戒烟 2 健康饮酒 4 饮食 
                    case "Master_RiskCrtl":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["riskCrtl"].ToString());
                        return modelTest;
                    // null,危险因素控制减重目标KG
                    case "Master_RiskCrtlWeight":
                        modelTest.Value = modelTest.KafkaData["riskCrtlWeight"].ToString();
                        return modelTest;
                    //case "狂犬",危险因素控制建议疫苗
                    case "Master_RiskCrtlVaccine":
                        modelTest.Value = modelTest.KafkaData["riskCrtlVaccine"].ToString();
                        return modelTest;
                    // null,危险因素控制其他
                    case "Master_RiskCrtlOther":
                        modelTest.Value = modelTest.KafkaData["riskCrtlOther"].ToString();
                        return modelTest;
                    //case "饮食清淡，加强锻炼",健康摘要
                    case "Master_HealthSummary":
                        modelTest.Value = modelTest.KafkaData["healthSummary"].ToString();
                        return modelTest;
                    //case "04CE95ED92E343FCB32AC76B4B23BB73",责任医生ID
                    case "Master_DoctorID":
                        modelTest.Value = modelTest.userInfo.DoctEmployeID;     /// modelTest.KafkaData["duid"].ToString();
                        return modelTest;
                    //case "周军",责任医生
                    case "Master_DoctorName":
                        modelTest.Value = modelTest.KafkaData["dname"].ToString();
                        return modelTest;
                    //case "E075AC49FCE443778F897CF839F3B924",操作用户ID
                    case "Master_UserID":  
                        modelTest.Value = modelTest.userInfo.DoctEmployeID;     /////////////??????
                        return modelTest;
                    //case "李茜",操作用户姓名
                    case "Master_UserName":
                        modelTest.Value = modelTest.KafkaData["dname"].ToString();    ///////???
                        return modelTest;
                    // false,是否完善
                    case "Master_IsStandard":
                        return modelTest;
                    // null 备注
                    case "Master_Remark":
                        return modelTest;
                    // 37,体温（浮点数）                    
                    case "Body_BodyTemperature":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["tem"].ToString();
                        return modelTest;
                    // 60,脉率（次/分钟）                
                    case "Body_PulseRate":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["pul"].ToString();
                        return modelTest;
                    // 61,心率（次/分钟,范围为10-200）                
                    case "Body_HeartRate":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["hr"].ToString().Length != 0 ? modelTest.KafkaData["healthyCheck"][0]["hr"] + "" : modelTest.KafkaData["healthyGeneral"][0]["pul"] + "" ;////////////////////
                        return modelTest;
                    // 63,呼吸频率（次/分钟,范围为5-99）                    
                    case "Body_RespiratoryRate":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["breath"].ToString();
                        return modelTest;
                    // 140,左侧收缩压（浮点数）            
                    case "Body_LeftSbp":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["bpmLS"].ToString();
                        return modelTest;
                    // 90,左侧舒张压（浮点数）            
                    case "Body_LeftDbp":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["bpmLD"].ToString();
                        return modelTest;
                    // 85,右侧收缩压（浮点数）            
                    case "Body_RightSbp":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["bpmRS"].ToString();
                        return modelTest;
                    // 56,右侧舒张压（浮点数）            
                    case "Body_RightDbp":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["bpmRD"].ToString();
                        return modelTest;
                    // 176,身高（CM）            
                    case "Body_Height":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["height"].ToString();
                        return modelTest;
                    // 65,体重（KG）            
                    case "Body_Weight":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["weight"].ToString();
                        return modelTest;
                    // 80,腰围（CM）                
                    case "Body_Waistline":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["waist"].ToString();
                        return modelTest;
                    // null,臀围（CM）            
                    case "Body_Hip":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["hip"].ToString();////???
                        return modelTest;
                    // 20.98,体质指数（BMI）（kg/m2）            
                    case "Body_Bmi":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["bmi"].ToString();
                        return modelTest;
                    // null,腰臀围比            
                    case "Body_Whr":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["waistToHip"].ToString();/////????
                        return modelTest;
                    // 4,足背动脉搏动（1 未触及、                         
                    case "Body_DorsalisPedisArteryPulse":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["pul"].ToString();////?????
                        return modelTest;
                    // null,足背动脉搏动侧位
                    case "Body_DorsalisPulseResult":
                        modelTest.Value = modelTest.KafkaData["healthyGeneral"][0]["pul"].ToString();/////???????
                        return modelTest;
                    // 2,口唇（1 红润、2 苍白、4 发绀、8 皲裂、16 疱疹）
                    case "Organ_Lips":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyOrgan"][0]["lips"].ToString());
                        return modelTest;
                    // 14,齿列（1 正常、2 缺齿、4 龋齿、8 义齿(假牙)）
                    case "Organ_Dentition":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["healthyOrgan"][0]["dentition"].ToString());//////
                        return modelTest;
                    //case "Organ_2148532544",齿列缺齿 （//2的[24~31] 次方的
                    case "Organ_MissingTeeth":
                        modelTest.Value =GetSgwTeethValue( modelTest.KafkaData["healthyOrgan"][0]["missingTeeth"]);/////
                        return modelTest;
                    //case "Organ_1075840016",    齿列龋齿 （同上）
                    case "Organ_Caries":
                        modelTest.Value = GetSgwTeethValue(modelTest.KafkaData["healthyOrgan"][0]["caries"]);
                        return modelTest;
                    //case "Organ_541069314",齿列义齿(假牙) （同上）
                    case "Organ_Denture":
                        modelTest.Value = GetSgwTeethValue(modelTest.KafkaData["healthyOrgan"][0]["denture"]);
                        return modelTest;
                    // 4,咽部（1 无充血、2 充血、4 淋巴滤泡增生）
                    case "Organ_Throat":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyOrgan"][0]["throat"].ToString());
                        return modelTest;
                    //case "Organ_1",左眼视力
                    case "Organ_LeftEye":
                        modelTest.Value = modelTest.KafkaData["healthyOrgan"][0]["leftEye"].ToString();
                        return modelTest;
                    //case "Organ_2",右眼视力
                    case "Organ_RightEye":
                        modelTest.Value = modelTest.KafkaData["healthyOrgan"][0]["rightEye"].ToString();
                        return modelTest;
                    //case "Organ_2.1",左眼矫正视力
                    case "Organ_LeftEyeVc":
                        modelTest.Value = modelTest.KafkaData["healthyOrgan"][0]["leftEyeVc"].ToString();
                        return modelTest;
                    //case "Organ_3.1",    右眼矫正视力
                    case "Organ_RightEyeVc":
                        modelTest.Value = modelTest.KafkaData["healthyOrgan"][0]["rightEyeVc"].ToString();
                        return modelTest;
                    // 2,听力（1 听见、2 听不清或无法听见）
                    case "Organ_Hearing":
                        modelTest.Value = modelTest.KafkaData["healthyOrgan"][0]["hearing"].ToString();
                        return modelTest;
                    // 2,运动功能（1 可顺利完成、2 无法独立完成任何一个动作）
                    case "Organ_MotorFunction":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["motorFunction"].ToString();
                        return modelTest;
                    //case "Organ_2",眼底（1 正常、2 异常）
                    case "Organ_Fundus":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["fundus"].ToString();
                        if (modelTest.Value.ToString() == "2") {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["fundusOther"].ToString();
                        }
                        return modelTest;
                    // 64,皮肤（1 正常、2 潮红、4 苍白、
                    case "Organ_Skin":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyCheck"][0]["skin"].ToString());
                        return modelTest;
                    // 8,巩膜（1 正常、2 黄染、4 充血、8 其他）
                    case "Organ_Sclera":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyCheck"][0]["sclera"].ToString());
                        return modelTest;
                    // 8,淋巴结（1 未触及、2 锁骨上、4 腋窝、8 其他）
                    case "Organ_LymphNodes":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyCheck"][0]["lymphNodes"].ToString());
                        return modelTest;
                    // 1,肺桶状胸（1 否、2 是）
                    case "Organ_BarrelChest":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["barrelChest"].ToString();
                        return modelTest;
                    //case "Organ_2",肺呼吸音（1 正常、2 异常）
                    case "Organ_BreathSounds":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["breathSounds"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["breathSoundsOther"].ToString();
                        }
                        return modelTest;
                    // 8,肺罗音（1 无、2 干罗音、4 湿罗音、8 其他）
                    case "Organ_Rale":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyCheck"][0]["rale"].ToString());
                        return modelTest;
                    // 2,心脏心律（1 齐、2 不齐、4 绝对不齐）
                    case "Organ_Rhythm":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyCheck"][0]["hr"].ToString());
                        return modelTest;
                    //case "Organ_2",心脏杂音（1 无、2 有）
                    case "Organ_HeartMurmur":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["heartMurmur"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["heartMurmurOther"].ToString();
                        }
                        return modelTest;
                    //case "Organ_2",腹部压痛（1 无、2 有）
                    case "Organ_AbdominalTenderness":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["abdominalTenderness"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["abdominalTendernessOther"].ToString();
                        }
                        return modelTest;
                    //case "Organ_2",腹部包块（1 无、2 有）
                    case "Organ_AbdominalMass":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["abdominalMass"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["abdominalMassOther"].ToString();
                        }
                        return modelTest;
                    //case "Organ_2",腹部肝大（1 无、2 有）
                    case "Organ_TheAbdomenLiver":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["abdomenLiver"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["abdomenLiverOther"].ToString();
                        }
                        return modelTest;
                    //case "Organ_2",腹部脾大（1 无、2 有）
                    case "Organ_Splenomegaly":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["splenomegaly"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["splenomegalyOther"].ToString();
                        }
                        return modelTest;
                    //case "Organ_2",移动性浊音（1 无、2 有）
                    case "Organ_ShiftingDullness":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["shiftingDullness"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["shiftingDullnessOther"].ToString();
                        }
                        return modelTest;
                    // 4,下肢水肿（1 无、2 单侧、4 双侧不对称、8 双侧对称）
                    case "Organ_LowerExtremityEdema":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyCheck"][0]["lowerExtremityEdema"].ToString());
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["lowerExtremityEdemaOther"].ToString();
                        }
                        return modelTest;
                    // 16,肛门指诊（1 未及异常、2 触痛、4 包块、8 前列腺异常 、16 其他）
                    case "Organ_Dre":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyCheck"][0]["dre"].ToString());
                        return modelTest;
                    // 16,乳腺（1 未见异常、2 乳房切除、4 异常泌乳、8 乳腺包块、16 其他）
                    case "Organ_Breast":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyCheck"][0]["breast"].ToString());
                        return modelTest;
                    //case "Organ_还好" 脏器功能其他
                    case "Organ_OrganOther":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["others"].ToString();
                        return modelTest;
                    // 30,空腹血糖，保存单位mmol/L
                    case "Labor_FastingBloodGlucose":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["fastingBloodGlucoseL"].ToString();
                        return modelTest;
                    // 25,餐后血糖mmol/L
                    case "Labor_PostprandialBloodGlucose":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["fastingBloodGlucoseR"].ToString();
                        return modelTest;
                    // 20,随机血糖mmol/L
                    case "Labor_RandomBloodGlucose":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0][""].ToString();//////////////?????
                        return modelTest;
                    // 10,血红蛋白g/L
                    case "Labor_Hemoglobin":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["hemoglobin"].ToString();
                        return modelTest;
                    //case "Labor_9",白细胞×10^9/L
                    case "Labor_Leukocyte":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["leukocyte"].ToString();
                        return modelTest;
                    //case "Labor_20",血小板×10^9/L
                    case "Labor_Platelet":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["platelet"].ToString();
                        return modelTest;
                    //case "Labor_没问题",血常规其他
                    case "Labor_OtherBlood":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["bloodOther"].ToString();
                        return modelTest;
                    //case "Labor_++++",尿蛋白（选项值分别为：-、+-、+、++、+++、++++）
                    case "Labor_UrineProtein":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["urineProtein"].ToString();
                        return modelTest;
                    //case "Labor_+++",尿糖（选项值分别为：-、+-、+、++、+++、++++）
                    case "Labor_Urine":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["urine"].ToString();
                        return modelTest;
                    //case "Labor_++",尿酮体（选项值分别为：-、+-、+、++、+++、++++）
                    case "Labor_Ketone":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["ketone"].ToString();
                        return modelTest;
                    //case "Labor_+",尿潜血（选项值分别为：-、+-、+、++、+++、++++）
                    case "Labor_OccultBloodInUrine":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["occultBloodinUrine"].ToString();
                        return modelTest;
                    //case "Labor_文字",尿常规其他
                    case "Labor_OtherUrine":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["urineOther"].ToString();
                        return modelTest;
                    // 10,尿微量白蛋白mg/dL
                    case "Labor_UrinaryAlbumin":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["urinaryAlbumin"].ToString();
                        return modelTest;
                    // 1,大便潜血（1 阴性、2 阳性）
                    case "Labor_FecalOccultBlood":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["fecalOccultBlood"].ToString();
                        return modelTest;
                    // 10,血清谷丙转氨酶U/L
                    case "Labor_SerumAla":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["serumAla"].ToString();
                        return modelTest;
                    // 11,血清谷草转氨酶U/L
                    case "Labor_SerumAa":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["serumAa"].ToString();
                        return modelTest;
                    // 12,白蛋白g/L
                    case "Labor_Albumin":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["albumin"].ToString();
                        return modelTest;
                    // 13,总胆红素μmol/L
                    case "Labor_TotalBilirubin":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["totalBilirubin"].ToString();
                        return modelTest;
                    // 14,结合胆红素μmol/L
                    case "Labor_Bilirubin":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["bilirubin"].ToString();
                        return modelTest;
                    // 15,血清肌酐μmol/L
                    case "Labor_SerumCreatinine":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["serumCreatinine"].ToString();
                        return modelTest;
                    // 16,血尿素氮mmol/L
                    case "Labor_Bun":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["bun"].ToString();
                        return modelTest;
                    // 17,血钾浓度mmol/L
                    case "Labor_PotassiumConcentration":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["potassiumConcentration"].ToString();
                        return modelTest;
                    // 18,血钠浓度mmol/L
                    case "Labor_SodiumConcentration":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["sodiumConcentration"].ToString();
                        return modelTest;
                    // 19,总胆固醇mmol/L
                    case "Labor_TotalCholesterol":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["totalCholesterol"].ToString();
                        return modelTest;
                    // 20,甘油三酯mmol/L
                    case "Labor_Triglycerides":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["triglycerides"].ToString();
                        return modelTest;
                    // null,肝功GPT
                    case "Labor_GPT":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0][""].ToString();////////???
                        return modelTest;
                    // 21,血清低密度脂蛋白胆固醇mmol/L
                    case "Labor_LdlCholesterol":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["ldlCholesterol"].ToString();
                        return modelTest;
                    // 22,血清高密度脂蛋白胆固醇mmol/L
                    case "Labor_HdlCholesterol":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["hdlCholesterol"].ToString();
                        return modelTest;
                    // 10,糖化血红蛋白%
                    case "Labor_GlycatedHemoglobin":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["glycated_hemoglobin"];
                        return modelTest;
                    //case "Labor_2",乙型肝炎表面抗原（1 阴性、2 阳性）
                    case "Labor_HepatitisBSurfaceAntigen":
                        //  modelTest.Value =  modelTest.KafkaData["healthyInspect"][0]["hepatitis_bsurface_antigen"];
                        return modelTest;
                    //case "Labor_1",    心电图（1 正常 、2 异常）
                    case "Labor_Ecg":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["ecg"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyInspect"][0]["ecgOther"].ToString();
                        }
                        return modelTest;
                    //case "Labor_1",胸部X线片（1 正常 、2 异常）
                    case "Labor_ChestXRay":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["chestXRay"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyInspect"][0]["chestXRayOther"].ToString();
                        }
                        return modelTest;
                    //case "Labor_2",腹部B超（1 正常 、2 异常）
                    case "Labor_BUltrasonicOther":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["bUltrasonicChao"].ToString();////////////???
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyInspect"][0]["bUltrasonicChaoOther"].ToString();
                        }
                        return modelTest;
                    //case "Labor_2",B超（1 正常 、2 异常）
                    case "Labor_BUltrasonicWave":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["bUltrasonicWave"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyInspect"][0]["bUltrasonicWaveOther"].ToString();
                        }
                        return modelTest;
                    //case "Labor_2",宫颈涂片（1 正常 、2 异常）
                    case "Labor_CervicalSmear":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["cervicalSmear"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyInspect"][0]["cervicalSmearOther"].ToString();
                        }
                        return modelTest;
                    //case "Labor_建议再检查",辅助检查其他
                    case "Labor_OtherLaboratory":
                        modelTest.Value = modelTest.KafkaData["healthyInspect"][0]["laboratoryOther"].ToString();
                        return modelTest;
                    // null,红细胞×10^9/L
                    case "Labor_Erythrocytes":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0][""].ToString();
                        return modelTest;
                    // null,白细胞分类计数
                    case "Labor_DifferentialCount":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0][""].ToString();
                        return modelTest;
                    // null,血转氨酶
                    case "Labor_BloodTransaminase":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0][""].ToString();
                        return modelTest;
                    // null,尿比重
                    case "Labor_Sg":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0][""].ToString();
                        return modelTest;
                    // null,尿酸碱度
                    case "Labor_Ph":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0][""].ToString();
                        return modelTest;
                    // null,淋球菌
                    case "Labor_Ng":
                        //  modelTest.Value = modelTest.KafkaData["healthyInspect"][0][""].ToString();
                        return modelTest;
                    //case "2",外阴（1 未见异常、2 异常）
                    case "Woman_Vulva":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["vulva"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["vulvaOther"].ToString();
                        }
                        return modelTest;
                    //case "Woman_2",阴道（1 未见异常、2 异常）
                    case "Woman_Vaginal":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["vaginal"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["vaginalOther"].ToString();
                        }
                        return modelTest;
                    //case "Woman_2",宫颈（1 未见异常、2 异常）
                    case "Woman_Cervix":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["cervix"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["cervixOther"].ToString();
                        }
                        return modelTest;
                    //case "Woman_2",宫体（1 未见异常、2 异常）
                    case "Woman_Palace":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["palace"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["palaceOther"].ToString();
                        }
                        return modelTest;
                    //case "Woman_2",附件（1 未见异常、2 异常）
                    case "Woman_UterineAdnexa":
                        modelTest.Value = modelTest.KafkaData["healthyCheck"][0]["uterineAdnexa"].ToString();
                        if (modelTest.Value.ToString() == "2")
                        {
                            modelTest.Value = modelTest.Value + "\u0001" + modelTest.KafkaData["healthyCheck"][0]["uterineAdnexaOther"].ToString();
                        }
                        return modelTest;
                    // null,阴道分泌物
                    case "Woman_VaginalSecretions":
                        //modelTest.Value = modelTest.KafkaData["healthyCheck"][0][""].ToString();
                        return modelTest;
                    // null,梅毒血清学试验
                    case "Woman_Vdrl":
                        //modelTest.Value = modelTest.KafkaData["healthyCheck"][0][""].ToString();
                        return modelTest;
                    // null,阴道清洁度
                    case "Woman_VaginalCleanness":
                        //modelTest.Value = modelTest.KafkaData["healthyCheck"][0][""].ToString();
                        return modelTest;
                    // null,其他
                    case "Woman_Other":
                        //modelTest.Value = modelTest.KafkaData["healthyCheck"][0][""].ToString();
                        return modelTest;
                    // null,-滴虫
                    case "Woman_Trichomonas":
                        //modelTest.Value = modelTest.KafkaData["healthyCheck"][0][""].ToString();
                        return modelTest;
                    // null念珠菌
                    case "Woman_Albicans":
                        //modelTest.Value = modelTest.KafkaData["healthyCheck"][0][""].ToString();
                        return modelTest;
                    // 8,健康状态（1 满意、2 基本满意、4 说不清楚、8 不太满意、16 不满意）
                    case "ScaleScore_Health":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["HealthyAgedTake"][0]["agedHealth"].ToString());
                        return modelTest;
                    // 4,生活能力选项（1 可自理（0～3分）、
                    case "ScaleScore_LifeSkills":
                        modelTest.Value = modelTest.KafkaData["HealthyAgedTake"][0]["agedLife"].ToString();
                        return modelTest;
                    // 13,生活能力得分
                    case "ScaleScore_LifeSkillsScore":
                        modelTest.Value = modelTest.KafkaData["HealthyAgedTake"][0]["agedLifeScore"].ToString();
                        return modelTest;
                    // 2,认知功能选项（1 粗筛阴性、2 粗筛阳性，简易智力状态检查）
                    case "ScaleScore_CognitiveFunction":
                        modelTest.Value = modelTest.KafkaData["HealthyAgedTake"][0][0][0]["agedCognitionOption"].ToString();
                        return modelTest;
                    // 21,认知功能得分（如果得分为空，表示认知粗筛阴性）
                    case "ScaleScore_CognitiveFunctionScore":
                        modelTest.Value = modelTest.KafkaData["HealthyAgedTake"][0]["agedCognitionScore"].ToString();
                        return modelTest;
                    // 2,情感状态选项（1 粗筛阴性、2 粗筛阳性，老年人抑郁评分检查）
                    case "ScaleScore_EmotionalState":
                        modelTest.Value = modelTest.KafkaData["HealthyAgedTake"][0]["agedEmotion"].ToString();
                        return modelTest;
                    // 17 情感状态得分（如果情感状态为空，表示粗筛阴性）
                    case "ScaleScore_EmotionalStateScore":
                        modelTest.Value = modelTest.KafkaData["HealthyAgedTake"][0]["agedEmotionScore"].ToString();
                        return modelTest;
                    // 4,锻炼频率（1 每天、2 每周一次以上、4 偶尔、8 不锻炼）
                    case "LifeStyle_ExerciseFrequency":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyLife"][0]["exerciseFrequency"].ToString());
                        return modelTest;
                    //case "30",每次锻炼时间（分钟）
                    case "LifeStyle_EachExerciseTime":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["exerciseEveryTime"].ToString();
                        return modelTest;
                    // 3,坚持锻炼时间（年）
                    case "LifeStyle_ExerciseTime":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["exerciseTime"].ToString();
                        return modelTest;
                    //case "LifeStyle_跑步",锻炼方式
                    case "LifeStyle_ExerciseMethod":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["exerciseWay"].ToString();
                        return modelTest;
                    // null,每周锻炼次数
                    case "LifeStyle_ExerciseWeekTimes":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0][""].ToString();
                        return modelTest;
                    // 4,饮食习惯（1 荤素均衡、2 荤食为主、4 素食为主、8 嗜盐、16 嗜油、32 嗜糖）
                    case "LifeStyle_Diet":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyLife"][0]["diet"].ToString());
                        return modelTest;
                    // 4,吸烟状况（1 从不吸烟、2 已戒烟、4 吸烟）
                    case "LifeStyle_SmokingStatus":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyLife"][0]["smokingStatus"].ToString());
                        return modelTest;
                    //case "LifeStyle_20",日吸烟量（平均支数）
                    case "LifeStyle_Smoking":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["smokingAmount"].ToString();
                        return modelTest;
                    // 23,开始吸烟年龄
                    case "LifeStyle_SmokingAge":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["smokingAge"].ToString();
                        return modelTest;
                    // 50,戒烟年龄
                    case "LifeStyle_AgeQuit":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["stopSmokingAge"].ToString();
                        return modelTest;
                    // 2,饮酒频率（1 从不、2 偶尔、4 经常、8 每天）
                    case "LifeStyle_DrinkingFrequency":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyLife"][0]["drinkingFrequency"].ToString());
                        return modelTest;
                    //case "LifeStyle_1",日饮酒量（平均两数）
                    case "LifeStyle_DailyAlcoholIntake":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["dailyAlcoholake"].ToString();
                        return modelTest;
                    // 1,是否戒酒（1 未戒酒、2 已戒酒）
                    case "LifeStyle_IsAlcohol":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["isAlcohol"].ToString();
                        return modelTest;
                    // 54,戒酒年龄
                    case "LifeStyle_AlcoholAge":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["alcoholAge"].ToString();
                        return modelTest;
                    // 25,开始饮酒年龄
                    case "LifeStyle_AgeStartedDrinking":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["drinkAge"].ToString();
                        return modelTest;
                    // 2,近一年内是否曾醉酒（1 是、2 否）
                    case "LifeStyle_IsDrunkLastYear":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["drunk"].ToString();
                        return modelTest;
                    // 16,饮酒种类（1 白酒、2 啤酒、4 红酒、8 黄酒、16 其他）
                    case "LifeStyle_AlcoholType":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyLife"][0]["alcoholType"].ToString());
                        return modelTest;
                    // 1,是否职业暴露（1 无、2 有）*
                    case "LifeStyle_IsOe":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["occupationalHistory"].ToString();
                        return modelTest;
                    //case "LifeStyle_计算机",工种
                    case "LifeStyle_Occupation":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["occupation"].ToString();
                        return modelTest;
                    // 30 从业时间（年数）
                    case "LifeStyle_WorkingTime":
                        modelTest.Value = modelTest.KafkaData["healthyLife"][0]["workingTime"].ToString();
                        return modelTest;
                    // 32,脑血管疾病（1 未发现、2 缺血性卒中、
                    case "Problems_Cerebrovascular":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyProblem"][0]["cerebrovascular"].ToString());
                        return modelTest;
                    // 32,肾脏疾病（1 未发现、2 糖尿病肾病、
                    case "Problems_Kidney":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyProblem"][0]["kidney"].ToString());
                        return modelTest;
                    // 64,心脏疾病（1 未发现、2 心肌梗死、4 心绞痛、
                    case "Problems_Heart":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyProblem"][0]["heart"].ToString());
                        return modelTest;
                    // 8,血管疾病（1 未发现、2 夹层动脉瘤、
                    case "Problems_Vascular":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyProblem"][0]["vascular"].ToString());
                        return modelTest;
                    // 16,眼部疾病（1 未发现、2 视网膜出血或渗出、
                    case "Problems_Eyes":
                        modelTest.Value = GetSgwValue(modelTest.KafkaData["healthyProblem"][0]["eyes"].ToString());
                        return modelTest;
                    // 2,神经系统疾病（1 未发现、2 有）
                    case "Problems_Nervoussystems":
                        modelTest.Value = modelTest.KafkaData["healthyProblem"][0]["nervoussystems"].ToString();
                        return modelTest;
                    // 2    其他系统疾病（1 未发现、2 有）
                    case "Problems_Others":
                        modelTest.Value = modelTest.KafkaData["healthyProblem"][0]["other"].ToString();
                        return modelTest;
                    //case "HIV快检结果",
                    case "ExamHiv_HivQuResult":
                        //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    //case "ExamHiv_HIV是否既往阳性",
                    case "ExamHiv_HivFrPositive":
                        //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    //case "ExamHiv_HIV是否采集静脉血",
                    case "ExamHiv_HivBloodCollect":
                        //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    //case "ExamHiv_HIV确诊结果",
                    case "ExamHiv_HivBloodResult":
                        //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    //case "ExamHiv_梅毒快检结果",
                    case "ExamHiv_SyphilisQuResult":
                        // //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    //case "ExamHiv_TPPA结果",
                    case "ExamHiv_TPPAResult":
                        //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    //case "ExamHiv_RPR结果",
                    case "ExamHiv_RPRResult":
                        // //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    //case "ExamHiv_安环",
                    case "ExamHiv_IUD":
                        // //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    //case "ExamHiv_怀孕"
                    case "ExamHiv_Pregnant":
                        //modelTest.Value = modelTest.KafkaData[""][0][""].ToString();
                        return modelTest;
                    case "OePostion":
                        JArray OePostionArray = new JArray() {
                        new JObject
                        {
                             "PoisonKind", 0,//毒物类型（0粉尘、1放射物质、2物理因素、3化学物质、4其他）
                             "PoisonName", modelTest.KafkaData["healthyLife"]["poisonFc"].ToString(),//毒物名称
                             "IsProtection",  modelTest.KafkaData["healthyLife"]["poisonFcOption"].ToString(),//是否防护（1无、2有）有的情况，才传防护信息值
                             "ProtectionMeasures", modelTest.KafkaData["healthyLife"]["poisonFcOther"].ToString()//防护措施
                        },
                        new JObject
                        {
                             "PoisonKind", 1,//毒物类型（0粉尘、1放射物质、2物理因素、3化学物质、4其他）
                             "PoisonName", modelTest.KafkaData["healthyLife"]["poisonFs"].ToString(),//毒物名称
                             "IsProtection",  modelTest.KafkaData["healthyLife"]["poisonFsOption"].ToString(),//是否防护（1无、2有）有的情况，才传防护信息值
                             "ProtectionMeasures", modelTest.KafkaData["healthyLife"]["poisonFsOther"].ToString()//防护措施
                        },
                        new JObject
                        {
                             "PoisonKind", 2,//毒物类型（0粉尘、1放射物质、2物理因素、3化学物质、4其他）
                             "PoisonName", modelTest.KafkaData["healthyLife"]["poisonWl"].ToString(),//毒物名称
                             "IsProtection",  modelTest.KafkaData["healthyLife"]["poisonWlOption"].ToString(),//是否防护（1无、2有）有的情况，才传防护信息值
                             "ProtectionMeasures", modelTest.KafkaData["healthyLife"]["poisonWlOther"].ToString()//防护措施
                        },
                        new JObject
                        {
                             "PoisonKind", 3,//毒物类型（0粉尘、1放射物质、2物理因素、3化学物质、4其他）
                             "PoisonName", modelTest.KafkaData["healthyLife"]["poisonHx"].ToString(),//毒物名称
                             "IsProtection",  modelTest.KafkaData["healthyLife"]["poisonHxOption"].ToString(),//是否防护（1无、2有）有的情况，才传防护信息值
                             "ProtectionMeasures", modelTest.KafkaData["healthyLife"]["poisonHxOther"].ToString()//防护措施
                        },
                        new JObject
                        {
                             "PoisonKind", 4,//毒物类型（0粉尘、1放射物质、2物理因素、3化学物质、4其他）
                             "PoisonName", modelTest.KafkaData["healthyLife"]["poisonQt"].ToString(),//毒物名称
                             "IsProtection",  modelTest.KafkaData["healthyLife"]["poisonQtOption"].ToString(),//是否防护（1无、2有）有的情况，才传防护信息值
                             "ProtectionMeasures", modelTest.KafkaData["healthyLife"]["poisonQtOther"].ToString()//防护措施
                        }
                };
                        modelTest.Value = OePostionArray;
                        return modelTest;
                    case "Vacc":
                        JArray VaccArray = new JArray();
                        foreach (JObject obj in JArray.FromObject(modelTest.KafkaData["healthyVaccination"])) {
                            VaccArray.Add(new JObject
                            {
                                 "VaccineName",modelTest.KafkaData["healthyVaccination"]["vaccineName"],//接种药物名称
                                 "VaccDate",GetSgwTime( modelTest.KafkaData["healthyVaccination"]["vaccDate"].ToString()).ToString("yyyy-MM-dd"),//接种日期
                                 "VaccOrgName", modelTest.KafkaData["healthyVaccination"]["vaccDate"]    //接种机构名称
                            });
                        }
                        modelTest.Value = VaccArray;
                        return modelTest;
                    case "Drug":
                        JArray DrugArray = new JArray();
                        foreach (JObject obj in JArray.FromObject(modelTest.KafkaData["healthyDrug"]))
                        {
                            DrugArray.Add(new JObject
                            {
                                "DrugName", modelTest.KafkaData["healthyDrug"]["drugName"] ,//药物名称
                                "Usage", modelTest.KafkaData["healthyDrug"]["usages"],//用法
                                "Amount", modelTest.KafkaData["healthyDrug"]["amount"],//用量
                                "MedicationTime",modelTest.KafkaData["healthyDrug"]["medicationTime"],//用药时长
                                "MedicationUnit",modelTest.KafkaData["healthyDrug"]["dayMonth"],//用药时长单位（1年、2月、3天）
                                "MedicationCompliance",modelTest.KafkaData["healthyDrug"]["medicationCompliance"] //1服药依从性（1规律、2间断、3不服药）
                            });
                        }
                        modelTest.Value = DrugArray;
                        return modelTest;
                    case "Hospt":
                        JArray HosptArray = new JArray();
                        foreach (JObject obj in JArray.FromObject(modelTest.KafkaData["healthyHospitaliZation"]))
                        {
                            HosptArray.Add(new JObject
                            {
                                "HistoryType", modelTest.KafkaData["healthyHospitaliZation"]["historyType"],//历史类型（1住院史、2病床史）
                                "InDate",GetSgwTime( modelTest.KafkaData["healthyHospitaliZation"]["inDate"].ToString()).ToString("yyyy-MM-dd") ,//入院日期
                                "OutDate", GetSgwTime( modelTest.KafkaData["healthyHospitaliZation"]["outDate"].ToString()).ToString("yyyy-MM-dd"),//出院日期
                                "Reason", modelTest.KafkaData["healthyHospitaliZation"]["reason"],//原因
                                "OrgName", modelTest.KafkaData["healthyHospitaliZation"]["orgName"],//医疗机构名称
                                "MedicalRecordNumber", modelTest.KafkaData["healthyHospitaliZation"]["medicalRecord"]// 病案号
                            });
                        }
                        modelTest.Value = HosptArray;
                        return modelTest;
                    case "ans1":
                        modelTest.Value="[" + (modelTest.KafkaData["HealthyAgedTake"][0]["agedLifeOption"].ToString().Contains("null")?"" : modelTest.KafkaData["HealthyAgedTake"][0]["agedLifeOption"]) + "]";
                        return modelTest;
                    case "ans2":
                        modelTest.Value = "[" + (modelTest.KafkaData["HealthyAgedTake"][0]["agedCognitionOption"].ToString().Contains("null") ? "" : modelTest.KafkaData["HealthyAgedTake"][0]["agedCognitionOption"]) + "]";
                        return modelTest;
                    case "ans3":
                        modelTest.Value = "[" + (modelTest.KafkaData["agedEmotionOption"][0]["agedLifeOption"].ToString().Contains("null") ? "" : modelTest.KafkaData["HealthyAgedTake"][0]["agedEmotionOption"]) + "]";
                        return modelTest;
                    case "Other":
                        JArray OtherArray = new JArray();
                        if (modelTest.KafkaData["symptom"].ToString().Contains("25"))    //症状其它
                        {
                            OtherArray.Add( new JObject {
                                "AttrName","Symptom",
                                "OtherText",modelTest.KafkaData["symptomOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyCheck"][0]["sclera"].ToString().Contains("4"))  
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Sclera",
                                "OtherText",modelTest.KafkaData["healthyCheck"][0]["sclera"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyCheck"][0]["skin"].ToString().Contains("7"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Skin",
                                "OtherText",modelTest.KafkaData["healthyCheck"][0]["skinOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyCheck"][0]["lymphNodes"].ToString().Contains("4"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","LymphNodes",
                                "OtherText",modelTest.KafkaData["healthyCheck"][0]["lymphNodesOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyCheck"][0]["breathSounds"].ToString().Contains("4"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","BreathSounds",
                                "OtherText",modelTest.KafkaData["healthyCheck"][0]["breathSoundsOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyCheck"][0]["rale"].ToString().Contains("4"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Rale",
                                "OtherText",modelTest.KafkaData["healthyCheck"][0]["raleOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyCheck"][0]["dre"].ToString().Contains("5"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Rale",
                                "OtherText",modelTest.KafkaData["healthyCheck"][0]["dreOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyCheck"][0]["breast"].ToString().Contains("5"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Breast",
                                "OtherText",modelTest.KafkaData["healthyCheck"][0]["breastOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyLife"][0]["alcoholType"].ToString().Contains("5"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","AlcoholType",
                                "OtherText",modelTest.KafkaData["healthyLife"][0]["alcoholTypeOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyProblem"][0]["cerebrovascular"].ToString().Contains("6"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Cerebrovascular",
                                "OtherText",modelTest.KafkaData["healthyProblem"][0]["cerebrovascularOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyProblem"][0]["kidney"].ToString().Contains("6"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Kidney",
                                "OtherText",modelTest.KafkaData["healthyProblem"][0]["kidneyOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyProblem"][0]["heart"].ToString().Contains("7"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Heart",
                                "OtherText",modelTest.KafkaData["healthyProblem"][0]["heartOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyProblem"][0]["vascular"].ToString().Contains("4"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Vascular",
                                "OtherText",modelTest.KafkaData["healthyProblem"][0]["vascularOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyProblem"][0]["eyes"].ToString().Contains("5"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Eyes",
                                "OtherText",modelTest.KafkaData["healthyProblem"][0]["eyesOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyProblem"][0]["nervoussystems"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Nervoussystems",
                                "OtherText",modelTest.KafkaData["healthyProblem"][0]["nervoussystemsOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["healthyProblem"][0]["other"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Others",
                                "OtherText",modelTest.KafkaData["healthyProblem"][0]["otherTxt"].ToString()
                            });
                        }
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
                        data += Math.Pow(2 , (Int32.Parse(value) - 1));
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
        /// 将后台值转换成公卫2次幂数据
        /// </summary>
        /// <param name="jToken"></param>
        /// <returns></returns>
        public static string GetSgwTeethValue(JToken jToken) {
            int[] v1 = { 24, 25, 26, 27, 28, 29, 30, 31 };
            int[] v2 = { 23, 22, 21, 20, 19, 18, 17, 16 };
            int[] v3 = { 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] v4 = { 7, 6, 5, 4, 3, 2, 1, 0 };
            double result = 0;
            int i = 1;
            foreach (var item in JObject.FromObject(jToken))
            {
                foreach (string value in item.Value.ToString().Split(','))
                {
                    result += Math.Pow(2, (i == 1 ? i == 2 ? 1 == 3 ? v1 : v2 : v3 : v4)[int.Parse(value) - 1]);
                }
                i += 1;
            }

            return result.ToString();
        }

        /// <summary>
        /// 判断是否为时间戳并转换成时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetSgwTime(string time) {
         string  result  =  (time is null) ? "" :
                      (time.Equals("") ? "" :
                       Int64.TryParse(time, out long a) ?
                       CommonTool.ControlTime.GetDateTime(long.Parse(time) / 1000).ToString() : time).ToString();
            return DateTime.Parse(result);

        }
    }
}



