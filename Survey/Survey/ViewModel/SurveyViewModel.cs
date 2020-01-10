using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModel
{
     class SurveyViewModel:INotifyPropertyChanged
    {
        //설문조사 기본정보
     
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
        private string Title;
        public string SurveyTitle
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
                NotifyPropertyChanged("SurveyTitle");
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
        private string Option;
        public string SurveyOption
        {
            get
            {
                return Option;
            }
            set
            {
                Option = value;
                NotifyPropertyChanged("SurveyOption");
            }
        }

        public List<string> SurveyOptionList
        {
            get
            {
                return new List<string> { "", "단답형", "장문형", "객관식1", "객관식2", "그리드" };
            }
        }

        public class Item
        {
            private string Name;
            public string ItemName
            {
                get
                {
                    return Name;
                }
                set
                {
                    Name = value;
                    NotifyPropertyChanged("ItemName");
                }
            }
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
