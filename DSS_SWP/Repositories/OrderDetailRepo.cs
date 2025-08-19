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
    public class OrderDetailRepo : BaseDAO<OrderDetail>
    {
        public OrderDetailRepo()
        {
            
        }

        public async Task<List<OrderDetail>> GetList()
        {
            return await _context.OrderDetails
                                 .Include(x => x.Product)
                                 .Include(x => x.Order)
                                 .ToListAsync();
        }

        public long GetLength()
        {
            return _context.OrderDetails
                                 .Count();
        }


        public OrderDetail? GetOrderDetailById(long id)
        {
            return _context.OrderDetails
                                 .Include(x => x.Product)
                                 .Include(x => x.Order)
                                 .FirstOrDefault(m => m.Id == id);
        }
    }
}
