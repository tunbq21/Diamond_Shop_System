using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerView.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {

            HttpContext.Session.Remove("UserId");

            return RedirectToPage("/HomePage");
        }
    }
}
