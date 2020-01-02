using System;
using System.ComponentModel;
using System.Windows.Input;
using Survey;
using System.Windows;
using System.Collections.ObjectModel;

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
        #endregion
        public class AdminList
        {
            public string AdminCode{ get; set; }
            public string AdminId{ get; set; }
            public string AdminPassword{ get; set; }
            public string AdminName{ get; set; }
            public string AdminGrade{ get; set; }
            public string AdminCreateAt { get; set; }
        }

        #region ICommand 제어
        public ICommand AddCommand { get; set; }
        //Add Command
        private void ExecuteAdd(object obj)
        {
            AdminList adl = new AdminList();
            Console.WriteLine(adl);
            adl.AdminCode = "A";
            adl.AdminId =  AdminId;
            adl.AdminPassword = AdminPassword;
            adl.AdminName = AdminName;
            adl.AdminGrade = AdminGrade;
            AdminLists.Add(adl);
            AdminLists = AdminLists;
            Console.WriteLine(adl);

            /*
            if (!string.IsNullOrEmpty(AdminId) || !string.IsNullOrEmpty(AdminPassword) || !string.IsNullOrEmpty(AdminMail) || !string.IsNullOrEmpty(AdminGrade))
            {
               
            }*/

            Console.WriteLine(AdminId.Length);
            Console.WriteLine(AdminPassword);
            Console.WriteLine(AdminGrade);
            
        }
        private bool CanExecuteAdd(object args)
        {
            return true;
        }
        #endregion

        #region 데이터그리드 뷰
        private ObservableCollection<AdminList> _AdminLists = new ObservableCollection<AdminList>();
        public ObservableCollection<AdminList> AdminLists
        {
            get { return _AdminLists; }
            set { _AdminLists = value; NotifyPropertyChanged("AdminLists"); }
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

        private string Grade;
        public string AdminGrade
        {
            get
            {

                return Grade;
            }
            set
            {
                Grade = value;
                NotifyPropertyChanged("AdminGrade");

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
