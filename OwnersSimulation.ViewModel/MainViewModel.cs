#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：MainViewModel
// 创 建 者：杨程
// 创建时间：2022/2/28 9:44:32
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model;
using OwnersSimulation.Model.Component;
using OwnersSimulation.Model.Map;
using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel
{
    public class MainViewModel : BillVM<United>
    {
        private IOwnerSimulationDataContext OSDC { get; set; }
        public MainViewModel(IDataContext dc,IAppConfig config, IOwnerSimulationDataContext osdc
            ) 
            : base(dc, config)
        {

            OSDC = osdc;
            //构造函数

            Title = config.AppChineseName;
        }

        public override void BillVmInitData()
        {
            //MapBlocks=new ObservableCollection<MapBlock>();

            
        }

        public override void PassData(object obj)
        {
            var model = obj as United;

            if (model != null)
            {
                SetEntity(model);
                Title = Title + $"-{Entity.UnitedName}";

                owner = DC.Client.Queryable<Owner>().First(f => f.UnitedId == model.BillId);

                OSDC.SetOwner(owner);

                ShowUI = Messenger.Default.Send<FrameworkElement>("GetView", ViewKeys.WildViewModel);
            }

            ReturnResult = false;
        }

        private bool ReturnResult { get; set; }
        public override object GetResult()
        {
            return ReturnResult;
        }

        #region 属性
        private FrameworkElement _ShowUI;
        public FrameworkElement ShowUI { get=> _ShowUI; set { _ShowUI = value;DoNotify(); } }

        /// <summary>
        /// 掌门
        /// </summary>
        public Owner owner { get; set; }

        //public ObservableCollection<MapBlock> MapBlocks { get; set; }
        #endregion

        #region 公共方法

        #endregion

        #region 私有方法
        
        #endregion

        #region 命令
        public RelayCommand testcommand => new RelayCommand(() => { });

        public RelayCommand ReturnLoginViewCommand => new RelayCommand(() =>
        {
            OSDC.ClearData();

            ReturnResult = true;
            ((Window)View).Close();


            //for (int i = 0; i < 50; i++)
            //{
            //    for (int j = 0; j < 50; j++)
            //    {
            //        MapBlock block = new MapBlock()
            //        {
            //            PosX = i * 20,
            //            PosY = j * 20,
            //            IsSelected = false,
            //        };

            //        MapBlocks.Add(block);
            //    }
            //}
        });

        /// <summary>
        /// 
        /// </summary>
        public RelayCommand<string> TopAreaButtonCommand => new RelayCommand<string>((s) =>
        {
            if (string.IsNullOrEmpty(s))
                return;
                       

            switch (s)
            {
                case "wild":
                    ShowUI=Messenger.Default.Send<FrameworkElement>("GetView",ViewKeys.WildViewModel);
                    break;
            }

            
        });
        #endregion
    }
}
