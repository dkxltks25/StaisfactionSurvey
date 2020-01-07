using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sql = Survey.ManageSql;
using Survey.ViewModel;
using static Survey.ViewModel.AdminViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace Survey
{
    /// <summary>
    /// AdminManagementPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdminManagementPage : Window
    {
        /// <summary>
        /// BtnState 
        /// 0 입력
        /// 1 수정
        /// 
        /// </summary>
        private int BtnState = 0;

        //바인딩 리스트 정의
        BindingList<AdminViewModel> myViewModel;
        string[] TempList = new string[5];
        Sql sql;

        //***************************************************
        //생성자
        //***************************************************

        public AdminManagementPage()
        {
            InitializeComponent();
            myViewModel = new BindingList<AdminViewModel>();
            DG1.ItemsSource = myViewModel;
            AdminInfo.DataContext = new AdminViewModel();
            DefaultButtonState();

            //DB연결
            sql = new Sql();
            
        }

        //***************************************************
        //데이터 그리드 뷰 내의 데이터 임시 체크
        //***************************************************
        private void SetTempViewModelList()
        {

            TempList[0] = myViewModel[DG1.SelectedIndex].AdminId;
            TempList[1] = myViewModel[DG1.SelectedIndex].AdminName;
            TempList[2] = myViewModel[DG1.SelectedIndex].AdminPassword;
            TempList[3] = myViewModel[DG1.SelectedIndex].AdminSGrade;

            Console.WriteLine(myViewModel[DG1.SelectedIndex].AdminCode);
            Console.WriteLine(myViewModel[DG1.SelectedIndex].AdminId);
            Console.WriteLine(myViewModel[DG1.SelectedIndex].AdminPassword);
            Console.WriteLine(myViewModel[DG1.SelectedIndex].AdminSGrade);
            Console.WriteLine("*****************************************");
            Console.WriteLine(TempList[0]);
            Console.WriteLine(TempList[1]);
        }

        //***************************************************
        //normal
        //***************************************************

        private void DefaultButtonState()
        {
            InfoButton.IsEnabled = true;
            AddButton.IsEnabled = true;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            CheckButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
        }
        //***************************************************
        //Add, update ,Cancel을 누르기 전
        //***************************************************

        private void DataChangeButtonState()
        {
            InfoButton.IsEnabled = true;
            AddButton.IsEnabled = false;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            CheckButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
            
        }
       
        #region 입력 창 reset
        private void reset()
        {
            adminId.Text = "";
            adminPassword.Text = "";
            adminName.Text = "";

        }
        #endregion
        //***************************************************
        //데이터 클리어 후
        //***************************************************

        private void UpdateAndDeleteButtonState()
        {
            InfoButton.IsEnabled = true;
            AddButton.IsEnabled = false;
            UpdateButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
            CheckButton.IsEnabled = false;
            CancelButton.IsEnabled = true;
        }
        //***************************************************
        //info 버튼
        //***************************************************
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //***************************************************
        //Select 버튼
        //***************************************************
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            sql.SelectAdmin(myViewModel);
        }
        //***************************************************
        //Add 버튼
        //***************************************************
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("***************입력*********************");
            BtnState = 0;
            reset();
            DataChangeButtonState();
            //Sql sql = new Sql();
            //Console.WriteLine(sql.SHA512("dkxltks25"));
        }


        //***************************************************
        //Update 버튼 클릭
        //***************************************************
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AdminInfo.IsEnabled = true;
            Console.WriteLine("***************수정*********************");

            BtnState = 1;
            DataChangeButtonState();

           
        }
        //***************************************************
        //Delete 버튼 클릭
        //***************************************************
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine("***************삭제*********************");
            if (myViewModel[DG1.SelectedIndex].AdminCode == "A")
            {
                try
                {
                    myViewModel.RemoveAt(DG1.SelectedIndex);

                }catch(Exception e1)
                {
                    Console.WriteLine(e1.ToString());
                }

            }
            else if (myViewModel[DG1.SelectedIndex].AdminCode == "D")
            {
                 myViewModel[DG1.SelectedIndex].AdminCode = myViewModel[DG1.SelectedIndex].AdminDivision;
            }
            else
            {
                myViewModel[DG1.SelectedIndex].AdminDivision = myViewModel[DG1.SelectedIndex].AdminCode;
                myViewModel[DG1.SelectedIndex].AdminCode = "D";
                Console.WriteLine(myViewModel[DG1.SelectedIndex].AdminDivision);

            }
            reset();
            DefaultButtonState();
            AdminInfo.IsEnabled = true;
        }
        //***************************************************
        //Check 버튼 클릭
        //***************************************************
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (BtnState == 0)
            {
                Console.WriteLine("***************추가 확인*********************");

                int ItemCount = DG1.Items.Count;
                if (ItemCount > 0)
                {
                    ItemCount = 0;

                }

                AdminViewModel data = (AdminViewModel)AdminInfo.DataContext;

                var item = data.AdminSGrade;
                string AdminCode = "A";
                AdminViewModel TempData = new AdminViewModel
                {
                    AdminCode = AdminCode,
                    AdminId = data.AdminId,
                    AdminName = data.AdminName,
                    AdminPassword = data.AdminPassword,
                    AdminSGrade = data.AdminSGrade
                };
                myViewModel.Insert(ItemCount, TempData);
                int result = sql.createAdmin(TempData, "dkxltks25");
                Console.WriteLine(result);
            }
            if(BtnState == 1)
            {
                Console.WriteLine("***************수정 확인*********************");
                int index = DG1.SelectedIndex;
                //클릭 값 체크
                int cnt = 0;
                if(myViewModel[index].AdminCode == "A")
                {
                    //입력구분이 A인경우 무시하고 지나감

                }
                else
                {
                    //아닐 경우
                    if (myViewModel[index].AdminId != TempList[0])
                    {
                        cnt++;
                    }
                    if (myViewModel[index].AdminName != TempList[1])
                    {
                        cnt++;

                    }
                    if (myViewModel[index].AdminPassword != TempList[2])
                    {
                        cnt++;

                    }
                    if (myViewModel[index].AdminSGrade != TempList[3])
                    {
                        cnt++;

                    }
                    //값 변경
                    if (cnt != 0)
                    {
                        Console.WriteLine("값 변경 감지 되었습니다.");
                        myViewModel[DG1.SelectedIndex].AdminCode = "U";
                        Console.WriteLine(myViewModel[DG1.SelectedIndex].AdminId);
                        sql.UpdateAdmin(myViewModel[DG1.SelectedIndex], "dkxltks25");
                    }

                }
            }
            AdminInfo.DataContext = new AdminViewModel();
            DefaultButtonState();
            reset();

        }

        //Cancel 버튼 클릭
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            reset();
            AdminInfo.DataContext = new AdminViewModel();
            AdminInfo.IsEnabled = true;
            DefaultButtonState();
        }

    

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SetTempViewModelList();
                DataGrid Select = (DataGrid)sender;
                AdminInfo.DataContext = myViewModel[Select.SelectedIndex];
                UpdateAndDeleteButtonState();
                AdminInfo.IsEnabled = false;
            }catch(Exception e1)
            {
            }
        }

     

        private void DG1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }

      
    }
}

