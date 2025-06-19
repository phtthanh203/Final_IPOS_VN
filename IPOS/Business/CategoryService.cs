using IPOS.DataAccess;
using IPOS.DB;
using System.Collections.Generic;

namespace IPOS.Business
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo = new CategoryRepository();

        public List<Category> GetAllCategories()
        {
            return _repo.GetAll();
        }


    }
}
