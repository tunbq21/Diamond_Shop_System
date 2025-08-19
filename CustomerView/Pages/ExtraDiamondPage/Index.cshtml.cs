﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSS_SWP.Models;

namespace CustomerView.Pages.ExtraDiamondPage
{
    public class IndexModel : PageModel
    {
        private readonly DSS_SWP.Models.DSS_CustomerContext _context;

        public IndexModel(DSS_SWP.Models.DSS_CustomerContext context)
        {
            _context = context;
        }

        public IList<ExtraDiamond> ExtraDiamond { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ExtraDiamond = await _context.ExtraDiamonds.ToListAsync();
        }
    }
}
