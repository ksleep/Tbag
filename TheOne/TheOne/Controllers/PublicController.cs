using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperExtension;
using DapperExtensions;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TheOne.Controllers
{
    public class PublicController : BaseController
    {
        private readonly IDatabase _database;
        public PublicController(IDatabase database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Tieba
        /// </summary>
        /// <param name="url"></param>
        public  JsonResult GetTieba(string url)
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
                foreach (var item in titleList)
                {
                    var id = item.SelectSingleNode("./div[1]/div[1]/a[1]").Attributes["href"].Value;
                    id = id.Substring(3, id.Length - 3);//贴吧ID
                    var title = item.SelectSingleNode("./div[1]/div[1]/a[1]").InnerText;//标题
                    var line = "https://tieba.baidu.com/p/" + id + "";
                    if (id.Length == 10)
                    {
                        //Console.WriteLine("标题： " + title + "链接：" + line);
                        //Console.WriteLine();
                        //string titleinfo = "";
                        if (title.Contains("【818】") || title.Contains("【树洞】") || title.Contains("【616】") || title.Contains("【鬼网三】"))
                        {
                            int cou = _database.GetSQLField<int>( "select count(0) 数量 from my_tieba where ID= " + id + "");
                           // string sqlstring = "select count(0) 数量 from my_tieba where ID= " + id + "";
                           // bool numss = Exists(sqlstring);
                            var typ = title.Substring(0, 4);
                            //if (numss == true) { }
                            //else
                            //{
                            //    Console.WriteLine("标题： " + title + "链接：" + line);
                            //    //插入数据
                            //    ExecuteSql($"insert into my_tieba (Title,Link,Type) value('{title}','{line}','{typ}')", connection);
                            //}

                            Console.WriteLine();

                        }


                        #region
                        //Console.WriteLine("标题  " + titleinfo + "");
                        //Console.WriteLine();
                        //Console.WriteLine("已获取到标题  " + title + "");
                        //Console.WriteLine();
                        //Console.WriteLine(" 已获取到链接  https://tieba.baidu.com/p/" + id + "");
                        //bool ok = SqlHelper.Is_Tid(id);
                        //if (ok)
                        //{
                        //    Console.WriteLine("正在添加数据" + id + "");
                        //    var username = item.SelectSingleNode("./div[1]/div[2]/span").Attributes["title"].Value;
                        //    username = username.Substring(6, username.Length - 6);//用户名
                        //    var userid = item.SelectSingleNode("./div[1]/div[2]/span").Attributes["data-field"].Value;
                        //    userid = userid.Substring(21, userid.Length - 22);//用户id
                        //    bool Insert_ok = SqlHelper.InsertTieba(new Model.Tieba()
                        //    {
                        //        Tid = id,
                        //        title = title,
                        //        username=username,
                        //        userid=userid
                        //    });
                        //    if (Insert_ok)
                        //    {
                        //        Console.ForegroundColor = ConsoleColor.Green;
                        //        Console.WriteLine("添加数据成功");
                        //    }
                        //    else
                        //    {
                        //        Console.ForegroundColor = ConsoleColor.Blue;
                        //        Console.WriteLine("添加数据失败");
                        //    }
                        //}
                        //else
                        //{
                        //    Console.ForegroundColor = ConsoleColor.Red;
                        //    Console.WriteLine("已存在数据");
                        //}
                        #endregion
                    }

                }
                #region
                var pageurl = hd.DocumentNode.SelectSingleNode(".//a[@class='next pagination-item ']").Attributes["href"].Value;
                pageurl = "https://" + pageurl;
                GetTieba(pageurl);
                Console.WriteLine("已写入全部数据");
                Console.WriteLine(Convert.ToInt32(url) + 50);
                GetTieba((Convert.ToInt32(url) + 50).ToString());
                #endregion
                Console.ReadKey();

            }

            return Json("");
        }
     

        //public static void PostFunction(MySqlConnection connection)
        //{
        //    string serviceAddress = "https://qtzqixiu.jz.fkw.com/ajax/statistics_h.jsp?cmd=mapIdList&type=2&wid=0&_TOKEN=3004219b824d044888d37409997cffc5";
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    string strContent = @"{ ""mmmm"": ""89e"",""nnnnnn"": ""0101943"",""kkkkkkk"": ""e8sodijf9""}";
        //    using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
        //    {
        //        dataStream.Write(strContent);
        //        dataStream.Close();
        //    }
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    string encoding = response.ContentEncoding;
        //    if (encoding == null || encoding.Length < 1)
        //    {
        //        encoding = "UTF-8"; //默认编码  
        //    }
        //    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
        //    string retString = reader.ReadToEnd();
        //    //解析josn
        //    JObject jo = JObject.Parse(retString);



        //    //JObject jo = (JObject)JsonConvert.DeserializeObject(retString);
        //    var json = JsonExtension.TosJSON(jo);
        //    Tes descJsonStu = JsonConvert.DeserializeObject<Tes>(json);

        //    string bs = descJsonStu.id;

        //    dynamic data1 = JsonConvert.DeserializeObject<dynamic>(json);
        //    //string b = data1.mapIdList[0].name;
        //    //dynamic c = data1.mapIdList;

        //    List<Tes> st = new List<Tes>();

        //    foreach (var item in data1.mapIdList)
        //    {
        //        Tes mod = new Tes();
        //        mod.id = item.id;
        //        mod.name = item.name;
        //        st.Add(mod);
        //    }

        //    for (int i = 0; i < st.Count; i++)
        //    {
        //        string type = st[i].name;
        //        if (type== "全部产品")
        //        {

        //        }
        //        else
        //        {
        //            int k = st[i].name.IndexOf("【");//找a的位置
        //            int j = st[i].name.IndexOf("】");//找b的位置
        //            type = (type.Substring(k + 1)).Substring(0, j - k - 1);//找出a和b之间的字符串
        //        }
        //        string host = $"qtzds.com/pd.jsp?id={st[i].id}";
        //        ExecuteSql($"insert into qtz_data (inum,name,type,host) value('{st[i].id}','{st[i].name}','{type}','{host}')", connection);
        //    }



        //    Debug.WriteLine(st);



        //}

    }
}