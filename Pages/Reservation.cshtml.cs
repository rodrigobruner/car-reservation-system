using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class ReservationModel : PageModel
{
    private readonly ILogger<ReservationModel> _logger;

    public CarInventory carInventory = new CarInventory();

    public Reserve reserve;

    public int selectedCar = 1;

    public ReservationModel(ILogger<ReservationModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int? car)
    {
        this.selectedCar = (int)car;
    }

    public IActionResult OnPost(Reserve reserve)
    {
        Console.WriteLine(reserve.ToString());
        if(!ModelState.IsValid)
            return Page();
    
        ReservationsRepo.AddReservation(reserve);
        return RedirectToPage("Confirmation", reserve);
    }
}
