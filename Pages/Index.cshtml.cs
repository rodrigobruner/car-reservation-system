using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    //List of cars avalible
    public CarInventory carInventory = new CarInventory(); 

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
