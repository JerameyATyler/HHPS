using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ihelped;

namespace ihelped.Pages
{
    public class AllotmentModel : PageModel
    {
        private readonly ihelpedContext _db;

        public AllotmentModel(ihelpedContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Users user {get; set;}

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return RedirectToPage(pageName: "Index");
        }
    }
}