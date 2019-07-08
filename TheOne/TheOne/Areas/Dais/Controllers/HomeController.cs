using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DapperExtension;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheOne.Areas.Dais.Controllers
{
    [Area("Dais")]
    public class HomeController : BaseController
    {
        private readonly IDatabase _database;
        public HomeController(IDatabase database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetData(int page, int limit, string sortField, string sortType, string name)
        {

            string sqlJoin = $@"select * from qtz_data";
            string sqlCount = "SELECT count(0) FROM qtz_data";

            var result = _database.GetPagesSQL<dynamic>(sqlJoin, sqlCount, page - 1, limit);

            return Json(new PageResponse(result.TotalItems, result.Items));
        }

        public JsonResult PostFunction(int page, int limit)
        {
            //MySqlConnection connection
            string serviceAddress = "https://qtzqixiu.jz.fkw.com/ajax/statistics_h.jsp?cmd=mapIdList&type=2&wid=0&_TOKEN=3004219b824d044888d37409997cffc5";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "POST";
            request.ContentType = "application/json";
            string strContent = @"{ ""mmmm"": ""89e"",""nnnnnn"": ""0101943"",""kkkkkkk"": ""e8sodijf9""}";
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            //解析josn
            JObject jo = JObject.Parse(retString);

            //JObject jo = (JObject)JsonConvert.DeserializeObject(retString);
            var json = DapperExtension.Extensions.TosJSON(jo);
            Tes descJsonStu = JsonConvert.DeserializeObject<Tes>(json);

            string bs = descJsonStu.id;

            dynamic data1 = JsonConvert.DeserializeObject<dynamic>(json);
            //string b = data1.mapIdList[0].name;
            //dynamic c = data1.mapIdList;

            List<Tes> st = new List<Tes>();

            foreach (var item in data1.mapIdList)
            {
                Tes mod = new Tes();
                if (item.name!="全部产品")
                {
                    mod.id = item.id;
                    mod.name = item.name;
                    try
                    {
                        int k = item.name.ToString().IndexOf("【");//找a的位置
                        int j = item.name.ToString().IndexOf("】");//找b的位置
                        mod.type = (item.name.ToString().Substring(k + 1)).Substring(0, j - k - 1);//找出a和b之间的字符串
                    }
                    catch (Exception e)
                    {
                        mod.type = "暂无分类";
                    }
             
                    mod.host = $"qtzds.com/pd.jsp?id={item.id}";
                    st.Add(mod);
                }
            
              
            }
           // List<Tes> ress = st.Take(30).ToList();
            List<Tes> res = st.ToList();
            int num;
            List<Tes> ress =new List<Tes>();
            if (page==1)
            {
                ress = st.Take(limit).ToList();
            }
            else
            {
                num = page * limit;
                ress = st.Skip(num).Take(limit).ToList();
            }
     
            //var ressss = new PageResponse(ress.Count, ress);

            return Json(new PageResponse(res.Count, ress));

            #region MyRegion

            //for (int i = 0; i < st.Count; i++)
            //{
            //    string type = st[i].name;
            //    if (type == "全部产品")
            //    {

            //    }
            //    else
            //    {
            //        int k = st[i].name.IndexOf("【");//找a的位置
            //        int j = st[i].name.IndexOf("】");//找b的位置
            //        type = (type.Substring(k + 1)).Substring(0, j - k - 1);//找出a和b之间的字符串
            //    }
            //    string host = $"qtzds.com/pd.jsp?id={st[i].id}";
            //   // ExecuteSql($"insert into qtz_data (inum,name,type,host) value('{st[i].id}','{st[i].name}','{type}','{host}')", connection);
            //}



            // Debug.WriteLine(st);

            #endregion




        }
        public class Tes
        {
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string host { get; set; }
        }
    }
}