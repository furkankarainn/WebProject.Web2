using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetMenus")]
        public async Task<IActionResult> GetMenus()
        {
            var data = await _menuService.GetAllMenus();
            return Ok(data.Data);
        }

        [HttpPost]
        public IActionResult CreateMenu(CreateMenuDto createMenuDto)
        {
            var result = _menuService.CreateMenu(createMenuDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
