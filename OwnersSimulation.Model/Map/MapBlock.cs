#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：MapBlock
// 创 建 者：杨程
// 创建时间：2022/2/28 18:59:08
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
using System.Windows.Input;

namespace OwnersSimulation.Model
{
    /// <summary>
    /// 地图块
    /// </summary>
    public partial class MapBlock
    {
        /// <summary>
        /// 地图名称
        /// </summary>
        public string MapName { get; set; }
        /// <summary>
        /// X坐标
        /// </summary>
        public int PosX { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        public int PosY { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; } = false;

        /// <summary>
        /// 地图类型
        /// </summary>
        public MapType MapType { get; set; }

        /// <summary>
        /// 地图最低启用等级
        /// </summary>
        public int ActiveMinLevel { get; set; }
    }

    public enum MapType
    {
        Wild = -1,

        Home = 1,

    }

    public partial class MapBlock
    {
        /// <summary>
        /// 绑定点击命令
        /// </summary>
        public ICommand ClickCommand { get; set; }

    }
}
