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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Components;
using Vampirewal.Core.DBContexts;
using Vampirewal.Core.Interface;
using Vampirewal.Core.IoC;
using Vampirewal.Core.OperationExcelService;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel
{
    public class ViewModelLocator : VampirewalViewModelLocator
    {
        public override void InitLocator()
        {

        }

        public override void InitRegisterService()
        {
            VampirewalIoC.GetInstance().RegisterService<IAppConfig,VampirewalConfig>();
            VampirewalIoC.GetInstance().RegisterService<IDialogMessage, VampirewalDialog>();
            VampirewalIoC.GetInstance().RegisterService<IDataContext, OwnersSimulationDB>();
            VampirewalIoC.GetInstance().RegisterService<IOperationExcelService, VampirewalOperationExcelService>();

            //CustomIoC.Instance.Register<IMapService, MapService>();
            
            VampirewalIoC.GetInstance().RegisterService(typeof(SqlSugarRepository<>), RegisterType.Factory);


            VampirewalIoC.GetInstance().RegisterService<IOwnerSimulationDataContext, OwnerSimulationDataContext>();
        }

        public override void InitRegisterViewModel()
        {
            //CustomIoC.Instance.Register<MainViewModel>();
            //CustomIoC.Instance.Register<LoginViewModel>();

            //CustomIoC.Instance.Register<AddUnitedViewModel>(); 
            //CustomIoC.Instance.Register<AddOwnerViewModel>();
            //CustomIoC.Instance.Register<SelectDiscipleViewModel>();
            //CustomIoC.Instance.Register<AskQuestionsViewModel>();

            //CustomIoC.Instance.Register<WildViewModel>();
            //CustomIoC.Instance.Register<UnitedViewModel>();

            //CustomIoC.Instance.Register<DiscipleInfoViewModel>();
            //CustomIoC.Instance.Register<DiscipleEquipTableViewModel>();

        }

        #region 实现

        public MainViewModel MainViewModel=> VampirewalIoC.GetInstance().GetInstance<MainViewModel>();

        public LoginViewModel LoginViewModel => VampirewalIoC.GetInstance().GetInstance<LoginViewModel>();

        public AddUnitedViewModel AddUnitedViewModel => VampirewalIoC.GetInstance().GetInstance<AddUnitedViewModel>();
        public AddOwnerViewModel AddOwnerViewModel => VampirewalIoC.GetInstance().GetInstance<AddOwnerViewModel>();
        public SelectDiscipleViewModel SelectDiscipleViewModel => VampirewalIoC.GetInstance().GetInstance<SelectDiscipleViewModel>();
        public AskQuestionsViewModel AskQuestionsViewModel => VampirewalIoC.GetInstance().GetInstance<AskQuestionsViewModel>();


        public WildViewModel WildViewModel => VampirewalIoC.GetInstance().GetInstance<WildViewModel>();
        public UnitedViewModel UnitedViewModel => VampirewalIoC.GetInstance().GetInstance<UnitedViewModel>();


        public DiscipleInfoViewModel DiscipleInfoViewModel => VampirewalIoC.GetInstance().GetInstance<DiscipleInfoViewModel>();
        public DiscipleEquipTableViewModel DiscipleEquipTableViewModel => VampirewalIoC.GetInstance().GetInstance<DiscipleEquipTableViewModel>();

        #endregion
    }
}
