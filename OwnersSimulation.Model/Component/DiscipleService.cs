﻿#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：DiscipleService
// 创 建 者：杨程
// 创建时间：2022/3/24 14:53:31
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
using System.Threading;
using System.Threading.Tasks;
using OwnersSimulation.Model.Equip;
using OwnersSimulation.Model.Interface;
using OwnersSimulation.Model.Self;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.Model.Component
{
    public partial class OwnerSimulationDataContext : NotifyBase, IDiscipleService
    {
        #region 弟子

        public ObservableCollection<Disciple> Disciples { get; private set; }

        public ObservableCollection<Disciple> RecruitDisciples { get; private set; }
        /// <summary>
        /// 创建弟子到招募列表
        /// </summary>
        /// <param name="Count">生成数量</param>
        public void CreateRecruitDisciple(int Count = 1)
        {
            RecruitDisciples.Clear();

            for (int i = 0; i < Count; i++)
            {
                Random random = new Random();

                Disciple disciple = new Disciple()
                {
                    discipleType = DiscipleType.NoAttribution,
                    DName = GetSingleName(),
                    Level = 1,
                    BillId = owner.BillId,
                    genderType = (GenderType)random.Next(1, 3),
                    Genius = random.Next(10, 201)
                };

                RecruitDisciples.Add(disciple);
                //Disciples.Add(disciple);
            }

        }

        public bool RecruitDisciple(Disciple entity)
        {
            try
            {
                RecruitDisciples.Remove(entity);
                Disciples.Add(entity);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 初始化弟子
        /// </summary>
        /// <param name="owner"></param>
        private void InitDisciple(Owner owner)
        {
            var curDisciples = repDisciple.ToList(w => w.BillId == owner.BillId && w.discipleType != DiscipleType.KickedOut && w.discipleType != DiscipleType.exit);

            foreach (var item in curDisciples)
            {
                var equips = repEquipment.ToList(w => w.EquipDiscipleID == item.DtlId);

                foreach (var equip in equips)
                {
                    item.WearEquip(equip);
                }

                item.RefreshFightingValue();
            }

            SetDisciples(curDisciples);
        }

        public void SetDisciples(List<Disciple> disciples)
        {
            Disciples = new ObservableCollection<Disciple>(disciples);
        }
        #endregion

        #region TOOLS
        public string GetSingleName()
        {
            var xing = OSDCExtension.GetSurname();

            //获取GB2312编码页（表）
            Encoding gb = Encoding.GetEncoding("gb2312");
            //调用函数产生4个随机中文汉字编码
            object[] bytes = OSDCExtension.CreateRegionCode(2, true);
            //根据汉字编码的字节数组解码出中文汉字
            string name = string.Empty;

            for (int i = 0; i < bytes.Length; i++)
            {
                name += gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
            }

            return $"{xing}{name}";
        }

        public List<string> GetChineseNameByCount(int count)
        {
            List<string> cur = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string name = GetSingleName();
                cur.Add(name);
                Thread.Sleep(100);
            }

            return cur;
        }
        #endregion
    }
}
