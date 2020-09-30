using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodNewsBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        /*public async Task<IActionResult> Get()
        {
            try
            {
                var news = await _newsService.GetAllNews();

                return news != null && news.Any() ?
                    (IActionResult)Ok(news)
                    : Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        BackgroundJob.Enqueue( () => _newsService.GetNewsFromUrl(""));
        RecurringJob.AddOrUpdate( () => _newsService.GetNewsFromUrl("")
            .Cron.Hauly()); запускается каждый час  прописать в стартапе


        }*/
    }
}