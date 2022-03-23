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
using Vampirewal.Core;
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Equip
{
    /// <summary>
    /// 
    /// </summary>
    [SugarTable("EquipBase")]
    public class EquipBase: DetailBaseModel
    {
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

        [SugarColumn(IsIgnore = true, IsJson = false, NoSerialize = true)]
        public string GetEquipTypeDisplay
        {
            get
            {
                return EquipType.GetDisplay();
            }
        }

        private int _Amount;
        /// <summary>
        /// 售价
        /// </summary>
        public int Amount
        {
            get { return _Amount; }
            set { _Amount = value; DoNotify(); }
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

        private int _EquipMinLevel;
        /// <summary>
        /// 装备最低等级要求
        /// </summary>
        public int EquipMinLevel
        {
            get { return _EquipMinLevel; }
            set { _EquipMinLevel = value; DoNotify(); }
        }

        #region 装备属性
        private int _Power;
        /// <summary>
        /// 力量值
        /// </summary>
        public int Power
        {
            get { return _Power; }
            set { _Power = value; DoNotify(); }
        }

        private int _Physical;
        /// <summary>
        /// 体力值
        /// </summary>
        public int Physical
        {
            get { return _Physical; }
            set { _Physical = value; DoNotify(); }
        }

        private int _Wisdom;
        /// <summary>
        /// 智力值
        /// </summary>
        public int Wisdom
        {
            get { return _Wisdom; }
            set { _Wisdom = value; DoNotify(); }
        }

        private int _Agile;
        /// <summary>
        /// 敏捷值
        /// </summary>
        public int Agile
        {
            get { return _Agile; }
            set { _Agile = value; }
        }
        #endregion
    }

    /// <summary>
    /// 装备
    ///<para><paramref name="BillId"/>是门派的<paramref name="BillId"/> </para> 
    /// </summary>
    [SugarTable("Equipment")]
    public class Equipment : EquipBase
    {
        public Equipment()
        {
            //构造函数
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
        /// <summary>
        /// 头部
        /// </summary>
        [Display(Name = "头部")]
        Head=1,
        /// <summary>
        /// 项链
        /// </summary>
        [Display(Name = "项链")]
        Necklace=2,
        /// <summary>
        /// 手部
        /// </summary>
        [Display(Name = "手部")]
        Hand=3,
        /// <summary>
        /// 胸部
        /// </summary>
        [Display(Name = "胸部")]
        Chest=4,
        /// <summary>
        /// 腿部
        /// </summary>
        [Display(Name = "腿部")]
        Leg=5,
        /// <summary>
        /// 脚部
        /// </summary>
        [Display(Name = "脚部")]
        Foot=6,
        /// <summary>
        /// 武器
        /// </summary>
        [Display(Name = "武器")]
        Weapons=7,
        /// <summary>
        /// 饰品
        /// </summary>
        [Display(Name = "饰品")]
        Ornament=8
    }

    /// <summary>
    /// 装备品质
    /// </summary>
    public enum EquipMaterial
    {
        /// <summary>
        /// 低劣
        /// </summary>
        [Display(Name = "低劣")]
        Inferior,
        /// <summary>
        /// 一般
        /// </summary>
        [Display(Name = "一般")]
        General,
        /// <summary>
        /// 优秀
        /// </summary>
        [Display(Name = "优秀")]
        Good,
        /// <summary>
        /// 精良
        /// </summary>
        [Display(Name = "精良")]
        Superior,
        /// <summary>
        /// 传奇
        /// </summary>
        [Display(Name = "传奇")]
        Legend,
        /// <summary>
        /// 神器
        /// </summary>
        [Display(Name = "神器")]
        Artifact
    }

}
