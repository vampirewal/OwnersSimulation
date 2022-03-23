#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：IOsTaskService
// 创 建 者：杨程
// 创建时间：2022/3/23 10:24:54
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnersSimulation.Model.Interface
{
    /// <summary>
    /// 任务服务接口
    /// </summary>
    public interface IOsTaskService
    {
        /// <summary>
        /// 任务
        /// </summary>
        ObservableCollection<OsTask> AllTasks { get; }

        /// <summary>
        /// 执行中的任务
        /// </summary>
        ObservableCollection<OsTask> DoingTasks { get; }

        /// <summary>
        /// 通过<paramref name="MapId"/>读取任务
        /// </summary>
        /// <param name="MapId">地图ID</param>
        void LoadTaskByMap(string MapId);

        bool IsCanDoTask(string TaskId);
        /// <summary>
        /// 转移到任务进行中
        /// </summary>
        /// <param name="task"></param>
        /// <param name="target"></param>
        void ToDoTask(OsTask task, Disciple target);
        /// <summary>
        /// 放弃任务
        /// </summary>
        /// <param name="task"></param>
        void GiveUpTask(OsTask task);
        /// <summary>
        /// 完成任务
        /// </summary>
        /// <param name="task"></param>
        void CompletedTask(OsTask task);
    }
}
