using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 统一判断是否符合上传条件
    /// </summary>
    public class UEEstimateModel
    {

        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string CardID { get; set; }

        /// <summary>
        /// 第三方个人ID
        /// </summary>
        public string PersonID { get; set; }

        /// <summary>
        /// 家庭ID
        /// </summary>
        public string FamilyID { get; set; }

        /// <summary>
        /// 医生ID
        /// </summary>
        public string DoctEmployeID { get; set; }

        /// <summary>
        /// 回执ID
        /// </summary>
        public string ReceptID { get; set; }

        /// <summary>
        /// 如果返回失败的失败的原因
        /// </summary>
        public string Result { get; set; }

    }
}
