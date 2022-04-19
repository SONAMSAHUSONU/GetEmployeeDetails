using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetEmployeeDetails
{
    class Program
    {

            static void Main(string[] args)
            {
            Console.WriteLine("Please Enter the Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
                Program obj = new Program();
                EmpDetails employe = obj.GetData(id);
                
                    Console.WriteLine(employe.E_id);
                    Console.WriteLine(employe.E_Fname);
                    Console.WriteLine(employe.E_Lname);
                    Console.WriteLine(employe.E_Mobile);
                    Console.WriteLine(employe.E_Age);
                    Console.WriteLine(employe.E_Email);

                

                Console.ReadLine();

            }
            public EmpDetails GetData(int E_id)
            {
            EmpDetails oEmpDetails = new EmpDetails();


            string Myconnection = "server=DESKTOP-93EJUAM;database=EMP_Test;Integrated Security = SSPI"; //we make the connection here

                SqlConnection con = new SqlConnection(Myconnection);
                SqlCommand cmd = new SqlCommand("sp_Empsdata", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                try
                {
                cmd.Parameters.AddWithValue("@Eid", E_id);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        oEmpDetails.E_id = Convert.ToInt32(dr["E_id"]);
                        oEmpDetails.E_Fname = Convert.ToString(dr["E_Fname"]);
                        oEmpDetails.E_Lname = Convert.ToString(dr["E_Lname"]);
                        oEmpDetails.E_Mobile = Convert.ToString(dr["E_Mobile"]);
                        oEmpDetails.E_Age = Convert.ToInt32(dr["E_Age"]);
                        oEmpDetails.E_Email = Convert.ToString(dr["E_Email"]);
                         
                    }

                }

            catch (Exception ex)
                {
                    return null;
                }

                finally
            {
                    con.Close();
                }
            return oEmpDetails;


        }
    }
        public class EmpDetails
        {
            public int E_id { get; set; }
            public string E_Fname { get; set; }
            public string E_Lname { get; set; }
            public string E_Mobile { get; set; }
            public int E_Age { get; set; }
            public string E_Email { get; set; }

        }
    }

    

