using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSS_SWP.Models;
using Service.Services;

namespace CustomerView.Pages.OrderDetailPage
{
    public class IndexModel : PageModel
    {
        private readonly OrderDetailService _context;

        public IndexModel(OrderDetailService context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderDetail = await _context.GetList();
            //OrderDetail = await _context.OrderDetails
            //    .Include(o => o.Order)
            //    .Include(o => o.Product).ToListAsync();
        }
    }
}
