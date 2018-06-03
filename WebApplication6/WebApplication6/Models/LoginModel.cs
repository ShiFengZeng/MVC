using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class LoginModel
    {        
        public int UserID { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage ="請輸入帳號")]
        public string UserName { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [DataType("Password")]
        public string UserPassword { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}