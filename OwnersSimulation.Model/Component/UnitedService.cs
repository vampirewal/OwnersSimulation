#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：UnitedService
// 创 建 者：杨程
// 创建时间：2022/3/24 14:50:15
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
    public partial class OwnerSimulationDataContext : NotifyBase, IUnitService
    {
        #region 门派

        public United united { get; private set; }


        #endregion
    }
}
