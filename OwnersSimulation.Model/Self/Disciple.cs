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

using OwnersSimulation.Model.Component;
using OwnersSimulation.Model.Equip;
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
    public class Disciple : DetailBaseModel
    {
        public Disciple()
        {

        }

        private string _DName;
        /// <summary>
        /// 徒弟名称
        /// </summary>
        public string DName
        {
            get { return _DName; }
            set { _DName = value; DoNotify(); }
        }

        #region 升级相关
        private decimal _CurrentLevelMaxExp;
        /// <summary>
        /// 当前等级下升级需要的经验值
        /// </summary>
        public decimal CurrentLevelMaxExp
        {
            get { return _CurrentLevelMaxExp; }
            set { _CurrentLevelMaxExp = value; DoNotify(); }
        }

        private decimal _Exp;
        /// <summary>
        /// 当前经验值
        /// </summary>
        public decimal Exp
        {
            get { return _Exp; }
            set
            {
                ActionSet<decimal>(ref _Exp, value, (NewValue) =>
                {
                    if (NewValue >= CurrentLevelMaxExp)
                    {
                        LevelUp();
                    }
                });
            }
        }

        /// <summary>
        /// 涨经验
        /// </summary>
        /// <param name="exp">增加的经验值</param>
        public void AddExp(decimal exp)
        {
            decimal curexp = Decimal.Floor(exp * (Genius / 100));

            Exp += curexp;
        }


        private int _Level;
        /// <summary>
        /// 弟子等级
        /// </summary>
        public int Level
        {
            get { return _Level; }
            set
            {

                //Set<int>(ref _Level, value, (NewValue) => 
                //{
                //    int cur=LevelUpHelper.GetInstance().GetCurrentLevelMaxExp(NewValue);
                //    if (Exp>=CurrentLevelMaxExp)
                //    {
                //        Exp = 0;
                //    }
                //    CurrentLevelMaxExp = cur;
                //});

                _Level = value;
                DoNotify();
            }
        }

        private void LevelUp()
        {
            Level++;
            CurrentLevelMaxExp = LevelUpHelper.GetInstance().GetCurrentLevelMaxExp(Level);
            Exp = 0;

            RefreshFightingValue();
        }
        #endregion

        #region 资质信息
        private int _Genius;
        /// <summary>
        /// 天赋指数（10-200）
        /// <para>经验获得的比例</para>
        /// </summary>
        public int Genius
        {
            get { return _Genius; }
            set
            {
                if (value < 10)
                    value = 10;
                if (value > 200)
                    value = 200;

                _Genius = value;
                DoNotify();
            }
        }

        private int _Power;
        /// <summary>
        /// 力量值
        /// <para>初始值在10-100之间</para>
        /// </summary>
        public int Power
        {
            get { return _Power; }
            set { _Power = value; DoNotify(); }
        }

        private int _PowerView;
        [SugarColumn(IsIgnore =true)]
        public int PowerView
        {
            get { return _PowerView; }
            set { _PowerView = value; DoNotify(); }
        }


        private int _Physical;
        /// <summary>
        /// 体力值
        /// <para>初始值在10-100之间</para>
        /// </summary>
        public int Physical
        {
            get { return _Physical; }
            set { _Physical = value; DoNotify(); }
        }

        private int _PhysicalView;
        [SugarColumn(IsIgnore = true)]
        public int PhysicalView
        {
            get { return _PhysicalView; }
            set { _PhysicalView = value; DoNotify(); }
        }

        private int _Wisdom;
        /// <summary>
        /// 智力值
        /// <para>初始值在10-100之间</para>
        /// </summary>
        public int Wisdom
        {
            get { return _Wisdom; }
            set { _Wisdom = value; DoNotify(); }
        }

        private int _WisdomView;
        [SugarColumn(IsIgnore = true)]
        public int WisdomView
        {
            get { return _WisdomView; }
            set { _WisdomView = value; DoNotify(); }
        }

        private int _Agile;
        /// <summary>
        /// 敏捷值
        /// <para>初始值在10-100之间</para>
        /// </summary>
        public int Agile
        {
            get { return _Agile; }
            set { _Agile = value; DoNotify(); }
        }

        private int _AgileView;
        [SugarColumn(IsIgnore = true)]
        public int AgileView
        {
            get { return _AgileView; }
            set { _AgileView = value; DoNotify(); }
        }


        #endregion

        #region 徒弟类型
        [SugarColumn(IsIgnore = true, IsJson = false, NoSerialize = true)]
        public string GetDiscipleTypeDisplay
        {
            get
            {
                return discipleType.GetDisplay();
            }
        }

        private DiscipleType _discipleType = DiscipleType.NoAttribution;
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


        private GenderType _genderType = GenderType.Man;
        /// <summary>
        /// 徒弟性别
        /// </summary>
        public GenderType genderType { get => _genderType; set { _genderType = value; DoNotify(); } }
        #endregion

        #region 徒弟职业类型
        [SugarColumn(IsIgnore = true, IsJson = false, NoSerialize = true)]
        public string GetProfessionalTypeDisplay
        {
            get
            {
                return professionalType.GetDisplay();
            }
        }


        private ProfessionalType _professionalType = ProfessionalType.BodyPractitioner;
        /// <summary>
        /// 徒弟职业类型
        /// </summary>
        public ProfessionalType professionalType
        {
            get { return _professionalType; }
            set { _professionalType = value; DoNotify(); }
        }
        #endregion

        #region 装备相关

        private Equipment _HeadEquipment;
        /// <summary>
        /// 头部装备格
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Equipment HeadEquipment
        {
            get { return _HeadEquipment; }
            private set
            {
                _HeadEquipment = value;

                DoNotify();
            }
        }

        private Equipment _HandEquipment;
        /// <summary>
        /// 手部装备格
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Equipment HandEquipment
        {
            get { return _HandEquipment; }
            private set
            {
                _HandEquipment = value;

                DoNotify();
            }
        }

        private Equipment _NecklaceEquipment;
        /// <summary>
        /// 项链装备格
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Equipment NecklaceEquipment
        {
            get { return _NecklaceEquipment; }
            private set
            {
                _NecklaceEquipment = value;

                DoNotify();
            }
        }

        private Equipment _ChestEquipment;
        /// <summary>
        /// 胸部装备格
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Equipment ChestEquipment
        {
            get { return _ChestEquipment; }
            private set
            {
                _ChestEquipment = value;

                DoNotify();
            }
        }

        private Equipment _LegEquipment;
        /// <summary>
        /// 腿部装备格
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Equipment LegEquipment
        {
            get { return _LegEquipment; }
            private set
            {
                _LegEquipment = value;

                DoNotify();
            }
        }

        private Equipment _FootEquipment;
        /// <summary>
        /// 脚部装备格
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Equipment FootEquipment
        {
            get { return _FootEquipment; }
            private set
            {
                _FootEquipment = value;

                DoNotify();
            }
        }

        private Equipment _WeaponsEquipment;
        /// <summary>
        /// 武器装备格
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Equipment WeaponsEquipment
        {
            get { return _WeaponsEquipment; }
            private set
            {
                _WeaponsEquipment = value;

                DoNotify();
            }
        }

        private Equipment _OrnamentEquipment;
        /// <summary>
        /// 饰品装备格
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Equipment OrnamentEquipment
        {
            get { return _OrnamentEquipment; }
            private set
            {
                _OrnamentEquipment = value;

                DoNotify();
            }
        }


        /// <summary>
        /// 穿装备
        /// </summary>
        /// <param name="equipment">装备</param>
        public void WearEquip(Equipment equipment)
        {
            switch (equipment.EquipType)
            {
                case EquipType.Head:

                    if (HeadEquipment != null)
                    {
                        TakeOffTheEquip(HeadEquipment);
                    }

                    HeadEquipment = equipment;
                    break;
                case EquipType.Hand:

                    if (HandEquipment != null)
                    {
                        TakeOffTheEquip(HandEquipment);
                    }
                    HandEquipment = equipment;
                    break;
                case EquipType.Necklace:
                    if (NecklaceEquipment != null)
                    {
                        TakeOffTheEquip(NecklaceEquipment);
                    }
                    NecklaceEquipment = equipment;
                    break;
                case EquipType.Chest:
                    if (ChestEquipment != null)
                    {
                        TakeOffTheEquip(ChestEquipment);
                    }
                    ChestEquipment = equipment;
                    break;
                case EquipType.Leg:
                    if (LegEquipment != null)
                    {
                        TakeOffTheEquip(LegEquipment);
                    }
                    LegEquipment = equipment;
                    break;
                case EquipType.Foot:
                    if (FootEquipment != null)
                    {
                        TakeOffTheEquip(FootEquipment);
                    }
                    FootEquipment = equipment;
                    break;
                case EquipType.Weapons:
                    if (WeaponsEquipment != null)
                    {
                        TakeOffTheEquip(WeaponsEquipment);
                    }
                    WeaponsEquipment = equipment;
                    break;
                case EquipType.Ornament:
                    if (OrnamentEquipment != null)
                    {
                        TakeOffTheEquip(OrnamentEquipment);
                    }
                    OrnamentEquipment = equipment;
                    break;
            }
            //equipment.WearEquip(this);
            ChangeProperty(equipment);
        }

        /// <summary>
        /// 脱下装备
        /// </summary>
        /// <param name="equipment"></param>
        public void TakeOffTheEquip(Equipment equipment)
        {
            switch (equipment.EquipType)
            {
                case EquipType.Head:
                    HeadEquipment = null;
                    break;
                case EquipType.Necklace:
                    NecklaceEquipment = null;
                    break;
                case EquipType.Hand:
                    HandEquipment = null;
                    break;
                case EquipType.Chest:
                    ChestEquipment = null;
                    break;
                case EquipType.Leg:
                    LegEquipment = null;
                    break;
                case EquipType.Foot:
                    FootEquipment = null;
                    break;
                case EquipType.Weapons:
                    WeaponsEquipment = null;
                    break;
                case EquipType.Ornament:
                    OrnamentEquipment = null;
                    break;
            }
            //equipment.TakeOffTheEquip();
            ChangeProperty(equipment, false);
        }


        /// <summary>
        /// 属性变化
        /// </summary>
        /// <param name="equipment">装备</param>
        /// <param name="IsHasEquip">是否穿上</param>
        private void ChangeProperty(Equipment equipment, bool IsHasEquip = true)
        {
            if (IsHasEquip)
            {
                this.PowerView = equipment.Power+this.Power;
                this.PhysicalView = equipment.Physical+this.Physical;
                this.WisdomView = equipment.Wisdom+this.Wisdom;
                this.AgileView = equipment.Agile+this.Agile;
            }
            else
            {
                this.PowerView =  this.Power;
                this.PhysicalView = this.Physical;
                this.WisdomView =  this.Wisdom;
                this.AgileView =  this.Agile;
            }
        }

        #endregion

        #region 战斗力相关

        private int _FightingValue;
        /// <summary>
        /// 战斗力
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int FightingValue
        {
            get { return _FightingValue; }
            set
            {
                _FightingValue = value;

                DoNotify();
            }
        }

        /// <summary>
        /// 刷新战斗力
        /// </summary>
        public void RefreshFightingValue()
        {

            switch (professionalType)
            {
                case ProfessionalType.BodyPractitioner:
                    FightingValue = Power * 10;
                    break;
                case ProfessionalType.TaoistPractitioner:
                    FightingValue = Agile * 10;
                    break;
                case ProfessionalType.MagicPractitioner:
                    FightingValue = Wisdom * 10;
                    break;
            }
        }
        #endregion
    }


}
