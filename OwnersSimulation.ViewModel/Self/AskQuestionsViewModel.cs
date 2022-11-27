#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：AskQuestionsViewModel
// 创 建 者：杨程
// 创建时间：2022/3/10 16:40:45
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
using System.Windows;
using OwnersSimulation.Model;
using Vampirewal.Core.IoC;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.ViewModel
{
    [VampirewalIoCRegister(ViewModelKeys.AskQuestionsViewModel, RegisterType.ViewModel)]
    public class AskQuestionsViewModel:ViewModelBase
    {
        public AskQuestionsViewModel()
        {
            //构造函数
            Title = "请确认";
        }

        bool Result=false;
        public override object GetResult()
        {
            return Result;
        }

        private string _QuestionContext;

        public string QuestionContext
        {
            get { return _QuestionContext; }
            set { _QuestionContext = value;DoNotify(); }
        }


        public override void PassData(object obj)
        {
            QuestionContext=obj.ToString();
        }

        public RelayCommand OkCommand => new RelayCommand(() => 
        {
            Result=true;
            CloseView();
        });

        public RelayCommand CancelCommand => new RelayCommand(() =>
        {
            Result = false;
            CloseView();
        });

        protected override void CloseView()
        {
            WindowsManager.GetInstance().CloseDialogWindow(ViewId);
        }
    }
}
