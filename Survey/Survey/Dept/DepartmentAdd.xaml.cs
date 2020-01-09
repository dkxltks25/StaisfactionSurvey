using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using Survey.ViewModel;
namespace Survey
{
    /// <summary>
    /// DepartmentAdd.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DepartmentAdd : Window
    {

        //바인딩 리스트 정의 -> 데이터 그리드와 연관됨
        BindingList<DeptViewModel> myViewModel;
        ManageSql sql = new ManageSql();
        string[] selectArray = new string[2];
        string AdminId = "dkxltks25:박재홍";
        private string ExcelFileName = "dkxltks25-박재홍-학생";
        //*********************************************
        //생성자
        //*********************************************

        public DepartmentAdd()
        {
            InitializeComponent();
            myViewModel = new BindingList<DeptViewModel>();
            DG1.ItemsSource = myViewModel;
            DeptInfo.DataContext = new DeptViewModel();
            DefaultState();
        }

        #region 화면제어
        //*********************************************
        // 화면 제어를 위한 함수들 (버튼의 ISEnabled를 수정) 
        // 화면순서
        // 1.Add 버튼 클릭 -> update,delete 이용불가
        // 2.확인 버튼 혹은 취소 버튼 클릭 -> 초기상태
        // 3.데이터 그리드 클릭 -> 업데이트 버튼 Delete버튼 ON
        //*********************************************

        /// <summary>
        /// 버튼 입력 상태 정의
        /// 0입력 
        /// 1수정
        /// 2삭제
        /// </summary>
        private int Btn_state = 0;
        //*********************************************
        // 초기상태
        //*********************************************
        private void DefaultState()
        {
            InfoButton.IsEnabled = true;
            SearchButton.IsEnabled= true;
            AddButton.IsEnabled= true;
            UpdateButton.IsEnabled= false;
            DeleteButton.IsEnabled= false;
            CheckButton.IsEnabled= false;
            CancelButton.IsEnabled= true;
            SaveButton.IsEnabled= true;
        }
        //*********************************************
        // Add버튼 클릭 
        //*********************************************
        private void checkState()
        {
            InfoButton.IsEnabled = true;
            SearchButton.IsEnabled = true;
            AddButton.IsEnabled = false;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            CheckButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
            SaveButton.IsEnabled = true;
        }
        //*********************************************
        // 데이터 그리드 클릭
        //*********************************************
        private void UpdateAndDeleteState()
        {
            InfoButton.IsEnabled = true;
            SearchButton.IsEnabled = true;
            AddButton.IsEnabled = false;
            UpdateButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
            CheckButton.IsEnabled = false;
            CancelButton.IsEnabled = true;
            SaveButton.IsEnabled = true;
        }

        //*********************************************
        // 텍스트 박스 클리어
        //*********************************************
        public void resetText()
        {
            //바인딩 해체
            DeptInfo.DataContext = new DeptViewModel();

            //텍스트 빈값 변경
            dept_id.Text = "";
            dept_name.Text="";
        }

        #endregion

        //*********************************************
        // Add 버튼 클릭 
        //*********************************************
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            checkState();
            resetText();
            Btn_state = 0;
            
        }
        
        //*********************************************
        // 업데이트 버튼 클릭 
        //*********************************************
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Btn_state = 1;
            checkState();
        }

        //*********************************************
        // 삭제 버튼 클릭 
        //*********************************************
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Btn_state = 2;
            int Index = DG1.SelectedIndex;
            if(Index > 0)
            {
                //저장되지 않은 데이터의 입력
                Console.WriteLine("--------------");
                if (myViewModel[Index].DeptCode == "A")
                {
                    myViewModel.RemoveAt(Index);
                }
                //삭제를 누른 경험이 있는 데이터
                else if (myViewModel[Index].DeptCode == "D")
                {
                    myViewModel[Index].DeptCode = myViewModel[Index].DeptDivision;
                }
                else
                {
                    myViewModel[Index].DeptDivision = myViewModel[Index].DeptCode;
                    myViewModel[Index].DeptCode = "D";

                }
            }
            


        }
        //*********************************************
        // 체크 버튼 클릭 
        //*********************************************
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            DeptViewModel Data = (DeptViewModel)DeptInfo.DataContext;

            //입력
            if (Btn_state == 0)
            {
                DeptViewModel Temp = new DeptViewModel
                {
                    DeptCode = "A",
                    DeptId = Data.DeptId,
                    DeptName = Data.DeptName,
                    DeptCreateAt = Data.DeptCreateAt
                };
                myViewModel.Insert(myViewModel.Count, Temp);
                sql.InsertDept(Temp,AdminId);
            }
            //수정
            if (Btn_state == 1)
            {
                //데이터가 변경된 경우
                Console.WriteLine("----------------------");
                Console.WriteLine(Data.DeptId);
                Console.WriteLine(Data.DeptName);
                if (selectArray[1] != Data.DeptName)
                {
                    //입력 구분값 변경 
                    if (Data.DeptCode == "S")
                    {
                        Data.DeptCode = "U";
                    }
                    Console.WriteLine(sql.UpdateDept(Data, AdminId));
                }
                Console.WriteLine("----------------------");

            }
            if (Btn_state == 2)
            {
                sql.DeleteDept(Data);
            }
            //바인딩 해제
            DefaultState();
            sql.SelectDept(myViewModel, string.Empty);
            selectArray = new string[2];
            resetText();

        }
        //*********************************************
        // 취소 버튼 클릭 
        //*********************************************
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DefaultState();
            resetText();
        }
       

        //*********************************************
        // 조회 버튼 클릭 
        //*********************************************
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            sql.SelectDept(myViewModel, string.Empty);
        }
        //*********************************************
        // 텍스트 변경시 조회 
        //*********************************************
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            sql.SelectDept(myViewModel, SelectText.Text);
        }
        //*********************************************
        // 데이터 그리드 서로 다른 행으로 변경 
        //*********************************************
        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                UpdateAndDeleteState();
                int index = DG1.SelectedIndex;
                if(index < 0)
                {
                    return;
                }

                DeptInfo.DataContext = myViewModel[DG1.SelectedIndex];
                selectArray[0] = myViewModel[DG1.SelectedIndex].DeptId;
                selectArray[1] = myViewModel[DG1.SelectedIndex].DeptName;
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }

        }
        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //CreateExcel();
        }
    }
}
