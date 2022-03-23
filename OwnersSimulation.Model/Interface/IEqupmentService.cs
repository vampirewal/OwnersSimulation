#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：IEqupmentService
// 创 建 者：杨程
// 创建时间：2022/3/23 10:25:41
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Equip;
using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnersSimulation.Model.Interface
{
    /// <summary>
    /// 装备服务接口
    /// </summary>
    public interface IEqupmentService
    {
        /// <summary>
        /// 已拥有装备数量
        /// </summary>
        int EquipCount { get; }
        /// <summary>
        /// 装备列表
        /// </summary>
        ObservableCollection<Equipment> Equipments { get; }

        /// <summary>
        /// 从数据库中获取所有装备
        /// </summary>
        void InitEquipments();

        /// <summary>
        /// 创建装备
        /// </summary>
        /// <param name="Count">生成数量</param>
        /// <param name="MinLv">生成装备的最低等级</param>
        void CreateEquip(int Count, int MinLv);

        /// <summary>
        /// 销毁装备
        /// </summary>
        void DeleteEquip();

        /// <summary>
        /// 穿装备
        /// </summary>
        /// <param name="equip"></param>
        /// <param name="disciple"></param>
        void WearEquip(Equipment equip, Disciple disciple);

        /// <summary>
        /// 脱装备
        /// </summary>
        /// <param name="equip"></param>
        void TakeOffEquip(Equipment equip);
    }
}
