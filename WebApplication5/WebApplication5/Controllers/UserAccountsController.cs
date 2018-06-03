using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class UserAccountsController : Controller
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MVC\WebApplication5\WebApplication5\App_Data\UserAccountsDatabase.mdf;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtbAccounts = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM UserAccountsTable", sqlCon);
                sqlDa.Fill(dtbAccounts);
            }
            return View(dtbAccounts);
        }

        // GET: UserAccounts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserAccountsModel());
        }

        [HttpPost]
        public ActionResult Create(UserAccountsModel userAccountmodel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO UserAccountsTable VALUES(@account,@password,@name,@age,@gender,@birthday,@email)";
                SqlCommand sqlComd = new SqlCommand(query, sqlCon);

                sqlComd.Parameters.AddWithValue("@account", userAccountmodel.account);
                sqlComd.Parameters.AddWithValue("@password", userAccountmodel.password);
                sqlComd.Parameters.AddWithValue("@name", userAccountmodel.name);
                sqlComd.Parameters.AddWithValue("@age", userAccountmodel.age);
                sqlComd.Parameters.AddWithValue("@gender", userAccountmodel.gender);
                sqlComd.Parameters.AddWithValue("@birthday", userAccountmodel.birthday);
                sqlComd.Parameters.AddWithValue("@email", userAccountmodel.email);
                sqlComd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            UserAccountsModel userAccountsModel = new UserAccountsModel();
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string query = "SELECT * FROM UserAccountsTable WHERE id=@id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlcon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);
                sqlDa.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                userAccountsModel.id = Convert.ToInt32(dt.Rows[0][0].ToString());
                userAccountsModel.account = dt.Rows[0][1].ToString();
                userAccountsModel.password = dt.Rows[0][2].ToString();
                userAccountsModel.name = dt.Rows[0][3].ToString();
                userAccountsModel.age = Convert.ToInt32(dt.Rows[0][4].ToString());
                userAccountsModel.gender = dt.Rows[0][5].ToString();
                userAccountsModel.birthday = dt.Rows[0][6].ToString();
                userAccountsModel.email = dt.Rows[0][7].ToString();
                return View(userAccountsModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(UserAccountsModel userAccountmodel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE UserAccountsTable SET account=@account,password=@password,name=@name,age=@age,gender=@gender,birthday=@birthday,email=@email WHERE id=@id";
                SqlCommand sqlComm = new SqlCommand(query, sqlCon);
                sqlComm.Parameters.AddWithValue("@id", userAccountmodel.id);
                sqlComm.Parameters.AddWithValue("@account", userAccountmodel.account);
                sqlComm.Parameters.AddWithValue("@password", userAccountmodel.password);
                sqlComm.Parameters.AddWithValue("@name", userAccountmodel.name);
                sqlComm.Parameters.AddWithValue("@age", userAccountmodel.age);
                sqlComm.Parameters.AddWithValue("@gender", userAccountmodel.gender);
                sqlComm.Parameters.AddWithValue("@birthday", userAccountmodel.birthday);
                sqlComm.Parameters.AddWithValue("@email", userAccountmodel.email);
                sqlComm.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM UserAccountsTable WHERE id=@id";
                SqlCommand sqlComd = new SqlCommand(query, sqlCon);
                sqlComd.Parameters.AddWithValue("@id", id);
                sqlComd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
