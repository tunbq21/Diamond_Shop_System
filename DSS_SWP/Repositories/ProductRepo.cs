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
    public class ProductRepo : BaseDAO<Product>
    {
        //private ExtraDiamondRepo _extraDiamondRepo;
        //private MainDiamondRepo _mainDiamondRepo;
        //private MaterialRepo _materialRepo;
        //private DiamondShellRepo _diamondShellRepo;

        public ProductRepo()
        {

        }

        public async Task<List<Product>> GetList()
        {
            return await _context.Products
                                 .Include(x => x.DiamondShell)
                                 .Include(x => x.MainDiamond)
                                 .ToListAsync();
        }


        public Product? GetProductById(long id)
        {
            return _context.Products
                       .Include(x => x.DiamondShell)
                       .Include(x => x.MainDiamond)
                       .FirstOrDefault(m => m.Id == id);
        }
        public async Task<List<Product>> GetLatestProducts(int count)
        {
            return await _context.Products
                .OrderByDescending(p => p.Id) 
                .Take(count)
                .ToListAsync();
        }

        //public double? GetExDiamondPrice(long id)
        //{
        //    _extraDiamondRepo = new ExtraDiamondRepo();
        //    double exPrice = _extraDiamondRepo.GetByIdLong(id).Price;
        //    return exPrice;
        //}

        //public double? GetShellPrice(long id)
        //{
        //    _diamondShellRepo = new DiamondShellRepo();
        //    _materialRepo = new MaterialRepo();
        //    DiamondShell shell = _diamondShellRepo.GetByIdLong(id);
        //    double materialPrice = _materialRepo.GetByIdInt(shell.MaterialId ?? 1).Price ?? 0;
        //    double shellPrice = materialPrice * shell.Weight ?? 0;
        //    return shellPrice;
        //}
        //public double? GetDiamondPrice(string origin, string cut, string caraWeight, string color)
        //{
        //    var diamondPriceList = _context.DiamondPriceLists
        //                                   .FirstOrDefault(d => d.Origin == origin
        //                                                     && d.Cut == cut
        //                                                     && d.CaraWeight == caraWeight
        //                                                     && d.Color == color);
        //    return diamondPriceList?.Price;
        //}

        //public double GetMainDiamondPrice(long id) 
        //{
        //    _mainDiamondRepo = new MainDiamondRepo();
        //    MainDiamond mainDiamond = _mainDiamondRepo.GetByIdLong(id);
        //    return GetDiamondPrice( mainDiamond.Origin, mainDiamond.Cut, mainDiamond.CaraWeight, mainDiamond.Color) ?? 0; 
        //}




        //public double? TotalPrice(long id)
        //{
        //    Product? a = GetProductById(id);
        //    double? price = 0;
        //    if (a != null)
        //    {
        //        price = GetExDiamondPrice(a.ExtraDiamondId  ?? 0) * a.NumberExDiamond + GetMainDiamondPrice(a.MainDiamondId) + GetShellPrice(a.DiamondShellId ?? 0);
        //    }
        //    return price;
        //}
    }
}
