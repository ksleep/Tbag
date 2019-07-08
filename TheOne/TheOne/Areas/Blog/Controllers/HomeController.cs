using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace TheOne.Areas.Blog.Controllers
{
    [Area("Blog")]
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
        //文章内容
        [HttpPost]
        public JsonResult GetArticleData()
        {
            var sql = $@"select * from  my_article";
            var result = _database.GetListSQL<dynamic>(sql);
            return Json(result);
        }

        //树加载方法
        [HttpPost]
        public JsonResult ArticleData(int page, int limit)
        {
            return Json(DataResult(page, limit));
        }

        //左侧树的数据以及翻页的数据
        public dynamic DataResult(int page, int limit)
        {

            string sqlstring = $@"select * from  my_article";
            string sqlcount = $@"select count(0) from my_article ";
            var result = _database.GetPagesSQL<dynamic>(sqlstring, sqlcount, page - 1, limit);
            //_database.Dispose();
            return result;
        }
    }
}