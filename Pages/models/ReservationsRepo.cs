using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

public static class ReservationsRepo {
    static private List<Reserve> RESERVATIONS = new List<Reserve>();

    static readonly string FILE_NAME = "reservations.json";

    public static void AddReservation(Reserve reservation){
        if (File.Exists(FILE_NAME))
        {
            List<Reserve> reservations = JsonSerializer.Deserialize<List<Reserve>>(File.ReadAllText(FILE_NAME));
            reservations.Add(reservation);
            string jsonList = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_NAME, jsonList);
        } else {
            List<Reserve> reservations =  new List<Reserve>();
            reservations.Add(reservation);
            string jsonList = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_NAME, jsonList);
        }
        
    }

    public static List<Reserve> getReservations(){
        if (File.Exists(FILE_NAME)) {
            List<Reserve> reservations =  JsonSerializer.Deserialize<List<Reserve>>(File.ReadAllText(FILE_NAME));
            return reservations;
        } else {
            List<Reserve> reservations = new List<Reserve>();
            return reservations;
        }
    }
}