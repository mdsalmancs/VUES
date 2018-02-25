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
using System.Threading;

namespace GUIFrame
{
    public partial class MainFrame : Form
    {
        System.Windows.Forms.Label Wrong = new System.Windows.Forms.Label();
        Thread t;
        Member mem;
        Student stu;
        Teacher fc;
        public MainFrame()
        {
            InitializeComponent();
        }

        public void InvisibleAll()
        {
            this.StudentStartPanel.Visible = false;
            this.Financialspanel.Visible = false;
            this.CourseAndResultsPanel.Visible = false;
            this.GradesByCurriculamPanel.Visible = false;
            this.MyCurriculumsPanel.Visible = false;
            this.LibrarySearchBookPanel.Visible = false;
            this.LibraryCurrentBorrowPanel.Visible = false;
            this.LibraryBorrowHistoryPanel.Visible = false;
            this.LibraryFinancialsPanel.Visible = false;
            this.MessegeMailBoxPanel.Visible = false;
            this.GradesBySemesterPanel.Visible = false;
            this.RegistrationPanel.Visible = false;
            this.OfferedPanel.Visible = false;
            this.ApplicationsPanel.Visible = false;
            this.AgreementsPanel.Visible = false;
            this.DownloadsPanel.Visible = false;
            this.StudentprofileScrollbarPanel.Visible = false;
            this.StudentOthersApplicationNewPanel.Visible = false;
            this.PasswordPanel.Visible = false;
            this.MessageMailBoxPanel2.Visible = false;
            this.PasswordPanel2.Visible = false;
            this.StudentCourseNotePanel.Visible = false;

            this.FacultyStartPanel.Visible = false;
            this.FacultyAcademicCoursesAndResultsPanel.Visible = false;
            this.FacultyLibrarySearchBookPanel.Visible = false;
            this.FacultyLibraryCurrentBorrowsPanel.Visible = false;
            this.FacultyLibraryBorrowHistoryPanel.Visible = false;
            this.FacultyProfileScrollbarPanel.Visible = false;
            this.FacultyEvaluationPanel.Visible = false;
            this.FacultyGivenNotesPanel.Visible = false;
            this.FacultyStudentListPanel.Visible = false;

            Wrong.Visible = false;




        }





        //
        //For username input
        //
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //
        //For password input
        //
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //
        //For login button click
        //
        private void button1_Click(object sender, EventArgs e)
        {
            Wrong.AutoSize = true;
            Wrong.Location = new System.Drawing.Point(566, 454);
            Wrong.Size = new System.Drawing.Size(30, 13);
            Wrong.Text = "*** Please check your Username or Id";
            Wrong.ForeColor = System.Drawing.Color.Red;
            Wrong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            if (txtUserName.Text[2] == '-')
            {

                string pass = String.Empty;
                stu = new Student();
                pass = stu.GetPassword(this.txtUserName.Text);


                if (this.txtPassword.Text == pass)
                {
                    this.LoginPanel.Hide();
                    this.InvisibleAll();
                    this.ReadyStudentHome();
                    this.StudentPanel.Show();
                    this.StudentStartPanel.Visible = true;
                    Wrong.Visible = false;
                    DataInfo();
                }

                else
                {
                    this.LoginPanel.Controls.Add(Wrong);
                    Wrong.Visible = true;
                }
            }

            else
            {
                string pass = String.Empty;
                fc = new Teacher();
                pass = fc.GetPassword(this.txtUserName.Text);
                if (this.txtPassword.Text == pass)
                {
                    this.LoginPanel.Hide();
                    this.InvisibleAll();
                    this.ReadyFacultyHome();
                    this.FacultyPanel.Show();
                    this.FacultyStartPanel.Visible = true;
                    Wrong.Visible = false;
                    FacultyProfileDataInfo();
                }



                else
                {
                    this.LoginPanel.Controls.Add(Wrong);
                    Wrong.Visible = true;
                }

            }
        }

        //
        //Cant access your account
        //
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        //
        //Courses and result button click from student home
        //

        private void StudentHomeCoursesAndResultsbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.CourseAndResultsPanel.Visible = true;

        }
        //
        //Financials button click from student home
        //
        private void StudentHomeFinancialsbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.Financialspanel.Visible = true;
        }

        //
        //Grades By Curriculam button click from student home
        //
        private void StudentHomeradesCurriculumbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.GradesByCurriculamPanel.Visible = true;
        }

        //
        //Grades by curriculam scrollbar click from student home
        //
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            GradeByCurtableLayoutPanel1.AutoScroll = false;
            GradeByCurtableLayoutPanel1.HorizontalScroll.Enabled = false;
            GradeByCurtableLayoutPanel1.HorizontalScroll.Visible = false;
            GradeByCurtableLayoutPanel1.HorizontalScroll.Maximum = 0;
            GradeByCurtableLayoutPanel1.AutoScroll = true;

        }
        //
        //Academic My Curriculam button click from student home
        //

        private void StudentHomeMyCurriculumsbutton_Click_1(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.MyCurriculumsPanel.Visible = true;
        }
        //
        //Academic Registration button click from student home
        //
        private void StudentHomeRegistrationbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.RegistrationPanel.Visible = true;
        }
        //
        //Grades by semester button click from student home
        //
        private void StudentHomeGradesSemesterbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.GradesBySemesterPanel.Visible = true;
        }
        //
        //Library search book button click from student home
        //
        private void StudentHomeSearchBokkbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.SearchBookStudent();
            this.LibrarySearchBookPanel.Visible = true;
        }
        //
        //Library Current Borrow button click from student home
        //
        private void StudentHomeCurrentBorrowsbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.CurrentBorrowsStudents();
            this.LibraryCurrentBorrowPanel.Visible = true;
        }

        //
        //Library Borrow History button click from student home
        //
        private void StudentHomeBorrowHistorybutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.BorrowHistoryStudents();
            this.LibraryBorrowHistoryPanel.Visible = true;
        }
        //
        //Library Financials Button Click from student home

        private void btnLibraryFinancials_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.LibraryFinancialsStudent();
            this.LibraryFinancialsPanel.Visible = true;
        }
        //
        //Logout Button click from Faculty home
        //
        private void StudentHomeOutbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.FacultyPanel.Visible = false;
            this.DisposeAll();
            this.LoginPanel.Visible = true;
        }
        //
        //Home Button click from Faculty home
        //
        private void StudentHomebutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            // this.StudentStartPanel.Visible = true;
            this.FacultyStartPanel.Visible = true;

        }
        //
        //Others offered  Button click from student home
        //
        private void StudentHomeOfferedbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.OfferedPanel.Visible = true;
        }
        //
        //Others Application  Button click from student home
        //
        private void StudentHomeApplicationbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.ApplicationsPanel.Visible = true;
        }
        //
        //Others Aggrement  Button click from student home
        //
        private void StudentHomeaggrementsbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.AgreementsPanel.Visible = true;
        }
        //
        //Others Download Button click from student home
        //
        private void StudentHomeDownloadbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.DownloadsPanel.Visible = true;
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            StudentprofileScrollbarPanel.AutoScroll = false;
            StudentprofileScrollbarPanel.HorizontalScroll.Enabled = false;
            StudentprofileScrollbarPanel.HorizontalScroll.Visible = false;
            StudentprofileScrollbarPanel.HorizontalScroll.Maximum = 0;
            StudentprofileScrollbarPanel.AutoScroll = true;
        }
        //
        //Others application New Button click from student home
        //
        private void btnNewApplicationsPanel_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.StudentOthersApplicationNewPanel.Visible = true;
        }
        //
        // Profile Button click from student home
        //
        private void StudentHomeProfilebutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.FacultyProfileScrollbarPanel.Visible = true;
        }
        //
        // Student Name Button click from student home
        //
        private void llblStudentHomeName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.InvisibleAll();
            this.StudentprofileScrollbarPanel.Visible = true;
        }
        //
        // Student Change password Button click from student home
        //
        private void StudentHomeOptioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.PasswordPanel.Visible = true;
        }

        //
        // Faculty Mid Term Button click from faculty Courses And Results

        //


        //
        // Faculty Final Term Button click from faculty Courses And Results

        //



        //
        // Faculty Courses And Results Button click from LeftMenu2
        //
        private void btnFacultyStartPanelCoursesAndResults_Click(object sender, EventArgs e)
        {

            this.InvisibleAll();
            this.FacultyAcademicCoursesAndResultsPanel.Visible = true;
        }
        //
        // Faculty Search Book Button click from LeftMenu2
        //

        private void btnFacultyStartPanelSearchBook_Click(object sender, EventArgs e)
        {

            this.InvisibleAll();
            this.FacultyLibrarySearchBookPanel.Visible = true;

        }
        //
        // Faculty Current Borrows Button click from LeftMenu2
        //

        private void btnFacultyStartPanelCurrentBorrows_Click(object sender, EventArgs e)
        {

            this.InvisibleAll();
            this.FacultyLibraryCurrentBorrowsPanel.Visible = true;

        }

        //
        // Faculty Borrow History Button click from LeftMenu2
        //
        private void btnFacultyStartPanelBorrowHistory_Click(object sender, EventArgs e)
        {

            this.InvisibleAll();
            this.FacultyLibraryBorrowHistoryPanel.Visible = true;

        }
        //
        // Faculty Mail Box Button click from LeftMenu2
        //

        private void btnFacultyStartPanelMailBox_Click(object sender, EventArgs e)
        {

            this.InvisibleAll();
            this.MessegeMailBoxPanel.Visible = true;

            try { t.Start(); }

            catch (Exception)
            { MessageBox.Show("Exception happend"); }


        }
        //
        // Faculty NAme Button click from FacultyStartPanel
        //
        private void linklblFacultyStartPanelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.InvisibleAll();
            this.FacultyProfileScrollbarPanel.Visible = true;
        }
        //
        // Home Button click from StudentStatic
        //
        private void btnHomeStudent_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.StudentStartPanel.Visible = true;
        }
        //
        // Profile Button click from StudentStatic
        //
        private void btnProfileStudent_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.StudentprofileScrollbarPanel.Visible = true;
        }
        //
        // Option Combo BOx click from StudentStatic
        //
        private void StudentoptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.PasswordPanel2.Visible = true;
        }
        //
        // Logout Button from StudentStatic
        //
        private void btnLogOutStudent_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.StudentPanel.Visible = false;
            this.LoginPanel.Visible = true;
            this.DisposeAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.FacultyAcademicCoursesAndResultsPanel.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.FacultyAcademicCoursesAndResultsPanel.Visible = true;
        }
        //
        //faculty home combobox method
        //
        private void comboBoxFacultyStartPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            fc.courseList.Clear();
            this.DisposeAll2();
            this.FacultyRegistrationReady();
        }

        private void btnFacultyCoursesAndResultsGradeEvaluation_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.FacultyEvaluationPanel.Visible = true;
        }

        private void FacultyEvaluationButtonBack_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.FacultyAcademicCoursesAndResultsPanel.Visible = true;
        }

        //
        // Faculty UploadButton click from FacultyGivenNotePanel
        //

        private void btnFacultyUpload_Click(object sender, EventArgs e)
        {

        }





        private void btnlblFacultyStudentListBack_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.FacultyGivenNotesPanel.Visible = true;
        }

        //
        // Faculty Student List Button click from FacultyGivenNotesPanel
        //

        private void btnFacultyStudentList_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.FacultyStudentListPanel.Visible = true;
        }
        //
        // Library search Button for student
        //
        private void LibrarySearchButtonStu_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            stu.SearchLibraryButtonClick(dt, txtboxSearchBookText.Text);
            this.LibrarySearchDataGridStu.DataSource = dt;
        }

        //
        // student home combo box
        //

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.DisposeAll2();
            this.StudentRegistrationReady();
        }

        private void StudentHomeMailBoxbutton_Click(object sender, EventArgs e)
        {
            this.InvisibleAll();
            this.MessageMailBoxPanel2.Visible = true;

            try { t.Start(); }

            catch (Exception)
            { MessageBox.Show("Exception happend"); }

        }


        private void LoadMail()
        {
            Application.Run(new OutlookMail.Form1());
        }























    }
}
