using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene
{
    /// <summary>
    /// 省公卫上传预留字段
    /// </summary>
    public static class PreliminaryJson
    {

        /// <summary>
        /// 省公卫测试预留字段   readonly必加
        /// </summary>
        public static readonly string Test = "{}";

        /// <summary>
        /// 糖尿病
        /// </summary>
        public static readonly string FollowBgmTrans = "{\"CmDiab\":{\"ID\":\"\",//\"PersonID\":\"\",//\"FollowUpDate\":\"\",//\"LowBloodSugarReactions\":\"\",//\"WayUp\":\"\",//\"Symptom\":\"\",//\"ExamBodyOther\":\"\",//\"NextWeight\":\"\",//\"NextHeartRate\":\"\",//\"NextSmoking\":\"\",//\"NextDailyAlcohol\":\"\",//\"NextExerciseWeekTimes\":\"\",//\"NextExerciseWeekMinute\":\"\",//\"Staple\":\"\",//\"NextStaple\":\"\",//\"PsychologicalAdjustment\":\"\",//\"ComplianceBehavior\":\"\",//\"MedicationCompliance\":\"\",//\"AdverseDrugReactions\":\"\",//\"FuClassification\":\"\",//\"FollowUpRemarks\":\"\",//\"NextFollowUpDate\":\"\",//\"DoctorName\":\"\",//\"UserID\":\"\",//\"DoctorID\":\"\"},//\"Body\":{\"BodyTemperature\":\"\",//\"DorsalisPedisArteryPulse\":\"\",//\"DorsalisPulseResult\":\"\",//\"HeartRate\":\"\",//\"RespiratoryRate\":\"\",//\"LeftSbp\":\"\",//\"LeftDbp\":\"\",//\"RightSbp\":\"\",//\"RightDbp\":\"\",//\"Height\":\"\",//\"Weight\":\"\",//\"Waistline\":\"\",//\"Hip\":\"\",//\"Bmi\":\"\"},//\"Labora\":{\"ID\":\"\",//\"FastingBloodGlucose\":\"\",//\"PostprandialBloodGlucose\":\"\",//\"RandomBloodGlucose\":\"\",//\"Hemoglobin\":\"\",//\"Leukocyte\":\"\",//\"Platelet\":\"\",//\"OtherBlood\":\"\",//\"UrineProtein\":\"\",//\"Urine\":\"\",//\"Ketone\":\"\",//\"OccultBloodInUrine\":\"\",//\"OtherUrine\":\"\",//\"UrinaryAlbumin\":\"\",//\"FecalOccultBlood\":\"\",//\"SerumAla\":\"\",//\"SerumAa\":\"\",//\"Albumin\":\"\",//\"TotalBilirubin\":\"\",//\"Bilirubin\":\"\",//\"SerumCreatinine\":\"\",//\"Bun\":\"\",//\"PotassiumConcentration\":\"\",//\"SodiumConcentration\":\"\",//\"TotalCholesterol\":\"\",//\"Triglycerides\":\"\",//\"GPT\":\"\",//\"LdlCholesterol\":\"\",//\"HdlCholesterol\":\"\",//\"GlycatedHemoglobin\":\"\",//\"HepatitisBSurfaceAntigen\":\"\",//\"Ecg\":\"\",//\"ChestXRay\":\"\",//\"BUltrasonicWave\":\"\",//\"CervicalSmear\":\"\",//\"OtherLaboratory\":\"\",//\"ExamDate\":\"\",//\"Erythrocytes\":\"\",//\"DifferentialCount\":\"\",//\"BloodTransaminase\":\"\",//\"Sg\":\"\",//\"Ph\":\"\",//\"Ng\":\"\",//\"Tppa\":\"\",//\"Hiv\":\"\"},//\"Lifestyle\":{\"ID\":\"\",//\"ExerciseFrequency\":\"\",//\"EachExerciseTime\":\"\",//\"ExerciseWeekTimes\":\"\",//\"Smoking\":\"\",//\"DailyAlcoholIntake\":\"\"},//\"Drug\":[],//\"Insulindrug\":[],//\"Organ\":{\"LeftEye\":\"\",//\"RightEye\":\"\",//\"LeftEyeVc\":\"\",//\"RightEyeVc\":\"\",//\"Hearing\":\"\",//\"MotorFunction\":\"\"},//\"Other\":[],//\"transout\":{\"TargetOrgName\":\"\",//\"TranoutReasons\":\"\"},//\"OrgID\":\"\"}";
        /// <summary>
        /// 健康体检表
        /// </summary>
        public static readonly string HealthyUserTrans = "{\"ProductCode\":\"\",\"DataSouceCode\":\"\",\"MtID\":\"\",\"ans1\":\"\",\"ans2\":\"\",\"ans3\":\"\",\"Master\":{\"PersonID\":\"\",\"ExamDate\":\"\",\"Symptom\":\"\",\"Assessment\":\"\",\"AssessmentAbnormal\":\"\",\"Guidance\":\"\",\"RiskCrtl\":\"\",\"RiskCrtlWeight\":\"\",\"RiskCrtlVaccine\":\"\",\"RiskCrtlOther\":\"\",\"HealthSummary\":\"\",\"DoctorID\":\"\",\"DoctorName\":\"\",\"UserID\":\"\",\"UserName\":\"\",\"IsStandard\":\"\",\"Remark\":\"\",},\"Body\":{\"BodyTemperature\":\"\",\"PulseRate\":\"\",\"HeartRate\":\"\",\"RespiratoryRate\":\"\",\"LeftSbp\":\"\",\"LeftDbp\":\"\",\"RightSbp\":\"\",\"RightDbp\":\"\",\"Height\":\"\",\"Weight\":\"\",\"Waistline\":\"\",\"Hip\":\"\",\"Bmi\":\"\",\"Whr\":\"\",\"DorsalisPedisArteryPulse\":\"\",\"DorsalisPulseResult\":\"\",},\"Organ\":{\"Lips\":\"\",\"Dentition\":\"\",\"MissingTeeth\":\"\",\"Caries\":\"\",\"Denture\":\"\",\"Throat\":\"\",\"LeftEye\":\"\",\"RightEye\":\"\",\"LeftEyeVc\":\"\",\"RightEyeVc\":\"\",\"Hearing\":\"\",\"MotorFunction\":\"\",\"Fundus\":\"\",\"Skin\":\"\",\"Sclera\":\"\",\"LymphNodes\":\"\",\"BarrelChest\":\"\",\"BreathSounds\":\"\",\"Rale\":\"\",\"Rhythm\":\"\",\"HeartMurmur\":\"\",\"AbdominalTenderness\":\"\",\"AbdominalMass\":\"\",\"TheAbdomenLiver\":\"\",\"Splenomegaly\":\"\",\"ShiftingDullness\":\"\",\"LowerExtremityEdema\":\"\",\"Dre\":\"\",\"Breast\":\"\",\"OrganOther\":\"\",},\"Labor\":{\"FastingBloodGlucose\":\"\",\"PostprandialBloodGlucose\":\"\",\"RandomBloodGlucose\":\"\",\"Hemoglobin\":\"\",\"Leukocyte\":\"\",\"Platelet\":\"\",\"OtherBlood\":\"\",\"UrineProtein\":\"\",\"Urine\":\"\",\"Ketone\":\"\",\"OccultBloodInUrine\":\"\",\"OtherUrine\":\"\",\"UrinaryAlbumin\":\"\",\"FecalOccultBlood\":\"\",\"SerumAla\":\"\",\"SerumAa\":\"\",\"Albumin\":\"\",\"TotalBilirubin\":\"\",\"Bilirubin\":\"\",\"SerumCreatinine\":\"\",\"Bun\":\"\",\"PotassiumConcentration\":\"\",\"SodiumConcentration\":\"\",\"TotalCholesterol\":\"\",\"Triglycerides\":\"\",\"GPT\":\"\",\"LdlCholesterol\":\"\",\"HdlCholesterol\":\"\",\"GlycatedHemoglobin\":\"\",\"HepatitisBSurfaceAntigen\":\"\",\"Ecg\":\"\",\"ChestXRay\":\"\",\"BUltrasonicOther\":\"\",\"BUltrasonicWave\":\"\",\"CervicalSmear\":\"\",\"OtherLaboratory\":\"\",\"Erythrocytes\":\"\",\"DifferentialCount\":\"\",\"BloodTransaminase\":\"\",\"Sg\":\"\",\"Ph\":\"\",\"Ng\":\"\",},\"Woman\":{\"Vulva\":\"\",\"Vaginal\":\"\",\"Cervix\":\"\",\"Palace\":\"\",\"UterineAdnexa\":\"\",\"VaginalSecretions\":\"\",\"Vdrl\":\"\",\"VaginalCleanness\":\"\",\"Other\":\"\",\"Trichomonas\":\"\",\"Albicans\":\"\",},\"OePostion\":[],\"Vacc\":[],\"Drug\":[],\"Hospt\":[],\"ScaleScore\":{\"Health\":\"\",\"LifeSkills\":\"\",\"LifeSkillsScore\":\"\",\"CognitiveFunction\":\"\",\"CognitiveFunctionScore\":\"\",\"EmotionalState\":\"\",\"EmotionalStateScore\":\"\",},\"LifeStyle\":{\"ExerciseFrequency\":\"\",\"EachExerciseTime\":\"\",\"ExerciseTime\":\"\",\"ExerciseMethod\":\"\",\"ExerciseWeekTimes\":\"\",\"Diet\":\"\",\"SmokingStatus\":\"\",\"Smoking\":\"\",\"SmokingAge\":\"\",\"AgeQuit\":\"\",\"DrinkingFrequency\":\"\",\"DailyAlcoholIntake\":\"\",\"IsAlcohol\":\"\",\"AlcoholAge\":\"\",\"AgeStartedDrinking\":\"\",\"IsDrunkLastYear\":\"\",\"AlcoholType\":\"\",\"IsOe\":\"\",\"Occupation\":\"\",\"WorkingTime\":\"\",},\"Problems\":{\"Cerebrovascular\":\"\",\"Kidney\":\"\",\"Heart\":\"\",\"Vascular\":\"\",\"Eyes\":\"\",\"Nervoussystems\":\"\",\"Others\":\"\",},\"ExamHiv\":{\"HivQuResult\":\"\",\"HivFrPositive\":\"\",\"HivBloodCollect\":\"\",\"HivBloodResult\":\"\",\"SyphilisQuResult\":\"\",\"TPPAResult\":\"\",\"RPRResult\":\"\",\"IUD\":\"\",\"Pregnant\":\"\",},\"Other\":[],\"ChsCons\":{}}";

        /// <summary>
        /// 签约
        /// </summary>
        public static readonly string ContractTrans = "{\"ProductCode\":\"\",\"ContractServices\":\"\",\"PERSON_ID\":\"\",\"TeamID\":\"\",\"SignPerson\":\"\",\"Tags\":\"\",\"Channel\":\"\",\"StartTime\":\"\",\"EndTime\":\"\",\"Attachfile\":\"\",\"Otheremark\":\"\",\"teamEmpId\":\"\",\"Fee\":\"\",\"SignDate\":\"\"}";
        
        /// <summary>
        /// 肺结核第一次随访
        /// </summary>
        public static readonly string FollowOnePulMonaryTrans = "{\"ProductCode\":\"\",\"tbFirstVisit\":{\"AdverseDrugReactions\":\"\",\"AlongBedroom\":\"\",\"AreationType\":\"\",\"ContactsExam\":\"\",\"DoctorID\":\"\",\"DoctorName\":\"\",\"DrugCardFill\":\"\",\"DrugCardStore\":\"\",\"DrugFastType\":\"\",\"DrugHarm\":\"\",\"FollowUpDate\":\"\",\"ID\":\"\",\"LivingPrecautions\":\"\",\"NextDailyAlcohol\":\"\",\"NextFollowUpDate\":\"\",\"NextSmoking\":\"\",\"OutdoorMedication\":\"\",\"PatientType\":\"\",\"PecipeDate\":\"\",\"RecipePlace\":\"\",\"SputumType\":\"\",\"Supervisor\":\"\",\"Symptom\":\"\",\"TbBaseID\":\"\",\"TbTreatment\":\"\",\"TreatementSputum\":\"\",\"WayUp\":\"\"},\"tbDrugUse\":{\"ChemotherapyRegimen\":\"\",\"Dosage\":\"\",\"Usage\":\"\"},\"examLifestyle\":{\"DailyAlcoholIntake\":\"\",\"Smoking\":\"\"},\"otherJson\":[]}";

        /// <summary>
        /// 肺结核随访
        /// </summary>
        public static readonly string FollowPulMonaryTrans = "{\"ProductCode\":\"\",\"examLifestyle\":{\"DailyAlcoholIntake\":\"\",\"Smoking\":\"\"},\"tbDrugUse\":{\"ChemotherapyRegimen\":\"\",\"Dosage\":\"\",\"MissedMedNum\":\"\",\"Usage\":\"\"},\"otherText\":[],\"tbFollowUp2\":{\"AdverseDrugReactions\":\"\",\"Complication\":\"\",\"DoctorID\":\"\",\"DoctorName\":\"\",\"FollowUpDate\":\"\",\"FollowUpRemarks\":\"\",\"ID\":\"\",\"NextDailyAlcohol\":\"\",\"NextFollowUpDate\":\"\",\"NextSmoking\":\"\",\"PersonID\":\"\",\"Supervisor\":\"\",\"Symptom\":\"\",\"TbBaseID\":\"\",\"TranOut\":\"\",\"TreatmentMonthOrder\":\"\",\"WayUp\":\"\",\"StopTreatDate\":\"\",\"StopTreatReason\":\"\",\"ShouldFollowUpCnt\":\"\",\"ActualFollowUpCnt\":\"\",\"ShouldMedicationCnt\":\"\",\"ActualMedicationCnt\":\"\",\"MedicationRate\":\"\",\"AppraiseDoctorID\":\"\",\"AppraiseDoctorName\":\"\"}}";

        /// <summary>
        /// 新生儿
        /// </summary>
        public static readonly string FollowNewBabyTrans = "{\"ProductCode\":\"\",\"ChildExamMaster\":{\"FollowUpKind\":\"\",\"FollowUp\":\"\",\"ChildID\":\"\",\"NextFollowUp\":\"\",\"DoctorID\":\"\",\"DoctorName\":\"\",\"OperatorID\":\"\",\"OperatorName\":\"\",\"Remark\":\"\",\"ID\":\"\"},\"ChildBaseInfo\":{\"ID\":\"\",\"FatherID\":\"\",\"FatherName\":\"\",\"FatherOccupation\":\"\",\"FatherTel\":\"\",\"FatheBirthday\":\"\",\"MotherID\":\"\",\"MotherName\":\"\",\"MotherOccupation\":\"\",\"MotherTel\":\"\",\"MotherBirthday\":\"\",\"GestationalWeek\":\"\",\"MotherPregnancyIllness\":\"\",\"BornOrgName\":\"\",\"BornSituation\":\"\",\"NeonatalSuffocation\":\"\",\"ApgarScore\":\"\",\"IsDeformity\":\"\",\"NewbornHearingScreening\":\"\",\"NeonatalIllnessScreening\":\"\",\"BornWeight\":\"\",\"BornHeight\":\"\"},\"ExamBody\":{\"ID\":\"\",\"BodyTemperature\":\"\",\"PulseRate\":\"\",\"RespiratoryRate\":\"\",\"Height\":\"\",\"Weight\":\"\"},\"ChildExam0\":{\"ID\":\"\",\"ReplacementFeeding\":\"\",\"MilkSupply\":\"\",\"DailyMilkNumber\":\"\",\"Vomiting\":\"\",\"Defecate\":\"\",\"DailyDefecateNumber\":\"\",\"Complexion\":\"\",\"JaundiceParts\":\"\",\"BregmaWh\":\"\",\"Bregma\":\"\",\"EyeAppearance\":\"\",\"EarAppearance\":\"\",\"LimbsMobility\":\"\",\"NeckBagPiece\":\"\",\"Nose\":\"\",\"Skin\":\"\",\"Oral\":\"\",\"Anus\":\"\",\"CardiopulmonaryAuscultation\":\"\",\"Chest\":\"\",\"Reproductive\":\"\",\"AbdominalTouch\":\"\",\"Spinal\":\"\",\"Cord\":\"\",\"Guide\":\"\",\"NextFollowPlace\":\"\"},\"OtherJson\":[{\"AttrName\":\"\",\"OtherText\":\"\"}],\"Person\":{\"GenderCode\":\"\",\"CardID\":\"\",\"BirthDay\":\"\",\"CurrentAddress\":\"\"}}";
        /// <summary>
        /// 一岁儿童随访
        /// </summary>
        public static readonly string FollowOneBabyTrans = "{\"ProductCode\":\"\",\"ChildExam0To1\":{\"Abdomen\":\"\",\"AnusGenitals\":\"\",\"Bregma\":\"\",\"BregmaWh\":\"\",\"BusinessID\":\"\",\"Cardiopulmonary\":\"\",\"Complexion\":\"\",\"DevelopmentAssessment\":\"\",\"EarAppearance\":\"\",\"EyeAppearance\":\"\",\"FollowUpPrevalence\":\"\",\"Diarrhea\":\"1\",\"Poeumonia\":\"1\",\"Trauma\":\"1\",\"PrevalenceOther\":\"\",\"FourLimbs\":\"\",\"Guide\":\"\",\"HeadSize\":\"\",\"Hearing\":\"\",\"Height\":\"\",\"ID\":\"\",\"NeckBagPiece\":\"\",\"Oral\":\"\",\"Other\":\"\",\"Rickets\":\"\",\"Skin\":\"\",\"Symptome\":\"\",\"TraditionalManagement\":\"\",\"Umbilication\":\"\",\"Weight\":\"\"},\"ChildExamMaster\":{\"ChildID\":\"\",\"DoctorID\":\"\",\"DoctorName\":\"\",\"FollowUpDate\":\"\",\"FollowUpKind\":\"\",\"ID\":\"\",\"Months\":\"\",\"NextFollowUpDate\":\"\",\"OperatorID\":\"\",\"OperatorName\":\"\",\"Remark\":\"\"},\"ExamBody\":{\"Height\":\"\",\"ID\":\"\",\"Weight\":\"\"},\"ExamLaboratory\":{\"Hemoglobin\":\"\",\"ID\":\"\"},\"OtherOptionText\":[{\"AttrName\":\"\",\"OtherText\":\"\"}]}";
        
         /*"{\"ProductCode\":\"\",\"ChildExam0To1\":{\"Abdomen\":\"\",\"AnusGenitals\":\"\",\"Bregma\":\"\",\"BregmaWh\":\"\",\"BusinessID\":\"\",\"Cardiopulmonary\":\"\",\"Complexion\":\"\",\"DevelopmentAssessment\":\"\",\"EarAppearance\":\"\",\"EyeAppearance\":\"\",\"FollowUpPrevalence\":\"\",\"Diarrhea\":\"1\",\"Poeumonia\":\"1\",\"Trauma\":\"1\",\"PrevalenceOther\":\"\",\"FourLimbs\":\"\",\"Guide\":\"\",\"HeadSize\":\"\",\"Hearing\":\"\",\"Height\":\"\",\"ID\":\"\",\"NeckBagPiece\":\"\",\"Oral\":\"\",\"Other\":\"\",\"Rickets\":\"\",\"Skin\":\"\",\"Symptome\":\"\",\"TraditionalManagement\":\"\",\"Umbilication\":\"\",\"Weight\":\"\"},\"ChildExamMaster\":{\"ChildID\":\"\",\"DoctorID\":\"\",\"DoctorName\":\"\",\"FollowUpDate\":\"\",\"FollowUpKind\":\"\",\"ID\":\"\",\"Months\":\"\",\"NextFollowUpDate\":\"\",\"OperatorID\":\"\",\"OperatorName\":\"\",\"Remark\":\"\"},\"ExamBody\":{\"Height\":\"\",\"ID\":\"\",\"Weight\":\"\"},\"ExamLaboratory\":{\"Hemoglobin\":\"\",\"ID\":\"\"},\"OtherOptionText\":[{\"AttrName\":\"\",\"OtherText\":\"\"}],\"Ticket\":{\"EmployeeID\":\"\",\"OrgId\":\"\",\"OrgName\":\"\",\"OrgType\":\"\",\"RegionCodeList\":[\"\"],\"UserName\":\"\"}}";*/

        /// <summary>
        /// 二岁儿童随访
        /// </summary>
        public static readonly string FollowTwoBabyTrans = "{\"ChildExamMaster\":{\"FollowUpKind\":\"\",\"Months\":\"\",\"FollowUp\":\"\",\"NextFollowUp\":\"\",\"ChildID\":\"\",\"DoctorID\":\"\",\"DoctorName\":\"\",\"Remark\":\"\",\"ID\":\"\"},\"ExamBody\":{\"ID\":\"\",\"Height\":\"\",\"Weight\":\"\"},\"ChildExam1To2\":{\"ID\":\"\",\"Weight\":\"\",\"Height\":\"\",\"Complexion\":\"\",\"Skin\":\"\",\"BregmaWh\":\"\",\"Bregma\":\"\",\"EyeAppearance\":\"\",\"EarAppearance\":\"\",\"Hearing\":\"\",\"TeethNumber\":\"\",\"DentalCariesNumber\":\"\",\"Cardiopulmonary\":\"\",\"Abdomen\":\"\",\"FourLimbs\":\"\",\"Gait\":\"\",\"Rickets\":\"\",\"AnusGenitals\":\"\",\"OutdoorActivities\":\"\",\"VitaminD\":\"\",\"DevelopmentAssessment\":\"\",\"FollowUpPrevalence\":\"\",\"Pneumonia\":\"\",\"Diarrhea\":\"\",\"Trauma\":\"\",\"PrevalenceOther\":\"\",\"TraditionalManagement\":\"\",\"Other\":\"\",\"Guide\":\"\"},\"ExamLaboratory\":{\"ID\":\"\",\"Hemoglobin\":\"\"},\"OtherJson\":[{\"AttrName\":\"\",\"OtherText\":\"\"}]}";
        
        /// <summary>
        /// 三岁儿童随访
        /// </summary>
        public static readonly string FollowThreeBabyTrans = "{\"ProductCode\":\"\",\"ChildExamMaster\":{\"FollowUpKind\":\"\",\"Months\":\"\",\"FollowUp\":\"\",\"NextFollowUp\":\"\",\"ChildID\":\"\",\"DoctorID\":\"\",\"DoctorName\":\"\",\"Remark\":\"\",\"ID\":\"\"},\"ExamBody\":{\"ID\":\"\",\"Height\":\"\",\"Weight\":\"\"},\"ChildExam3To6\":{\"ID\":\"\",\"Weight\":\"\",\"Height\":\"\",\"PhysicaldevelopAssessment\":\"\",\"Eyesight\":\"\",\"Hearing\":\"\",\"TeethNumber\":\"\",\"DentalCariesNumber\":\"\",\"Cardiopulmonary\":\"\",\"Abdomen\":\"\",\"Other\":\"\",\"TraditionalManagement\":\"\",\"FollowUpPrevalence\":\"\",\"Pneumonia\":\"\",\"Diarrhea\":\"\",\"Trauma\":\"\",\"PrevalenceOther\":\"\",\"Guide\":\"\",\"DevelopmentAssessment\":\"\"},\"ExamLaboratory\":{\"ID\":\"\",\"Hemoglobin\":\"\"},\"OtherJson\":[{\"AttrName\":\"\",\"OtherText\":\"\"}]}";

    }

}










