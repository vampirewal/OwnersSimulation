#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：LevelUpHelper
// 创 建 者：杨程
// 创建时间：2022/3/9 16:53:03
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
using Vampirewal.Core;

namespace OwnersSimulation.Model.Component
{
    /// <summary>
    /// 等级经验值帮助类
    /// </summary>
    public class LevelUpHelper : BaseSingleton<LevelUpHelper>
    {
        private int MinExp = 100;

        private int MaxLevel = 100;

        private Dictionary<int, int> LevelExp { get; set; } = new Dictionary<int, int>();


        /// <summary>
        /// 初始化经验池
        /// </summary>
        public void InitLevelExp()
        {
            LevelExp.Clear();

            for (int i = 1; i <= MaxLevel; i++)
            {
                //系数
                double Coefficient = 1;

                #region 等级判断
                if (i > 1 && i <= 10)
                {
                    Coefficient = 1.5d;
                }
                if (i > 10 && i <= 20)
                {
                    Coefficient = 2d;
                }
                if (i > 20 && i <= 30)
                {
                    Coefficient = 2.5d;
                }
                if (i > 30 && i <= 40)
                {
                    Coefficient = 3d;
                }
                if (i > 40 && i <= 50)
                {
                    Coefficient = 3.5d;
                }
                if (i > 50 && i <= 60)
                {
                    Coefficient = 4d;
                }
                if (i > 60 && i <= 70)
                {
                    Coefficient = 4.5d;
                }
                if (i > 70 && i <= 80)
                {
                    Coefficient = 5d;
                }
                if (i > 80 && i <= 90)
                {
                    Coefficient = 5.5d;
                }
                if (i > 90 && i <= 100)
                {
                    Coefficient = 6d;
                }
                #endregion

                if (i == MaxLevel)
                {
                    Coefficient = 9999;
                }

                int curLevel = (int)(i * MinExp * Coefficient);
                LevelExp.Add(i, curLevel);

            }
        }

        /// <summary>
        /// 获取当前等级下升级需要的经验值
        /// </summary>
        /// <param name="CurrentLevel"></param>
        /// <returns></returns>
        public int GetCurrentLevelMaxExp(int CurrentLevel)
        {
            if (LevelExp.Count < this.MaxLevel)
                InitLevelExp();

            if (CurrentLevel > MaxLevel)
                return LevelExp[MaxLevel];

            return LevelExp[CurrentLevel];
        }
    }
}
