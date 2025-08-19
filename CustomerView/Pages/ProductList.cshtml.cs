using DSS_SWP.Models;
using Service.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerView.Pages
{
    public class ProductListModel : PageModel
    {
        private readonly ProductService _productService;

        public List<Product> Products { get; set; }
        public List<string> Shapes { get; set; }
        public List<string> Colors { get; set; }
        public List<string> Clarities { get; set; }

        public ProductListModel()
        {
            _productService = new ProductService();
        }

        public async Task OnGet()
        {
            Products = await _productService.GetList();
            Shapes = GetShapes();
            Colors = GetColors();
            Clarities = GetClarities();
        }

        private List<string> GetShapes()
        {
            return new List<string> { "Round", "Princess", "Emerald", "Cushion", "Marquise", "Oval" };
        }

        private List<string> GetColors()
        {
            return new List<string> { "D", "E", "F", "G", "H", "I", "J" };
        }

        private List<string> GetClarities()
        {
            return new List<string> { "IF", "VVS1", "VVS2", "VS1", "VS2", "SI1", "SI2" };
        }
    }
}
