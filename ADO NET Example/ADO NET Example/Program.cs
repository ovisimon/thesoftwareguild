using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SWCCorp"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetProductListByLocation";

                cmd.Parameters.AddWithValue("@LocationID", "1");

                conn.Open();

                List<Employee> list = new List<Employee>();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employee e = new Employee();

                        e.EmpID = (int)dr["EmpID"];
                        e.FirstName = dr["FirstName"].ToString();
                        e.LastName = dr["LastName"].ToString();
                        e.HireDate = (DateTime)dr["HireDate"];
                        if(dr["LocationID"] != DBNull.Value)
                        {
                            e.LocationID = (int)dr["LocationID"];
                        }
                        list.Add(e);
                    }
                }
                foreach(var emp in list)
                {
                    Console.WriteLine($"{ emp.FirstName} {emp.LastName} {emp.HireDate} ");
                }
                Console.ReadKey();
            }
        }
    }

    public class Employee
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? HireDate { get; set; }
        public int? LocationID { get; set; }
        public int? ManagerID { get; set; }
        public string Status { get; set; }
    }
}
