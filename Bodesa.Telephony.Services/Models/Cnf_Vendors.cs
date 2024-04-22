namespace Bodesa.Telephony.Services.Models
{
    public class Cnf_Vendors
    {
        public string ID { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public short VendorStatus { get; set; }

        public string VendorCompany { get; set; }

        public int PayrollNumber { get; set; }

        public string FullName { get; set; }

        public bool IsOnline { get; set; }

        public bool IsEnabled { get; set; }

        public bool PasswordExpires { get; set; }

        public DateTime? PasswordExpiresOn { get; set; }

        public string VendorProfile_ID { get; set; }

        public string JobID { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedFrom { get; set; }

        public Guid OtherID { get; set; }

        public bool PasswordReset { get; set; }
        public string VerifiedData { get; set; }
        public DateTime? UserValidationDate { get; set; }
    }
}
