using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSS_SWP.Models;

namespace CustomerView.Pages.DiamondPriceListPage
{
    public class DeleteModel : PageModel
    {
        private readonly DSS_SWP.Models.DSS_CustomerContext _context;

        public DeleteModel(DSS_SWP.Models.DSS_CustomerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiamondPriceList DiamondPriceList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diamondpricelist = await _context.DiamondPriceLists.FirstOrDefaultAsync(m => m.Id == id);

            if (diamondpricelist == null)
            {
                return NotFound();
            }
            else
            {
                DiamondPriceList = diamondpricelist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diamondpricelist = await _context.DiamondPriceLists.FindAsync(id);
            if (diamondpricelist != null)
            {
                DiamondPriceList = diamondpricelist;
                _context.DiamondPriceLists.Remove(DiamondPriceList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
