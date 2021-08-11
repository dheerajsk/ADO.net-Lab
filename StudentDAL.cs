using ADO.net_Lab.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADO.net_Lab
{
    public class StudentDAL
    {
        string connectionString = "data source=.;initial catalog=SchoolDB;integrated security=True;MultipleActiveResultSets=True";

        public IEnumerable<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Student", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.ID = Convert.ToInt64(reader["ID"]);
                    student.Name = reader["Name"].ToString();
                    student.Year = reader["Year"].ToString();
                    students.Add(student);
                }
                con.Close();
            }

            return students;
        }
    }
}
