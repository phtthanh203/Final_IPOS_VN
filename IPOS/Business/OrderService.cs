using IPOS.DB;
using IPOS.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace IPOS.Business
{
    public class OrderService
    {
        private readonly ProductRepository _productRepo = new ProductRepository();

        public List<ProductDetails> GetAllProducts()
        {
            return _productRepo.GetAll();
        }

        public List<ProductDetails> FilterProductsByKeyword(string keyword)
        {
            return _productRepo.GetAll()
                .Where(p => p.ProductName.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }

        public List<ProductDetails> FilterProductsByCategory(int categoryId)
        {
            return _productRepo.GetAll()
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public int CalculateTotalPrice(List<ProductDetails> cart)
        {
            return cart.Sum(p => p.Price);
        }

        public int ApplyDiscount(int total, int discountValue, bool isPercent)
        {
            return isPercent ? total * discountValue / 100 : discountValue;
        }
    }
}
