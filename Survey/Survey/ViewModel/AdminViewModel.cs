using System;
using System.ComponentModel;
using System.Windows.Input;
using Survey;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Globalization;

namespace Survey.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
        {
        #region 생성자
        public AdminViewModel()
        {
            //Add커맨드 할당
            AddCommand = new Command.Command(ExecuteAdd, CanExecuteAdd);
        }
        #endregion 데이터 그리드 뷰 정보
        public class AdminList
        {
            public string AdminCode{ get; set; }
            public string AdminId { get; set; }
            public string AdminPassword{ get; set; }
            public string AdminName{ get; set; }
            public string AdminSGrade{ get; set; }
            public string AdminCreateAt { get; set; }
            public int GetAllSize()
            {
                return AdminCode.Length + AdminId.Length + AdminPassword.Length + AdminName.Length + AdminSGrade.Length + AdminCreateAt.Length;
            }
        }

        #region ICommand 제어
        public ICommand AddCommand { get; set; }
        //Add Command
        private void ExecuteAdd(object obj)
        {
            //리스트 정보
            AdminList adl = new AdminList();
            Console.WriteLine(adl);
            adl.AdminCode = "A";
            adl.AdminId =  AdminId;
            adl.AdminPassword = AdminPassword;
            adl.AdminName = AdminName;
            adl.AdminSGrade = AdminSGrade;

            AdminLists.Add(adl);
            AddEnabled = false;
            
        }
        private bool CanExecuteAdd(object args)
        {
            return true;
        }
        private Boolean _AddEnabled =false;
        public Boolean AddEnabled
        {
            get { return _AddEnabled; }
            set
            {
                _AddEnabled = value;
                NotifyPropertyChanged("AddEnabled");
            }
        }
        #endregion

        #region 데이터그리드 뷰
        private ObservableCollection<AdminList> _AdminLists = new ObservableCollection<AdminList>();
        public ObservableCollection<AdminList> AdminLists
        {
            get { return _AdminLists; }
            set { _AdminLists = value; NotifyPropertyChanged("AdminLists"); }
        }
        public void RemoveList (int Position)
        {
            Console.WriteLine(AdminLists.Count);
            AdminLists.RemoveAt(Position);
        }
        #endregion

        #region Admin 기본정보
        private string Id;
        public string AdminId
        {
            get {

                return Id;
            }
            set {
                if(value != null)
                {
                    Id = value;
                    NotifyPropertyChanged("AdminId");
                }
            }
        }

        private string Password;
        public string AdminPassword
        {
            get
            {

                return Password;
            }
            set
            {
                Password = value;
                NotifyPropertyChanged("AdminPassword");

            }
        }

        private string Name;
        public string AdminName
        {
            get
            {

                return Name;
            }
            set
            {
                Name = value;
                NotifyPropertyChanged("AdminName");

            }
        }

       
        private string SGrade;
        public string AdminSGrade
        {
            get
            {
                return SGrade;
            }
            set
            {
                SGrade = value;
                NotifyPropertyChanged("AdminSGrade");

            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;


        //이벤트 할당
        protected void NotifyPropertyChanged(string PropertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
       
    }
}
