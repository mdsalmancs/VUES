using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class Member
    {
        string name;
        string id;
        string dept;
        string fatherName;
        string motherName;
        string presentAddress;
        string permanentAddress;
        string phoneNo;
        string email;
        string dateOfBirth;
        string sex;
        string religion;
        string nationality;
        string maritalStatus;
        string blood;

        protected DBConnection db;

        public Member()
        {
            id = null;
            dept = null;
            fatherName = null;
            motherName = null;
            presentAddress = null;
            permanentAddress = null;
            phoneNo = null;
            email = null;
            dateOfBirth = null;
            sex = null;
            religion = null;
            nationality = null;
            maritalStatus = null;
            blood = null;
            name = null;

        }

        public Member(string name, string id, string dept, string fatherName, string motherName, string presentAddress, string permanentAddress, string phoneNo, string email, string dateOfBirth, string sex, string religion, string nationality, string maritalStatus, string blood)
        {
            this.name = name;
            this.id = id;
            this.dept = dept;
            this.fatherName = fatherName;
            this.motherName = motherName;
            this.presentAddress = presentAddress;
            this.permanentAddress = permanentAddress;
            this.phoneNo = phoneNo;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.sex = sex;
            this.religion = religion;
            this.nationality = nationality;
            this.maritalStatus = maritalStatus;
            this.blood = blood;

        }


        public string Id
        {
            set { this.id = value; }
            get { return this.id; }
        }


        public string Name
        {
            set { this.name = value; }
            get { return this.name; }
        }

        public string Dept
        {
            set { this.dept = value; }
            get { return this.dept; }
        }

        public string FatherName
        {
            set { this.fatherName = value; }
            get { return this.fatherName; }
        }

        public string MotherName
        {
            set { this.motherName = value; }
            get { return this.motherName; }
        }

        public string PresentAddress
        {
            set { this.presentAddress = value; }
            get { return this.presentAddress; }
        }

        public string PermanentAddress
        {
            set { this.permanentAddress = value; }
            get { return this.permanentAddress; }
        }

        public string PhoneNo
        {
            set { this.phoneNo = value; }
            get { return this.phoneNo; }
        }

        public string Email
        {
            set { this.email = value; }
            get { return this.email; }
        }

        public string DateOfBirth
        {
            set { this.dateOfBirth = value; }
            get { return this.dateOfBirth; }
        }

        public string Sex
        {
            set { this.sex = value; }
            get { return this.sex; }
        }

        public string Religion
        {
            set { this.religion = value; }
            get { return this.religion; }
        }

        public string Nationality
        {
            set { this.nationality = value; }
            get { return this.nationality; }
        }

        public string MaritalStatus
        {
            set { this.maritalStatus = value; }
            get { return this.maritalStatus; }
        }

        public string Blood
        {
            set { this.blood = value; }
            get { return this.blood; }
        }


        public virtual string GetPassword(string getp)
        {
            string sl = String.Empty;
            db = new DBConnection();
            string query = "Select * From Students_151 Where Id='" + getp + "';";
            db.GetQuery(query);
            if (db.dr.HasRows)
            {
                while (db.dr.Read())
                {
                    sl = db.dr.GetString(1);

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

        public void SearchLibrary(DataTable dt)
        {
            string query = "SELECT * FROM Search_Book";
            db = new DBConnection();
            db.GetQuery(query);
            db.dr.Dispose();
            db.dt.Fill(dt);
            db.dt.Dispose();
            db.dr.Dispose();
        }

        public void SearchLibraryButtonClick(DataTable dt, string q)
        {
            string query = "SELECT * FROM Search_Book where Title LIKE '%" + q + "%';";
            db = new DBConnection();
            db.GetQuery(query);
            db.dr.Dispose();
            db.dt.Fill(dt);
            db.dt.Dispose();
        }

        public void LibraryCurrentBorrow(DataTable dt, String q)
        {
            string query = "SELECT Title,Edition,BorrowedOn,ExpectedReturnedon FROM Borrow_Book where BorrowedBy= '" + q + "' AND ReturnedOn='-';";
            db = new DBConnection();
            db.GetQuery(query);
            db.dr.Dispose();
            db.dt.Fill(dt);
            db.dt.Dispose();
        }

        public void LibraryBorrowHistory(DataTable dt, String q)
        {
            string query = "SELECT Title,Edition,BorrowedOn,ExpectedReturnedon,ReturnedOn FROM Borrow_Book where BorrowedBy= '" + q + "'";
            db = new DBConnection();
            db.GetQuery(query);
            db.dr.Dispose();
            db.dt.Fill(dt);
            db.dt.Dispose();
        }

        public int LibraryFinancials(DataTable dt, String q)
        {
            int i = 0;
            string query = "SELECT Title,Edition,BorrowedOn,ExpectedReturnedon,ReturnedOn,Fine FROM Borrow_Book where BorrowedBy= '" + q + "'";
            db = new DBConnection();
            db.GetQuery(query);
            if (db.dr.HasRows)
            {
                while (db.dr.Read())
                {
                    i += Convert.ToInt32(db.dr.GetString(5));
                }
            }
            db.dr.Dispose();
            db.dt.Fill(dt);
            db.dt.Dispose();
            return i;
        }




    }
}
