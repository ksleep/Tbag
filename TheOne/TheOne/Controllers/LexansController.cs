using DapperExtension;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace TheOne.Controllers
{
    public class LexansController : BaseController
    {
        private readonly IDatabase _database;
        public LexansController(IDatabase database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            //var result = _database.GetSQL<PlanTaskModel>($"SELECT id,inum,name,type,host FROM qtz_data where id=4");
            return View();
        }
        [HttpPost]
        public JsonResult GetData(int page, int limit, string sortField, string sortType, string name)
        {

            string sqlJoin = $@"select * from my_tieba";
            string sqlCount = "SELECT count(0) FROM my_tieba";

            var result = _database.GetPagesSQL<dynamic>(sqlJoin, sqlCount, page - 1, limit);
            
            return Json(new PageResponse(result.TotalItems, result.Items));
        }
        public class PlanTaskModel
        {
            public virtual int id { get; set; }
            public virtual int inum { get; set; }
            public virtual string name { get; set; }
            public virtual string type { get; set; }
            public virtual string host { get; set; }
        }

        
    }
}