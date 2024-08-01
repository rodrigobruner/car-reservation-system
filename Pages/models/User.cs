

public class User{
    public int id {set; get;}
    public string name {set; get;}
    public string email {set; get;}
    public string password {set; get;}
    public string role = "User";

    public User(){}
    public User(int id,
                string name,
                string email,
                string password,
                string role="User"){

        this.id = id;
        this.name = name;
        this.email  = email;
        this.password = password;
        this.role = role;
    }
}