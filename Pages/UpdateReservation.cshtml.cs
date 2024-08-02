using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class UpdateReservationModel : PageModel
{

    public CarInventory carInventory = new CarInventory();

    public Reserve reserve;

    public int selectedCar = 1;
    private readonly ILogger<UpdateReservationModel> _logger;

    public UpdateReservationModel(ILogger<UpdateReservationModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int? id)
    {
        reserve = ReservationsRepo.GetReservation((int)id);
        if (reserve == null) {
            Response.Redirect("/Reservation");
        }   
        
        this.selectedCar = reserve.car;
    }

    public IActionResult OnPost(Reserve reserve)
    {
        Console.WriteLine(reserve.ToString());
        if(!ModelState.IsValid)
            return Page();
    
        ReservationsRepo.UpdateReservation(reserve);
        return RedirectToPage("Reservations");
    }
}

