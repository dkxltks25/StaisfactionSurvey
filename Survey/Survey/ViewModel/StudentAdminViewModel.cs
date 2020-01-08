using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModel
{
    /// <summary>
    /// StudentAdmin의 뷰 보델 페이지 입니다.
    /// </summary>
    public class StudentAdminViewModel :INotifyPropertyChanged
    {


        #region 기본정보
        private string studentCode;
        ManageSql Sql = new ManageSql();
        public string StudentCode
        {
            get { return studentCode; }
            set { studentCode = value; NotifyPropertyChanged("StudentCode"); }
        }
        private string studentDivision;
        public string StudentDivision
        {
            get { return studentDivision; }
            set { studentDivision = value; NotifyPropertyChanged("StudentDivision"); }
        }
        private string studentNumber;
        public string StudentNumber
        {
            get
            {
                return studentNumber;
            }
            set
            {
                studentNumber = value;
                NotifyPropertyChanged("SutdnetNumber");
            }
        }
        //앞자리
        private string studentResNumber1;
        public string StudentResNumber1
        {
            get
            {
                return studentResNumber1;
            }
            set
            {
                studentResNumber1 = value;
                NotifyPropertyChanged("StudentResNumber1");
            }
        }
        //뒷자리
        private string studentResNumber2;
        public string StudentResNumber2
        {
            get
            {
                return studentResNumber2;
            }
            set
            {
                studentResNumber2 = value;
                NotifyPropertyChanged("StudentResNumber2");
            }
        }
        private string studentResNumber;
        public string StudentResNumber
        {
            get { return StudentResNumber1 + StudentResNumber2; }
            
        }
        private string studentName;
        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                studentName = value;
                NotifyPropertyChanged("StudentName");

            }
        }
        private string studentSex;
        public string StudentSex
        {
            get
            {
                return studentSex;
            }
            set
            {
                studentSex = value;
                NotifyPropertyChanged("StudentSex");
            }
        }
        private string studentDept;
        public string StudentDept
        {
            get
            {
                return studentDept;
            }
            set
            {
                studentDept = value;
                NotifyPropertyChanged("StudentDept");
            }
        }
        private string studentPhone;
        public string StudentPhone
        {
            get
            {
                return studentPhone;
            }
            set
            {
                studentPhone = value;
                NotifyPropertyChanged("StudentPhone");
            }
        }
        private string studentEmail;
        public string StudentEmail
        {
            get
            {
                return studentEmail;
            }
            set
            {
                studentEmail = value;
                NotifyPropertyChanged("StudentEmail");
            }
        }
        private string studentPassword;
        public string StudentPassword
        {
            get
            {
                return studentPassword;
            }
            set
            {
                studentPassword = value;
                NotifyPropertyChanged("StudentPassword");
            }
        }
      
        public List<string> DeptList
        {
            get
            {
                return Sql.SelectDeptNameList();
            }
        }
        public List<string> SexList
        {
            get
            {
                return new List<string> { "M", "F" };
            }
        }
        #endregion

        #region property 변경 체크
        public event PropertyChangedEventHandler PropertyChanged;
        //이벤트 할당
        protected void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion
    }
}
