using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class ConfirmationModel : PageModel
{
    private readonly ILogger<ConfirmationModel> _logger;

    public Reserve reserve;

    public Car car;

    public ConfirmationModel(ILogger<ConfirmationModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(Reserve _reserve)
    {
        
        CarInventory carInventory = new CarInventory();
        this.car = carInventory.getCarByID(_reserve.car);
        reserve = _reserve;
    }
}

