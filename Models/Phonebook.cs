

namespace Models
{
    public class Phonebook{
      public Guid Id {get; set;}
      public string Name {get; set;}
      public string Email {get; set;}
      public string Address {get; set;}
      public string PhoneNumber {get; set;}
      public DateTime CreatedAt {get; set;}

      public override string ToString()
      {
        return $"{this.Name} - {this.PhoneNumber}";
      }
    }
}
