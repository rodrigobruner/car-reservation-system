using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class SingupModel : PageModel
{
    private readonly ILogger<SingupModel> _logger;

    public User user;

    public string? error;

    public SingupModel(ILogger<SingupModel> logger)
    {
        _logger = logger;
    }
    public void OnGet(string? errorMsg)
    {
        this.error = errorMsg;
        Console.WriteLine(errorMsg);
    }

    public IActionResult OnPost(User user)
    {
        bool status = UsersRepo.AddUser(user);
        Console.WriteLine(status);
        if (!status) {
            return RedirectToPage("Singup", new { errorMsg = "User already exists." });
        }
        return RedirectToPage("UserConfirmation", user);
    }
}

