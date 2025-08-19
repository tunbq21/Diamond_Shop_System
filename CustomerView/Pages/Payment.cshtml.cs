using DSS_SWP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Services;
using System.Collections.Generic;

namespace CustomerView.Pages
{
    public class PaymentModel : PageModel
    {
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

        private readonly OrderService _orderService = new OrderService();

        private readonly OrderDetailService _orderDetailService = new OrderDetailService();

        public PaymentModel(OrderService orderService, OrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        [BindProperty]
        public Order Order { get; set; } = new Order()!;

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = new OrderDetail()!;
        public void OnGet(long Id, string name, string product_code, int total_price, string image)
        {
            // Nhận thông tin sản phẩm từ URL
            Products.Add(new ProductViewModel
            {
                Id = Id,
                ProductName = name,
                ProductCode = product_code,
                TotalPrice = total_price,
                Image = image
            });
        }

    public async Task<IActionResult> OnPost()
        {
            try { 
                long customerId = long.Parse(HttpContext.Session.GetString("UserId"));
                Order.OrderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Order.PaymentId = 1;
                Order.CustomerId = customerId;
                Order.Status = 1;

                _orderService.Add(Order);

                long orderId = _orderService.GetLength();
                OrderDetail.OrderId = orderId;
                _orderDetailService.Add(OrderDetail);
                return RedirectToPage("./HomePage");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
        }
    }

    public class ProductViewModel
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int TotalPrice { get; set; }
        public string Image { get; set; }
    }
}
