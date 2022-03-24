#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：TaskService
// 创 建 者：杨程
// 创建时间：2022/3/24 14:55:15
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnersSimulation.Model.Interface;
using OwnersSimulation.Model.Self;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.Model.Component
{
    public partial class OwnerSimulationDataContext : NotifyBase, IOsTaskService
    {
        #region 任务
        public ObservableCollection<OsTask> AllTasks { get; private set; }


        public ObservableCollection<OsTask> DoingTasks { get; private set; }

        public void LoadTaskByMap(string MapId)
        {
            AllTasks.Clear();

            DC.Client.Queryable<OsTask>().Where(w => w.BillId == MapId).ToList().ForEach(f =>
            {
                if (!DoingTasks.Any(a => a.DtlId == f.DtlId))
                {
                    AllTasks.Add(f);
                }
            });

        }

        public bool IsCanDoTask(string TaskId)
        {
            return !DoingTasks.Any(a => a.DtlId == TaskId) && DoingTasks.Count < 10;
        }

        public void ToDoTask(OsTask task, Disciple target)
        {
            if (IsCanDoTask(task.DtlId))
            {
                if (task.TaskCompleteDifficulty <= target.Level)
                {
                    task.taskState = TaskState.Doing;
                    task.TaskCompletedPersonId = target.DtlId;
                    task.TaskStartTime = DateTime.Now;
                    task.TaskFinishedTime = DateTime.Now.AddSeconds(task.TaskCompleteTime);
                    DoingTasks.Add(task);
                    AllTasks.Remove(task);
                }
                else
                {
                    Dialog.ShowPopupWindow("任务等级不能高于弟子等级！", WindowsManager.Windows["MainView"], Vampirewal.Core.WpfTheme.WindowStyle.MessageType.Error);
                }
            }
        }

        public void GiveUpTask(OsTask task)
        {
            if (!string.IsNullOrEmpty(task.TaskCompletedPersonId))
            {
                task.TaskCompletedPersonId = null;
                task.TaskStartTime = null;
                task.TaskFinishedTime = null;
                task.taskState = TaskState.GiveUp;
                DoingTasks.Remove(task);
            }
        }

        public void CompletedTask(OsTask task)
        {
            task.taskState = TaskState.Done;

            united.AddMoney(task.RewardDiamond);

            Disciples.First(f => f.DtlId == task.TaskCompletedPersonId).AddExp(task.RewardExp);

            DoingTasks.Remove(task);

            if (OSDCExtension.GetRandom(1, 101) > 80)
            {
                CreateEquip(1, task.TaskCompleteDifficulty);
            }
        }
        #endregion
    }
}
