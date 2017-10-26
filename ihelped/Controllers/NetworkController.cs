using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ihelped.Controllers
{
    public class NetworkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}