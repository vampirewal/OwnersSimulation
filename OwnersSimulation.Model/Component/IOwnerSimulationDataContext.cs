#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：IOwnerSimulationDataContext
// 创 建 者：杨程
// 创建时间：2022/3/2 15:22:05
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnersSimulation.Model.Component
{
    /// <summary>
    /// 掌门模拟上下文接口
    /// </summary>
    public interface IOwnerSimulationDataContext
    {
        /// <summary>
        /// 
        /// </summary>
        United united { get; }

        void SetUnited(United united);


        Owner owner { get; }

        void SetOwner(Owner owner);

        /// <summary>
        /// 清空数据，用于返回主菜单的时候使用
        /// </summary>
        void ClearData();


    }

    /// <summary>
    /// 掌门模拟上下文
    /// </summary>
    public class OwnerSimulationDataContext : IOwnerSimulationDataContext
    {
        public United united { get; private set; }

        public Owner owner {get; private set;}

        /// <summary>
        /// 清空数据，用于返回主菜单的时候使用
        /// </summary>
        public void ClearData()
        {
            united=null;
            owner=null;
        }

        public void SetOwner(Owner owner)
        {
            this.owner=owner;
        }

        public void SetUnited(United united)
        {
            this.united=united;
        }
    }
}
