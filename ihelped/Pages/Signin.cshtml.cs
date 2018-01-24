using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ihelped;

namespace ihelped.Pages
{
    public class SigninModel : PageModel
    {
        private readonly ihelpedContext _db;

        public SigninModel(ihelpedContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Users newUser {get; set;}

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            
            return RedirectToPage(pageName: "Index");
        }
    }
}