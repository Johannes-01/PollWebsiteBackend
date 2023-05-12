using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webserver.Context;
using Webserver.Model;

namespace Webserver.Controllers
{
    public class HomeController : Controller
    {
        private readonly PollDbContext context;
       public HomeController(PollDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var polls = this.context.Polls.Include(m => m.PollID).Select(m => new Poll
            {
                PollID = m.PollID,
                Description = m.Description
            });
            return View(polls);
        }
    }
}
