using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

public static class UsersRepo {
    static private List<User> USERS = new List<User>();

    static readonly string FILE_NAME = "./Json/Users.json";

    public static void AddUser(User user){
        if (File.Exists(FILE_NAME))
        {
            List<User> users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(FILE_NAME));
            users.Add(user);
            string jsonList = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_NAME, jsonList);
        } else {
            List<User> users =  new List<User>();
            users.Add(user);
            string jsonList = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_NAME, jsonList);
        }
        
    }

    public static void AddDefaultUsers(){

        if(GetUsers().Count() == 0){
            User admin = new User(1, "Admin", "admin@site.com", "123456", "Admin");
            AddUser(admin);
        }
    }

    public static User GetUser(string email){
        User user = GetUsers().Where(u => u.email.Equals(email, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        return user != null ? user : throw new Exception("User not found.");
    }

    public static bool ValidateCredential(string email, string password){
        try{
            Console.WriteLine("Log");
            Console.WriteLine(email);
        User user = UsersRepo.GetUser(email);
            return user.password == password;
        } catch (Exception e) {
            Console.WriteLine($"An error occurred on login: {e.Message}");
            return false;
        }
    }

    public static List<User> GetUsers(){
        if (File.Exists(FILE_NAME)) {
            List<User> users =  JsonSerializer.Deserialize<List<User>>(File.ReadAllText(FILE_NAME));
            return users;
        } else {
            List<User> users = new List<User>();
            return users;
        }
    }
}