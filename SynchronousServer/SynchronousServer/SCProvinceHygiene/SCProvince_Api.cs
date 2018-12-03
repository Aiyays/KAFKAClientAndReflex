using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene
{

    /// <summary>
    /// 省公卫接口 
    /// </summary>
    public class SCProvince_Api
    {

        private static JObject CommonUnified(string url, string type, JObject obj)
        {
            JObject ret = null;
            ///类型编号
            string result = CommonTool.NetworkPush.WebserversPost(url, type, obj.ToString());
            try
            {
                ret = JObject.Parse(result);
            }
            catch (Exception ex)
            {
                ret = new JObject() { result };
                CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, obj.ToString() + ret);
            }
            return ret;
        }



        #region 查询

        /// <summary>
        /// 根据身份证查询家庭档案信息
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="ProductCode"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static JObject QueryFamilyInfo(string cardID, string ProductCode, string url, string pageSize = "100", string pageIndex = "0") => CommonUnified(url, "54-5", new JObject
        {
            ["ProductCode"] = ProductCode,
            ["masterCardId"] = cardID,
            ["PageSize"] = pageSize,
            ["PageIndex"] = pageIndex
        });

        /// <summary>
        /// 根据身份证查询个人基本信息
        /// </summary>
        /// <param name="cardID">身份证号码</param>
        /// <param name="productCode"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static JObject QueryInfomation(string cardID, string productCode, string url, string pageSize = "100", string pageIndex = "0") => CommonUnified(url, "55-12", new JObject
        {
            ["ProductCode"] = productCode,
            ["KeyCode"] = "2",
            ["KeyValue"] = cardID,
            ["PageSize"] = pageSize,
            ["PageIndex"] = pageIndex
        });



        /// <summary>
        /// 查询医务人员
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="productCode"></param>
        /// <param name="orgID">医院ID</param>
        /// <param name="doctName">医生姓名</param>
        /// <param name="tel">电话号码-选填</param>
        /// <returns></returns>
        public static JObject QueryDoctor(string url, string productCode, string doctName) => CommonUnified(url, "69-7", new JObject
        {
            ["ProductCode"] = productCode,
            ["QueryType"] = "0",
            ["MedWorkerName"] = doctName,
            ["PageSize"] = "10",
            ["PageIndex"] = "0",
        });



        /// <summary>
        /// 查询慢病的档案
        /// </summary>
        /// <param name="url"></param>
        /// <param name="productCode"></param>
        /// <param name="regionID"></param>
        /// <param name="cardID"></param>
        /// <param name="buildType"></param>
        /// <returns></returns>
        public static JObject QueryChronicDisease(string url, string productCode, string regionID, string cardID, string buildType) => CommonUnified(url, "57-1", new JObject
        {
            ["ProductCode"] = productCode,
            ["RegionID"] = regionID,
            ["BuildType"] = buildType,
            ["KeyValue"] = cardID,
            ["PageSize"] = "10",
            ["PageIndex"] = "0",
        });


        #endregion

        #region 添加

        /// <summary>
        /// 家庭建档
        /// </summary>
        /// <param name="cardID">身份证</param>
        /// <param name="productCode">产品号</param>
        /// <param name="url">地址</param>
        /// <param name="RegionID">区划ID</param>
        /// <param name="BuildDate">建档时间</param>
        /// <returns></returns>
        public static JObject AddFamilyInfo(string cardID, string productCode, string url, string RegionID, string BuildDate) => CommonUnified(url, "54-1", new JObject() {
                { "FamilyList",new JArray(){ new JObject
                     {
                         ["BuildDate"] = BuildDate,
                         ["MasterCardID"] = cardID,
                         ["RegionID"] = RegionID,
                         ["Lastsynctime"] = DateTime.Now.ToString()
                     }} },
                    {"ProductCode",productCode }
            });

        /// <summary>
        /// 个人建档
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="cardID">身份证号码</param>
        /// <param name="name">姓名</param>
        /// <param name="familyId">家庭档案ID</param>
        /// <param name="RegionCode">档案坐在区划代码</param>
        /// <param name="jObject">其余补充的条款</param>
        /// <returns></returns>
        public static JObject AddPersonInfo(string url, string productCode, string cardID, string name, string familyId, string RegionCode, JObject jObject = null)
        {
            string type = "55-2";
            JObject ret = null;
            //是否有不必须要的条件
            try
            {
                if (jObject is null || jObject == new JObject())
                {
                    jObject = new JObject()
                        {
                        { "PersonCode",""},
                        { "CardID",cardID},
                        { "Name",name},
                        { "FamilyID",familyId},
                        { "RegionCode",RegionCode}
                     };
                }
                else
                {
                    jObject["PersonCode"] = "";
                    jObject["CardID"] = cardID;
                    jObject["Name"] = name;
                    jObject["FamilyID"] = familyId;
                    jObject["RegionCode"] = RegionCode;
                }
                string result = CommonTool.NetworkPush.WebserversPost(url, type, new JObject
                {
                    ["ProductCode"] = productCode,
                    ["PersonList"] = new JArray() { jObject },
                }.ToString());
                try

                {
                    //尝试转化为JObject
                    ret = JObject.Parse(result);
                }
                catch (Exception ex)
                {
                    ret = new JObject() { result };
                    CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, cardID + ret);

                }
            }
            catch (Exception ex)
            {
                ret = new JObject() { };
            }
            return ret;
        }

        #endregion


        #region 糖尿病
       
        /// <summary>
        ///  根据个人ID查询糖尿病
        /// </summary>
        /// <param name="url"></param>
        /// <param name="regionCode"></param>
        /// <param name="cardID">身份证号码</param>
        /// <param name="productCode"></param>
        /// <param name="date">随访时间</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static JObject QueryBGM(string url, string regionCode, string cardID, string productCode, string times, string pageSize = "100", string pageIndex = "0")
        {
            //将时间或者时间戳转换成DateTime格式
            //times = "2018-11-19";
            DateTime date = Int64.TryParse(times, out long a) ? DateTime.Parse(CommonTool.ControlTime.GetDateTime(long.Parse(times) / 1000).ToString()) : DateTime.Parse(times);
            JObject ret = null;
            string type = "59-7";
            //请求 访问 并得到返回的结果
            string result = CommonTool.NetworkPush.WebserversPost(url, type, new JObject
            {
                ["ProductCode"] = productCode,
                ["RegionCode"] = regionCode,
                ["KeyValueType"] = "2",
                 //["KeyValue"] = "510411199804055018",
                ["KeyValue"] = cardID,
                ["StartFollowupDate"] = date.AddDays(-1).ToString("yyyy-MM-dd"),
                ["EndFollowupDate"] = date.AddDays(+1).ToString("yyyy-MM-dd"),
                ["PageSize"] = pageSize,
                ["PageIndex"] = pageIndex,
            }.ToString());
            try
            {
                //尝试转换成JObject数据
                ret = JObject.Parse(result);
            }
            catch (Exception ex)
            {
                //转换失败后
                ret = new JObject() { result };
                CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, cardID + ret);
            }
            return ret;
        }

        /// <summary>
        /// 根据档案ID查询详细的糖尿病随访
        /// </summary>
        /// <param name="url"></param>
        /// <param name="productCode"></param>
        /// <param name="iD"></param>
        /// <returns></returns>
        public static JObject QueryBgmRecordInfo(string url, string productCode, string iD) => CommonUnified(url, "59-3", new JObject
        {
            ["ProductCode"] = productCode,
            ["KeyCode"] = "2",
            ["ID"] = iD,
        });

        /// <summary>
        /// 新增或者更新糖尿病
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static JObject AddUpdateBgmInfo(string url, JObject obj) => CommonUnified(url,"59-2",obj);
         
        #endregion
    }
}
