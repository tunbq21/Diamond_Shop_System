using Microsoft.AspNetCore.Mvc.RazorPages;
using DSS_SWP.Models;
using Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductDetailModel : PageModel
{
    private readonly ProductService _productService;
    private readonly MaterialService _materialService;

    public ProductDetailModel(ProductService productService, MaterialService materialService)
    {
        _productService = productService;
        _materialService = materialService;
    }

    public Product Product { get; set; }
    public List<Material> Materials { get; set; }

    public async Task OnGetAsync(long id)
    {
        Product = _productService.GetProductById(id);
        Materials = _materialService.GetAllMaterials();
    }
}
