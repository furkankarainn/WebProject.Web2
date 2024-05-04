using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public HomeController(IMenuService menuService)
        {
            _menuService = menuService;
        }


        //[HttpGet("GetMenus")]
        //[SecuredOperation("product.add,admin")]
        //[ValidationAspect(typeof(ProductValidator))]
        public async Task<IActionResult> GetMenus()
        {
            var data = await _menuService.GetAllMenus();
            return Ok(data.Data);
        }
    }
}
