using System.ComponentModel.DataAnnotations;

public class Reserve{
    public int id {get;set;}
    
    [Required ( ErrorMessage = "Please enter your name") ]
    public string name {get; set;}
    
    [Required (ErrorMessage = "Please enter a phone number.")]
    [RegularExpression ("([0-9]+(-[0-9]+)+)", ErrorMessage = "Please provide a valid phone number in format XXX-YYY-ZZZZ")]
    public string phone {get; set;}

    [Required ( ErrorMessage = "Please enter your e-mail") ]
    public string email {get; set;}

    public string date {get; set;}

    [Required (ErrorMessage = "Please select a time slot.")]
    public string time {get; set;}

    [Required (ErrorMessage = "Please select a car.")]
    public int car {get; set;}

    public static List<String> GetPickupTimes(){
        List<String> list = new List<String>();
        for(var h=9; h < 21; h++){
            for(var m=0; m<60; m=m+15){
                list.Add($"{h.ToString("00")}:{m.ToString("00")}");
            }
        }
        return list;
    }

    public override string ToString()
    {
        return  String.Format("{0} {1} {2} {3} {4} {5}", this.name, this.phone, this.email,this.date, this.time, this.car);
    }
}