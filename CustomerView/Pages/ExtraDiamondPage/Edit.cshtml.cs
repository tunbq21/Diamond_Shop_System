using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSS_SWP.Models;

namespace CustomerView.Pages.ExtraDiamondPage
{
    public class EditModel : PageModel
    {
        private readonly DSS_SWP.Models.DSS_CustomerContext _context;

        public EditModel(DSS_SWP.Models.DSS_CustomerContext context)
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

            var extradiamond =  await _context.ExtraDiamonds.FirstOrDefaultAsync(m => m.Id == id);
            if (extradiamond == null)
            {
                return NotFound();
            }
            ExtraDiamond = extradiamond;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExtraDiamond).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraDiamondExists(ExtraDiamond.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExtraDiamondExists(long id)
        {
            return _context.ExtraDiamonds.Any(e => e.Id == id);
        }
    }
}
