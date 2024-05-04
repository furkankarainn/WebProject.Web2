using Core.Utilities.Helpers;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Web.Views.Shared.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly HttpRequestHelper _httpRequestHelper;

        public MenuViewComponent(HttpRequestHelper httpRequestHelper)
        {
            _httpRequestHelper = httpRequestHelper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _httpRequestHelper.GetAsync<List<MenuComponentDto>>("/api/menu/getmenus");

            return View(result);
        }
    }
}
