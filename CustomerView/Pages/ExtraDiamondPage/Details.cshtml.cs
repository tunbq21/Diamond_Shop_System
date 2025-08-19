using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSS_SWP.Models;

namespace CustomerView.Pages.ExtraDiamondPage
{
    public class DetailsModel : PageModel
    {
        private readonly DSS_SWP.Models.DSS_CustomerContext _context;

        public DetailsModel(DSS_SWP.Models.DSS_CustomerContext context)
        {
            _context = context;
        }

        public ExtraDiamond ExtraDiamond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extradiamond = await _context.ExtraDiamonds.FirstOrDefaultAsync(m => m.Id == id);
            if (extradiamond == null)
            {
                return NotFound();
            }
            else
            {
                ExtraDiamond = extradiamond;
            }
            return Page();
        }
    }
}
