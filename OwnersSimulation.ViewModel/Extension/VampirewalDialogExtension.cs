﻿#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：VampirewalDialogExtension
// 创 建 者：杨程
// 创建时间：2022/3/8 16:07:35
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
using Vampirewal.Core.Components;
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;
using Vampirewal.Core.WpfTheme.WindowStyle;

namespace OwnersSimulation.ViewModel.Extension
{
    public static class VampirewalDialogExtension
    {
        /// <summary>
        /// Dialog扩展方法=>选择弟子窗体
        /// </summary>
        /// <param name="dialog"></param>
        /// <returns></returns>
        public static Disciple SelectDisciple(this IDialogMessage dialog)
        {
            var result = dialog.OpenDialogWindow(new Vampirewal.Core.WpfTheme.WindowStyle.DialogWindowSetting()
            {
                UiView = WindowsManager.GetInstance().GetView( ViewKeys.SelectDiscipleView),
                WindowHeight = 500,
                WindowWidth = 500,
                IsOpenWindowSize = false,
                IsShowMaxButton = false,
                IsShowMinButton = false,
                IconStr = @"pack://application:,,,/OwnersSimulation.View;component/Vampirewal-Logo.png"
            }) as Disciple;


            return result;
        }

        /// <summary>
        /// 弹出通用提问窗体
        /// </summary>
        /// <param name="dialog"></param>
        /// <param name="QuestionStr"></param>
        /// <returns></returns>
        public static bool GetAskQuestions(this IDialogMessage dialog,string QuestionStr)
        {
            return Convert.ToBoolean( dialog.OpenDialogWindow(new DialogWindowSetting()
            {
                UiView = WindowsManager.GetInstance().GetView( ViewKeys.AskQuestionsView),
                WindowHeight = 200,
                WindowWidth = 350,
                IsOpenWindowSize = false,
                IsShowMaxButton = false,
                IsShowMinButton = false,
                PassData=QuestionStr,
                IconStr = @"pack://application:,,,/OwnersSimulation.View;component/Vampirewal-Logo.png"
            }));
        }

        /// <summary>
        /// 打开弟子详细页面
        /// </summary>
        /// <param name="dialog"></param>
        /// <param name="disciple"></param>
        /// <returns></returns>
        public static bool OpenDiscipleInfoView(this IDialogMessage dialog,Disciple disciple)
        {
            return Convert.ToBoolean(dialog.OpenDialogWindow(new DialogWindowSetting()
            {
                UiView = WindowsManager.GetInstance().GetView( ViewKeys.DiscipleInfoView, disciple),
                WindowHeight = 505,
                WindowWidth = 800,
                IsOpenWindowSize = false,
                IsShowMaxButton = false,
                IsShowMinButton = false,
                PassData = disciple,
                IconStr = @"pack://application:,,,/OwnersSimulation.View;component/Vampirewal-Logo.png"
            }));
        }
    }
}
