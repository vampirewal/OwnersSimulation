#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：WildViewModel
// 创 建 者：杨程
// 创建时间：2022/3/2 14:52:52
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Component;
using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel.MainPage
{
    /// <summary>
    /// 野外页面VM
    /// </summary>
    public class WildViewModel:ViewModelBase
    {
        private IOwnerSimulationDataContext OSDC { get; set; }  
        public WildViewModel(IDataContext dc, IOwnerSimulationDataContext osdc) :base(dc)
        {
            OSDC = osdc;
            //构造函数
            GetMapsData();
        }

        public override void InitData()
        {
            OsTasks = new ObservableCollection<OsTask>();
        }

        #region 属性
        public ObservableCollection<Map> Maps { get; set; }

        public ObservableCollection<OsTask> OsTasks { get; set; }
        #endregion

        #region 公共方法

        #endregion

        #region 私有方法
        /// <summary>
        /// 获取地图数据
        /// </summary>
        private void GetMapsData()
        {
            if (Maps == null)
            {
                Maps = new ObservableCollection<Map>();
            }
            else
            {
                Maps.Clear();
            }

            DC.Client.Queryable<Map>().Where(w => OSDC.owner.Level >= w.ActiveMinLevel).ToList().ForEach(f => Maps.Add(f));
        }
        #endregion

        #region 命令
        /// <summary>
        /// 获取对应地图的任务列表
        /// </summary>
        public RelayCommand<Map> GetTaskByMapCommand => new RelayCommand<Map>((m) => 
        {
            OsTasks.Clear();

            DC.Client.Queryable<OsTask>().Where(w=>w.BillId==m.BillId).ToList().ForEach(f=>OsTasks.Add(f));
        });
        #endregion
    }
}
