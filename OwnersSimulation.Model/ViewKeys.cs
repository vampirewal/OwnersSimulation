#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：ViewKeys
// 创 建 者：杨程
// 创建时间：2022/2/28 9:39:41
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnersSimulation.Model
{
    public class ViewKeys
    {
        private const string BaseViewKey = "OwnersSimulation.View.";

        /// <summary>
        /// 登陆窗体
        /// </summary>
        public const string LoginView = BaseViewKey + "LoginView";

        /// <summary>
        /// 选择弟子窗体
        /// </summary>
        public const string SelectDiscipleView = BaseViewKey + "SelectDiscipleView";

        /// <summary>
        /// 提问返回bool窗体
        /// </summary>
        public const string AskQuestionsView = BaseViewKey + "AskQuestionsView";

        /// <summary>
        /// 主窗体
        /// </summary>
        public const string MainView = BaseViewKey + "MainWindow";



        #region MyRegion
        /// <summary>
        /// 新增门派View
        /// </summary>
        public const string AddUnitedView = BaseViewKey + "AddUnitedView";
        /// <summary>
        /// 新增掌门View
        /// </summary>
        public const string AddOwnerView = BaseViewKey + "AddOwnerView";
        #endregion

        /// <summary>
        /// 野外View
        /// </summary>
        public const string WildView = BaseViewKey + "WildView";
        /// <summary>
        /// 宗门View
        /// </summary>
        public const string UnitedView = BaseViewKey + "UnitedView";

        /// <summary>
        /// 查看弟子详细信息View
        /// </summary>
        public const string DiscipleInfoView = BaseViewKey + "DiscipleInfoView";



        /// <summary>
        /// 装备Tab页面
        /// </summary>
        public const string DiscipleEquipTableView = BaseViewKey + "DiscipleEquipTableView";
    }

    public class ViewModelKeys
    {
        private const string BaseViewModelKey = "OwnersSimulation.ViewModel.";
        /// <summary>
        /// 登陆VM
        /// </summary>
        public const string LoginViewModel = BaseViewModelKey + "LoginViewModel";
        public const string MainViewModel = BaseViewModelKey + "MainViewModel";

        #region 野外
        public const string WildViewModel = BaseViewModelKey + "WildViewModel";
        #endregion

        public const string UnitedViewModel = BaseViewModelKey + "UnitedViewModel";

        public const string AskQuestionsViewModel = BaseViewModelKey + "AskQuestionsViewModel";

        public const string AddOwnerViewModel = BaseViewModelKey + "AddOwnerViewModel";
        public const string AddUnitedViewModel = BaseViewModelKey + "AddUnitedViewModel";
        public const string SelectDiscipleViewModel = BaseViewModelKey + "SelectDiscipleViewModel";

public const string DiscipleInfoViewModel = BaseViewModelKey + "DiscipleInfoViewModel";
public const string DiscipleEquipTableViewModel = BaseViewModelKey + "DiscipleEquipTableViewModel";

    }
}
