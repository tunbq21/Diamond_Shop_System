using DSS_SWP.Models;
using DSS_SWP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderDetailService
    {
        private OrderDetailRepo _repo = new OrderDetailRepo();

        public OrderDetailService()
        {
            
        }

        public async Task<List<OrderDetail>> GetList()
        {
            return await _repo.GetList();
        }

        public OrderDetail? GetOrderById(long id)
        {
            return _repo.GetOrderDetailById(id);
        }
        public long GetLength()
        {
            return _repo.GetLength();
        }

        public async void Add(OrderDetail orderDetail)
        {
            await _repo.CreateAsync(orderDetail);
        }

        public async void Update(OrderDetail orderDetail)
        {
            await _repo.UpdateAsync(orderDetail);
        }

        public int Save()
        {
            return _repo.Save();
        }
    }
}
