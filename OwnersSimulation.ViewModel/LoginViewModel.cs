#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：LoginViewModel
// 创 建 者：杨程
// 创建时间：2022/2/28 14:19:16
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
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Vampirewal.Core;
using Vampirewal.Core.DBContexts;
using Vampirewal.Core.Interface;
using Vampirewal.Core.IoC;
using Vampirewal.Core.SimpleMVVM;
using Vampirewal.Core.WpfTheme.WindowStyle;

namespace OwnersSimulation.ViewModel
{
    /// <summary>
    /// 搜索条件的继承，有特殊的就写这里
    /// </summary>
    public class United_Search:United
    {

    }

    [VampirewalIoCRegister(ViewModelKeys.LoginViewModel, RegisterType.ViewModel)]
    public class LoginViewModel:BillListBaseVM<United, United_Search>
    {
        private IOwnerSimulationDataContext _osdc;
        public IOwnerSimulationDataContext OSDC { get=> _osdc; set { _osdc = value;DoNotify(); } }
        private IMapService MapService { get; set; }
        private SqlSugarRepository<United> repUnited { get; set; }

        public LoginViewModel(IDataContext dc,IAppConfig config,IDialogMessage dialog, IOwnerSimulationDataContext osdc,SqlSugarRepository<United> _repUnited
            //,IMapService mapService
            ) :base(dc,config, dialog)
        {
            OSDC = osdc;
            repUnited = _repUnited;
            //MapService=mapService;
            //构造函数
            Title = config.AppChineseName;

            GetList(true);

            //Map map = new Map()
            //{
            //    MapName = "主城",
            //    ActiveMinLevel = 0,
            //    IsActive = true,

            //};

            //DC.AddEntity(map);

            
        }

        protected override void InitVM()
        {
            //SystemDataContext.GetInstance().loginUserInfo = new Vampirewal.Core.Models.LoginUserInfo()
            //{
            //    ITCode = "admin",
            //    Name = "admin",
            //};

            VampireCoreContext.GetInstance().User = new Sys_User()
            {
                BillId=Guid.NewGuid().ToString(),
                LoginId="admin",
                Name="admin"
            };
        }
                
        
        protected override FrameworkElement SetView()
        {
            throw new NotImplementedException();//只为了使用这个BillListBaseVM，不需要使用这个，故没有实现这个方法
        }


        public override ISugarQueryable<United_Search> GetSearchQuery()
        {
            return repUnited.AsQueryable().Select<United_Search>();//如果没有特殊的查询需求，基本上框架写好的，和这个是一样的
        }

        #region 属性

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法
        /// <summary>
        /// 初始化程序数据
        /// </summary>
        private void InitSystemData()
        {
            var maps=DC.Client.Queryable<Map>().Where(w=>w.IsActive).ToList();

            OSDC.SetMaps(maps);

            //初始化地图

            //MapService.JudgeMapData(maps);

            //初始化任务
        }

        
        #endregion

        #region 命令
        /// <summary>
        /// 新增门派命令
        /// </summary>
        public RelayCommand AddNewUnitedCommand => new RelayCommand(() => 
        {
            var result= Dialog.OpenDialogWindow(new Vampirewal.Core.WpfTheme.WindowStyle.DialogWindowSetting()
            {
                UiView=WindowsManager.GetInstance().GetView(ViewKeys.AddUnitedView),
                WindowHeight=400,
                WindowWidth=500,
                IsShowMaxButton=false,
                IsShowMinButton=false,
                IsOpenWindowSize=false,
                TitleFontSize=15,
                
            });

            if (result != null)
            {
                var IsCreateOwner=Convert.ToBoolean( Dialog.OpenDialogWindow(new Vampirewal.Core.WpfTheme.WindowStyle.DialogWindowSetting()
                {
                    UiView = WindowsManager.GetInstance().GetView(ViewKeys.AddOwnerView),
                    WindowHeight = 400,
                    WindowWidth = 500,
                    IsShowMaxButton = false,
                    IsShowMinButton = false,
                    IsOpenWindowSize = false,
                    TitleFontSize = 15,
                    PassData= result
                }));

                if (IsCreateOwner)
                {
                    EntityList.Clear();

                    GetList(true);
                }
                else
                {
                    United united= result as United;

                    //DC.DeleteEntity(united);
                }
            }

        });

        /// <summary>
        /// 刷新界面数据
        /// </summary>
        public RelayCommand RefreshUnitedCommand => new RelayCommand(() => 
        {
            EntityList.Clear();

            GetList(true);
        });


        
        /// <summary>
        /// 选择门派后开始玩耍
        /// </summary>
        public RelayCommand<United> StartUnitedManagementCommand => new RelayCommand<United>((u) => 
        {
            OSDC.InitGame(u);

            //var IsInitGame = Dialog.OpenDialogWindow(new Vampirewal.Core.WpfTheme.WindowStyle.DialogWindowSetting()
            //{
            //    UiView = Messenger.Default.Send<FrameworkElement>("GetView", ViewKeys.SelectDiscipleView),
            //    WindowHeight = 500,
            //    WindowWidth = 500,
            //    IsOpenWindowSize = false,
            //    IsShowMaxButton = false,
            //    IsShowMinButton = false,
            //    PassData = u
            //});

            //var dd= Dialog.SelectDisciple();

            //if (!IsInitGame)
            //{
            //    ((Window)View).Close();
            //}

            ((Window)View).Hide();
            ((Window)View).ShowInTaskbar = false;

            //var result =(bool) Dialog.OpenDialogWindow(new Vampirewal.Core.WpfTheme.WindowStyle.DialogWindowSetting()
            //{
            //    UiView = VampirewalIoC.GetInstance().GetInstance<FrameworkElement>(ViewKeys.MainView),
            //    WindowHeight = 768,
            //    WindowWidth = 1366,
            //    IsShowMaxButton = true,
            //    IsShowMinButton = true,
            //    IsOpenWindowSize = true,
            //    TitleFontSize = 15,
            //    PassData= u
            //});

            //var mainview = VampirewalIoC.GetInstance().GetInstance<MainWindowBase>(ViewKeys.MainView);

            //mainview.DataSource.PassData(u);
            //if (mainview.ShowDialog()==true)
            //{
            //    ((Window)View).Show();
            //    ((Window)View).ShowInTaskbar = true;
            //}
            //else
            //{
            //    ((Window)View).Close();
            //}

            bool MainResult = (bool)WindowsManager.GetInstance().OpenDialogWindow(ViewKeys.MainView, u);

            if (MainResult)
            {
                ((Window)View).Show();
                ((Window)View).ShowInTaskbar = true;
            }
            else
            {
                ((Window)View).Close();
            }


        });
        #endregion

        
    }
}
