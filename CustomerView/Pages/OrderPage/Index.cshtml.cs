using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSS_SWP.Models;
using Service.Services;

namespace CustomerView.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly OrderService _context;

        public IndexModel(OrderService context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.GetList();
        }
    }
}
