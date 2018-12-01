using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ResponseResultModel> Get()
        {
            var categories = new List<CategoryModel>
            {
                new CategoryModel{Id = 1, Name="Ăn uống"},
                new CategoryModel{Id = 2, Name="Thời trang"},
                new CategoryModel{Id = 3, Name="Du lịch"},
                new CategoryModel{Id = 4, Name="Học tập"},
                new CategoryModel{Id = 5, Name="Sức khỏe"},
                new CategoryModel{Id = 6, Name="Xe cộ"},
                new CategoryModel{Id = 7, Name="Khác"},
            };

            return new ResponseResultModel
            {
                Data = categories,
                Code = 200,
                Message = "OK"
            };
        }
    }
}