using AngriEnergyConnect.Model;
using AngriEnergyConnect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngriEnergyConnect.Pages
{
    public class LoginModel(UserService userService) : PageModel
    {
        private readonly UserService _userService = userService;
        //---------------------------------------------------------------------------------------------//
        // Variables to receive page data
        //---------------------------------------------------------------------------------------------//
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public bool loginResult { get; set; }
        //---------------------------------------------------------------------------------------------//
        // On Submit validade login and return data containing status
        //---------------------------------------------------------------------------------------------//
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
                TempData["LoginResult"] = "";
                return RedirectToPage("/Index");
            }
            TempData["LoginResult"] = "fail";
            return Page();

        }

        public void OnGet()
        {
        }
    }
}
//--------------------------------...END OF FILE...-------------------------------------------------------------//
