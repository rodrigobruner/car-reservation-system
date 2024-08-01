using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class UserConfirmationModel : PageModel
{
    private readonly ILogger<UserConfirmationModel> _logger;

    public UserConfirmationModel(ILogger<UserConfirmationModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

