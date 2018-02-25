using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
namespace GUIFrame
{
    public partial class MainFrame
    {

        List<Label> listlbl = new List<Label>();
        List<Label> listlbl2 = new List<Label>();
        List<LinkLabel> listllbl = new List<LinkLabel>();
        List<LinkLabel> listllbl2 = new List<LinkLabel>();
        //For the home
        public void ReadyStudentHome()
        {
            stu.getStudentSchedule(this.txtUserName.Text);
            DateTime datevalue = DateTime.Today;
            for (int i = 0; i < 3; i++)
            {
                datevalue = datevalue.AddDays(i);
                string today = datevalue.ToString("ddd");
                Label newlabel2 = new Label();
                newlabel2.AutoSize = true;
                newlabel2.Text = String.Format(today + ":");
                newlabel2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.HomeScheduleFlpanel.Controls.Add(newlabel2);
                this.listlbl.Add(newlabel2);
                bool chk = false;
                foreach (Courses c in stu.courseList)
                {
                    if (c.timing1[0] == today[0])
                    {
                        LinkLabel newlabel = new LinkLabel();
                        newlabel.Text = String.Format(c.courseName);
                        newlabel.Click += (s, p) =>
                        {
                            this.InvisibleAll();
                            this.StudentCourseNotePanel.Visible = true;
                            this.StudentNotesflowLayoutPanel3.Visible = true;
                            this.stu.GetNotes(c.courseName);
                            //foreach (string q in stu.hList)
                            //{
                                LinkLabel newlabel3 = new LinkLabel();
                                newlabel3.Click += (j, k) => { };
                                newlabel3.Name = "q";
                                newlabel3.TabStop = true;
                                newlabel3.AutoSize = true;
                                newlabel3.Visible = true;
                                newlabel3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                newlabel3.Text = "q";
                                this.StudentNotesflowLayoutPanel3.Controls.Add(newlabel3);
                            //}
                        };
                        newlabel.Name = "\n" + c.timing1;
                        newlabel.TabStop = true;
                        newlabel.AutoSize = true;
                        newlabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Label newlabelnew = new Label();
                        newlabelnew.AutoSize = true;
                        newlabelnew.Text = String.Format(c.timing1 + " Room N0:" + c.roomNo1 + "\n");
                        this.HomeScheduleFlpanel.Controls.Add(newlabel);
                        this.HomeScheduleFlpanel.Controls.Add(newlabelnew);
                        this.listlbl.Add(newlabelnew);
                        this.listllbl.Add(newlabel);
                    }
                    else if (c.timing2[0] == today[0])
                    {
                        LinkLabel newlabel = new LinkLabel();
                        newlabel.Click += (s, p) =>
                        {
                            this.InvisibleAll();
                            this.StudentCourseNotePanel.Visible = true;
                        };
                        newlabel.Name = "/n" + c.timing1;
                        newlabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        newlabel.Text = String.Format(c.courseName);
                        Label newlabelnew = new Label();
                        newlabelnew.AutoSize = true;
                        newlabelnew.Text = String.Format(c.timing2 + " Room N0:" + c.roomNo2 + "\n");
                        this.HomeScheduleFlpanel.Controls.Add(newlabel);
                        this.HomeScheduleFlpanel.Controls.Add(newlabelnew);
                        this.listlbl.Add(newlabelnew);
                        this.listllbl.Add(newlabel);
                    }
                    else
                    {
                    }
                }
                if (chk)
                {
                    Label newlabel = new Label();
                    newlabel.Name = "timing1";
                    newlabel.Text = "No class Today";
                    this.HomeScheduleFlpanel.Controls.Add(newlabel);
                }
            }
            this.StudentRegistrationReady();

        }

        public void StudentRegistrationReady()
        {
            stu.courseList.Clear();
            stu.getStudentRegistration(txtUserName.Text, comboBox1.Text);
            foreach (Courses c in stu.courseList)
            {

                LinkLabel newlabel = new LinkLabel();
                newlabel.Click += (s, p) =>
                {
                    this.InvisibleAll();
                    this.StudentCourseNotePanel.Visible = true;
                };
                newlabel.Name = "\n" + c.timing1;
                newlabel.TabStop = true;
                newlabel.AutoSize = true;
                newlabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newlabel.Text = String.Format(c.courseName);
                Label newlabelnew = new Label();
                newlabelnew.AutoSize = true;
                newlabelnew.Text = String.Format(c.timing1 + " Room N0:" + c.roomNo1 + "\n");
                this.HomeRegistrationFlpanel.Controls.Add(newlabel);
                this.HomeRegistrationFlpanel.Controls.Add(newlabelnew);
                this.listlbl2.Add(newlabelnew);
                this.listllbl2.Add(newlabel);
            }

        }



