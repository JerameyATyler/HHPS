using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ihelped;

namespace ihelped.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ihelpedContext _db;

        public RegisterModel(ihelpedContext db)
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

            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();
            return RedirectToPage(pageName: "Index");
        }
    }
}