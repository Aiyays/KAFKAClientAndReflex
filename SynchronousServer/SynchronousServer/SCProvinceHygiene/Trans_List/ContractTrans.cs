using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene.Trans_List
{
    /// <summary>
    /// 签约
    /// </summary>
    public class ContractTrans
    {
        /// <summary>
        /// 签约转换
        /// </summary>
        /// <returns></returns>
        public static Model.TransModel Trans(Model.TransModel modelTest)
        {
            try
            {
                switch (modelTest.Key)
                {

                    case "ProductCode":
                        modelTest.Value = modelTest.BasicInfo["ProductCode"].ToString();
                        return modelTest;

                    //服务包(服务包ID中间以","隔开)
                    case "ContractServices":
                        return modelTest;
                    //服务对象
                    case "PERSON_ID":
                        modelTest.Value = modelTest.userInfo.PersonID;
                        return modelTest;
                    //签约团队ID
                    case "TeamID":
                        return modelTest;
                    //签约代表
                    case "SignPerson":
                        return modelTest;
                    //人群特征(多个人群特征用逗号隔开，比如:高血压,糖尿病，人群标签通过接口48-3获取)
                    case "Tags":
                        return modelTest;
                    //签约渠道
                    case "Channel":
                        return modelTest;
                    //开始时间
                    case "StartTime":
                        modelTest.Key = "createtime";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long a) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;

                    //结束时间
                    case "EndTime":
                        modelTest.Key = "abatetime";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long a) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;
   

                    //合同照片
                    case "Attachfile":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("image") ? modelTest.KafkaData["image"] : modelTest.Value;
                        return modelTest;

                    //备注
                    case "Otheremark":
                        return modelTest;
                    //团队医生ID
                    case "teamEmpId":
                        return modelTest;

                    //费用
                    case "Fee":
                        modelTest.Value = modelTest.KafkaData.ContainsKey("amount") ? modelTest.KafkaData["amount"] : modelTest.Value;
                        return modelTest;

                    //签约日期
                    case "SignDate":
                        modelTest.Key = "createtime";
                        modelTest.Value = modelTest.KafkaData.ContainsKey(modelTest.Key) ? modelTest.KafkaData[modelTest.Key] : "";
                        modelTest.Value = (modelTest.Value is null) ? "" :
                          (modelTest.Value.ToString().Equals("") ? "" :
                           Int64.TryParse(modelTest.Value.ToString(), out long a) ?
                           CommonTool.ControlTime.GetDateTime(long.Parse(modelTest.Value.ToString()) / 1000).ToString() : modelTest.Value.ToString()).ToString();
                        return modelTest;

                    default:
                        return modelTest;
                }

            }
            catch (Exception ex)
            {
                //异常日志记录
                CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, modelTest.Key);
            }


            return modelTest;
        }




    }
}
