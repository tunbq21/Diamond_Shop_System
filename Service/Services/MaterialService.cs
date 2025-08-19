using DSS_SWP.Repositories;
using DSS_SWP.Models;
using System.Collections.Generic;

namespace Service.Services
{
    public class MaterialService
    {
        private readonly MaterialRepo _repo;

        public MaterialService(MaterialRepo repo) // Nhận repo qua constructor
        {
            _repo = repo;
        }

        public List<Material> GetAllMaterials()
        {
            return _repo.GetAllMaterials();
        }
    }
}
