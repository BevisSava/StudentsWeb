using StudentsWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace StudentsWeb.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyRpt"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GenerateReport(DateTime fromDate, DateTime toDate)
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Student WHERE BirthDate BETWEEN @FromDate AND @ToDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        BirthDate = (DateTime)reader["BirthDate"]

                    });
                }
            }
            return View("ReportView", students);
        }
    }
}