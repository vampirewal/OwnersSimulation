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

using OwnersSimulation.Model.Component;
using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel.MainPage
{
    /// <summary>
    /// 徒弟信息页
    /// </summary>
    public class DiscipleInfoViewModel:DetailVM<Disciple>
    {
        private IOwnerSimulationDataContext _OSDC;
        public IOwnerSimulationDataContext OSDC { get=> _OSDC; set { _OSDC = value;DoNotify(); } }


        private IDialogMessage Dialog { get; set; }

        public DiscipleInfoViewModel(IOwnerSimulationDataContext osdc,IDialogMessage dialog)
        {
            OSDC= osdc;
            Dialog = dialog;
            //构造函数
        }

        public override void PassData(object obj)
        {
            var entity = obj as Disciple;
            if (entity != null)
            {
                SetEntity(entity);

                Title = $"{entity.DName} 的信息";
            }
            else
            {

            }
        }

        #region 属性

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        #endregion

        #region 命令

        #endregion
    }
}
