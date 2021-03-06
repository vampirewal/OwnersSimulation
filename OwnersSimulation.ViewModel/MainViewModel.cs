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
using OwnersSimulation.Model;
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
using OwnersSimulation.ViewModel.Extension;

namespace OwnersSimulation.ViewModel
{
    public class MainViewModel : BillVM<United>
    {
        public IOwnerSimulationDataContext OSDC { get; set; }

        private IDialogMessage Dialog { get; set; }
        public MainViewModel(IDataContext dc,IAppConfig config, IOwnerSimulationDataContext osdc,IDialogMessage dialog
            ) 
            : base(dc, config)
        {

            OSDC = osdc;
            Dialog = dialog;
            //构造函数

            Title = config.AppChineseName;

            //OSDC.CreateEquip(5);
        }

        public override void BillVmInitData()
        {
            //MapBlocks=new ObservableCollection<MapBlock>();

            Disciples = new ObservableCollection<Disciple>();
        }

        public override void PassData(object obj)
        {
            var model = obj as United;

            if (model != null)
            {
                SetEntity(model);
                Title = Title + $"-{Entity.UnitedName}";

                

                //owner = DC.Client.Queryable<Owner>().First(f => f.UnitedId == model.BillId);

                //OSDC.SetOwner(owner);

                //var curDisciples= DC.Client.Queryable<Disciple>().Where(w => w.BillId == owner.BillId&&w.discipleType!= DiscipleType.KickedOut&&w.discipleType!= DiscipleType.exit).ToList();

                //OSDC.SetDisciples(curDisciples);

                //curDisciples.ForEach(f => Disciples.Add(f));

                ShowUI = Messenger.Default.Send<FrameworkElement>("GetView", ViewKeys.WildView);

                //CreateData(owner.BillId);

                
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

        public ObservableCollection<Disciple> Disciples { get; set; }
        #endregion

        #region 公共方法

        #endregion

        #region 私有方法
        private void CreateData(string OwnerId)
        {
            List<Disciple> disciplesss=new List<Disciple>();

            for (int i = 0; i < 50; i++)
            {
                Disciple d=new Disciple()
                {
                    DName=OSDC.GetSingleName(),
                    BillId=OwnerId,
                    discipleType =DiscipleType.Outside1,
                    Level=1
                };

                disciplesss.Add(d);
            }

            DC.AddEntityList(disciplesss);
        }
        #endregion

        #region 命令

        public RelayCommand CloseWindowCommand => new RelayCommand(() => 
        {
            if (Dialog.GetAskQuestions("关闭游戏前是否需要保存？"))
            {
                OSDC.SaveGame();
            }

        });

        public RelayCommand ReturnLoginViewCommand => new RelayCommand(() =>
        {
            OSDC.SaveGame();

            OSDC.ClearData();

            ReturnResult = true;

            ((Window)View).Close();

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
                    ShowUI=Messenger.Default.Send<FrameworkElement>("GetView",ViewKeys.WildView);
                    break;
                case "United":
                    ShowUI = Messenger.Default.Send<FrameworkElement>("GetView", ViewKeys.UnitedView);
                    break;
            }

            
        });

        public RelayCommand AddOneDiscipleCommand => new RelayCommand(() => 
        {
            OSDC.CreateRecruitDisciple();
        });

        public RelayCommand<Disciple> LookDiscipleInfoViewCommand => new RelayCommand<Disciple>((l) => 
        {
            Dialog.OpenDiscipleInfoView(l);
        });
        #endregion
    }
}
