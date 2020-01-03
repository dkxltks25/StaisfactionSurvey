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
        public AdminManagementPage()
        {
            InitializeComponent();
            myViewModel = new BindingList<AdminViewModel>();
            DG1.ItemsSource = myViewModel;
            AdminInfo.DataContext = new AdminViewModel();
            DefaultButtonState();
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
        //Add, update ,Cancel을 누른 후
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
            AdminViewModel data = (AdminViewModel)AdminInfo.DataContext;
            data.AdminId = "";
            data.AdminName = "";
            data.AdminPassword = "";
            data.AdminSGrade = "M";
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
        //Add 버튼
        //***************************************************
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
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
            BtnState = 1;
            Console.WriteLine(DG1.SelectedIndex);
            Console.WriteLine(myViewModel[DG1.SelectedIndex].AdminId);
            myViewModel[DG1.SelectedIndex].AdminCode = "S";
            //AdminViewModel Data = (AdminViewModel)AdminInfo.DataContext;

            //Data.AdminCode = "S";
            //reset();
            DefaultButtonState();

        }
        //***************************************************
        //Cancel 버튼 클릭
        //***************************************************
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataChangeButtonState();

        }
        //***************************************************
        //Check 버튼 클릭
        //***************************************************
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if(BtnState == 0)
            {
                int ItemCount = DG1.Items.Count;
                if (ItemCount < 0)
                {
                    ItemCount = 0;
                }

                AdminViewModel data = (AdminViewModel)AdminInfo.DataContext;
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
                
            }
            DefaultButtonState();
            reset();

        }

        //Cancel 버튼 클릭
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            reset();
            DefaultButtonState();
        }

    

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid Select = (DataGrid)sender;
            AdminInfo.DataContext = myViewModel[Select.SelectedIndex];
            UpdateAndDeleteButtonState();
        }

     

        private void DG1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }

      
    }
}
