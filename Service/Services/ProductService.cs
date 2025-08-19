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
    public class ProductService
    {
        private ProductRepo _repo = new ProductRepo();
        public async Task<List<Product>> GetList()
        {
            return await _repo.GetList(); 
        }

        public Product? GetProductById(long id)
        {
            return _repo.GetProductById(id);
        }


        public async void Add(Product product)
        {
            await _repo.CreateAsync(product);
        }

        public async void Update(Product product)
        {
            await _repo.UpdateAsync(product);
        }

        public int Save()
        {
            return  _repo.Save();
        }
        public async Task<List<Product>> GetLatestProducts()
        {
            return await _repo.GetLatestProducts(5); 
        }

    }
}
