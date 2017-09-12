using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Account:BaseBusinessObject
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordExpireddate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string Status { get; set; }
        public int AccountType { get; set; }
        public string DisplayName { get; set; }
        public string IsLocked { get; set; }
        public string IsActivated { get; set; }
        public DateTime LockedDate { get; set; }
        public int LockedBy { get; set; }
        public DateTime ActivatedDate { get; set; }
        public int ActivatedBy { get; set; }
        public DateTime LastLogin { get; set; }
        public int DonViPhongBanId { get; set; }
    }
}
