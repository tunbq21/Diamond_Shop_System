using DSS_SWP.BaseDAO;
using DSS_SWP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS_SWP.Repositories
{
    public class OrderRepo : BaseDAO<Order>
    {
        public OrderRepo()
        {
            
        }

        public async Task<List<Order>> GetList()
        {
            return await _context.Orders
                                 .Include(x => x.Payment)
                                 .ToListAsync();
        }

        public long GetLength()
        {
            return _context.Orders
                                 .Count();
        }

        public Order? GetOrderById(long id)
        {
            return _context.Orders
                                 .Include(x => x.Payment)
                                 .FirstOrDefault(m => m.Id == id);
        }
    }
}
