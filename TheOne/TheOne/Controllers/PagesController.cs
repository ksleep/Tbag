using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TheOne.Controllers
{
    public class PagesController : BaseController
    {
        //做任意名称的单页面时使用，避免新增页面时需要改代码
        //例如 Page/Helper  Page/App   Page/About
        [Route("/Pages/{Name}")]
        public IActionResult Index(string Name)
        {
            return View(Name, "");
        }
    }
}