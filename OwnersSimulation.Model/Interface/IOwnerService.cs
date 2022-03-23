#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：IOwnerService
// 创 建 者：杨程
// 创建时间：2022/3/23 10:22:16
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

namespace OwnersSimulation.Model.Interface
{
    /// <summary>
    /// 掌门服务接口
    /// </summary>
    public interface IOwnerService
    {
        /// <summary>
        /// 掌门
        /// </summary>
        Owner owner { get; }
    }
}
