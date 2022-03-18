#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：United
// 创 建 者：杨程
// 创建时间：2022/2/28 14:08:47
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
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Self
{
    /// <summary>
    /// 门派
    /// </summary>
    public class United:BillBaseModel
    {
        private string _UnitedName;
        /// <summary>
        /// 门派名称
        /// </summary>
        public string UnitedName
        {
            get { return _UnitedName; }
            set { _UnitedName = value; DoNotify(); }
        }

        private int _Level;
        /// <summary>
        /// 门派等级
        /// </summary>
        public int Level
        {
            get { return _Level; }
            set { _Level = value; DoNotify(); }
        }

        private UnitedType _unitedType;
        /// <summary>
        /// 门派类型
        /// </summary>
        public UnitedType unitedType
        {
            get { return _unitedType; }
            set { _unitedType = value; DoNotify(); }
        }

        private int _Money;
        /// <summary>
        /// 灵石数
        /// </summary>
        public int Money
        {
            get { return _Money; }
            set { _Money = value; DoNotify(); }
        }

        public void AddMoney(int add)
        {
            Money += add;
        }

        public void ReduceMoney(int reduce)
        {
            Money -= reduce;
        }

        private int _EquipWarehouseCount;
        /// <summary>
        /// 装备仓库格数
        /// </summary>
        public int EquipWarehouseCount
        {
            get { return _EquipWarehouseCount; }
            set { _EquipWarehouseCount = value; DoNotify(); }
        }


    }

    /// <summary>
    /// 门派类型
    /// </summary>
    public enum UnitedType
    {
        [Display(Name ="佛道")]
        Buddha=0,
        [Display(Name = "道家")]
        Taoism =1,
        [Display(Name = "魔教")]
        Diabolism
    }
}
