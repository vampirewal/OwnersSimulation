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

using OwnersSimulation.Model;
using OwnersSimulation.Model.Component;
using OwnersSimulation.Model.Self;
using OwnersSimulation.ViewModel.Extension;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Interface;
using Vampirewal.Core.IoC;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel
{
    /// <summary>
    /// 野外页面VM
    /// </summary>
    [VampirewalIoCRegister(ViewModelKeys.WildViewModel, RegisterType.ViewModel)]
    public class WildViewModel : ViewModelBase
    {
        public IOwnerSimulationDataContext OSDC { get; set; }

        private IDialogMessage Dialog { get; set; }
        public WildViewModel(IDataContext dc, IOwnerSimulationDataContext osdc, IDialogMessage dialog) : base(dc)
        {
            OSDC = osdc;
            Dialog = dialog;
            //构造函数
            
        }

        public override void InitData()
        {

        }

        #region 属性
        
        #endregion

        #region 公共方法

        #endregion

        #region 私有方法
        
        #endregion

        #region 命令
        /// <summary>
        /// 获取对应地图的任务列表
        /// </summary>
        public RelayCommand<Map> GetTaskByMapCommand => new RelayCommand<Map>((m) =>
        {
            OSDC.LoadTaskByMap(m.BillId);
        });

        public RelayCommand<OsTask> SelectTaskToDoCommand => new RelayCommand<OsTask>((s) =>
        {
            var target = Dialog.SelectDisciple();

            if (target!=null)
            {
                OSDC.ToDoTask(s, target);
            }
            
        });

        public RelayCommand<OsTask> GiveUpaskCommand => new RelayCommand<OsTask>((c) =>
        {
            OSDC.GiveUpTask(c);
        });

        public RelayCommand<OsTask> CompletedTaskCommand => new RelayCommand<OsTask>((c) =>
        {
            if (c.TaskFinishedTime.HasValue&&c.TaskFinishedTime<DateTime.Now)
            {
                OSDC.CompletedTask(c);
            }
            else if(c.TaskFinishedTime.HasValue)
            {
                TimeSpan ts= (TimeSpan)(c.TaskFinishedTime-DateTime.Now);

                Dialog.ShowPopupWindow($"任务完成还需要{ts.TotalSeconds.ToString("0.00")}秒", WindowsManager.GetInstance().Windows["MainView"], Vampirewal.Core.WpfTheme.WindowStyle.MessageType.Error);
            }
            
        });
        #endregion
    }
}
