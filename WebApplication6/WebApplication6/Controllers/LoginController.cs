using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class LoginController : Controller
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MVC\WebApplication6\WebApplication6\App_Data\UserDatabase.mdf;Integrated Security=True";
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorzion(LoginModel model)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM UserTable WHERE  UserName=@UserName AND UserPassword=@UserPassword COLLATE Latin1_General_CS_AI";

                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", model.UserName);
                sqlDa.SelectCommand.Parameters.AddWithValue("@UserPassword", model.UserPassword);

                sqlDa.Fill(dt);
                if (dt.Rows.Count != 1)
                {
                    model.LoginErrorMessage = "帳號或密碼錯誤";
                    return View("Index", model);
                }
                else
                {
                    Session["ID"] = model.UserID;
                    Session["UserName"] = dt.Rows[0][1];
                    return RedirectToAction("Index", "Home");
                }
            }           
        }
        public ActionResult LogOut()
        {
            int ID = (int)Session["ID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}