#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：OwnersSimulationDB
// 创 建 者：杨程
// 创建时间：2022/2/28 10:59:35
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.DBContexts;
using Vampirewal.Core.Interface;

namespace OwnersSimulation.DataContext
{
    public class OwnersSimulationDB : VampirewalDbBase
    {
        public OwnersSimulationDB(IAppConfig config) : base(config)
        {
            
        }

        protected override void CodeFirst()
        {
            CreateTable<United>();
            CreateTable<Owner>();
            CreateTable<Disciple>();

            CreateTable<Map>();
            CreateTable<OsTask>();

            CreateTable<Equipment>();
        }
    }
}
