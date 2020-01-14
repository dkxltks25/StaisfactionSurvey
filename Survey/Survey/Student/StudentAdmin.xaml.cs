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
using Excel = Microsoft.Office.Interop.Excel;
using Survey.ViewModel;
using System.Reflection;

namespace Survey.Student
{
    /// <summary>
    /// StudentAdmin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StudentAdmin : Window
    {
        BindingList<StudentAdminViewModel> myViewModel;
        //엑셀 파일명 지정
        private string ExcelFileName = "dkxltks25-박재홍-학생";
        //파일 변경 감지
        string[] TempData = new string[9];
        //관리자
        string admin = "dkxltks25:박재홍";
        //데이터베이스 선언
        private ManageSql Sql = new ManageSql();
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
            SearchButton.IsEnabled = true;
            AddButton.IsEnabled = true;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            CheckButton.IsEnabled = false;
            CancelButton.IsEnabled = true;
            SaveButton.IsEnabled = true;
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
            if (Btn_state == 1)
            {
                if (myViewModel[DG1.SelectedIndex].StudentCode == "A")
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
            if (Btn_state == 2)
            {
                IList items = DG1.SelectedItems;
                if (items.Count > 1)
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
                                else if (item.StudentCode == "D")
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
                else if (items.Count == 1)
                {
                    StudentAdminViewModel DeleteData = myViewModel[DG1.SelectedIndex];
                    if (DeleteData.StudentCode == "A")
                    {
                        myViewModel.Remove(DeleteData);
                    }
                    else if (DeleteData.StudentCode == "D")
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
            ReadDataGridView();
            Sql.SelectStudent(myViewModel);
        }
        //*********************************************
        //데이터 그리드뷰 전체 읽기
        //*********************************************
        private void ReadDataGridView()
        {
            //바인딩리스트 조회
            for(int i = myViewModel.Count -1; i>=0; i--)
            {
                //데이터 베이스 입력
                if(myViewModel[i].StudentCode == "A")
                {
                    Sql.CreateStudent(myViewModel[i], admin);
                }
                //업데이트
                else if(myViewModel[i].StudentCode == "U")
                {
                    Sql.CreateStudent(myViewModel[i], admin);
                }
                //삭제
                else if(myViewModel[i].StudentCode == "D")
                {
                    Sql.DeleteStudent(myViewModel[i]);
                }
                //S의 경우는 그냥 넘어 간다.
            }
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
            if (DG1.SelectedIndex < 0)
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
            TempData[0] = studentNumber.Text;
            TempData[1] = studentName.Text;
            TempData[2] = studentPhone.Text;
            TempData[3] = studentPassword.Text;
            TempData[4] = studentDept.Text;
            TempData[5] = studentSex.Text;
            TempData[6] = studentEmail.Text;
            TempData[7] = studentResNo.Text;
            TempData[8] = studentResNo1.Text;
        }

        #region 엑셀 정보처리 영역
        //*********************************************
        //엑셀파일 윈도우 드래그
        //*********************************************
        private void Window_Drop(object sender, DragEventArgs e)
        {
            String File = System.IO.Path.GetFullPath(((string[])(e.Data.GetData(e.Data.GetFormats()[7])))[0].ToString());
            ExcelRead(File);
        }

        //*********************************************
        //엑셀파일 읽기
        //*********************************************
        private void ExcelRead(string FilePath)
        {
            Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Open(FilePath, 0, true, 5, Missing.Value, Missing.Value, false, Missing.Value, Missing.Value, true, false, Missing.Value, false, false, false);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
            string str;
            int rCnt = 0; // 열 갯수
            int cCnt = 0; // 행 갯수


            Excel.Range range = worksheet.UsedRange;

            System.Array myvalues = (System.Array)range.Cells.Value2;
            //string[] strArray = ConvertToStringArray(myvalues);
            myViewModel.Clear();
            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
             

                StudentAdminViewModel Data = new StudentAdminViewModel
                {
                    StudentCode = "A",
                    StudentNumber = (range.Cells[rCnt, 1] as Excel.Range).Value2.ToString(),
                    StudentResNumber1 = (range.Cells[rCnt, 2] as Excel.Range).Value2.ToString(),
                    StudentResNumber2 = (range.Cells[rCnt, 3] as Excel.Range).Value2.ToString(),
                    StudentName = (range.Cells[rCnt, 4] as Excel.Range).Value2.ToString(),
                    StudentSex = (range.Cells[rCnt, 5] as Excel.Range).Value2.ToString(),
                    StudentDept = (range.Cells[rCnt, 6] as Excel.Range).Value2.ToString(),
                    StudentPhone = (range.Cells[rCnt, 7] as Excel.Range).Value2.ToString(),
                    StudentEmail = (range.Cells[rCnt, 8] as Excel.Range).Value2.ToString(),
                    StudentPassword = (range.Cells[rCnt, 2] as Excel.Range).Value2.ToString()
                };
                myViewModel.Insert(myViewModel.Count,Data);
            }

        }
        //*********************************************
        // 엑셀 파일 만들기 
        //*********************************************
        private void CreateExcel()
        {
            try
            {
                object missingType = Type.Missing;
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add(missingType);
                // 워크 시트 생성
                // Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets.Add(missingType, missingType, missingType, missingType);
                // 워크 시트 첫번째 요소 가져옴
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1);
                excelWorksheet.Cells[1, 1] = "학번(Ex:201887082)";
                excelWorksheet.Cells[1, 2] = "주민등록번호 앞자리(Ex:990714)";
                excelWorksheet.Cells[1, 3] = "주민등록번호 뒷자리(Ex:xxxxxxx)";
                excelWorksheet.Cells[1, 4] = "성명(Ex:박재홍)";
                excelWorksheet.Cells[1, 5] = "성별(M혹은F로 표기해주세요)";
                excelWorksheet.Cells[1, 6] = "학과 및 부서(소프트웨어전공)";
                excelWorksheet.Cells[1, 7] = "연락처(01041645367)";
                excelWorksheet.Cells[1, 8] = "이메일 주소(dkxltks25@naver.com)";
                excelWorksheet.Cells[1, 9] = "비밀번호(빈칸 등록시 주민번호 앞자리 등록)";

                excelBook.SaveAs(
                    @ExcelFileName,  // 유니코드 파일명 변환
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                    missingType,
                    missingType,
                    missingType,
                    missingType,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    missingType,
                    missingType,
                    missingType,
                    missingType,
                    missingType);
                excelBook.Close(true, missingType, missingType);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                excelApp = null;
                Console.WriteLine("성공");
            }

            catch
            {
                MessageBox.Show("Excel 파일 저장중 에러가 발생했습니다.");
            }
        }
        #endregion

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


