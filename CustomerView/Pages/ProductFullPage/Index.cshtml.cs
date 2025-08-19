using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSS_SWP.Models;
using Service.Services;

namespace CustomerView.Pages.ProductFullPage
{
    public class IndexModel : PageModel
    {
        private ProductService _context;

        public IndexModel(ProductService context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.GetList();
        }
    }
}
