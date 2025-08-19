﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DSS_SWP.Models;

namespace CustomerView.Pages.DiamondPriceListPage
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
            return Page();
        }

        [BindProperty]
        public DiamondPriceList DiamondPriceList { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DiamondPriceLists.Add(DiamondPriceList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
