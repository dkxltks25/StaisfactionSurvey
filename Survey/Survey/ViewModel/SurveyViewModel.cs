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
        #region  설문조사 기본정보
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
                Console.WriteLine("-------테스트" + value);
                Option = value;
                NotifyPropertyChanged("SurveyOption");
            }
        }
       private string Number;
        public string OptionNumber
        {
            
            get
            {
                switch (SurveyOption)
                {
                    case "단답형":
                        return "0";
                    case "장문형":
                        return "1";
                    case "객관식1":
                        return "2";
                    case "객관식2":
                        return "3";
                    case "그리드":
                        return "4";
                    default:
                        return "E";
                }

            }
        }
        public List<string> SurveyOptionList
        {
            get
            {
                return new List<string> { "", "단답형", "장문형", "객관식1", "객관식2", "그리드" };
            }
        }
        private BindingList<Item> MyItem =  new BindingList<Item>();
        public BindingList<Item> SurveyItem
        {
            get
            {
                try
                {
                   return MyItem;
                   
                }
                catch(Exception err)
                {
                    return MyItem = new BindingList<Item>();
                }
                
            }
            
        }
        public class Item
        {
            private string Code;
            public string SurveyInputCode
            {
                get
                {
                    return Code;
                }
                set
                {
                    Code = value;
                    NotifyPropertyChanged("SurveyInputCode");
                }
            }
        

            private string item;
            public string SurveyItem
            {
                get
                {
                    return item;
                }
                set
                {
                    item = value;
                    NotifyPropertyChanged("SurveyItem");
                }
            }
            private string Row;
            public string SurveyRow
            {
                get
                {
                    return Row;
                }
                set
                {
                    Row = value;
                    NotifyPropertyChanged("SurveyRow");
                }
            }
            private string Column;
            public string SurveyColumn
            {
                get
                {
                    return Column;
                }
                set
                {
                    Column = value;
                    NotifyPropertyChanged("SurveyColumn");
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
