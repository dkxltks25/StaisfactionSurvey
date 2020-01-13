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
        private string startTime;
        public string StartTime
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
        private string finishTime;
        public string FinishTime
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
        #endregion

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
