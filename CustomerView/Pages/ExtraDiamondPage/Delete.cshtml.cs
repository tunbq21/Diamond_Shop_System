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
    public class DeleteModel : PageModel
    {
        private readonly DSS_SWP.Models.DSS_CustomerContext _context;

        public DeleteModel(DSS_SWP.Models.DSS_CustomerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extradiamond = await _context.ExtraDiamonds.FindAsync(id);
            if (extradiamond != null)
            {
                ExtraDiamond = extradiamond;
                _context.ExtraDiamonds.Remove(ExtraDiamond);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
