using AngriEnergyConnect.Model;
using AngriEnergyConnect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngriEnergyConnect.Pages
{
    public class SignUpModel(UserService userService) : PageModel
    {
        private readonly UserService _userService = userService;

        [BindProperty]
        public User user { get; set; }  

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _userService.AddAsync(user);
            return RedirectToPage("Index");
        }

        public void OnGet()
        {
        }
    }
}
