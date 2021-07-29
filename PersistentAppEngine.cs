using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CaseStudy
{
    class CourseAlreadyTaken : ApplicationException
    {
        internal CourseAlreadyTaken(string msg) : base(msg) { }
    }

    class PersistentAppEngine
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
                "Data Source = DESKTOP-GBJB52G; Initial Catalog = dbCaseStudy; Integrated Security = true");
            con.Open();
            return con;
        }

        internal void RegisterStudent()
        {
            
            Student student = new Student();
            Console.WriteLine("Enter the Name: ");
            student.name = Console.ReadLine();
            Console.WriteLine("Enter the Date in dd/mm/yyyy fromat: ");
            student.dob = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter your first phone number:");
            student.PhoneNumbers[0] = Console.ReadLine();
            Console.WriteLine("Enter your second phone number:");
            student.PhoneNumbers[1] = Console.ReadLine();

            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("spu_RegisterStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sname", student.name);
                cmd.Parameters.AddWithValue("@dob", student.dob.Date);
                cmd.Parameters.AddWithValue("@phone1", student.PhoneNumbers[0]);
                cmd.Parameters.AddWithValue("@phone2", student.PhoneNumbers[1]);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Rows Affected: {rowsAffected}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }

        internal void IntroduceCourse()
        {
            int cid;
            string cname;
            int duration;
            double fees;
            int rowsAffected;

            try
            {
                con = GetConnection();

                Console.WriteLine("Enter the Course ID: ");
                cid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Name: ");
                cname = Console.ReadLine();
                Console.WriteLine("Enter the duration in days:");
                duration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the fees:");
                fees = Convert.ToDouble(Console.ReadLine());


                Console.WriteLine("1.Degree \n 2.Diploma");
                int courseType = Convert.ToInt32(Console.ReadLine());

                switch (courseType)
                {
                    case 1:
                        Console.WriteLine("Type Bachelors or Masters");
                        string Level = Console.ReadLine();
                        Console.WriteLine("Type 'true' is placement available else 'false'");
                        bool isPlacementAvailable = Convert.ToBoolean(Console.ReadLine());

                        cmd = new SqlCommand("spu_IntroduceDeegreeCourse", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cid", cid);
                        cmd.Parameters.AddWithValue("@CName", cname);
                        cmd.Parameters.AddWithValue("@Duration", duration);
                        cmd.Parameters.AddWithValue("@Fees", fees);
                        cmd.Parameters.AddWithValue("@Level", Level);
                        if(isPlacementAvailable)
                            cmd.Parameters.AddWithValue("@IsPlacementAvailable", 1);
                        else
                            cmd.Parameters.AddWithValue("@IsPlacementAvailable", 0);

                        rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Rows Affected: {rowsAffected}");
                        break;
                    case 2:
                        Console.WriteLine("Type professional or academic");
                        string DiplomaType = Console.ReadLine();

                        cmd = new SqlCommand("spu_IntroduceDiplomaCourse", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cid", cid);
                        cmd.Parameters.AddWithValue("@CName", cname);
                        cmd.Parameters.AddWithValue("@Duration", duration);
                        cmd.Parameters.AddWithValue("@Fees", fees);
                        cmd.Parameters.AddWithValue("@Type", DiplomaType);
   
                        rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Rows Affected: {rowsAffected}");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }

        internal void Enroll()
        {
            int IsAvailable;

            Console.WriteLine("Enter the student ID");
            int sid = Convert.ToInt32(Console.ReadLine());

            CallDisplayCourses();

            Console.WriteLine("Enter the Course ID that you want");
            int cid = Convert.ToInt32(Console.ReadLine());

            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("CourseAlreadyTaken", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@sid", sid);
                IsAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                if (IsAvailable == 1)
                {
                    throw new CourseAlreadyTaken("Course Already Taken by the student.");
                }
                else
                {
                    cmd = new SqlCommand("spu_AddEnrollment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@sid", sid);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Rows Affected: {rowsAffected}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }

        internal void CallDisplayStudent()
        {
            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("DisplayStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0]+" "+dr[1]+" "+dr[2]+" "+dr[3]+" "+dr[4]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        internal void CallDisplayCourses()
        {
            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("DisplayCourses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3] + " " + dr[4] + " " + dr[5] + " " + dr[6]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        internal void CallDisplayEnrollments()
        {
            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("DisplayEnrollments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
