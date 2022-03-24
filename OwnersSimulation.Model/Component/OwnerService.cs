#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：OwnerService
// 创 建 者：杨程
// 创建时间：2022/3/24 14:52:14
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnersSimulation.Model.Interface;
using OwnersSimulation.Model.Self;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.Model.Component
{
    public partial class OwnerSimulationDataContext : NotifyBase, IOwnerService
    {
        #region 掌门
        public Owner owner { get; private set; }

        /// <summary>
        /// 初始化掌门
        /// </summary>
        /// <param name="united"></param>
        private void InitOwner(United united)
        {
            var CurOwner = DC.Client.Queryable<Owner>().First(f => f.UnitedId == united.BillId);
            //SetOwner(owner);
            this.owner = CurOwner;
        }


        #endregion
    }
}
