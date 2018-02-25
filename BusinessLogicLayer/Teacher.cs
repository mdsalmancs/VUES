using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    public class Teacher : Member
    {
        public string jobTitle;

        public List<Courses> courseList = new List<Courses>();


        //Constructor teacher
        public Teacher()
            : base()
        {
            jobTitle = null;
        }

        //contructor teacher
        public Teacher(string jobTitle, string program, string core, string cgpa, string credit, string garduationDate, string admissionDate)
        {
            this.jobTitle = jobTitle;
        }

        public Teacher(string jobTitle)
        {
            this.jobTitle = jobTitle;

        }


        public void GetFacultyInfo(string getp, Teacher fc)
        {
            db = new DBConnection();
            string query = "Select * From Faculty_1400 Where Id='" + getp + "';";
            db.GetQuery(query);
            if (db.dr.HasRows)
            {
                while (db.dr.Read())
                {

                    fc.Id = db.dr.GetString(0);
                    fc.Name = db.dr.GetString(1);

                    fc.Dept = db.dr.GetString(2);



                    fc.PresentAddress = db.dr.GetString(3);
                    fc.PermanentAddress = db.dr.GetString(4);
                    fc.PhoneNo = (db.dr.GetString(12));
                    fc.Email = db.dr.GetString(5);
                    fc.DateOfBirth = db.dr.GetString(6);
                    fc.Sex = db.dr.GetString(7);
                    fc.Nationality = db.dr.GetString(8);
                    fc.Religion = db.dr.GetString(9);
                    fc.MaritalStatus = db.dr.GetString(10);
                    fc.Blood = db.dr.GetString(11);



                }
                db.dr.Dispose();

            }
            else
            {

                db.dr.Dispose();

            }
        }
        public override string GetPassword(string getp)
        {
            string sl = String.Empty;
            db = new DBConnection();
            string query = "Select * From Faculty_1400 Where Id='" + getp + "';";
            db.GetQuery(query);
            if (db.dr.HasRows)
            {
                while (db.dr.Read())
                {
                    sl = db.dr.GetString(13);

                }
                db.dr.Dispose();
                return sl;
            }
            else
            {
                sl = "error";
                db.dr.Dispose();
                return sl;
            }
        }


        public void getFacultySchedule(string getp)
        {
            db = new DatabaseLayer.DBConnection();
            string query = "SELECT CourseName FROM OfferedCourses_Spring_17 WHERE CourseTeacher='" + getp + "';";
            db.GetQuery(query);
            if (db.dr.HasRows)
            {
                while (db.dr.Read())
                {
                    if (db.dr[0].ToString() != null)
                    {
                        try
                        {
                            string sl = db.dr.GetString(0);
                            courseList.Add(new Courses(sl));
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
                db.dr.Dispose();
            }

            //}
            db.con.Dispose();
            this.GetCourseList("Spring_17");
        }

        public void GetCourseList(string s)
        {
            db = new DatabaseLayer.DBConnection();
            for (int i = 0; i < courseList.Count; i++)
            {
                string query = "SELECT * FROM OfferedCourses_" + s + " WHERE CourseName='" + courseList[i].courseName + "';";
                db.GetQuery(query);
                if (db.dr.HasRows)
                {
                    while (db.dr.Read())
                    {
                        courseList[i].SetValue(db.dr.GetString(0), db.dr.GetString(2),
 db.dr.GetString(3), db.dr.GetString(5), db.dr.GetString(5), db.dr.GetString(6));
                    }
                    db.dr.Dispose();
                }

            }
            db.con.Dispose();
        }



        public void getFacultyRegistration(string getp, string s)
        {
            db = new DatabaseLayer.DBConnection();
            string query = "SELECT CourseName FROM OfferedCourses_" + s + " WHERE CourseTeacher='" + getp + "';";
            db.GetQuery(query);
            if (db.dr.HasRows)
            {
                while (db.dr.Read())
                {
                    if (db.dr[0].ToString() != null)
                    {
                        try
                        {
                            string sl = db.dr.GetString(0);
                            courseList.Add(new Courses(sl));
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
                db.dr.Dispose();
            }

            //}
            db.con.Dispose();
            this.GetCourseList(s);
        }
    }






}
