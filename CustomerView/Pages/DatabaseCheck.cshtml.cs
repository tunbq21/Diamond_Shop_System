using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

public class DatabaseCheckModel : PageModel
{
    private readonly IConfiguration _configuration;

    public bool IsDatabaseConnected { get; set; }
    public string ErrorMessage { get; set; }

    public DatabaseCheckModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnGet()
    {
        string connectionString = _configuration.GetConnectionString("DSS_CustomerContext");

        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IsDatabaseConnected = connection.State == System.Data.ConnectionState.Open;
            }
        }
        catch (Exception ex)
        {
            IsDatabaseConnected = false;
            ErrorMessage = ex.Message;
        }
    }
}
