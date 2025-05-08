using AngriEnergyConnect.Model;
using AngriEnergyConnect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngriEnergyConnect.Pages
{
    public class LoginModel(UserService userService) : PageModel
    {
        private readonly UserService _userService = userService;

        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public bool loginResult { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var success = await _userService.LoginAsync(email, password); 
            loginResult = success;
            if (success) 
            {
                TempData["LoginResult"] = "sucess";
                return RedirectToAction("Index");
            }
            TempData["LoginResult"] = "fail";
            return Page();

        }

        public void OnGet()
        {
        }
    }
}
