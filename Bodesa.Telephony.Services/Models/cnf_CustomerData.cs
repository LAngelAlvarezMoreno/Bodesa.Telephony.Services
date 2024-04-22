using System.ComponentModel.DataAnnotations;

namespace Bodesa.Telephony.Services.Models
{
    public class cnf_CustomerData
    {
        [Key]
        public string PayrollNumber { get; set;}
        public string Name { get; set;}
        public string SecondName { get; set;}
        public string LastName { get; set;}
        public string SecondLastName { get; set;}
        public string PhoneNumber { get; set;}
        public string Department { get; set;}
        public string LeaderShip { get; set;}
        public string CECOS { get; set;}
    }
}
