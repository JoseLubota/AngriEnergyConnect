using AngriEnergyConnect.Model;
using AngriEnergyConnect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngriEnergyConnect.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [BindProperty(SupportsGet =true)]
        public DateOnly? fromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly? toDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? category { get; set; }

        public List<Product> filteredProducts { get; set; } = new();

        public async void OnGetAsync()
        {
            var allProducts = await _productService.GetAllAsync();
            filteredProducts = allProducts
                .Where(p =>
                (!fromDate.HasValue || p.productionDate >= fromDate) &&
                (!toDate.HasValue || p.productionDate <= toDate) &&
                (string.IsNullOrEmpty(category) || p.category == category)
                ).ToList();

        }
    }
}
