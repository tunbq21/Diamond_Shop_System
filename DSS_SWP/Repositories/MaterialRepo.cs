using DSS_SWP.BaseDAO;
using DSS_SWP.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSS_SWP.Repositories
{
    public class MaterialRepo : BaseDAO<Material>
    {
        public MaterialRepo()
        {
        }

        public List<Material> GetAllMaterials()
        {
            return GetAll().ToList(); 
        }
    }
}
