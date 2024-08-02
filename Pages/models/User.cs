

public class User{
    public int id {set; get;}
    public string name {set; get;}
    public string email {set; get;}
    public string password {set; get;}
    public string role {set; get;}

    public User(){}
    public User(string name,
                string email,
                string password,
                string role="User"){
        this.name = name;
        this.email  = email;
        this.password = password;
        this.role = role;
    }
}