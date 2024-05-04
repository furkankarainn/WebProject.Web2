using Core.Utilities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            //var result = _homeControler.GetMenus().Result;
            //var menuList = new List<MenuComponentDto>();
            //if (result is OkObjectResult okResult)
            //{
            //    var data = okResult.Value as List<MenuComponentDto>;
            //    if (data != null)
            //    {
            //        // Burada data değişkeni üzerinde işlemlerinizi yapabilirsiniz.
            //        foreach (var item in data)
            //        {
            //            menuList.Add(item);
            //        }
            //    }
            //}

            return View();
        }
    }
}
