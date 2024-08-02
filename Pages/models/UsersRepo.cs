using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

public static class UsersRepo {
    static private List<User> USERS = new List<User>();

    static readonly string FILE_NAME = "./Json/Users.json";

    public static bool AddUser(User user){
        try{
            if(GetUser(user.email) != null){
                return false;
            }

            user.id = ID.New();
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            
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
            return true;
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            return false;
        }
        
    }

    public static void AddDefaultUsers(){

        if(GetUsers().Count() == 0){
            User admin = new User("Admin", "admin@site.com", "123456", "Admin");
            AddUser(admin);
        }
    }

    public static User GetUser(string email){
        User user = GetUsers().Where(u => u.email.Equals(email, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        return user;
    }

    public static bool ValidateCredential(string email, string password){
        try{
            Console.WriteLine("Log");
            Console.WriteLine(email);
            User user = UsersRepo.GetUser(email);
            return BCrypt.Net.BCrypt.Verify(password, user.password);
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