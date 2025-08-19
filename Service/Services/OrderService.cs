using DSS_SWP.Models;
using DSS_SWP.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService
    {
        private OrderRepo _repo = new OrderRepo();
        public OrderService()
        {
            
        }

        public async Task<List<Order>> GetList()
        {
            return await _repo.GetList();
        }

        public Order? GetOrderById(long id)
        {
            return _repo.GetOrderById(id);
        }

        public long GetLength()
        {
            return _repo.GetLength();
        }
        public async void Add(Order order)
        {
            await _repo.CreateAsync(order);
        }

        public async void Update(Order order)
        {
            await _repo.UpdateAsync(order);
        }

        public int Save()
        {
            return _repo.Save();
        }

    }
}
