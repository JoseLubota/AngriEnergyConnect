using AngriEnergyConnect.Model;
using AngriEnergyConnect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngriEnergyConnect.Pages
{
    public class ProductModel(ProductService _productService) : PageModel
    {
        [BindProperty]
        public Product product { get; set; }

        public List<Product> userProducts { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _productService.AddAsync(product); 
            return Page();
        }
        

        public async Task OnGetAsync()
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            string? accountType = HttpContext.Session.GetString("accountType");
            if(userId != null && accountType != null)
            {
                if(accountType == "Farmer")
                {
                    userProducts = await _productService.GetBtUserIdAsync(userId.Value);
                }
                else
                {
                    userProducts = await _productService.GetAllAsync();
                }

            }
        }
    }
}
