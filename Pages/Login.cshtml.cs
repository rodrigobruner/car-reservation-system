using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;

    public User user;

    public string error;

    public LoginModel(ILogger<LoginModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost(User user)
    {
        Console.WriteLine("Aqui");
        Console.WriteLine(user.email);
        if(UsersRepo.ValidateCredential(user.email, user.password)){
            HttpContext.Session.SetString("User", user.email);
            return RedirectToPage("/Reservations");
        }
        Console.WriteLine("Login fail!");
        this.error = "Invalid username or password";
        return Page();
    }
}

