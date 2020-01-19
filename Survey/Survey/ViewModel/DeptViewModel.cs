using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModel
{
    class DeptViewModel : INotifyPropertyChanged
    {
        #region 기본 정보
        private string Code;
        public string DeptCode
        {
            get
            {
                return Code;
            }
            set
            {
                Code = value;
                NotifyPropertyChanged("DeptCode");
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
        private DateTime CreateAt = DateTime.Now;
        public DateTime DeptCreateAt
        {
            get
            {
                return CreateAt;
            }
            set
            {
                CreateAt = value;
                NotifyPropertyChanged("CreateAt");
            }
        }
        private string Division;
        public string DeptDivision
        {
            get
            {
                return Division;
            }
            set
            {
                Division = value;
                NotifyPropertyChanged("DeptDivision");
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
