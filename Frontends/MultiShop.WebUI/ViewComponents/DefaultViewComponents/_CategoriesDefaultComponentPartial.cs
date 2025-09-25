using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CategoriesDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        //private readonly ICategoryService _categoryService;
        //public _CategoriesDefaultComponentPartial(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var values = await _categoryService.GetAllCategoryAsync();
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
                //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                //    return View(values);
                //}

                var list = new List<ResultCategoryDto>();
            list.Add(new ResultCategoryDto { CategoryID = "1", CategoryName = "Elektronik", ImageUrl = "" });
            list.Add(new ResultCategoryDto { CategoryID = "1", CategoryName = "Telefon", ImageUrl = "" });
            list.Add(new ResultCategoryDto { CategoryID = "1",CategoryName = "Bilgisayar", ImageUrl = ""});
            list.Add(new ResultCategoryDto { CategoryID = "1",CategoryName = "Oyuncak", ImageUrl = ""});
            list.Add(new ResultCategoryDto { CategoryID = "1",CategoryName = "Kıyafet", ImageUrl = ""});
            list.Add(new ResultCategoryDto { CategoryID = "1",CategoryName = "Mobilya", ImageUrl = ""});
            list.Add(new ResultCategoryDto { CategoryID = "1",CategoryName = "Temizlik", ImageUrl = ""});
            list.Add(new ResultCategoryDto { CategoryID = "1",CategoryName = "Küçük Ev Aletleri", ImageUrl = ""});

            return View(list);
        }

    }
}
