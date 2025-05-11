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

        [BindProperty(SupportsGet =true)]
        public int? filterFarmerId { get; set; }

        [BindProperty(SupportsGet =true)]
        public string? action {  get; set; }

        public List<Product> userProducts { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _productService.AddAsync(product);

            int? userId = HttpContext.Session.GetInt32("UserID");
            string? accountType = HttpContext.Session.GetString("accountType");


            if (accountType == "Farmer")
            {
                userProducts = await _productService.GetBtUserIdAsync(userId.Value);
            }

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
                else // Employee
                {
                    var allProducts = await _productService.GetAllAsync();

                    if(action == "clear")
                    {
                        // Clear the filter
                        filterFarmerId = null;
                        userProducts = allProducts;
                    }else if (filterFarmerId.HasValue)
                    {
                        userProducts = allProducts
                            .Where(p => p.userID == filterFarmerId.Value)
                            .ToList();
                    }
                    else
                    {
                        userProducts = allProducts;
                    }
                    
                }

            }
        }
    }
}
