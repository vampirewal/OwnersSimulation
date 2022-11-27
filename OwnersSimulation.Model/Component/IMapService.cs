#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：IMapService
// 创 建 者：杨程
// 创建时间：2022/3/3 16:49:25
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
using OwnersSimulation.Model.Self;
using Vampirewal.Core.Interface;

namespace OwnersSimulation.Model.Component
{
    /// <summary>
    /// 地图服务
    /// </summary>
    public interface IMapService
    {
        /// <summary>
        /// 是否存在地图数据
        /// </summary>
        bool HasMapData { get; }

        /// <summary>
        /// 判断地图数据
        /// </summary>
        /// <param name="Source"></param>
        void JudgeMapData(List<Map> Source);


    }

    [Obsolete("暂时弃用",true)]
    public class MapService : IMapService
    {
        private IOwnerSimulationDataContext OSDC { get; set; }

        public MapService(IOwnerSimulationDataContext osdc, IDataContext dc)
        {
            OSDC = osdc;
            DC = dc;
        }

        private IDataContext DC { get; set; }
        

        public bool HasMapData { get; private set; } = false;

        public void JudgeMapData(List<Map> Source)
        {
            if (Source.Count > 0)
            {
                HasMapData = true;

            }

            if (!HasMapData)
            {
                CreateMap("宗门", 0);
                CreateMap("小树林", 1);
                CreateMap("墓地", 2);

                if (Maps.Count>0)
                {
                    //DC.AddEntityList(Maps);

                    OSDC.Maps.Clear();
                    OSDC.SetMaps(Maps);
                }


            }

        }

        private List<Map> Maps=new List<Map>();

        private void CreateMap(string MapName, int MinLevel)
        {
            Map map = new Map()
            {
                MapName = MapName,
                ActiveMinLevel = MinLevel,
                IsActive = true,
                Checked = false,
                CreateBy = "admin",
                CreateTime = DateTime.Now,
            };

            Maps.Add (map);
        }
    }
}
