#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：ViewModelLocator
// 创 建 者：杨程
// 创建时间：2022/2/28 9:30:04
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.DataContext;
using OwnersSimulation.ViewModel;
using OwnersSimulation.ViewModel.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Components;
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.View
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        public override void InitLocator()
        {

        }

        public override void InitRegisterService()
        {
            CustomIoC.Instance.Register<IAppConfig,VampirewalConfig>();
            CustomIoC.Instance.Register<IDialogMessage, VampirewalDialog>();
            CustomIoC.Instance.Register<IDataContext, OwnersSimulationDB>();
            
        }

        public override void InitRegisterViewModel()
        {
            CustomIoC.Instance.Register<MainViewModel>();
            CustomIoC.Instance.Register<LoginViewModel>();

            CustomIoC.Instance.Register<AddUnitedViewModel>(); 
            CustomIoC.Instance.Register<AddOwnerViewModel>();

        }

        #region 实现

        public MainViewModel MainViewModel=>CustomIoC.Instance.GetInstance<MainViewModel>();

        public LoginViewModel LoginViewModel => CustomIoC.Instance.GetInstance<LoginViewModel>();

        public AddUnitedViewModel AddUnitedViewModel => CustomIoC.Instance.GetInstanceWithoutCaching<AddUnitedViewModel>();
        public AddOwnerViewModel AddOwnerViewModel => CustomIoC.Instance.GetInstanceWithoutCaching<AddOwnerViewModel>();

        #endregion
    }
}
