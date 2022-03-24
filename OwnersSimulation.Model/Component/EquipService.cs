#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：EquipService
// 创 建 者：杨程
// 创建时间：2022/3/24 14:22:34
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnersSimulation.Model.Equip;
using OwnersSimulation.Model.Self;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.Model.Component
{
    public partial class OwnerSimulationDataContext : NotifyBase, IOwnerSimulationDataContext
    {
        #region 装备
        private int _EquipCount;
        public int EquipCount { get => _EquipCount; private set { _EquipCount = value; DoNotify(); } }

        public ObservableCollection<Equipment> Equipments { get; private set; }

        public void InitEquipments(bool IsInit = false)
        {
            if (IsInit)
            {
                IsHasEquipBase();
            }

            Equipments.Clear();

            DC.Client.Queryable<Equipment>().Where(w => w.BillId == united.BillId && !w.IsEquip).ToList().ForEach(f =>
            {
                Equipments.Add(f);
            });

            EquipCount = Equipments.Count;
        }

        /// <summary>
        /// 判断装备基类库中是否有数据
        /// </summary>
        private void IsHasEquipBase()
        {
            if (!DC.Client.Queryable<EquipBase>().Any())
            {
                List<EquipBase> equips = new List<EquipBase>();
                #region 头
                equips.Add(new EquipBase() { EquipName = "麻布帽", Amount = 2, EquipMinLevel = 1, EquipType = EquipType.Head, Power = 1, Agile = 1, Physical = 1, Wisdom = 1, BillId = "-1" });
                #endregion

                #region 项链
                equips.Add(new EquipBase() { EquipName = "麻绳", Amount = 1, EquipMinLevel = 1, EquipType = EquipType.Necklace, Power = 1, Agile = 1, Physical = 1, Wisdom = 1, BillId = "-1" });
                #endregion

                #region 手
                equips.Add(new EquipBase() { EquipName = "麻布手套", Amount = 1, EquipMinLevel = 1, EquipType = EquipType.Hand, Power = 1, Agile = 1, Physical = 1, Wisdom = 1, BillId = "-1" });
                #endregion

                #region 胸
                equips.Add(new EquipBase() { EquipName = "麻布衣", Amount = 1, EquipMinLevel = 1, EquipType = EquipType.Chest, Power = 1, Agile = 1, Physical = 1, Wisdom = 1, BillId = "-1" });
                #endregion

                #region 腿
                equips.Add(new EquipBase() { EquipName = "麻布裤", Amount = 1, EquipMinLevel = 1, EquipType = EquipType.Leg, Power = 1, Agile = 1, Physical = 1, Wisdom = 1, BillId = "-1" });
                #endregion

                #region 脚
                equips.Add(new EquipBase() { EquipName = "麻布鞋", Amount = 1, EquipMinLevel = 1, EquipType = EquipType.Foot, Power = 1, Agile = 1, Physical = 1, Wisdom = 1, BillId = "-1" });
                #endregion

                #region 武器
                equips.Add(new EquipBase() { EquipName = "木剑", Amount = 5, EquipMinLevel = 1, EquipType = EquipType.Weapons, Power = 3, Agile = 2, Physical = 5, Wisdom = 1, BillId = "-1" });
                #endregion

                #region 饰品
                equips.Add(new EquipBase() { EquipName = "石戒指", Amount = 5, EquipMinLevel = 1, EquipType = EquipType.Ornament, Power = 0, Agile = 0, Physical = 10, Wisdom = 5, BillId = "-1" });
                #endregion




                DC.AddEntityList(equips);
            }
        }

        public void CreateEquip(int Count, int MinLv)
        {
            if (Count > united.EquipWarehouseCount - Equipments.Count)
            {
                Count = united.EquipWarehouseCount - Equipments.Count;
            }

            List<Equipment> list = new List<Equipment>();

            int MaxLv = MinLv + 5;

            Random random = new Random();

            for (int i = 0; i < Count; i++)
            {
                Equipment equip = new Equipment()
                {
                    BillId = united.BillId,
                };



                int randa = random.Next(1, 1001);

                #region 部位
                if (randa <= 125)
                {
                    equip.EquipType = EquipType.Head;
                }
                else if (randa > 125 && randa <= 250)
                {
                    equip.EquipType = EquipType.Necklace;
                }
                else if (randa > 250 && randa <= 375)
                {
                    equip.EquipType = EquipType.Hand;
                }
                else if (randa > 375 && randa <= 500)
                {
                    equip.EquipType = EquipType.Chest;
                }
                else if (randa > 500 && randa <= 625)
                {
                    equip.EquipType = EquipType.Leg;
                }
                else if (randa > 625 && randa <= 750)
                {
                    equip.EquipType = EquipType.Foot;
                }
                else if (randa > 750 && randa <= 875)
                {
                    equip.EquipType = EquipType.Weapons;
                }
                else
                {
                    equip.EquipType = EquipType.Ornament;
                }

                var EquipBaseEntity = DC.Client.Queryable<EquipBase>().Where(w => w.EquipType == equip.EquipType && w.EquipMinLevel >= MinLv && w.EquipMinLevel < MaxLv).ToList().GetRandomOne();
                if (EquipBaseEntity != null)
                {
                    equip.EquipName = EquipBaseEntity.EquipName;
                    equip.EquipMinLevel = EquipBaseEntity.EquipMinLevel;
                    equip.Power = EquipBaseEntity.Power;
                    equip.Physical = EquipBaseEntity.Physical;
                    equip.Wisdom = EquipBaseEntity.Wisdom;
                    equip.Agile = EquipBaseEntity.Agile;
                    equip.Amount = EquipBaseEntity.Amount;
                }
                else
                {
                    continue;
                }
                #endregion

                int randb = random.Next(1, 1001);

                #region 材质
                if (randb <= 250)
                {
                    equip.equipMaterial = EquipMaterial.Inferior;
                    EquipMaterialChanged(equip, 1);
                }
                else if (randb > 250 && randb <= 500)
                {
                    equip.equipMaterial = EquipMaterial.General;
                    EquipMaterialChanged(equip, 2);
                }
                else if (randb > 500 && randb <= 700)
                {
                    equip.equipMaterial = EquipMaterial.Good;
                    EquipMaterialChanged(equip, 3);
                }
                else if (randb > 700 && randb <= 850)
                {
                    equip.equipMaterial = EquipMaterial.Superior;
                    EquipMaterialChanged(equip, 5);
                }
                else if (randb > 850 && randb <= 950)
                {
                    equip.equipMaterial = EquipMaterial.Legend;
                    EquipMaterialChanged(equip, 7);
                }
                else
                {
                    equip.equipMaterial = EquipMaterial.Artifact;
                    EquipMaterialChanged(equip, 10);
                }
                #endregion

                equip.EquipNo = OSDCExtension.CreateEquipNo(equip.EquipType, united, Equipments.Where(w => w.EquipType == equip.EquipType).ToList());


                Equipments.Add(equip);

                list.Add(equip);
            }

            if (list.Count > 0)
            {
                DC.AddEntityList(list);
            }
        }

        private void EquipMaterialChanged(Equipment equip, int num)
        {
            equip.Power *= num;
            equip.Physical *= num;
            equip.Agile *= num;
            equip.Wisdom *= num;

            equip.Amount *= num;
        }

        public void DeleteEquip()
        {
            var deletes = Equipments.Where(w => w.Checked).ToList();

            //foreach (var equip in deletes)
            //{
            //    Equipments.Remove(equip);
            //}

            if (deletes.Count > 0)
            {
                DC.DeleteEntityList(deletes);

                InitEquipments();
            }
        }

        public void WearEquip(Equipment equip, Disciple disciple)
        {


            //var equip= Equipments.First(f=>f.DtlId == DtlId);
            equip.WearEquip(disciple);
            disciple.WearEquip(equip);

            DC.UpdateEntity(equip);

            InitEquipments();
        }

        public void TakeOffEquip(Equipment equip)
        {
            //var equip=DC.Client.Queryable<Equipment>().First(f=>f.DtlId==DtlId);

            equip?.TakeOffTheEquip();

            DC.UpdateEntity(equip);

            InitEquipments();
        }
        #endregion
    }
}
