using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Courses
    {
        public string courseId;
        public string courseName;
        public string timing1;
        public string timing2;
        public string roomNo1;
        public string roomNo2;
        public string courseTeacher;

        public Courses()
        {
        }


        public Courses(string cn)
        {
            this.courseName = cn;
        }

        public void SetValue(string ci, string t1, string t2, string rn1, string rn2, string ct)
        {
            this.courseId = ci;
            this.courseTeacher = ct;
            this.timing1 = t1;
            this.timing2 = t2;
            this.roomNo1 = rn1;
            this.roomNo2 = rn2;
        }
    }
}
