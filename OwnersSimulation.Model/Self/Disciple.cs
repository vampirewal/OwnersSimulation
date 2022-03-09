#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：Disciple
// 创 建 者：杨程
// 创建时间：2022/3/1 18:07:00
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core;
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Self
{
    /// <summary>
    /// 徒弟
    /// <para>其中<paramref name="BillId"/>是<paramref name="师傅的BillId"/></para>
    /// </summary>
    public class Disciple:DetailBaseModel
    {
        private string _DName;
        /// <summary>
        /// 徒弟名称
        /// </summary>
        public string DName
        {
            get { return _DName; }
            set { _DName = value; DoNotify(); }
        }

        private int _Exp;
        /// <summary>
        /// 徒弟经验值
        /// </summary>
        public int Exp
        {
            get { return _Exp; }
            set { _Exp = value; DoNotify(); }
        }


        private int _Level;
        /// <summary>
        /// 弟子等级
        /// </summary>
        public int Level
        {
            get { return _Level; }
            set { _Level = value; DoNotify(); }
        }

        #region 徒弟类型
        [SugarColumn(IsIgnore = true, IsJson = false, NoSerialize = true)]
        public string GetDiscipleTypeDisplay
        {
            get
            {
                return discipleType.GetDisplay();
            }
        }

        private DiscipleType _discipleType;
        /// <summary>
        /// 徒弟类型
        /// </summary>
        public DiscipleType discipleType
        {
            get { return _discipleType; }
            set { _discipleType = value; DoNotify(); }
        }
        #endregion

        #region 徒弟性别
        [SugarColumn(IsIgnore = true, IsJson = false, NoSerialize = true)]
        public string GetGenderTypeDisplay
        {
            get
            {
                return genderType.GetDisplay();
            }
        }


        private GenderType _genderType;
        /// <summary>
        /// 徒弟性别
        /// </summary>
        public GenderType genderType { get => _genderType; set { _genderType = value; DoNotify(); } } 
        #endregion
    }

    /// <summary>
    /// 徒弟类型
    /// </summary>
    public enum DiscipleType
    {
        /// <summary>
        /// 踢出
        /// </summary>
        [Display(Name ="踢出")]
        KickedOut=-2,
        /// <summary>
        /// 退出
        /// </summary>
        [Display(Name = "退出")]
        exit =-1,
        /// <summary>
        /// 无归属
        /// </summary>
        [Display(Name = "无归属")]
        NoAttribution=0,
        [Display(Name = "外门弟子一级")]
        Outside1 =1,
        [Display(Name = "外门弟子二级")]
        Outside2 =2,
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
        Inner1 =11,
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
        Elite =21,
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
        Man =1,
        /// <summary>
        /// 女性
        /// </summary>
        [Display(Name = "女性")]
        Woman =2
    }
}
