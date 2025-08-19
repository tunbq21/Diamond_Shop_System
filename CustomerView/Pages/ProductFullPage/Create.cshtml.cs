using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DSS_SWP.Models;

namespace CustomerView.Pages.ProductFullPage
{
    public class CreateModel : PageModel
    {
        private readonly DSS_SWP.Models.DSS_CustomerContext _context;

        public CreateModel(DSS_SWP.Models.DSS_CustomerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DiamondShellId"] = new SelectList(_context.DiamondShells, "Id", "Image");
        ViewData["ExtraDiamondId"] = new SelectList(_context.ExtraDiamonds, "Id", "Name");
        ViewData["MainDiamondId"] = new SelectList(_context.MainDiamonds, "Id", "CaraWeight");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
