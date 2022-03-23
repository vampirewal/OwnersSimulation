#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：DiscipleEquipTableViewModel
// 创 建 者：杨程
// 创建时间：2022/3/21 18:06:34
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using NPOI.POIFS.FileSystem;
using OwnersSimulation.Model.Component;
using OwnersSimulation.Model.Equip;
using OwnersSimulation.Model.Self;
using OwnersSimulation.ViewModel.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel.MainPage
{
    public class DiscipleEquipTableViewModel : DetailVM<Disciple>
    {
        private IOwnerSimulationDataContext _OSDC;
        public IOwnerSimulationDataContext OSDC { get => _OSDC; set { _OSDC = value; DoNotify(); } }


        private IDialogMessage Dialog { get; set; }

        public DiscipleEquipTableViewModel(IOwnerSimulationDataContext osdc,IDialogMessage dialog) : base()
        {
            //构造函数

            OSDC = osdc;

            Dialog = dialog;
        }

        public override void PassData(object obj)
        {
            var entity = obj as Disciple;
            if (entity != null)
            {
                var aa = DtlEntity;
                SetEntity(entity);
            }
        }

        #region 属性
        private bool _IsOpen = false;

        public bool IsOpen
        {
            get { return _IsOpen; }
            set { _IsOpen = value; DoNotify(); }
        }

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        #endregion

        #region 命令

        public RelayCommand<Equipment> WearEquipCommand => new RelayCommand<Equipment>((w) =>
        {
            //w.EquipDiscipleID = DtlEntity.DtlId;
            //w.EquipDiscipleName = DtlEntity.DName;

            OSDC.WearEquip(w, DtlEntity);

            //DtlEntity.WearEquip(w);


        });

        public RelayCommand SaleEquipCommand => new RelayCommand(() => 
        {
            var SelectedEquips=OSDC.Equipments.Where(w=>w.Checked).ToList();

            if (Dialog.GetAskQuestions("是否卖掉？"))
            {
                bool CanDelete = true;
                StringBuilder ErrorStr = new StringBuilder();

                int AllAmount = 0;

                foreach (var item in SelectedEquips)
                {
                    if (!string.IsNullOrEmpty(item.EquipDiscipleID))
                    {
                        ErrorStr.AppendLine($"装备：{item.EquipName} 存在归属!");

                        item.Checked = false;
                    }
                    else
                    {
                        OSDC.united.AddMoney(item.Amount);
                        AllAmount += item.Amount;
                    }
                    
                }

                if (CanDelete)
                {
                    OSDC.DeleteEquip();

                    Dialog.ShowPopupWindow($"总计售卖金额：{AllAmount} 灵石！", WindowsManager.Windows["MainView"], Vampirewal.Core.WpfTheme.WindowStyle.MessageType.Successful);
                }
                
            }
        });
        #endregion
    }
}
