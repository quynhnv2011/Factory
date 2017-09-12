using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;
using Core.Web.Models;
using Business;

namespace CsdlHkd.BackEnd.Models
{
    public class AccountAddModel
    {
        public int Id { get; set; }
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Email không đúng định dạng")]
        [MaxLength(50, ErrorMessage = "Email nhập không quá 50 ký tự")]
        [Required(ErrorMessage = "Bạn vui lòng nhập email")]
        public string Email { get; set; }
        [MaxLength(8, ErrorMessage = "Mật khẩu nhập không quá 8 ký tự")]
        [Required(ErrorMessage = "Bạn vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Mật khẩu nhập lại không đúng")]
        public string RePassword { get; set; }
        public System.DateTime PasswordExpiredDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int CurrentLanguageID { get; set; }
        public int Status { get; set; }
        public int AccountType { get; set; }
        [MaxLength(50, ErrorMessage = "Họ tên nhập không quá 50 ký tự")]
        [Required(ErrorMessage = "Bạn vui lòng nhập họ tên")]
        public string DisplayName { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActivated { get; set; }
        public DateTime LockedDate { get; set; }
        public int LockedBy { get; set; }
        public DateTime ActivatedDate { get; set; }
        public int ActivatedBy { get; set; }
        public DateTime LastLoginDate { get; set; }
        [Required(ErrorMessage = "Bạn vui lòng nhập chọn phòng ban")]
        public int DonViId { get; set; }
        public List<EnumModel> ListStatus { get; set; }
    }
}