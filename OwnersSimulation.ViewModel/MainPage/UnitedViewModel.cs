#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：UnitedViewModel
// 创 建 者：杨程
// 创建时间：2022/3/9 9:31:37
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel.MainPage
{
    /// <summary>
    /// 门派
    /// </summary>
    public class UnitedViewModel:ViewModelBase
    {
        #region 程序数据上下文
        private IOwnerSimulationDataContext _OSDC;

        public IOwnerSimulationDataContext OSDC
        {
            get { return _OSDC; }
            set { _OSDC = value; DoNotify(); }
        } 
        #endregion

        public UnitedViewModel(IOwnerSimulationDataContext osdc)
        {
            OSDC = osdc;
            //构造函数
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
