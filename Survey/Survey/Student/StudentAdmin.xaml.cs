using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using ExcelDataReader;
using Survey.ViewModel;
namespace Survey.Student
{
    /// <summary>
    /// StudentAdmin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StudentAdmin : Window
    {
        BindingList<StudentAdminViewModel> myViewModel;
        string[] TempData = new string[9];  
        public StudentAdmin()
        {
            InitializeComponent();
            DefaultState();
            myViewModel = new BindingList<StudentAdminViewModel>();
            DG1.ItemsSource = myViewModel;
            StudentInfo.DataContext = new StudentAdminViewModel();
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
        private int Btn_state = -1;
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
            StudentInfo.DataContext = new StudentAdminViewModel();
            //텍스트 빈값 변경
            studentNumber.Text = "";
            studentName.Text = "";
            studentPhone.Text = "";
            studentPassword.Text = "";
            studentDept.Text = "";
            studentSex.Text = "";
            studentEmail.Text = "";
            studentResNo.Text = "";
            studentResNo1.Text = "";
        }
        #endregion
        
        //*********************************************
        //검색 버튼 클릭
        //*********************************************
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //*********************************************
        //추가  버튼 클릭
        //*********************************************
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            checkState();
            resetText();
            Btn_state = 0;
        }
        //*********************************************
        //업데이트 버튼 클릭
        //*********************************************
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            checkState();
            Btn_state = 1; 
        }
        //*********************************************
        //삭제 버튼 클릭
        //*********************************************
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            checkState();
            Btn_state = 2;
        }
        //*********************************************
        //확인 버튼 클릭
        //*********************************************
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            DefaultState();
            //입력
            StudentAdminViewModel data = (StudentAdminViewModel)StudentInfo.DataContext;

            if (Btn_state == 0)
            {

                StudentAdminViewModel temp = new StudentAdminViewModel
                {
                    StudentCode = "A",
                    StudentNumber = data.StudentNumber,
                    StudentName = data.StudentName,
                    StudentResNumber1 = data.StudentResNumber1,
                    StudentResNumber2 = data.StudentResNumber2,
                    StudentSex = data.StudentSex,
                    StudentDept = data.StudentDept,
                    StudentPassword = data.StudentPassword,
                    StudentEmail = data.StudentEmail,
                    StudentPhone = data.StudentPhone,
                };
                myViewModel.Insert(myViewModel.Count, temp);
            }
            //업데이트
            if(Btn_state == 1)
            {
                if(myViewModel[DG1.SelectedIndex].StudentCode == "A")
                {

                } 
                else
                {
                    int cnt = 0;
                    if (TempData[0] != data.StudentNumber)
                    {
                        cnt++;
                    }
                    if (TempData[1] == data.StudentName)
                    {
                        cnt++;
                    }
                    if (TempData[2] == data.StudentPhone)
                    {
                        cnt++;
                    }
                    if (TempData[3] == data.StudentPassword)
                    {
                        cnt++;
                    }
                    if (TempData[4] == data.StudentDept)
                    {
                        cnt++;
                    }
                    if (TempData[5] == data.StudentSex)
                    {
                        cnt++;
                    }
                    if (TempData[6] == data.StudentEmail)
                    {
                        cnt++;
                    }
                    if (TempData[7] == data.StudentResNumber1)
                    {
                        cnt++;
                    }
                    if (TempData[8] == data.StudentResNumber2)
                    {
                        cnt++;
                    }

                    if (cnt > 0)
                    {
                        data.StudentCode = "U";
                    }
                }
            }
            if(Btn_state == 2)
            {
                IList items = DG1.SelectedItems;
                if(items.Count > 1)
                {
                    List<int> indexArray = new List<int>();
                    foreach (StudentAdminViewModel item in items)
                    {
                        for (int i = 0; i < myViewModel.Count; i++)
                        {
                            if (myViewModel[i].StudentNumber == item.StudentNumber)
                            {
                                if (item.StudentCode == "A")
                                {
                                    indexArray.Add(i);
                                }
                                else if(item.StudentCode == "D")
                                {
                                    myViewModel[i].StudentCode = myViewModel[i].StudentDivision;
                                }
                                else
                                {
                                    myViewModel[i].StudentDivision = myViewModel[i].StudentCode;
                                    myViewModel[i].StudentCode = "D";
                                }
                            }

                        }
                    }
                    for (int i = indexArray.Count - 1; i >= 0; i--)
                    {
                        myViewModel.RemoveAt(indexArray[i]);
                    }
                }
                else if(items.Count == 1)
                {
                    StudentAdminViewModel DeleteData = myViewModel[DG1.SelectedIndex];
                    if(DeleteData.StudentCode == "A")
                    {
                        myViewModel.Remove(DeleteData);
                    }
                    else if(DeleteData.StudentCode == "D")
                    {
                        DeleteData.StudentCode = DeleteData.StudentDivision;
                    }
                    else
                    {
                        DeleteData.StudentDivision = DeleteData.StudentCode;
                        DeleteData.StudentCode = "D";
                    }
                }
                else
                {
                    MessageBox.Show("선택이 안되었네요");
                }
               
            }
            resetText();
        }
        
        //*********************************************
        //취소 버튼 클릭
        //*********************************************
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DefaultState();
            resetText();
        }
        //*********************************************
        //저장 버튼 클릭
        //*********************************************
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StudentName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StudentResNo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //*********************************************
        //그리드의 선택 데이터 변경
        //*********************************************
        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DG1.SelectedIndex < 0)
            {
                return;
            }

            UpdateAndDeleteState();
            StudentInfo.DataContext = myViewModel[DG1.SelectedIndex];
            SetDataGridChanged();
        }

        //*********************************************
        // 데이터 변경 체크
        //*********************************************
        private void SetDataGridChanged()
        {
            TempData[0]=studentNumber.Text;
            TempData[1]=studentName.Text;
            TempData[2]=studentPhone.Text ;
            TempData[3]=studentPassword.Text;
            TempData[4]=studentDept.Text;
            TempData[5]=studentSex.Text ;
            TempData[6]=studentEmail.Text ;
            TempData[7]=studentResNo.Text ;
            TempData[8]=studentResNo1.Text;
        }
        //*********************************************
        //엑셀파일 윈도우 드래그
        //*********************************************
        private void Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                var file = files[0];
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // Choose one of either 1 or 2:

                        // 1. Use the reader methods
                        do
                        {
                            while (reader.Read())
                            {
                                // reader.GetDouble(0);
                            }
                        } while (reader.NextResult());

                        // 2. Use the AsDataSet extension method
                        var result = reader.AsDataSet();

                        // The result of each spreadsheet is in result.Tables
                    }

                }
            }
         
     
    }

}
