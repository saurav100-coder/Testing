using StudentRecord.Models;
using System.Data;
using System.Data.SqlClient;

namespace StudentRecord.Databse_Operation
{
    public class StuDbOperation
    {
        private string conString = "Server=.;database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True";
        public List<Student> GetAllStudents()
        {
            //connection();
            List<Student> stuList = new List<Student>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetStudentDetails", con);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    stuList.Add(
                        new Student
                        {
                            StudId = Convert.ToInt32(row["StudId"]),
                            Name = Convert.ToString(row["Name"]),
                            City = Convert.ToString(row["City"]),
                            Department = Convert.ToString(row["Department"]),
                            Gender = Convert.ToString(row["Gender"])
                        });
                }
            }

            return stuList;


        }
    }
}
