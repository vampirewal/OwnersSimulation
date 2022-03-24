#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：IOwnerSimulationDataContext
// 创 建 者：杨程
// 创建时间：2022/3/2 15:22:05
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Equip;
using OwnersSimulation.Model.Interface;
using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vampirewal.Core;
using Vampirewal.Core.Interface;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.Model.Component
{
    /// <summary>
    /// 掌门模拟上下文接口
    /// </summary>
    public interface IOwnerSimulationDataContext :
        IUnitService,//门派服务接口
        IOwnerService,//掌门服务接口
        IDiscipleService,//弟子服务接口
        IOsTaskService,//任务服务接口
        IEqupmentService//装备服务接口
    {
        #region 地图
        /// <summary>
        /// 地图
        /// </summary>
        List<Map> Maps { get; }

        /// <summary>
        /// 设置地图
        /// </summary>
        /// <param name="maps"></param>
        void SetMaps(List<Map> maps);
        #endregion

        #region 功能
        /// <summary>
        /// 清空数据，用于返回主菜单的时候使用
        /// </summary>
        void ClearData();

        /// <summary>
        /// 游戏初始化
        /// </summary>
        /// <param name="united">门派</param>
        void InitGame(United united);

        /// <summary>
        /// 保存游戏
        /// </summary>
        void SaveGame();
        #endregion

    }

    /// <summary>
    /// 掌门模拟上下文
    /// </summary>
    public partial class OwnerSimulationDataContext : NotifyBase, IOwnerSimulationDataContext
    {
        #region Service
        private IDataContext DC { get; set; }
        private IOperationExcelService OperationExcelService { get; set; }
        private IDialogMessage Dialog { get; set; }
        #endregion

        public OwnerSimulationDataContext(IDataContext dc, IOperationExcelService operationExcelService, IDialogMessage dialog)
        {
            DC = dc;
            OperationExcelService = operationExcelService;
            Dialog = dialog;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            RecruitDisciples = new ObservableCollection<Disciple>();

            AllTasks = new ObservableCollection<OsTask>();

            DoingTasks = new ObservableCollection<OsTask>();

            Equipments = new ObservableCollection<Equipment>();
        }

        #region 功能

        public void InitGame(United united)
        {
            this.united = united;

            InitOwner(united);
            //Thread.Sleep(3000);
            InitEquipments(true);

            //Thread.Sleep(3000);

            InitMap();

            InitDisciple(owner);
        }

        public void SaveGame()
        {
            //1、保存门派信息
            DC.UpdateEntity(united);

            //2、保存掌门信息
            DC.UpdateEntity(owner);

            //3、保存弟子信息
            {
                var DiscipleList = Disciples.ToList();

                var InsertDiscipleList = new List<Disciple>();
                var UpdateDiscipleList = new List<Disciple>();


                foreach (var item in DiscipleList)
                {
                    var IsDbHave = DC.Client.Queryable<Disciple>().Any(w => w.DtlId == item.DtlId);

                    if (IsDbHave)
                    {
                        UpdateDiscipleList.Add(item);
                    }
                    else
                    {
                        InsertDiscipleList.Add(item);
                    }
                }

                DC.UpdateEntityList(UpdateDiscipleList);
                DC.AddEntityList(InsertDiscipleList);
            }

            //4、保存装备信息
            {
                DC.UpdateEntityList(Equipments.ToList());
            }
        }

        /// <summary>
        /// 清空数据，用于返回主菜单的时候使用
        /// </summary>
        public void ClearData()
        {
            united = null;
            owner = null;
            Disciples?.Clear();
            Maps?.Clear();
            Equipments?.Clear();
        }
        #endregion

        

        #region 地图
        public List<Map> Maps { get; private set; }

        public void SetMaps(List<Map> maps)
        {
            Maps = maps;
        }

        private void InitMap()
        {
            var CurMap = DC.Client.Queryable<Map>().ToList();

            if (CurMap.Count > 0)
            {
                Maps = CurMap;
            }
            else
            {
                Maps = OperationExcelService.ExcelToList<Map>(true, $"{AppDomain.CurrentDomain.BaseDirectory}Map.xlsx");

                DC.AddEntityList(Maps);
            }
        }
        #endregion

        

        

        #region TOOLS
        public string GetSingleName()
        {
            var xing = OSDCExtension.GetSurname();

            //获取GB2312编码页（表）
            Encoding gb = Encoding.GetEncoding("gb2312");
            //调用函数产生4个随机中文汉字编码
            object[] bytes = OSDCExtension.CreateRegionCode(2, true);
            //根据汉字编码的字节数组解码出中文汉字
            string name = string.Empty;

            for (int i = 0; i < bytes.Length; i++)
            {
                name += gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
            }

            return $"{xing}{name}";
        }

        public List<string> GetChineseNameByCount(int count)
        {
            List<string> cur = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string name = GetSingleName();
                cur.Add(name);
                Thread.Sleep(100);
            }

            return cur;
        }
        #endregion

    }

    /// <summary>
    /// OSDC上下文扩展
    /// </summary>
    public static class OSDCExtension
    {
        /// <summary>
        /// 调用函数产生X个随机中文汉字编码
        /// </summary>
        /// <param name="strlength"></param>
        /// <param name="isRandomCount"></param>
        /// <returns></returns>
        public static object[] CreateRegionCode(int strlength, bool isRandomCount = false)
        {
            if (isRandomCount)
            {
                Random random = new Random();
                strlength = random.Next(1, strlength + 1);
            }

            //定义一个字符串数组储存汉字编码的组成元素
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            //定义一个object数组用来
            object[] bytes = new object[strlength];
            /*每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bject数组中
             每个汉字有四个区位码组成
             区位码第1位和区位码第2位作为字节数组第一个元素
             区位码第3位和区位码第4位作为字节数组第二个元素
            */

            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();
                //区位码第2位
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机数发生器的种子避免产生重复值
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();
                //区位码第3位
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();
                //区位码第4位
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();
                //定义两个字节变量存储产生的随机汉字区位码
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                //将两个字节变量存储在字节数组中
                byte[] str_r = new byte[] { byte1, byte2 };
                //将产生的一个汉字的字节数组放入object数组中
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }

        /// <summary>
        /// 姓氏获取
        /// </summary>
        /// <returns></returns>
        public static string GetSurname()
        {
            Random random = new Random();
            int index = random.Next(0, surname.Count());
            return surname[index];
        }

        private static List<string> surname { get; set; } = new List<string>() {"赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯", "陈", "楮", "卫", "蒋", "沈", "韩", "杨",
                                                                 "朱", "秦", "尤", "许", "何", "吕", "施", "张", "孔", "曹", "严", "华", "金", "魏", "陶", "姜",
                                                                 "戚", "谢", "邹", "喻", "柏", "水", "窦", "章", "云", "苏", "潘", "葛", "奚", "范", "彭", "郎",
                                                                 "鲁", "韦", "昌", "马", "苗", "凤", "花", "方", "俞", "任", "袁", "柳", "酆", "鲍", "史", "唐",
                                                                 "费", "廉", "岑", "薛", "雷", "贺", "倪", "汤", "滕", "殷", "罗", "毕", "郝", "邬", "安", "常",
                                                                 "乐", "于", "时", "傅", "皮", "卞", "齐", "康", "伍", "余", "元", "卜", "顾", "孟", "平", "黄",
                                                                 "和", "穆", "萧", "尹", "姚", "邵", "湛", "汪", "祁", "毛", "禹", "狄", "米", "贝", "明", "臧",
                                                                 "计", "伏", "成", "戴", "谈", "宋", "茅", "庞", "熊", "纪", "舒", "屈", "项", "祝", "董", "梁",
                                                                 "杜", "阮", "蓝", "闽", "席", "季", "麻", "强", "贾", "路", "娄", "危", "江", "童", "颜", "郭",
                                                                 "梅", "盛", "林", "刁", "锺", "徐", "丘", "骆", "高", "夏", "蔡", "田", "樊", "胡", "凌", "霍",
                                                                 "虞", "万", "支", "柯", "昝", "管", "卢", "莫", "经", "房", "裘", "缪", "干", "解", "应", "宗",
                                                                 "丁", "宣", "贲", "邓", "郁", "单", "杭", "洪", "包", "诸", "左", "石", "崔", "吉", "钮", "龚",
                                                                 "程", "嵇", "邢", "滑", "裴", "陆", "荣", "翁", "荀", "羊", "於", "惠", "甄", "麹", "家", "封",
                                                                 "芮", "羿", "储", "靳", "汲", "邴", "糜", "松", "井", "段", "富", "巫", "乌", "焦", "巴", "弓",
                                                                 "牧", "隗", "山", "谷", "车", "侯", "宓", "蓬", "全", "郗", "班", "仰", "秋", "仲", "伊", "宫",
                                                                 "宁", "仇", "栾", "暴", "甘", "斜", "厉", "戎", "祖", "武", "符", "刘", "景", "詹", "束", "龙",
                                                                 "叶", "幸", "司", "韶", "郜", "黎", "蓟", "薄", "印", "宿", "白", "怀", "蒲", "邰", "从", "鄂",
                                                                 "索", "咸", "籍", "赖", "卓", "蔺", "屠", "蒙", "池", "乔", "阴", "郁", "胥", "能", "苍", "双",
                                                                 "闻", "莘", "党", "翟", "谭", "贡", "劳", "逄", "姬", "申", "扶", "堵", "冉", "宰", "郦", "雍",
                                                                 "郤", "璩", "桑", "桂", "濮", "牛", "寿", "通", "边", "扈", "燕", "冀", "郏", "浦", "尚", "农",
                                                                 "温", "别", "庄", "晏", "柴", "瞿", "阎", "充", "慕", "连", "茹", "习", "宦", "艾", "鱼", "容",
                                                                 "向", "古", "易", "慎", "戈", "廖", "庾", "终", "暨", "居", "衡", "步", "都", "耿", "满", "弘",
                                                                 "匡", "国", "文", "寇", "广", "禄", "阙", "东", "欧", "殳", "沃", "利", "蔚", "越", "夔", "隆",
                                                                 "师", "巩", "厍", "聂", "晁", "勾", "敖", "融", "冷", "訾", "辛", "阚", "那", "简", "饶", "空",
                                                                 "曾", "毋", "沙", "乜", "养", "鞠", "须", "丰", "巢", "关", "蒯", "相", "查", "后", "荆", "红",
                                                                 "游", "竺", "权", "逑", "盖", "益", "桓", "公", "仉", "督", "晋", "楚", "阎", "法", "汝", "鄢",
                                                                 "涂", "钦", "岳", "帅", "缑", "亢", "况", "后", "有", "琴", "归", "海", "墨", "哈", "谯", "笪",
                                                                 "年", "爱", "阳", "佟", "商", "牟", "佘", "佴", "伯", "赏",
                                                                 "万俟", "司马", "上官", "欧阳", "夏侯", "诸葛", "闻人", "东方", "赫连", "皇甫", "尉迟", "公羊",
                                                                 "澹台", "公冶", "宗政", "濮阳", "淳于", "单于", "太叔", "申屠", "公孙", "仲孙", "轩辕", "令狐",
                                                                 "锺离", "宇文", "长孙", "慕容", "鲜于", "闾丘", "司徒", "司空", "丌官", "司寇", "子车", "微生",
                                                                 "颛孙", "端木", "巫马", "公西", "漆雕", "乐正", "壤驷", "公良", "拓拔", "夹谷", "宰父", "谷梁",
                                                                 "段干", "百里", "东郭", "南门", "呼延", "羊舌", "梁丘", "左丘", "东门", "西门", "南宫"};

        /// <summary>
        /// 创建装备编号
        /// </summary>
        /// <param name="equipType"></param>
        /// <param name="united"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string CreateEquipNo(EquipType equipType, United united, List<Equipment> source)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(equipType.ToString());
            sb.Append((int)equipType);
            sb.Append((source.Count() + 1).ToString("0000000"));


            return sb.ToString();
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        /// <returns></returns>
        public static int GetRandom(int Min,int Max)
        {
            Random random=new Random();

            return random.Next(Min, Max);
        }

        /// <summary>
        /// 扩展-获取随机一个装备
        /// </summary>
        /// <param name="equips"></param>
        /// <returns></returns>
        public static EquipBase GetRandomOne(this List<EquipBase> equips)
        {
            int count=equips.Count;

            return equips[GetRandom(0, count)];
        }
    }



}
