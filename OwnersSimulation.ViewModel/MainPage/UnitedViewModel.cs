#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：UnitedViewModel
// 创 建 者：杨程
// 创建时间：2022/3/9 9:31:37
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model;
using OwnersSimulation.Model.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.IoC;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel
{
    /// <summary>
    /// 门派
    /// </summary>
    [VampirewalIoCRegister(ViewModelKeys.UnitedViewModel, RegisterType.ViewModel)]
    public class UnitedViewModel:ViewModelBase
    {
        #region 程序数据上下文
        private IOwnerSimulationDataContext _OSDC;

        public IOwnerSimulationDataContext OSDC
        {
            get { return _OSDC; }
            set { _OSDC = value; DoNotify(); }
        } 
        #endregion

        public UnitedViewModel(IOwnerSimulationDataContext osdc)
        {
            OSDC = osdc;
            //构造函数
            MapBlocks = new ObservableCollection<MapBlock>();

            testmapblocks = new ObservableCollection<testmapblock>();

            for (int i = 0; i < 100; i++)
            {
                testmapblock test = new testmapblock()
                {
                    index = i + 1,
                    BlockName = $"{i + 1}_block"
                };

                testmapblocks.Add(test);
            }
        }

        #region 属性
        public ObservableCollection<MapBlock> MapBlocks { get; set; }


        public ObservableCollection<testmapblock> testmapblocks { get; set; }


        #endregion

        #region 公共方法

        #endregion

        #region 私有方法
        private void CreateMapBlock(int num)
        { 
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    MapBlock cur = new MapBlock()
                    {
                        PosX = 20 * i,
                        PosY = 20 * j,
                        MapType = MapType.Wild,
                        ClickCommand = MapBlockClickCommand
                    };

                    if (cur.PosX==20&&cur.PosY==20)
                    {
                        cur.MapType = MapType.Home;
                        cur.MapName = "宗门";
                    }
                    
                    MapBlocks.Add(cur);
                }
                
            }

            
        }
        #endregion

        #region 命令
        public RelayCommand ViewLoadedCommand => new RelayCommand(() => 
        {
            CreateMapBlock(100);
        });

        public RelayCommand<MapBlock> MapBlockClickCommand => new RelayCommand<MapBlock>((m) => 
        {
            
        });
        #endregion
    }

    public class testmapblock
    {
        public int index { get; set; }

        public string BlockName { get; set; }
    }
}
