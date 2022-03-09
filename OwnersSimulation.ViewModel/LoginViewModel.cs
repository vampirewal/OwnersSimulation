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
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel
{
    /// <summary>
    /// 搜索条件的继承，有特殊的就写这里
    /// </summary>
    public class United_Search:United
    {

    }

    public class LoginViewModel:BillListBaseVM<United, United_Search>
    {
        private IOwnerSimulationDataContext _osdc;
        public IOwnerSimulationDataContext OSDC { get=> _osdc; set { _osdc = value;DoNotify(); } }
        private IMapService MapService { get; set; }

        public LoginViewModel(IDataContext dc,IAppConfig config,IDialogMessage dialog, IOwnerSimulationDataContext osdc
            //,IMapService mapService
            ) :base(dc,config, dialog)
        {
            OSDC = osdc;
            //MapService=mapService;
            //构造函数
            Title = config.AppChineseName;

            GetList();

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
            SystemDataContext.GetInstance().loginUserInfo = new Vampirewal.Core.Models.LoginUserInfo()
            {
                ITCode = "admin",
                Name = "admin",
            };
        }
                
        
        protected override FrameworkElement SetView()
        {
            throw new NotImplementedException();//只为了使用这个BillListBaseVM，不需要使用这个，故没有实现这个方法
        }


        //public override ISugarQueryable<United_Search> GetSearchQuery()
        //{
        //    return DC.Client.Queryable<United>().Select<United_Search>();//如果没有特殊的查询需求，基本上框架写好的，和这个是一样的
        //}

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
                UiView=Messenger.Default.Send<FrameworkElement>("GetView",ViewKeys.AddUnitedView),
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
                    UiView = Messenger.Default.Send<FrameworkElement>("GetView", ViewKeys.AddOwnerView),
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

                    GetList();
                }
                else
                {
                    United united= result as United;

                    DC.DeleteEntity(united);
                }
            }


            

        });

        /// <summary>
        /// 刷新界面数据
        /// </summary>
        public RelayCommand RefreshUnitedCommand => new RelayCommand(() => 
        {
            EntityList.Clear();

            GetList();
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

            

            var GetResult = Messenger.Default.Send<bool>("OpenDialogWindowGetResultByPassData", ViewKeys.MainView, u);

            if (GetResult)
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

        //private void InitOwner(United model,out Owner o)
        //{
        //    var owner = DC.Client.Queryable<Owner>().First(f => f.UnitedId == model.BillId);
            
        //    //OSDC.SetOwner(owner);

        //    o = owner;
        //}

        //public void InitDisciples(Owner owner)
        //{
        //    var curDisciples = DC.Client.Queryable<Disciple>().Where(w => w.BillId == owner.BillId && w.discipleType != DiscipleType.KickedOut && w.discipleType != DiscipleType.exit).ToList();

        //    OSDC.SetDisciples(curDisciples);
        //}
    }
}
