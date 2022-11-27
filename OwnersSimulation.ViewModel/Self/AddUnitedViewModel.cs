#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：AddUnitedViewModel
// 创 建 者：杨程
// 创建时间：2022/2/28 14:37:33
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model;
using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vampirewal.Core;
using Vampirewal.Core.Interface;
using Vampirewal.Core.IoC;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel
{
    /// <summary>
    /// 新增门派VM
    /// </summary>
    [VampirewalIoCRegister(ViewModelKeys.AddUnitedViewModel, RegisterType.ViewModel)]
    public class AddUnitedViewModel:BillVM<United>
    {
        public AddUnitedViewModel(IDataContext dc):base(dc)
        {
            //构造函数
            
        }

        public override void BillVmInitData()
        {
            Title = "新增门派";
        }

        public override object GetResult()
        {
            if (!string.IsNullOrEmpty(Entity.UnitedName))
            {
                return Entity;
            }

            return null;
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
            try
            {
                if (!string.IsNullOrEmpty(Entity.UnitedName))
                {
                    DoAdd();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ((Window)View).Close();
            }
            
        });
        #endregion
    }
}
