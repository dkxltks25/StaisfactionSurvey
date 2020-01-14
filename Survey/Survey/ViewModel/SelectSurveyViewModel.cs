using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModel
{
    public class SelectSurveyViewModel : INotifyPropertyChanged
    {
        #region 기본정보

        private string Code;
        public string SurveyCode
        {
            get
            {
                return Code;
            }
            set
            {
                Code = value;
                NotifyPropertyChanged("SurveyCode");
            }
        }
        private string Id;
        public string SurveyId
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
                NotifyPropertyChanged("SurveyId");
            }
        }
        private string Name;
        public string SurveyName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
                NotifyPropertyChanged("SurveyName");
            }
        }
        private string Descrip;
        public string SurveyDescrip
        {
            get
            {
                return Descrip;
            }
            set
            {
                Descrip = value;
                NotifyPropertyChanged("SurveyDescrip");
            }
        }

        private DateTime startTime = DateTime.Now;
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
                NotifyPropertyChanged("StartTime");
            }
        }
        private DateTime finishTime = DateTime.Now;
        public DateTime FinishTime
        {
            get
            {
                return finishTime;
            }
            set
            {
                finishTime = value;
                NotifyPropertyChanged("FinishTime");
            }
        }
        private string Division;
        public string SurveyDivision
        {
            get
            {
                return Division;
            }
            set
            {
                Division = value;
                NotifyPropertyChanged("SurveyDivision");
            }
        }
        #endregion
        private BindingList<Dept> lDG = new BindingList<Dept>();
        public BindingList<Dept> LDG
        {
            get
            {
                return lDG;
            }
        }
        private BindingList<Dept> rDG = new BindingList<Dept>();
        public BindingList<Dept> RDG
        {
            get
            {
                return rDG;
            }
        }
        public class Dept
        {
            private string code;
            public string DeptCode
            {
                get
                {
                    return code;
                }
                set
                {
                    code = value;
                    NotifyPropertyChanged("DeptCode");
                }
            }
            private string Name;
            public string DeptName
            {
                get
                {
                    return Name;
                }
                set
                {
                    Name = value;
                    NotifyPropertyChanged("DeptName");
                }
            }
            private string Id;
            public string DeptId
            {
                get
                {
                    return Id;
                }
                set
                {
                    Id = value;
                    NotifyPropertyChanged("DeptId");
                }
            }
            private string Dvision;
            public string DeptDvision
            {
                get
                {
                    return Dvision;
                }
                set
                {
                    Dvision = value;
                    NotifyPropertyChanged("DeptDvision");
                }
            }
            #region 프로퍼티 이벤트 등록
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


        #region 프로퍼티 이벤트 등록
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
