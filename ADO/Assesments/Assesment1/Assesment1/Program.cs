using System;
using System.Data;
using System.Data.SqlClient;

namespace Assesment1
{
    class Employee
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-4C2BJ84\\SQLEXPRESS;Initial Catalog=assesments;User id=sa;password=Infinite@1234;");
            try
            {
                con.Open();

                // 1. Insert Employee
                SqlCommand insertCmd = new SqlCommand("insertemployee", con);
                insertCmd.CommandType = CommandType.StoredProcedure;

                insertCmd.Parameters.AddWithValue("@name", "manisha");
                insertCmd.Parameters.AddWithValue("@salary", 30000);
                insertCmd.Parameters.AddWithValue("@gender", "female");

                SqlParameter newIdParam = new SqlParameter("@newempid", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter netSalParam = new SqlParameter("@netsalary", SqlDbType.Decimal) { Direction = ParameterDirection.Output };

                insertCmd.Parameters.Add(newIdParam);
                insertCmd.Parameters.Add(netSalParam);

                insertCmd.ExecuteNonQuery();

                int empId = Convert.ToInt32(newIdParam.Value);
                decimal netSalary = Convert.ToDecimal(netSalParam.Value);

                Console.WriteLine($"Inserted Employee:\n - EmpID: {empId}\n - Net Salary: ₹{netSalary}\n");



                // 2. Update Employee Salary
                SqlCommand updateCmd = new SqlCommand("updateemployeesalary", con);
                updateCmd.CommandType = CommandType.StoredProcedure;
                updateCmd.Parameters.AddWithValue("@empid", empId);

                SqlParameter updatedSalParam = new SqlParameter("@updatedsalary", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                updateCmd.Parameters.Add(updatedSalParam);

                updateCmd.ExecuteNonQuery();

                decimal updatedSalary = Convert.ToDecimal(updatedSalParam.Value);
                Console.WriteLine($"Updated Salary for EmpID {empId}:\n - New Salary: ₹{updatedSalary}\n");

                
                SqlCommand fetchCmd = new SqlCommand("select * from employee_details where empid = @empid", con);
                fetchCmd.Parameters.AddWithValue("@empid", empId);

                SqlDataReader reader = fetchCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine(" Employee Details:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"EmpID     : {reader["empid"]}");
                        Console.WriteLine($"Name      : {reader["name"]}");
                        Console.WriteLine($"Salary    : ₹{reader["salary"]}");
                        Console.WriteLine($"NetSalary : ₹{reader["netsalary"]}");
                        Console.WriteLine($"Gender    : {reader["gender"]}");
                        
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                
            }

            Console.ReadKey();
        }
    }
}


