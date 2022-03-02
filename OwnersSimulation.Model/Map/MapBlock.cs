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

namespace OwnersSimulation.Model.Map
{
    /// <summary>
    /// 地图块
    /// </summary>
    public class MapBlock
    {
        public int PosX { get; set; }

        public int PosY { get; set; }

        public bool IsSelected { get; set; } = false;
    }
}
