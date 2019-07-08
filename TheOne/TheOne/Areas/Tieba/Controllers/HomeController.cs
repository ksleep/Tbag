using DapperExtension;
using DapperExtensions;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TheOne.Areas.Tieba.Controllers
{
    [Area("Tieba")]
    public class HomeController : BaseController
    {
        private readonly IDatabase _database;
        private static ChineseLunisolarCalendar ChineseCalendar = new ChineseLunisolarCalendar();

        ///<summary>
        /// 十天干
        ///</summary>
        private static string[] tg = {"甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸"};

        ///<summary>
        /// 十二地支
        ///</summary>
        private static string[] dz = {"子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥"};

        ///<summary>
        /// 十二生肖
        ///</summary>
        private static string[] sx = {"鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪"};

        ///<summary>
        /// 返回农历天干地支年
        ///</summary>
        ///<param name="year">农历年</param>
        ///<return s></return s>
        public static string GetLunisolarYear(int year)
        {
            if (year > 3)
            {
                int tgIndex = (year - 4) % 10;
                int dzIndex = (year - 4) % 12;

                return string.Concat(tg[tgIndex], dz[dzIndex], "[", sx[dzIndex], "]");
            }

            throw new ArgumentOutOfRangeException("无效的年份!");
        }

        ///<summary>
        /// 农历月
        ///</summary>

        ///<return s></return s>
        private static string[] months = {"正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二(腊)"};

        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days1 = {"初", "十", "廿", "三"};

        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days = {"一", "二", "三", "四", "五", "六", "七", "八", "九", "十"};


        ///<summary>
        /// 返回农历月
        ///</summary>
        ///<param name="month">月份</param>
        ///<return s></return s>
        public static string GetLunisolarMonth(int month)
        {
            if (month < 13 && month > 0)
            {
                return months[month - 1];
            }

            throw new ArgumentOutOfRangeException("无效的月份!");
        }

        ///<summary>
        /// 返回农历日
        ///</summary>
        ///<param name="day">天</param>
        ///<return s></return s>
        public static string GetLunisolarDay(int day)
        {
            if (day > 0 && day < 32)
            {
                if (day != 20 && day != 30)
                {
                    return string.Concat(days1[(day - 1) / 10], days[(day - 1) % 10]);
                }
                else
                {
                    return string.Concat(days[(day - 1) / 10], days1[1]);
                }
            }

            throw new ArgumentOutOfRangeException("无效的日!");
        }


        public HomeController(IDatabase database)
        {
            _database = database;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult GetData(int page, int limit, string sortField, string sortType, string name)
        {
            // PPoo();
            // GetTieba("");
            //PostFunction();
            //短链查看长链
            //string redirectUrl;
            //WebRequest myRequest = WebRequest.Create("http://t.cn/EbbMdRJ");

            //WebResponse myResponse = myRequest.GetResponse();
            //redirectUrl = myResponse.ResponseUri.ToString();

            //myResponse.Close();

            //Test();
            PPoo();
            //string imgSourceURL =
            //    "http://q2.qlogo.cn/headimg_dl?bs=784641708&dst_uin=784641708&dst_uin=784641708&;dst_uin=784641708&spec=100&url_enc=0&referer=bu_interface&term_type=PC";
            //SaveImageFromWeb(imgSourceURL, "D://Users//","233344");

            string sqlJoin = $@"select * from my_tieba ";
            string sqlCount = "SELECT count(0) FROM my_tieba";

            var result = _database.GetPagesSQL<dynamic>(sqlJoin, sqlCount, page - 1, limit);

            return Json(new PageResponse(result.TotalItems, result.Items));
        }

        /// <summary>
        /// Tieba
        /// </summary>
        /// <param name="url"></param>
        public JsonResult GetTieba(string url)
        {
            var httpResult = new HttpHelper().GetHtml(new HttpItem()
            {
                URL = "https://tieba.baidu.com/f?kw=剑网3&ie=utf-8&pn=" + url + ""
                //URL = "https://tieba.baidu.com/f?kw=%E6%8A%97%E5%8E%8B&ie=utf-8&pn=" + url + ""
            });
            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(httpResult.Html);
                var titleList = hd.DocumentNode.SelectNodes(".//div[@class='col2_right j_threadlist_li_right ']");
                var Timetext = hd.DocumentNode.SelectNodes(".//span[@class='pull-right is_show_create_time']");

                string yy = DateTime.Now.Year.ToString();
                string MM = DateTime.Now.Month.ToString();
                string DD = DateTime.Now.Day.ToString();


                for (int i = 0; i < titleList.Count; i++)
                {
                    var id = titleList[i].SelectSingleNode("./div[1]/div[1]/a[1]").Attributes["href"].Value;
                    id = id.Substring(3, id.Length - 3); //贴吧ID
                    var title = titleList[i].SelectSingleNode("./div[1]/div[1]/a[1]").InnerText; //标题
                    var typ = title.Length >= 4 ? title.Substring(0, 4) : ""; //类型
                    var line = "https://tieba.baidu.com/p/" + id + ""; //链接
                    if (title.Contains("【818】") || title.Contains("【树洞】") || title.Contains("【616】") ||
                        title.Contains("【鬼网三】"))
                    {
                        var timeinfo = "";
                        timeinfo = yy + "-" + MM + "-" + DD + "-" + Timetext[i].InnerText; //时间
                        int count = _database.GetSQLField<int>($"select count(0) from my_tieba where Tid='{id}'");
                        if (count == 0)
                        {
                            _database.ExecuteSQL(
                                $"insert into my_tieba (Title,Link,Type,Time,Tid) value('{title}','{line}','{typ}','{timeinfo}','{id}')");
                        }

                    }
                }
                //foreach (var item in titleList)
                //{
                //    var id = item.SelectSingleNode("./div[1]/div[1]/a[1]").Attributes["href"].Value;
                //    id = id.Substring(3, id.Length - 3);//贴吧ID
                //    var title = item.SelectSingleNode("./div[1]/div[1]/a[1]").InnerText;//标题
                //    var typ = title.Substring(0, 4);//类型
                //    var line = "https://tieba.baidu.com/p/" + id + "";//链接
                //    if (title.Contains("【818】") || title.Contains("【树洞】") || title.Contains("【616】") || title.Contains("【鬼网三】"))
                //    {
                //        int count = _database.GetSQLField<int>($"select count(0) from my_tieba where Tid='{id}'");
                //        if (count == 0)
                //        {
                //            _database.ExecuteSQL($"insert into my_tieba (Title,Link,Type,Tid) value('{title}','{line}','{typ}','{id}')");
                //        }

                //    }

                //    #region

                //    //Console.WriteLine("标题  " + titleinfo + "");
                //    //Console.WriteLine();
                //    //Console.WriteLine("已获取到标题  " + title + "");
                //    //Console.WriteLine();
                //    //Console.WriteLine(" 已获取到链接  https://tieba.baidu.com/p/" + id + "");
                //    //bool ok = SqlHelper.Is_Tid(id);
                //    //if (ok)
                //    //{
                //    //    Console.WriteLine("正在添加数据" + id + "");
                //    //    var username = item.SelectSingleNode("./div[1]/div[2]/span").Attributes["title"].Value;
                //    //    username = username.Substring(6, username.Length - 6);//用户名
                //    //    var userid = item.SelectSingleNode("./div[1]/div[2]/span").Attributes["data-field"].Value;
                //    //    userid = userid.Substring(21, userid.Length - 22);//用户id
                //    //    bool Insert_ok = SqlHelper.InsertTieba(new Model.Tieba()
                //    //    {
                //    //        Tid = id,
                //    //        title = title,
                //    //        username=username,
                //    //        userid=userid
                //    //    });
                //    //    if (Insert_ok)
                //    //    {
                //    //        Console.ForegroundColor = ConsoleColor.Green;
                //    //        Console.WriteLine("添加数据成功");
                //    //    }
                //    //    else
                //    //    {
                //    //        Console.ForegroundColor = ConsoleColor.Blue;
                //    //        Console.WriteLine("添加数据失败");
                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    Console.ForegroundColor = ConsoleColor.Red;
                //    //    Console.WriteLine("已存在数据");
                //    //}

                //    #endregion
                //}



                #region

                var pageurl = hd.DocumentNode.SelectSingleNode(".//a[@class='next pagination-item ']")
                    .Attributes["href"].Value;
                pageurl = "https://" + pageurl;
                GetTieba(pageurl);
                Console.WriteLine("已写入全部数据");
                Console.WriteLine(Convert.ToInt32(url) + 50);
                GetTieba((Convert.ToInt32(url) + 50).ToString());
            }

            #endregion

            Console.ReadKey();

            return Json("");
        }



        /// <summary>
        /// 保存web图片到本地
        /// </summary>
        /// <param name="imgUrl">web图片路径</param>
        /// <param name="path">保存路径</param>
        /// <param name="fileName">保存文件名</param>
        /// <returns></returns>
        public  string SaveImageFromWeb(string imgUrl, string path, string fileName)
        {
            //if (path.Equals(""))
            //    //throw new Exception("未指定保存文件的路径");
            //    Directory.CreateDirectory(MapPath("~/upimg/hufu"));
            if (Directory.Exists(path))
            {
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                directoryInfo.Create();
            }



            string imgName = imgUrl.ToString().Substring(imgUrl.ToString().LastIndexOf("/") + 1);
            string defaultType = ".jpg";
            string[] imgTypes = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string imgType = imgUrl.ToString().Substring(imgUrl.ToString().LastIndexOf("."));
            string imgPath = "";
            foreach (string it in imgTypes)
            {
                if (imgType.ToLower().Equals(it))
                    break;
                if (it.Equals(".bmp"))
                    imgType = defaultType;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imgUrl);
            request.UserAgent = "Mozilla/6.0 (MSIE 6.0; Windows NT 5.1; Natas.Robot)";
            request.Timeout = 3000;

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            if (response.ContentType.ToLower().StartsWith("image/"))
            {
                byte[] arrayByte = new byte[1024];
                int imgLong = (int)response.ContentLength;
                int l = 0;

                if (fileName == "")
                    fileName = imgName;

                FileStream fso = new FileStream(path + fileName + imgType, FileMode.Create);
                while (l < imgLong)
                {
                    int i = stream.Read(arrayByte, 0, 1024);
                    fso.Write(arrayByte, 0, i);
                    l += i;
                }

                fso.Close();
                stream.Close();
                response.Close();
                imgPath = fileName + imgType;
                return imgPath;
            }
            else
            {
                return "";
            }
        }











        //日常接口
        public JsonResult PPoo()
        {
            var httpClient = new HttpClient();
            var url = new Uri("http://www.jx3tong.com/?m=api&c=info&a=content_list");
            var body = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "category_id", "0"},
                    { "add_ad", "1"},
                    { "p", "1"},
                    { "num", "20"},
                });
            var response = httpClient.PostAsync(url, body).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(data);
            var json = DapperExtension.Extensions.TosJSON(obj);
            dynamic data1 = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic c = data1.daily_info;
            //时间
            dynamic dailytime = c.daily_update_time;
            //日常
            dynamic dailylist = c.daily_list;
            List<Titlee> list = new List<Titlee>();

            //遍历日常装泛型
            foreach (var item in dailylist)
            {
                Titlee mod = new Titlee();
                mod.id = item.id;
                mod.title = item.title;
                list.Add(mod);
            }

            string dazhan = "";
            string pubdaily = "";
            string zhanchang = "";
            string mijing = "";
            string gongfang = "";
            DateTime ti = new DateTime();
            var tim = DateTime.Now;

            if (list.Count != 0 && list.Count == 5)
            {
                gongfang = list[4].title.Trim();
                dazhan = list[0].title.Trim();
                pubdaily = list[1].title.Trim();
                zhanchang = list[2].title.Trim();
                mijing = list[3].title.Trim();

            }

            var ssp = dailytime.ToString();
            ssp = ssp.Replace("  ", ",");
            string[] strarrs = ssp.Split(',');
            //时间
            string dtime = "";
            //工作日
            string dwork = "";

            if (strarrs.Length != 0)
            {
                dtime = strarrs[0];
                dwork = strarrs[1];
            }
            //判断今天是周几
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            //农历
            var oldtime = GetChineseDateTime(tim).Trim();
            var hink = "";
            var gftime = "";
            var alltime = "";
            switch (week)
            {
                case "星期一":
                    hink = "本周第一天科举放榜，帮会可开启阴山商路";
                    alltime = "\n  战场、跑商(12:00-次日1:00)" + "\n  公共日常(7:00 - 次日6:59)" + "\n  矿车(10:00 - 次日1:59)";
                    break;
                case "星期二":
                    hink = "小攻防记得19:28地图排队，阵营小斗士冲鸭！";
                    alltime = "\n  逐鹿中原<小攻防>(20:00-22:00)" + "\n  战场、跑商(12:00-次日1:00)" + "\n  公共日常(7:00 - 次日6:59)" + "\n  矿车(10:00 - 次日1:59)";
                    break;
                case "星期三":
                    hink = "帮会可开启阴山商路，点天工树最后一天！";
                    alltime = "\n  战场、跑商(12:00-次日1:00)" + "\n  公共日常(7:00 - 次日6:59)" + "\n  矿车(10:00 - 次日1:59)";
                    break;
                case "星期四":
                    hink = "本周10人本CD的最后一天，记得清CD哦！(1/2)";
                    alltime = "\n  逐鹿中原<小攻防>(20:00-22:00)" + "\n  战场、跑商(12:00-次日1:00)" + "\n  公共日常(7:00 - 次日6:59)" + "\n  矿车(10:00 - 次日1:59)";
                    break;
                case "星期五":
                    alltime = "\n  战场、跑商(12:00-次日1:00)" + "\n  公共日常(7:00 - 次日6:59)" + "\n  矿车(10:00 - 次日1:59)";
                    break;
                case "星期六":
                    alltime = "\n  浩气盟<大攻防>(13:00-15:00、19:00-21:00)" + "\n  攻防前置(12:00-次日1:00)" + "\n  战场、跑商(12:00-次日1:00)" + "\n  公共日常(7:00 - 次日6:59)" + "\n  矿车(10:00 - 次日1:59)";
                    break;
                case "星期日":
                    hink = "本周最后一天啦，记得科举、帮会杀猪！"+"\n  副本没清完的赶紧清CD了！";
                    alltime = "\n  恶人谷<大攻防>(13:00-15:00、19:00-21:00)" + "\n  战场、跑商(12:00-次日1:00)" + "\n  公共日常(7:00 - 次日6:59)" + "\n  矿车(10:00 - 次日1:59)";
                    break;
                default:
                    break;
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine("今天是" + dtime + " 星期" + dwork + "\n->" + "农历" + oldtime + "\n->" + dazhan + "\n->" + zhanchang + "\n->" + pubdaily  + "\n->" + gongfang + "\n->" + mijing + "\n->" + hink+ alltime + "\n日常每天7:00更新！");




            return Json("");
        }
        public class Titlee {
            public string id { get; set; }
            public string title { get; set; }
        }
        ///<summary>
        /// 根据公历获取农历日期
        ///</summary>
        ///<param name="datetime">公历日期</param>
        ///<return s></return s>
        public static string GetChineseDateTime(DateTime datetime)
        {
            int year = ChineseCalendar.GetYear(datetime);
            int month = ChineseCalendar.GetMonth(datetime);
            int day = ChineseCalendar.GetDayOfMonth(datetime);
            //获取闰月， 0 则表示没有闰月
            int leapMonth = ChineseCalendar.GetLeapMonth(year);

            bool isleap = false;

            if (leapMonth > 0)
            {
                if (leapMonth == month)
                {
                    //闰月
                    isleap = true;
                    month--;
                }
                else if (month > leapMonth)
                {
                    month--;
                }
            }
            return string.Concat(GetLunisolarMonth(month), "月", GetLunisolarDay(day));
           // return string.Concat(GetLunisolarYear(year), "年", isleap ? "闰" : string.Empty," "+ GetLunisolarMonth(month), "月", GetLunisolarDay(day));
        }

        public IActionResult AddTieba()
        {
            return View();
        }

        public string Test()
        {
            string M_str_sqlcon = "server=39.105.2.189;user id=root;password=12345;database=mydata"; //根据自己的设置
            MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
            myCon.Open();
            string sqlstring = "select * from my_tieba";
            var dataseet = ExecuteReade(sqlstring, myCon);
            //读取字段
            while (dataseet.Read())
            {
               string titl=dataseet["Title"].ToString();
            }
           //关闭数据库链接 释放资源
            myCon.Close();
            return "";
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static MySqlDataReader ExecuteReade(string SQLString, MySqlConnection connection)
        {

            MySqlCommand cmd = new MySqlCommand(SQLString, connection);
            try
            {
                MySqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, MySqlConnection connection)
        {

            using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
            {
                try
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }

        }
    }

}