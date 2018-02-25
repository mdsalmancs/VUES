using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Student : Member         //inherited by Member
    {
        string program;
        string core;
        string cgpa;
        string credit;
        string admissionDate;
        string major;
        string minor;
        string elective;
        string secondMajor;
        string graduationDate;

        public List<Courses> courseList = new List<Courses>();
        public List<string> hList = new List<string>();


        //constructor
        public Student()
            : base()
        {
            program = null;
            core = null;
            cgpa = null;
            credit = null;
            admissionDate = null;
            this.graduationDate = null;

        }


        public Student(string program, string core, string cgpa, string credit, string garduationDate, string admissionDate)
        {
            this.program = program;
            this.core = core;
            this.cgpa = cgpa;
            this.credit = credit;
            this.graduationDate = garduationDate;
            this.admissionDate = admissionDate;
        }

        public string Program
        {
            set { this.program = value; }
            get { return this.program; }
        }

        public string Minor
        {
            set { this.minor = value; }
            get { return this.minor; }
        }

        public string Major
        {
            set { this.major = value; }
            get { return this.major; }
        }

        public string Core
        {
            set { this.core = value; }
            get { return this.core; }
        }

        public string Elective
        {
            set { this.elective = value; }
            get { return this.elective; }
        }

        public string Cgpa
        {
            set { this.cgpa = value; }
            get { return this.cgpa; }
        }

        public string Credit
        {
            set { this.credit = value; }
            get { return this.credit; }
        }



        public string SecondMajor
        {
            set { this.secondMajor = value; }
            get { return this.secondMajor; }
        }

        public string GraduationDate
        {
            set { this.graduationDate = value; }
            get { return this.graduationDate; }
        }

        public string AdmissionDate
        {
            set { this.admissionDate = value; }
            get { return this.admissionDate; }
        }





        public void getStudentSchedule(string getp)
        {
            db = new DatabaseLayer.DBConnection();
            for (int i = 1; i < 8; i++)
            {
                string query = "SELECT Subject" + i.ToString() + " FROM Registration_151_Spring_17 WHERE Id='" + getp + "';";
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

            }
            db.con.Dispose();
            this.GetCourseList();
        }

        public void GetCourseList()
        {
            db = new DatabaseLayer.DBConnection();
            for (int i = 0; i < courseList.Count; i++)
            {
                string query = "SELECT * FROM OfferedCourses_Spring_17 WHERE CourseName='" + courseList[i].courseName + "';";
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


        public void GetStudentInfo(string getp, Student stu)
        {
            db = new DatabaseLayer.DBConnection();
            string query = "Select * From Students_151 Where Id='" + getp + "';";
            db.GetQuery(query);
            if (db.dr.HasRows)
            {
                while (db.dr.Read())
                {

                    stu.Id = db.dr.GetString(0);
                    stu.Name = db.dr.GetString(2);
                    stu.Cgpa = Convert.ToString(db.dr.GetDouble(3));
                    stu.Credit = Convert.ToString(db.dr.GetInt32(4));
                    stu.Program = db.dr.GetString(5);
                    stu.Dept = db.dr.GetString(6);
                    stu.Core = db.dr.GetString(7);
                    if (db.dr[8].ToString() != null)
                    {
                        try
                        {
                            stu.Major = db.dr.GetString(8);


                            stu.SecondMajor = db.dr.GetString(9);
                            stu.Minor = db.dr.GetString(10);
                        }
                        catch (Exception ex)
                        {
                            stu.Major = "-";
                            stu.SecondMajor = "-";
                            stu.Minor = "-";
                        }
                    }
                    stu.Elective = db.dr.GetString(11);
                    stu.FatherName = db.dr.GetString(12);
                    stu.MotherName = db.dr.GetString(13);
                    stu.PresentAddress = db.dr.GetString(14);
                    stu.PermanentAddress = db.dr.GetString(15);
                    stu.PhoneNo = (db.dr.GetString(16));
                    stu.Email = db.dr.GetString(17);
                    stu.DateOfBirth = db.dr.GetString(18);
                    stu.Sex = db.dr.GetString(19);
                    stu.Nationality = db.dr.GetString(20);
                    stu.Religion = db.dr.GetString(21);
                    stu.MaritalStatus = db.dr.GetString(22);
                    stu.Blood = db.dr.GetString(23);
                    stu.AdmissionDate = db.dr.GetString(24);
                    stu.GraduationDate = db.dr.GetString(25);


                }
                db.dr.Dispose();

            }
            else
            {

                db.dr.Dispose();

            }
        }

        public void getStudentRegistration(string getp, string s)
        {
            db = new DatabaseLayer.DBConnection();
            for (int i = 1; i < 8; i++)
            {
                string query = "SELECT Subject" + i.ToString() + " FROM Registration_151_" + s + " WHERE Id='" + getp + "';";
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

                            }
                        }
                    }
                    db.dr.Dispose();
                }

            }
            db.con.Dispose();
            this.GetCourseList();
        }


        public void GetNotes(string s)
        {
            db = new DatabaseLayer.DBConnection();
            string query = "SELECT * FROM File_Spring_17 WHERE CourseID=(SELECT CourseID FROM OfferedCourses_Spring_17 Where CourseName='" + s + "');";
            db.GetQuery(query);
            int i = 0;
            DataTable t=new DataTable();
            db.dr.Dispose();
            db.dt.Fill(t);
            i = t.Columns.Count;

            for (int j = 1; j <= i; j++)
            {
                string query1 = "Select Note" + j.ToString() + " From File_Spring_17 Where CourseID=(Select CourseID From OfferedCourses_Spring_17 Where CourseName='" + s + "');";
                db = new DatabaseLayer.DBConnection();
                db.GetQuery(query1);
                db.dr.Dispose();
                db.dt.Fill(t);
                for (int a = 0; a < t.Columns.Count; a++)
                {
                    string sl = t.Columns[a].ToString();
                    hList.Add(sl);
                }
                db.dr.Dispose();
                db.dt.Dispose();
            }
        }


  
              




    }





}
