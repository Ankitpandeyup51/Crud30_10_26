using Crud30_10_26.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud30_10_26.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult Registeration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registeration(StudentModel model)
        {
            ViewBag.Message = "Your contact page.";
            SqlCommand cmd = new SqlCommand("Insert Into Student values (@id,@name,@email,@phone,@dob,@gender,@password,@address)", con);
            cmd.Parameters.AddWithValue("@id", model.Id);
            cmd.Parameters.AddWithValue("@name", model.name);
            cmd.Parameters.AddWithValue("@email", model.email);
            cmd.Parameters.AddWithValue("@phone", model.phone);
            cmd.Parameters.AddWithValue("@dob", model.dob);
            cmd.Parameters.AddWithValue("@gender", model.gender);
            cmd.Parameters.AddWithValue("@password", model.password);
            cmd.Parameters.AddWithValue("@address", model.address);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                return Content("<script>alert('Data Inserted Successfully');location.href='/Home/Registeration';</script>");
            }
            else
            {
                return Content("<script>alert('Registration Failed');location.href='/Home/Registeration';</script>");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Student model)
        {
            SqlCommand cmd = new SqlCommand("Select * from Student where email=@email and password=@password", con);
            cmd.Parameters.AddWithValue("@email", model.email);
            cmd.Parameters.AddWithValue("@password", model.password);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                con.Close();
                return Content("<script>alert('Login Successful');location.href='/Home/Index';</script>");
            }
            else
            {
                con.Close();
                return Content("<script>alert('Invalid Email or Password');location.href='/Home/Login';</script>");
            }
        }
        public ActionResult StudentList()
        {

            SqlCommand cmd = new SqlCommand("Select * from Student", con);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);


            return View(dt);
        }
        public ActionResult DeleteOneStudent(int id)
        {

            SqlCommand cmd = new SqlCommand("delete from Student where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {

                return Content("<script>alert('Student Deleted Successful');location.href='/Home/StudentList';</script>");
            }
            else
            {

                return Content("<script>alert('No record Found');location.href='/Home/StudentList';</script>");
            }
        }
        public ActionResult UpdateStudent(int id)
        {

            SqlCommand cmd = new SqlCommand("select * from Student where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);

            return View(dt);
        }
        [HttpPost]
        public ActionResult UpdateStudent(StudentModel model)
        {
            ViewBag.Message = "Your contact page.";
            SqlCommand cmd = new SqlCommand("Update Student set name=@name,email=@email,phone=@phone,dob=@dob,gender=@gender,password=@password,address=@address where id=@id", con);
            cmd.Parameters.AddWithValue("@id", model.Id);
            cmd.Parameters.AddWithValue("@name", model.name);
            cmd.Parameters.AddWithValue("@email", model.email);
            cmd.Parameters.AddWithValue("@phone", model.phone);
            cmd.Parameters.AddWithValue("@dob", model.dob);
            cmd.Parameters.AddWithValue("@gender", model.gender);
            cmd.Parameters.AddWithValue("@password", model.password);
            cmd.Parameters.AddWithValue("@address", model.address);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                return Content("<script>alert('Data Inserted Successfully');location.href='/Home/Registeration';</script>");
            }
            else
            {
                return Content("<script>alert('Registration Failed');location.href='/Home/Registeration';</script>");
            }
        }


    }
}