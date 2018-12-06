using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SCP_Api_Model
{
    public class AddUpApiModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 服务包
        /// </summary>
        public string ContractServices { get; set; }
        /// <summary>
        /// 服务对象
        /// </summary>
        public string PERSON_ID { get; set; }
        /// <summary>
        /// 签约团队ID
        /// </summary>
        public string TeamID { get; set; }
        /// <summary>
        /// 签约代表
        /// </summary>
        public string SignPerson { get; set; }
        /// <summary>
        /// 人群特征 (多个人群特征用逗号隔开，比如:高血压,糖尿病，人群标签通过接口48-3获取)
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 签约渠道
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 合同照片
        /// </summary>
        public string Attachfile { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Otheremark { get; set; }
        /// <summary>
        /// 团队医院ID
        /// </summary>
        public string teamEmpId { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        public string Fee { get; set; }
        /// <summary>
        /// 签约日期
        /// </summary>
        public string SignDate { get; set; }



    }
}
