using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace conestoga_sdt_assignment_3_car_reservation_system.Pages;

public class ManageReservationModel : PageModel
{
    private readonly ILogger<ManageReservationModel> _logger;
    public bool status = false;

    public ManageReservationModel(ILogger<ManageReservationModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int? id)
    {
        try {
            User user = null;
            var userEmail = HttpContext?.Session?.GetString("User"); // Here is required httpConext

            if(userEmail != null) {
                if (id != null) {
                    this.status = ReservationsRepo.RemoveReservation((int)id);
                    if (this.status) {
                        Response.Redirect("/Reservations");
                    }
                }
            } else {
                Response.Redirect("/Login");
            }
        } catch (Exception e) {
            Response.Redirect("/Login");
        }
    }
}

