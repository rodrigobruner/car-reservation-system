using System.Diagnostics;

public enum CarCategory{
    Economy,
    Compact,
    Intermediate,
    Standard,
    Premium,
    SUV,
    Pickup,
    Luxury,
}

public class Car{
    public int id {set; get;}
    public CarCategory category {set; get;}
    public string model {set; get;}
    public string brand {set; get;}
    public string image {set; get;}
    public string description {set; get;}
    public bool isAutomatic {set; get;}
    public int numberOfPeople {set; get;}
    public int numberOfBags {set; get;}
    public double pricePerDay {set; get;}

    public Car( int id, 
                CarCategory category, 
                string model, 
                string brand, 
                string image,
                string description, 
                bool isAutomatic, 
                int numberOfPeople, 
                int numberOfBags, 
                double pricePerDay){

        this.id = id;
        this.category = category;
        this.model = model;
        this.brand = brand;
        this.image = image;
        this.description = description;
        this.isAutomatic = isAutomatic;
        this.numberOfPeople = numberOfPeople;
        this.numberOfBags = numberOfBags;
        this.pricePerDay = pricePerDay;
    }
}


public class CarInventory{

    private List<Car> inventory = new List<Car>();

    public CarInventory(){
        setInventory();
    }

    public List<Car> getInventory(){
        return inventory;
    }

    public Car getCarByID(int id){
        return this.inventory.SingleOrDefault<Car>(item => item.id == id);
    }

      // Source https://www.enterprise.ca
    public void setInventory()
    {
        inventory.Add(new Car(1, CarCategory.Economy, "Spark", "Chevrolet", "Economy.png", "AM/FM Stereo Radio; Automatic; Air Conditioning; 2 Wheel Drive; Gasoline Vehicle", false, 4, 2, 68.37));
        inventory.Add(new Car(2, CarCategory.Compact, "Versa", "Nissan", "Compact.png", "AM/FM Stereo Radio; Automatic; Air Conditioning; 2 Wheel Drive; Gasoline Vehicle", true, 5, 2, 68.37));
        inventory.Add(new Car(3, CarCategory.Intermediate, "Forte", "Kia", "Intermediate.png", "AM/FM Stereo Radio; Automatic; Air Conditioning; 2 Wheel Drive; Gasoline Vehicle", true, 5, 3, 69.50));
        inventory.Add(new Car(4, CarCategory.Standard, "Jetta", "Volkswagen", "Standard.png", "Cruise Control; AM/FM Stereo Radio; Automatic; Air Conditioning; 2 Wheel Drive; Gasoline Vehicle; Bluetooth", true, 5, 4, 70.63));
        inventory.Add(new Car(5, CarCategory.Premium, "Maxima", "Nissan", "Premium.png", "Cruise Control; AM/FM Stereo Radio; Automatic; Air Conditioning; 2 Wheel Drive; Gasoline Vehicle; Bluetooth", true, 5, 4, 75.15));
        inventory.Add(new Car(6, CarCategory.SUV, "Edge", "Ford", "SUV.png", "Cruise Control; AM/FM Stereo Radio; Automatic; Air Conditioning; 2 Wheel Drive; Gasoline Vehicle; Bluetooth", true, 5, 5, 79.64));
        inventory.Add(new Car(7, CarCategory.Pickup, "F150 4WD", "Ford", "Pickup.png", "Cruise Control; AM/FM Stereo Radio; Automatic; Air Conditioning; 2 Wheel Drive; Gasoline Vehicle; Bluetooth", true, 4, 4, 76.28));
        inventory.Add(new Car(8, CarCategory.Luxury, "Wrangler 4", "Jeep", "Luxury.png", "Cruise Control; AM/FM Stereo Radio; Automatic; Air Conditioning; 2 Wheel Drive; Gasoline Vehicle; Bluetooth", true, 5, 5, 96.62));
    }
}