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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Self
{
    /// <summary>
    /// 徒弟
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

        private int _Level;
        /// <summary>
        /// 弟子等级
        /// </summary>
        public int Level
        {
            get { return _Level; }
            set { _Level = value; DoNotify(); }
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

    }

    /// <summary>
    /// 徒弟类型
    /// </summary>
    public enum DiscipleType
    {
        [Display(Name ="踢出")]
        KickedOut=-2,
        [Display(Name = "退出")]
        exit =-1,
        [Display(Name = "外门弟子")]
        Outside =0,
        [Display(Name = "内门弟子")]
        Inner =1,
        [Display(Name = "精英弟子")]
        Elite =2,
    }
}
