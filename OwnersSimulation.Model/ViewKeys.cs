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
        private static string BaseViewKey = "OwnersSimulation.View.";

        /// <summary>
        /// 登陆窗体
        /// </summary>
        public static string LoginView { get => $"{BaseViewKey}LoginView"; }

        /// <summary>
        /// 选择弟子窗体
        /// </summary>
        public static string SelectDiscipleView { get => $"{BaseViewKey}SelectDiscipleView"; }

        /// <summary>
        /// 提问返回bool窗体
        /// </summary>
        public static string AskQuestionsView { get => $"{BaseViewKey}AskQuestionsView"; }

        /// <summary>
        /// 主窗体
        /// </summary>
        public static string MainView { get => $"{BaseViewKey}MainWindow"; }



        #region MyRegion
        /// <summary>
        /// 新增门派View
        /// </summary>
        public static string AddUnitedView { get => $"{BaseViewKey}AddUnitedView"; }
        /// <summary>
        /// 新增掌门View
        /// </summary>
        public static string AddOwnerView { get => $"{BaseViewKey}AddOwnerView"; }
        #endregion

        /// <summary>
        /// 野外View
        /// </summary>
        public static string WildView { get => $"{BaseViewKey}WildView"; }

        /// <summary>
        /// 宗门View
        /// </summary>
        public static string UnitedView { get => $"{BaseViewKey}UnitedView"; }

        /// <summary>
        /// 查看弟子详细信息View
        /// </summary>
        public static string DiscipleInfoView { get => $"{BaseViewKey}DiscipleInfoView"; }

        /// <summary>
        /// 装备Tab页面
        /// </summary>
        public static string DiscipleEquipTabView { get => $"{BaseViewKey}DiscipleEquipTableView"; }
    }
}
