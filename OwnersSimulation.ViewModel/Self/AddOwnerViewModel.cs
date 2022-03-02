#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：AddOwnerViewModel
// 创 建 者：杨程
// 创建时间：2022/3/2 11:24:33
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel.Self
{
    /// <summary>
    /// 新增掌门
    /// </summary>
    public class AddOwnerViewModel:BillVM<Owner>
    {
        public AddOwnerViewModel(IDataContext dc):base(dc)
        {
            //构造函数
        }

        public override void BillVmInitData()
        {
            
        }


        private United OwnerUnited { get; set; }

        public override void PassData(object obj)
        {
            var united=obj as United;

            if (united != null)
            {
                Title = $"为 <{united.UnitedName}> 添加1位掌门！ ";

                OwnerUnited=united;
            }

            
        }

        bool IsOK { get; set; }=false;
        public override object GetResult()
        {
            return IsOK;
        }

        #region 属性

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        #endregion

        #region 命令
        public RelayCommand SaveCommand => new RelayCommand(() => 
        {
            if (OwnerUnited == null)
                return;

            try
            {
                Entity.UnitedId = OwnerUnited.BillId;

                DoAdd();

                IsOK= true; 

                ((Window)View).Close();
            }
            catch 
            {

            }

            

            
        });
        #endregion
    }
}
