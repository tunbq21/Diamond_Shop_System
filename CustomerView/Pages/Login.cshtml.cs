using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Services;

namespace CustomerView.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        private readonly UserService _accountRepo = new UserService();
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }


        public async Task<IActionResult> OnPost()
        {
            try
            {
                var account = _accountRepo.GetAccount(email, password);
                if (account != null)
                {
                    // Lưu thông tin người dùng vào session
                    HttpContext.Session.SetString("UserId", account.Id.ToString());
                    HttpContext.Session.SetString("UserName", account.Name); // Lưu tên người dùng nếu cần

                    TempData["Message"] = "Login Success";
                    Console.WriteLine("Login Success");
                    HttpContext.Session.SetString("UserId", account.Id.ToString());
                    return RedirectToPage("/HomePage");
                }
                else
                {
                    
                    TempData["Message"] = "Tài khoảng hoặc mật khẩu bị sai. Vui lòng nhập lại!";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }

        }
    }
}
