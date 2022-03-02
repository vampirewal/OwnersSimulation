#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：Map
// 创 建 者：杨程
// 创建时间：2022/3/2 16:01:18
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Self
{
    /// <summary>
    /// 地图类
    /// <para>因制作可视化的地图太费劲了</para>
    /// </summary>
    [SugarTable("Map")]
    public class Map:BillBaseModel
    {
        private string _MapName;

        public string MapName
        {
            get { return _MapName; }
            set { _MapName = value;DoNotify(); }
        }

        private int _ActiveMinLevel;
        /// <summary>
        /// 地图最低启用等级
        /// </summary>
        public int ActiveMinLevel
        {
            get { return _ActiveMinLevel; }
            set { _ActiveMinLevel = value; DoNotify(); }
        }


        private bool _IsActive;
        /// <summary>
        /// 是否开启地图
        /// </summary>
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; DoNotify(); }
        }



    }
}
