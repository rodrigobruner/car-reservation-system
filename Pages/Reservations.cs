using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class ReservationsModel : PageModel
{
    private readonly ILogger<ReservationsModel> _logger;

    public List<Reserve> reservations;

    public CarInventory carInventory;

    public ReservationsModel(ILogger<ReservationsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
            
        try {
            User user = null;
            var userEmail = HttpContext?.Session?.GetString("User"); // Here is required httpConext

            if(userEmail != null) {
                carInventory = new CarInventory();
                reservations = ReservationsRepo.getReservations();
                user = UsersRepo.GetUser(userEmail);
                if(user.role != "Admin") {
                    reservations = ReservationsRepo.getReservationsByEmail(user.email);
                }
            } else {
                Response.Redirect("/Login");
            }
        } catch (Exception e) {
            Response.Redirect("/Login");
        }
        
    }
}