        public void DataInfo()
        {
            string s = txtUserName.Text;
            stu.GetStudentInfo(s, stu);
            this.llblStudentHomeName.Text = stu.Name;
            this.name.Text = stu.Name;
            this.id.Text = stu.Id;
            this.cgpa.Text = stu.Cgpa;
            this.credit.Text = stu.Credit;
            this.program.Text = stu.Program;
            this.dept.Text = stu.Dept;
            this.core.Text = stu.Core;
            this.major.Text = stu.Major;
            this.secmajor.Text = stu.SecondMajor;
            this.minor.Text = stu.Minor;
            this.elective.Text = stu.Elective;
            this.fathername.Text = stu.FatherName;
            this.mothername.Text = stu.MotherName;
            this.present.Text = stu.PresentAddress;
            this.permanent.Text = stu.PermanentAddress;
            this.phone.Text = stu.PhoneNo;
            this.email.Text = stu.Email;
            this.dob.Text = stu.DateOfBirth;
            this.sex.Text = stu.Sex;
            this.nationality.Text = stu.Nationality;
            this.rel.Text = stu.Religion;
            this.maritalstatus.Text = stu.MaritalStatus;
            this.blood.Text = stu.Blood;
            this.admission.Text = stu.AdmissionDate;
            this.graduation.Text = stu.GraduationDate;

        }



        public void ReadyFacultyHome()
        {
            fc.getFacultySchedule(this.txtUserName.Text);
            DateTime datevalue = DateTime.Today;
            for (int i = 0; i < 3; i++)
            {
                datevalue = datevalue.AddDays(i);
                string today = datevalue.ToString("ddd");
                Label newlabel2 = new Label();
                newlabel2.AutoSize = true;
                newlabel2.Text = String.Format(today + ":");
                newlabel2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.facultyHomeFlpanelRoutine.Controls.Add(newlabel2);
                bool chk = false;
                this.listlbl.Add(newlabel2);
                foreach (Courses c in fc.courseList)
                {
                    if (c.timing1[0] == today[0])
                    {
                        LinkLabel newlabel = new LinkLabel();
                        newlabel.Click += (s, p) =>
                        {
                            this.InvisibleAll();
                            this.FacultyGivenNotesPanel.Visible = true;
                        };
                        newlabel.Name = "\n" + c.timing1;
                        newlabel.TabStop = true;
                        newlabel.AutoSize = true;
                        newlabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        newlabel.Text = String.Format(c.courseName);
                        Label newlabelnew = new Label();
                        newlabelnew.AutoSize = true;
                        newlabelnew.Text = String.Format(c.timing1 + " Room N0:" + c.roomNo1 + "\n");
                        this.facultyHomeFlpanelRoutine.Controls.Add(newlabel);
                        this.facultyHomeFlpanelRoutine.Controls.Add(newlabelnew);
                        this.listlbl.Add(newlabelnew);
                        this.listllbl.Add(newlabel);
                    }
                    else if (c.timing2[0] == today[0])
                    {
                        LinkLabel newlabel = new LinkLabel();
                        newlabel.Click += (s, p) =>
                        {
                            this.InvisibleAll();
                            this.FacultyGivenNotesPanel.Visible = true;
                        };
                        newlabel.Name = "/n" + c.timing1;
                        newlabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        newlabel.Text = String.Format(c.courseName);
                        Label newlabelnew = new Label();
                        newlabelnew.AutoSize = true;
                        newlabelnew.Text = String.Format(c.timing2 + " Room N0:" + c.roomNo2 + "\n");
                        this.facultyHomeFlpanelRoutine.Controls.Add(newlabel);
                        this.facultyHomeFlpanelRoutine.Controls.Add(newlabelnew);
                        this.listlbl.Add(newlabelnew);
                        this.listllbl.Add(newlabel);
                    }
                    else
                    {
                    }
                }
                if (chk)
                {
                    Label newlabel = new Label();
                    newlabel.Name = "timing1";
                    newlabel.Text = "No class Today";
                    this.facultyHomeFlpanelRoutine.Controls.Add(newlabel);
                }
            }
            this.FacultyRegistrationReady();

        }

