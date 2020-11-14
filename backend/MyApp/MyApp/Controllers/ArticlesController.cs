using Microsoft.AspNetCore.Mvc;
using MyApp.Helper;
using MyApp.Interfaces.IManagers;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleManager articleManager;

        public ArticlesController(IArticleManager articleManager)
        {
            this.articleManager = articleManager;
        }
        //[Route("get")]
        public async Task<IActionResult> Index()
        {
            var result = await articleManager.GetArticles();
            return Ok(result.ToResponse("articles retreived"));
        }

        [Route("like/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            var result = await articleManager.LikeArticles(id);
            return Ok(result.ToResponse("article liked! "));
        }
    }
}
