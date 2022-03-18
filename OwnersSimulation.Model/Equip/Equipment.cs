#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：EquipBase
// 创 建 者：杨程
// 创建时间：2022/3/17 14:04:25
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Self;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Equip
{
    /// <summary>
    /// 装备
    ///<para><paramref name="BillId"/>是门派的<paramref name="BillId"/> </para> 
    /// </summary>
    [SugarTable("Equipment")]
    public class Equipment : DetailBaseModel
    {
        public Equipment()
        {
            //构造函数
        }

        private string _EquipNo;
        /// <summary>
        /// 装备编号
        /// </summary>
        [SugarColumn()]
        public string EquipNo
        {
            get { return _EquipNo; }
            set { _EquipNo = value; DoNotify(); }
        }

        private string _EquipName;
        /// <summary>
        /// 装备名称
        /// </summary>
        public string EquipName
        {
            get { return _EquipName; }
            set { _EquipName = value; DoNotify(); }
        }

        private EquipType _EquipType = EquipType.Head;
        /// <summary>
        /// 装备类型
        /// </summary>
        public EquipType EquipType { get => _EquipType; set { _EquipType = value; DoNotify(); } }


        private EquipMaterial _equipMaterial = EquipMaterial.Inferior;
        /// <summary>
        /// 装备品质
        /// </summary>
        public EquipMaterial equipMaterial
        {
            get { return _equipMaterial; }
            set { _equipMaterial = value; DoNotify(); }
        }

        private bool _IsEquip;
        /// <summary>
        /// 是否装备
        /// </summary>
        public bool IsEquip
        {
            get { return _IsEquip; }
            private set { _IsEquip = value; DoNotify(); }
        }

        private string _EquipDiscipleID;
        /// <summary>
        /// 装备人ID
        /// </summary>
        [SugarColumn(IsNullable =true)]
        public string EquipDiscipleID
        {
            get { return _EquipDiscipleID; }
            private set { _EquipDiscipleID = value; DoNotify(); }
        }

        private string _EquipDiscipleName;
        /// <summary>
        /// 装备人姓名
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string EquipDiscipleName
        {
            get { return _EquipDiscipleName; }
            private set { _EquipDiscipleName = value; DoNotify(); }
        }

        /// <summary>
        /// 穿装备
        /// </summary>
        /// <param name="disciple"></param>
        public void WearEquip(Disciple disciple)
        {
            IsEquip=true;
            EquipDiscipleID = disciple.DtlId;
            EquipDiscipleName = disciple.DName;
        }

        /// <summary>
        /// 脱下装备
        /// </summary>
        public void TakeOffTheEquip()
        {
            IsEquip = false;
            EquipDiscipleID = string.Empty;
            EquipDiscipleName = string.Empty;
        }


    }

    /// <summary>
    /// 装备类型
    /// </summary>
    public enum EquipType
    {
        [Display(Name = "头部")]
        Head=1,
        [Display(Name = "项链")]
        Necklace=2,
        [Display(Name = "手部")]
        Hand=3,
        [Display(Name = "胸部")]
        Chest=4,
        [Display(Name = "腿部")]
        Leg=5,
        [Display(Name = "脚部")]
        Foot=6,
        [Display(Name = "武器")]
        Weapons=7,
        [Display(Name = "饰品")]
        Ornament=8
    }

    /// <summary>
    /// 装备品质
    /// </summary>
    public enum EquipMaterial
    {
        [Display(Name = "低劣")]
        Inferior
    }

}
