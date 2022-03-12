#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：Enums
// 创 建 者：杨程
// 创建时间：2022/3/10 15:50:37
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnersSimulation.Model
{
    /// <summary>
    /// 徒弟类型
    /// </summary>
    public enum DiscipleType
    {
        /// <summary>
        /// 踢出
        /// </summary>
        [Display(Name = "踢出")]
        KickedOut = -2,
        /// <summary>
        /// 退出
        /// </summary>
        [Display(Name = "退出")]
        exit = -1,
        /// <summary>
        /// 无归属
        /// </summary>
        [Display(Name = "无归属")]
        NoAttribution = 0,
        [Display(Name = "外门弟子一级")]
        Outside1 = 1,
        [Display(Name = "外门弟子二级")]
        Outside2 = 2,
        [Display(Name = "外门弟子三级")]
        Outside3 = 3,
        [Display(Name = "外门弟子四级")]
        Outside4 = 4,
        [Display(Name = "外门弟子五级")]
        Outside5 = 5,
        [Display(Name = "外门弟子六级")]
        Outside6 = 6,
        [Display(Name = "外门弟子七级")]
        Outside7 = 7,
        [Display(Name = "外门弟子八级")]
        Outside8 = 8,
        [Display(Name = "外门弟子九级")]
        Outside9 = 9,
        [Display(Name = "外门弟子十级")]
        Outside10 = 10,
        [Display(Name = "内门弟子一级")]
        Inner1 = 11,
        Inner2 = 12,
        Inner3 = 13,
        Inner4 = 14,
        Inner5 = 15,
        Inner6 = 16,
        Inner7 = 17,
        Inner8 = 18,
        Inner9 = 19,
        Inner10 = 20,
        [Display(Name = "精英弟子")]
        Elite = 21,
    }

    /// <summary>
    /// 性别类型
    /// </summary>
    public enum GenderType
    {
        /// <summary>
        /// 男性
        /// </summary>
        [Display(Name = "男性")]
        Man = 1,
        /// <summary>
        /// 女性
        /// </summary>
        [Display(Name = "女性")]
        Woman = 2
    }

    /// <summary>
    /// 职业类型
    /// </summary>
    public enum ProfessionalType
    {
        /// <summary>
        /// 体修
        /// </summary>
        [Display(Name ="体修")]
        BodyPractitioner=1,
        /// <summary>
        /// 道修
        /// </summary>
        [Display(Name = "道修")]
        TaoistPractitioner =2,
        /// <summary>
        /// 法修
        /// </summary>
        [Display(Name = "法修")]
        MagicPractitioner1 = 3,
    }
}
