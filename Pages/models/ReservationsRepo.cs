using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

public static class ReservationsRepo {
    static private List<Reserve> RESERVATIONS = new List<Reserve>();

    static readonly string FILE_NAME = "./Json/Reservations.json";

    public static void AddReservation(Reserve reservation){
        //Generate a ID
        reservation.id = ID.New();

        if (File.Exists(FILE_NAME)) { // If it exists, take the data and add new ones
            List<Reserve> reservations = JsonSerializer.Deserialize<List<Reserve>>(File.ReadAllText(FILE_NAME));
            reservations.Add(reservation);
            string jsonList = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_NAME, jsonList);
        } else { // If it not exist create a new file and add the data
            List<Reserve> reservations =  new List<Reserve>();
            reservations.Add(reservation);
            string jsonList = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_NAME, jsonList);
        }
        
    }

    public static Reserve GetReservation(int id){
        Reserve reserve = getReservations().Where(reserve => reserve.id == id).FirstOrDefault();
        return reserve != null ? reserve : throw new Exception("Reservation not found.");
    }

    public static bool RemoveReservation(int id){
        List<Reserve> reservations =  getReservations();
        List<Reserve> removeTheseReserves = reservations.Where(r => r.id == id).ToList();
        var status = false;
        foreach (var reservation in removeTheseReserves) {
            reservations.Remove(reservation);
            status = true;
        }
        string jsonList = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FILE_NAME, jsonList);
        return status;
    }

    public static void UpdateReservation(Reserve reservation){
        RemoveReservation(reservation.id);
        AddReservation(reservation);
    }

    public static List<Reserve> getReservations(){
        if (File.Exists(FILE_NAME)) {
            List<Reserve> reservations = JsonSerializer.Deserialize<List<Reserve>>(File.ReadAllText(FILE_NAME));
            return reservations;
        } else {
            List<Reserve> reservations = new List<Reserve>();
            return reservations;
        }
    }

    public static List<Reserve> getReservationsByEmail(string email){
        List<Reserve> reservations = getReservations();
        return reservations.Where(reserve => reserve.email == email).ToList();
    }
}