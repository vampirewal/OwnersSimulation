#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：SelectDiscipleViewModel
// 创 建 者：杨程
// 创建时间：2022/3/8 15:32:48
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vampirewal.Core.IoC;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel
{
    [VampirewalIoCRegister(ViewModelKeys.SelectDiscipleViewModel, RegisterType.ViewModel)]
    public class SelectDiscipleViewModel : ViewModelBase
    {
        public IOwnerSimulationDataContext OSDC { get; set; }
        public SelectDiscipleViewModel(IOwnerSimulationDataContext osdc)
        {
            //构造函数
            OSDC = osdc;

            Title = "选择弟子";
        }

        public override object GetResult()
        {
            return CurDisciple;
        }

        private Disciple CurDisciple { get; set; }

        #region 属性

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        #endregion

        #region 命令
        public RelayCommand CancelCommand => new RelayCommand(() => 
        {
            ((Window)View).Close();
        });

        public RelayCommand<Disciple> SelectDiscipleCommand => new RelayCommand<Disciple>((d) => 
        {
            if (d!=null)
            {
                CurDisciple = d;

                ((Window)View).Close();
            }
        });
        #endregion
    }
}
