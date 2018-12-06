using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene.Trans_List
{
  public  class FollowNewBabyTrans
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
                    //随访类型:1 新生儿随访 2 满月儿童随访 3 三月儿童随访 4 六月儿童随访 5 八月儿童随访 6 一岁儿童随访 7 一岁半儿童随访 8 二岁儿童随访 9 二岁半儿童随访 10 三岁儿童随访 11 四岁儿童随访 12 五岁儿童随访 13 六岁儿童随访
                    case "ChildExamMaster_FollowUpKind":
                        modelTest.Value = 1;/////////////?????
                        return modelTest;
                    //随访日期
                    case "ChildExamMaster_FollowUp":
                        modelTest.Value = GetSgwTime(modelTest.KafkaData["followDate"].ToString()).ToString("yyyy-MM-dd"); 
                        return modelTest;
                    //新生儿个人ID
                    case "ChildExamMaster_ChildID":
                        modelTest.Value = modelTest.userInfo.PersonID;
                        return modelTest;
                    //下次预约日期
                    case "ChildExamMaster_NextFollowUp":
                        modelTest.Value = GetSgwTime(modelTest.KafkaData["nextFollowDate"].ToString()).ToString("yyyy-MM-dd"); 
                        return modelTest;
                    //随访医生ID
                    case "ChildExamMaster_DoctorID":
                        modelTest.Value = modelTest.userInfo.DoctEmployeID;
                        return modelTest;
                    //随访医生姓名
                    case "ChildExamMaster_DoctorName":
                        modelTest.Value = modelTest.KafkaData["dname"].ToString();
                        return modelTest;
                    //操作员ID
                    case "ChildExamMaster_OperatorID":
                        modelTest.Value = modelTest.userInfo.DoctEmployeID; ////////////////??
                        return modelTest;
                    //操作员姓名
                    case "ChildExamMaster_OperatorName":
                        modelTest.Value = modelTest.KafkaData["dname"].ToString();//////////???
                        return modelTest;
                    //备注
                    case "ChildExamMaster_Remark":
                        //modelTest.Value = modelTest.KafkaData[""].ToString();////////////////////???
                        return modelTest;
                    //儿童随访主表ID
                    case "ChildExamMaster_ID":
                        //modelTest.Value = modelTest.KafkaData[""].ToString();///////////////////???
                        return modelTest;
                    //基本信息ID
                    case "ChildBaseInfo_ID":
                        modelTest.Value = modelTest.BasicInfo["PersonID"].ToString();
                        return modelTest;
                    //父亲个人ID
                    case "ChildBaseInfo_FatherID":
                        //modelTest.Value = modelTest.KafkaData[""].ToString();/////////////???
                        return modelTest;
                    //父亲姓名
                    case "ChildBaseInfo_FatherName":
                        modelTest.Value = modelTest.KafkaData["fatherName"].ToString();
                        return modelTest;
                    //父亲职业
                    case "ChildBaseInfo_FatherOccupation":
                        modelTest.Value = modelTest.KafkaData["fatherJob"].ToString();
                        return modelTest;
                    //父亲联系电话
                    case "ChildBaseInfo_FatherTel":
                        modelTest.Value = modelTest.KafkaData["fatherTel"].ToString();
                        return modelTest;
                    //父亲出生日期
                    case "ChildBaseInfo_FatheBirthday":
                        modelTest.Value = GetSgwTime(modelTest.KafkaData["fatherBirthday"].ToString()).ToString("yyyy-MM-dd");
                        return modelTest;
                    //母亲个人ID
                    case "ChildBaseInfo_MotherID":
                        //modelTest.Value = modelTest.KafkaData[""].ToString();////////////????
                        return modelTest;
                    //母亲姓名
                    case "ChildBaseInfo_MotherName":
                        modelTest.Value = modelTest.KafkaData["motherName"].ToString();
                        return modelTest;
                    //母亲职业
                    case "ChildBaseInfo_MotherOccupation":
                        modelTest.Value = modelTest.KafkaData["motherJob"].ToString();
                        return modelTest;
                    //母亲联系电话
                    case "ChildBaseInfo_MotherTel":
                        modelTest.Value = modelTest.KafkaData["motherTel"].ToString();
                        return modelTest;
                    //母亲出生日期
                    case "ChildBaseInfo_MotherBirthday":
                        modelTest.Value =GetSgwTime( modelTest.KafkaData["motherBirthday"].ToString()).ToString("yyyy-MM-dd");
                        return modelTest;
                    //出生孕周
                    case "ChildBaseInfo_GestationalWeek":
                        modelTest.Value = modelTest.KafkaData["gestationalWeeks"].ToString();
                        return modelTest;
                    //母亲妊娠期患病情况:1糖尿病2妊娠期高血压4其他8无
                    case "ChildBaseInfo_MotherPregnancyIllness":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["gestationSicken"].ToString());
                        return modelTest;
                    //助产机构名称
                    case "ChildBaseInfo_BornOrgName":
                        modelTest.Value = modelTest.KafkaData["orgname"].ToString();
                        return modelTest;
                    //出生情况:1顺产2胎头吸引4产钳8剖宫16双多胎32臀位64其他
                    case "ChildBaseInfo_BornSituation":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["birthCondition"].ToString());
                        return modelTest;
                    //新生儿窒息:1无2有
                    case "ChildBaseInfo_NeonatalSuffocation":
                        modelTest.Value = modelTest.KafkaData["breath"].ToString();
                        return modelTest;
                    //APGAR评分:1 1分钟 2 5分钟 4 不详
                    case "ChildBaseInfo_ApgarScore":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["score"].ToString());
                        return modelTest;
                    //是否有畸形:1 无 2 有
                    case "ChildBaseInfo_IsDeformity":
                        modelTest.Value = modelTest.KafkaData["malformation"].ToString();
                        return modelTest;
                    //新生儿听力筛查:1 通过 2 未通过 4 未筛查 8 不详 
                    case "ChildBaseInfo_NewbornHearingScreening":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["hearing"].ToString());
                        return modelTest;
                    //新生儿疾病筛查:1 甲低 2 苯丙酮尿症 4 其他遗传代谢病
                    case "ChildBaseInfo_NeonatalIllnessScreening":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["disease"].ToString());
                        return modelTest;
                    //新生儿出生体重
                    case "ChildBaseInfo_BornWeight":
                        modelTest.Value = modelTest.KafkaData["birthWeight"].ToString();
                        return modelTest;
                    //出生身长
                    case "ChildBaseInfo_BornHeight":
                        modelTest.Value = modelTest.KafkaData["birthHeight"].ToString();
                        return modelTest;
                    //体格检查ID
                    case "ExamBody_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString(); /////???
                        return modelTest;
                    //体温
                    case "ExamBody_BodyTemperature":
                        modelTest.Value = modelTest.KafkaData["tem"].ToString();
                        return modelTest;
                    //脉率
                    case "ExamBody_PulseRate":
                        modelTest.Value = modelTest.KafkaData["pul"].ToString();
                        return modelTest;
                    //呼吸频率
                    case "ExamBody_RespiratoryRate":
                        modelTest.Value = modelTest.KafkaData["breathing"].ToString();
                        return modelTest;
                    //身高CM
                    case "ExamBody_Height":
                        modelTest.Value = modelTest.KafkaData["birthHeight"].ToString();
                        return modelTest;
                    //体重KG
                    case "ExamBody_Weight":
                        modelTest.Value = modelTest.KafkaData["nowWeight"].ToString();
                        return modelTest;
                    //新生儿检查ID
                    case "ChildExam0_ID":
                        modelTest.Value = modelTest.KafkaData[""].ToString();////////
                        return modelTest;
                    //喂养方式:1 纯母乳 2 混合 4 人工
                    case "ChildExam0_ReplacementFeeding":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["feedingType"].ToString());
                        return modelTest;
                    //每次吃奶量
                    case "ChildExam0_MilkSupply":
                        modelTest.Value = modelTest.KafkaData["milkYield"].ToString();
                        return modelTest;
                    //每日吃奶次数
                    case "ChildExam0_DailyMilkNumber":
                        modelTest.Value = modelTest.KafkaData["milkNum"].ToString();
                        return modelTest;
                    //呕吐:1 无 2 有
                    case "ChildExam0_Vomiting":
                        modelTest.Value = modelTest.KafkaData["vomit"].ToString();
                        return modelTest;
                    //大便:1 糊状 2 稀
                    case "ChildExam0_Defecate":
                        modelTest.Value = modelTest.KafkaData["shit"].ToString();
                        return modelTest;
                    //每日大便次数
                    case "ChildExam0_DailyDefecateNumber":
                        modelTest.Value = modelTest.KafkaData["shitNum"].ToString();
                        return modelTest;
                    //面色: 1 红润 2 黄染 4 其他
                    case "ChildExam0_Complexion":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["face"].ToString());
                        return modelTest;
                    //黄疸部位:1 面部 2 躯干 4 四肢 8 手足
                    case "ChildExam0_JaundiceParts":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["jaundice"].ToString());
                        return modelTest;
                    //前囟长X宽
                    case "ChildExam0_BregmaWh":
                        modelTest.Value = modelTest.KafkaData["bregmaticL"].ToString()+"*" + modelTest.KafkaData["bregmaticR"].ToString();
                        return modelTest;
                    //前囟:1 正常 2 膨隆 4 凹陷 8 其他
                    case "ChildExam0_Bregma":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["bregmaticType"].ToString());
                        return modelTest;
                    //眼外观:1 未见异常 2 异常
                    case "ChildExam0_EyeAppearance":
                        modelTest.Value = modelTest.KafkaData["eye"].ToString();
                        return modelTest;
                    //耳外观:1 未见异常 2 异常
                    case "ChildExam0_EarAppearance":
                        modelTest.Value = modelTest.KafkaData["ear"].ToString();
                        return modelTest;
                    //四肢活动度:1 未见异常 2 异常
                    case "ChildExam0_LimbsMobility":
                        modelTest.Value = modelTest.KafkaData["limb"].ToString();
                        return modelTest;
                    //颈部包块:1 无 2 有
                    case "ChildExam0_NeckBagPiece":
                        modelTest.Value = modelTest.KafkaData["neck"].ToString();
                        return modelTest;
                    //鼻外观:1 未见异常 2 异常
                    case "ChildExam0_Nose":
                        modelTest.Value = modelTest.KafkaData["nose"].ToString();
                        return modelTest;
                    //皮肤:1 未见异常 2 湿疹 4 糜烂 8 其他
                    case "ChildExam0_Skin":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["skin"].ToString());
                        return modelTest;
                    //口腔:1 未见异常 2 异常
                    case "ChildExam0_Oral":
                        modelTest.Value = modelTest.KafkaData["oral"].ToString();
                        return modelTest;
                    //肛门:1 未见异常 2 异常
                    case "ChildExam0_Anus":
                        modelTest.Value = modelTest.KafkaData["anal"].ToString();
                        return modelTest;
                    //心肺听诊:1 未见异常 2 异常
                    case "ChildExam0_CardiopulmonaryAuscultation":
                        modelTest.Value = modelTest.KafkaData["heartLung"].ToString();
                        return modelTest;
                    //胸部:1 未见异常 2 异常
                    case "ChildExam0_Chest":
                        modelTest.Value = modelTest.KafkaData["anus"].ToString();
                        return modelTest;
                    //外生殖器:1 未见异常 2 异常
                    case "ChildExam0_Reproductive":
                        modelTest.Value = modelTest.KafkaData["germ"].ToString();
                        return modelTest;
                    //腹部触诊:1 未见异常 2 异常
                    case "ChildExam0_AbdominalTouch":
                        modelTest.Value = modelTest.KafkaData["belly"].ToString();
                        return modelTest;
                    //脊柱:1 未见异常 2 异常
                    case "ChildExam0_Spinal":
                        modelTest.Value = modelTest.KafkaData["spine"].ToString();
                        return modelTest;
                    //脐带:1 未脱 2 脱落 4 脐带有渗出 8 其他
                    case "ChildExam0_Cord":
                        modelTest.Value =GetSgwValue( modelTest.KafkaData["funicle"].ToString());
                        return modelTest;
                    //指导:1 喂养指导 2 发育指导 4 防病指导 8 预防伤害指导 16 口腔保健指导 32 其他
                    case "ChildExam0_Guide":
                        modelTest.Value =GetSgwValue(modelTest.KafkaData["guidance"].ToString()) ;
                        return modelTest;
                    //下次随访地点
                    case "ChildExam0_NextFollowPlace":
                        modelTest.Value = modelTest.KafkaData["nextFollowAddr"].ToString();
                        return modelTest;
                    //性别(1男,2女,9未说明的性别,0未知性别)
                    case "Person_GenderCode":
                        modelTest.Value = modelTest.KafkaData["gendercode"].ToString();
                        return modelTest;
                    //身份证号码
                    case "Person_CardID":
                        modelTest.Value = modelTest.KafkaData["cardid"].ToString();
                        return modelTest;
                    //出生日期(必填)
                    case "Person_BirthDay":
                        modelTest.Value =GetSgwTime(modelTest.KafkaData["birthday"].ToString()).ToString("yyyy-MM-dd");
                        return modelTest;
                    //当前地址
                    case "Person_CurrentAddress":
                        modelTest.Value = modelTest.KafkaData["familyaddr"].ToString();
                        return modelTest;
                    case "OtherJson":
                        JArray OtherArray = new JArray();
                        if (modelTest.KafkaData["gestationSicken"].ToString().Contains("3"))    //症状其它
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","MotherPregnancyIllness",
                                "OtherText",modelTest.KafkaData["gestationSickenOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["birthCondition"].ToString().Contains("7"))    
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","BornSituation",
                                "OtherText",modelTest.KafkaData["birthConditionOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["breath"].ToString().Contains("2"))   
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","NeonatalSuffocation",
                                "OtherText",modelTest.KafkaData["breathOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["malformation"].ToString().Contains("2"))    
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","IsDeformity",
                                "OtherText",modelTest.KafkaData["malformationOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["disease"].ToString().Contains("3"))   
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","NeonatalIllnessScreening",
                                "OtherText",modelTest.KafkaData["diseaseOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["face"].ToString().Contains("3"))   
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Complexion",
                                "OtherText",modelTest.KafkaData["face"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["bregmaticType"].ToString().Contains("3"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Bregma",
                                "OtherText",modelTest.KafkaData["bregmaticTypeOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["eye"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","EyeAppearance",
                                "OtherText",modelTest.KafkaData["eyeOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["ear"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","EarAppearance",
                                "OtherText",modelTest.KafkaData["earOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["limb"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","LimbsMobility",
                                "OtherText",modelTest.KafkaData["limbOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["neck"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","NeckBagPiece",
                                "OtherText",modelTest.KafkaData["neckOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["nose"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Nose",
                                "OtherText",modelTest.KafkaData["noseOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["skin"].ToString().Contains("4"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Skin",
                                "OtherText",modelTest.KafkaData["skinOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["oral"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Oral",
                                "OtherText",modelTest.KafkaData["oralOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["anal"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Anus",
                                "OtherText",modelTest.KafkaData["analOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["heartLung"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","CardiopulmonaryAuscultation",
                                "OtherText",modelTest.KafkaData["heartLungOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["anus"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Chest",
                                "OtherText",modelTest.KafkaData["anusOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["germ"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Reproductive",
                                "OtherText",modelTest.KafkaData["germOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["belly"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","AbdominalTouch",
                                "OtherText",modelTest.KafkaData["bellyOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["spine"].ToString().Contains("2"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Spinal",
                                "OtherText",modelTest.KafkaData["spineOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["funicle"].ToString().Contains("3"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Cord",
                                "OtherText",modelTest.KafkaData["funicleOther"].ToString()
                            });
                        }
                        if (modelTest.KafkaData["guidance"].ToString().Contains("6"))
                        {
                            OtherArray.Add(new JObject {
                                "AttrName","Guide",
                                "OtherText",modelTest.KafkaData["guidanceOther"].ToString()
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
