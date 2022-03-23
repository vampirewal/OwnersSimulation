#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：DiscipleInfoViewModel
// 创 建 者：杨程
// 创建时间：2022/3/12 11:45:37
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model;
using OwnersSimulation.Model.Component;
using OwnersSimulation.Model.Equip;
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
using Vampirewal.Core.WpfTheme.CustomControl;

namespace OwnersSimulation.ViewModel.MainPage
{
    /// <summary>
    /// 徒弟信息页
    /// </summary>
    public class DiscipleInfoViewModel : DetailVM<Disciple>
    {
        private IOwnerSimulationDataContext _OSDC;
        public IOwnerSimulationDataContext OSDC { get => _OSDC; set { _OSDC = value; DoNotify(); } }


        private IDialogMessage Dialog { get; set; }

        public DiscipleInfoViewModel(IOwnerSimulationDataContext osdc, IDialogMessage dialog, IDataContext dc, DiscipleEquipTableViewModel equipView) : base(dc)
        {
            OSDC = osdc;
            Dialog = dialog;
            //构造函数

            TableView = Messenger.Default.Send<FrameworkElement>("GetView", ViewKeys.DiscipleEquipTabView);


            DiscipleEquipTableVM = equipView;
            

            
        }

        private FrameworkElement _TableView;
        /// <summary>
        /// Tab页
        /// </summary>
        public FrameworkElement TableView
        {
            get { return _TableView; }
            set { _TableView = value; DoNotify(); }
        }

        private DiscipleEquipTableViewModel _DiscipleEquipTableVM;
        public DiscipleEquipTableViewModel DiscipleEquipTableVM { get=> _DiscipleEquipTableVM; set { _DiscipleEquipTableVM = value;DoNotify(); } }



        public override object GetResult()
        {
            return true;
        }

        public override void PassData(object obj)
        {
            var entity = obj as Disciple;
            if (entity != null)
            {
                SetEntity(entity);

                Title = $"{entity.DName} 的信息";

                CurExpStr = $"{DtlEntity.Exp}/{DtlEntity.CurrentLevelMaxExp}";

                RadarObj radarModel = new RadarObj()
                {
                    Name = "力量",
                    DataValue = DtlEntity.Power
                };

                DisciplePropertys.Add(radarModel);

                radarModel = new RadarObj()
                {
                    DataValue = DtlEntity.Physical,
                    Name = "体力"
                };
                DisciplePropertys.Add(radarModel);

                radarModel = new RadarObj()
                {
                    DataValue = DtlEntity.Agile,
                    Name = "敏捷"
                };
                DisciplePropertys.Add(radarModel);

                radarModel = new RadarObj()
                {
                    DataValue = DtlEntity.Wisdom,
                    Name = "智力"
                };
                DisciplePropertys.Add(radarModel);

                DiscipleEquipTableVM.PassData(DtlEntity);
            }
            else
            {

            }
        }

        #region 属性
        private string _CurExpStr;

        public string CurExpStr
        {
            get
            {
                return _CurExpStr;
            }
            set
            {
                _CurExpStr = value;
                DoNotify();
            }
        }

        public ObservableCollection<RadarObj> DisciplePropertys { get; set; } = new ObservableCollection<RadarObj>();
        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        #endregion

        #region 命令
        /// <summary>
        /// 切换Table页命令
        /// </summary>
        public RelayCommand<string> TabItemChangedCommand => new RelayCommand<string>((o) =>
        {


            switch (o)
            {
                case "装备":
                    TableView = Messenger.Default.Send<FrameworkElement>("GetView", ViewKeys.DiscipleEquipTabView);
                    break;
                case "技能":
                    break;
            }

        });



        public RelayCommand<Equipment> TakeOffTheEquipCommand => new RelayCommand<Equipment>((e) =>
        {
            DtlEntity.TakeOffTheEquip(e);

            OSDC.TakeOffEquip(e);
        });
        #endregion
    }
}
