using IPOS.DataAccess;
using IPOS.DB;
using IPOS.Models;
using IPOS_VN.Models;
using System;
using System.Collections.Generic;

namespace IPOS.Business
{
    public class PaymentService
    {
        private readonly OrderRepository orderRepo;

        public PaymentService()
        {
            orderRepo = new OrderRepository();
        }

        public void ProcessPayment(string maDonHang, int tongTien, List<ProductDetails> cart, int? tableId)
        {
            var order = new OrderModel
            {
                OrderCode = maDonHang,
                TotalAmount = tongTien,
                Status = "New",
                OrderTime = DateTime.Now,
                IsTakeAway = false,
                TableId = tableId
            };

            int orderId = orderRepo.CreateOrder(order);

            foreach (var item in cart)
            {
                orderRepo.AddOrderDetail(orderId, item.ProductId, item.Price);
            }
        }
    }
}
