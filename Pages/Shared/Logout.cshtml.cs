using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngriEnergyConnect.Pages.Shared
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Clear current sesison usedID and accouType
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
