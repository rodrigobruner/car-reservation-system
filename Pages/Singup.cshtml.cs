using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class SingupModel : PageModel
{
    private readonly ILogger<SingupModel> _logger;

    public User user;

    public SingupModel(ILogger<SingupModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost(User user)
    {
        if(!ModelState.IsValid)
            return Page();
    
        UsersRepo.AddUser(user);
        return RedirectToPage("UserConfirmation", user);
    }
}

