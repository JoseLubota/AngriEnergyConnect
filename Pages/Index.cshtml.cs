using AngriEnergyConnect.Model;
using AngriEnergyConnect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AngriEnergyConnect.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Creates variabble to handle product services 
        private readonly ProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        //---------------------------------------------------------------------------------------------//
        // Variables to receive page data
        //---------------------------------------------------------------------------------------------//
        [BindProperty(SupportsGet =true)]
        public DateOnly? fromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly? toDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? category { get; set; }

        // List for filtered products 
        public List<Product> filteredProducts { get; set; } = new();

        //---------------------------------------------------------------------------------------------//
        // On Get filter table data and retrieve it
        //---------------------------------------------------------------------------------------------//
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
//--------------------------------...END OF FILE...-------------------------------------------------------------//
