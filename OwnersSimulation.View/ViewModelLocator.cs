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
using OwnersSimulation.Model.Component;
using OwnersSimulation.ViewModel;
using OwnersSimulation.ViewModel.MainPage;
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
            CustomIoC.Instance.Register<IOperationExcelService, VampirewalOperationExcelService>();

            //CustomIoC.Instance.Register<IMapService, MapService>();
            CustomIoC.Instance.Register<IOwnerSimulationDataContext, OwnerSimulationDataContext>();
            
        }

        public override void InitRegisterViewModel()
        {
            CustomIoC.Instance.Register<MainViewModel>();
            CustomIoC.Instance.Register<LoginViewModel>();

            CustomIoC.Instance.Register<AddUnitedViewModel>(); 
            CustomIoC.Instance.Register<AddOwnerViewModel>();
            CustomIoC.Instance.Register<SelectDiscipleViewModel>();
            CustomIoC.Instance.Register<AskQuestionsViewModel>();

            CustomIoC.Instance.Register<WildViewModel>();
            CustomIoC.Instance.Register<UnitedViewModel>();

            CustomIoC.Instance.Register<DiscipleInfoViewModel>();
            CustomIoC.Instance.Register<DiscipleEquipTableViewModel>();

        }

        #region 实现

        public MainViewModel MainViewModel=>CustomIoC.Instance.GetInstance<MainViewModel>();

        public LoginViewModel LoginViewModel => CustomIoC.Instance.GetInstance<LoginViewModel>();

        public AddUnitedViewModel AddUnitedViewModel => CustomIoC.Instance.GetInstanceWithoutCaching<AddUnitedViewModel>();
        public AddOwnerViewModel AddOwnerViewModel => CustomIoC.Instance.GetInstanceWithoutCaching<AddOwnerViewModel>();
        public SelectDiscipleViewModel SelectDiscipleViewModel => CustomIoC.Instance.GetInstance<SelectDiscipleViewModel>();
        public AskQuestionsViewModel AskQuestionsViewModel => CustomIoC.Instance.GetInstanceWithoutCaching<AskQuestionsViewModel>();


        public WildViewModel WildViewModel => CustomIoC.Instance.GetInstance<WildViewModel>();
        public UnitedViewModel UnitedViewModel => CustomIoC.Instance.GetInstance<UnitedViewModel>();


        public DiscipleInfoViewModel DiscipleInfoViewModel => CustomIoC.Instance.GetInstanceWithoutCaching<DiscipleInfoViewModel>();
        public DiscipleEquipTableViewModel DiscipleEquipTableViewModel => CustomIoC.Instance.GetInstanceWithoutCaching<DiscipleEquipTableViewModel>();

        #endregion
    }
}
