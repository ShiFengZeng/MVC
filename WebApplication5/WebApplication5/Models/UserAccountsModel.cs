using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class UserAccountsModel
    {
        public int id { get; set; }
        [DisplayName("帳號")]
        public string account { get; set; }
        [DisplayName("密碼")]
        public string password { get; set; }
        [DisplayName("使用者名稱")]
        public string name { get; set; }
        [DisplayName("年齡")]
        public int age { get; set; }
        [DisplayName("性別")]
        public string gender { get; set; }
        [DisplayName("生日")]
        public string birthday { get; set; }
        [DisplayName("信箱")]
        public string email { get; set; }
    }
}