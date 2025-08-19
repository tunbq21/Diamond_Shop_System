using Service.Services;
using DSS_SWP.Repositories;

namespace CustomerView
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // Add Session
            builder.Services.AddSession();

            // DI - Dependency Injection
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<OrderDetailService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<MaterialService>();
            builder.Services.AddScoped<MaterialRepo>(); // Đăng ký MaterialRepo ở đây

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseSession();

            app.UseAuthorization();
            app.MapFallbackToPage("/HomePage");

            app.MapRazorPages();

            app.Run();
        }
    }
}