        public void FacultyRegistrationReady()
        {
            fc.courseList.Clear();
            fc.getFacultyRegistration(txtUserName.Text, comboBoxFacultyStartPanel.Text);
            if (fc.courseList.Count != 0)
            {
                foreach (Courses c in fc.courseList)
                {

                    LinkLabel newlabel = new LinkLabel();
                    newlabel.Click += (s, p) =>
                    {
                        this.InvisibleAll();
                        this.FacultyGivenNotesPanel.Visible = true;
                    };
                    newlabel.Name = "\n" + c.timing1;
                    newlabel.TabStop = true;
                    newlabel.AutoSize = true;
                    newlabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newlabel.Text = String.Format(c.courseName);
                    Label newlabelnew = new Label();
                    newlabelnew.AutoSize = true;
                    newlabelnew.Text = String.Format(c.timing1 + " Room N0:" + c.roomNo1 + "\n");
                    this.facultyHomeFlpanelList.Controls.Add(newlabel);
                    this.facultyHomeFlpanelList.Controls.Add(newlabelnew);
                    this.listlbl2.Add(newlabelnew);
                    this.listllbl2.Add(newlabel);

                }
            }

        }


        public void FacultyProfileDataInfo()
        {
            string s = txtUserName.Text;
            fc.GetFacultyInfo(s, fc);
            this.linklblFacultyStartPanelName.Text = fc.Name;
            this.fname.Text = fc.Name;
            this.fid.Text = fc.Id;
            this.fdept.Text = fc.Dept;
            this.fpresent.Text = fc.PresentAddress;
            this.fpermanent.Text = fc.PermanentAddress;
            this.fphone.Text = fc.PhoneNo;
            this.femail.Text = fc.Email;
            this.fdob.Text = fc.DateOfBirth;
            this.fsex.Text = fc.Sex;
            this.fnationality.Text = fc.Nationality;
            this.frel.Text = fc.Religion;
            this.fmaritalstatus.Text = fc.MaritalStatus;
            this.fblood.Text = fc.Blood;
        }


        public void SearchBookStudent()
        {

            txtboxSearchBookText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtboxSearchBookText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            DataTable dt = new DataTable();
            stu.SearchLibrary(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Title"].ToString();
                coll.Add(name);
            }

            txtboxSearchBookText.AutoCompleteCustomSource = coll;
        }

        public void CurrentBorrowsStudents()
        {
            DataTable dt = new DataTable();
            stu.LibraryCurrentBorrow(dt, txtUserName.Text);
            this.LibraryCurrentBorrowsDataGridStu.DataSource = dt;
        }

        public void BorrowHistoryStudents()
        {
            DataTable dt = new DataTable();
            stu.LibraryBorrowHistory(dt, txtUserName.Text);
            this.BorrowHistoryDataGridStu.DataSource = dt;
        }

        public void LibraryFinancialsStudent()
        {
            DataTable dt = new DataTable();
            int i = stu.LibraryFinancials(dt, txtUserName.Text);
            this.txtboxFinancialsCTatalFine.Text = i.ToString();
            this.txtboxFinancialsCLeft.Text = (50 - i).ToString();
            this.LibraryFinacialsDataGridStu.DataSource = dt;
        }

        public void SearchBookFaculty()
        {
            txtboxFacultyLibrarySearchBook.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtboxFacultyLibrarySearchBook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            DataTable dt = new DataTable();
            stu.SearchLibrary(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Title"].ToString();
                coll.Add(name);
            }

            txtboxFacultyLibrarySearchBook.AutoCompleteCustomSource = coll;
        }

        public void DisposeAll()
        {
            foreach (Label l in listlbl)
            {
                l.Dispose();
            }

            foreach (LinkLabel l in listllbl)
            {
                l.Dispose();
            }
        }

        public void DisposeAll2()
        {
            foreach (Label l in listlbl2)
            {
                l.Dispose();
            }

            foreach (LinkLabel l in listllbl2)
            {
                l.Dispose();
            }
        }

        public static void ShowError(string s)
        {
            MessageBox.Show("file Could not be transfered");
        }
    }
}
