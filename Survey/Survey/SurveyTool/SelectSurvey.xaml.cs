using System;
using System.Collections;
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
using LiveCharts;
using LiveCharts.Wpf;
using Survey.ViewModel;
namespace Survey.SurveyTool
{
    /// <summary>
    /// SelectSurvey.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SelectSurvey : Window
    {
        BindingList<SelectSurveyViewModel> myViewModel;
        public int btn_state = 0;
        string[] tempArray = new string[3];
        ManageSql Sql = new ManageSql();
        //Application.Current.MainWindow = this;

        public SelectSurvey()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;

            SurveyInfo.DataContext = new SelectSurveyViewModel();
            myViewModel = new BindingList<SelectSurveyViewModel>();
            DG1.ItemsSource = myViewModel;
            DefaultState();
            
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
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
            SurveyInfo.DataContext = new SelectSurveyViewModel();
            name.Text = "";

            st.SelectedDate = DateTime.Now;
            ft.SelectedDate = DateTime.Now;

        }

        #endregion


        //*****************************************************************
        // Add버튼 클릭 
        //*****************************************************************
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            btn_state = 0;
            checkState();
        }

        //*****************************************************************
        // 업데이트 버튼 클릭 
        //*****************************************************************
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            btn_state = 1;
            checkState();
        }
        //*****************************************************************
        // 삭제 버튼 클릭 
        //*****************************************************************
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            btn_state = 2;
            checkState();
        }
        //*****************************************************************
        // 확인 버튼 클릭 
        //*****************************************************************
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        { 
            SelectSurveyViewModel data = (SelectSurveyViewModel)SurveyInfo.DataContext;
            if(btn_state == 0)
            {
                Console.WriteLine(data.SurveyName);
                SelectSurveyViewModel temp = new SelectSurveyViewModel
                {
                    SurveyCode = "A",
                    SurveyName = data.SurveyName,
                    SurveyDescrip = data.SurveyDescrip,
                    StartTime = data.StartTime,
                    FinishTime = data.FinishTime
                };
                myViewModel.Insert(myViewModel.Count, temp);
            }
            //업데이트
            else if(btn_state == 1)
            {
                if (myViewModel[DG1.SelectedIndex].SurveyCode == "S")
                {
                    myViewModel[DG1.SelectedIndex].SurveyCode = "U";
                }
                else if (myViewModel[DG1.SelectedIndex].SurveyCode == "D")
                {
                    myViewModel[DG1.SelectedIndex].SurveyCode = "U";
                }
            }
            //삭제
            else if(btn_state == 2)
            {
                if(myViewModel[DG1.SelectedIndex].SurveyCode == "S" || myViewModel[DG1.SelectedIndex].SurveyCode == "U")
                {
                    myViewModel[DG1.SelectedIndex].SurveyDivision = myViewModel[DG1.SelectedIndex].SurveyCode;
                    myViewModel[DG1.SelectedIndex].SurveyCode = "D";
                }else if(myViewModel[DG1.SelectedIndex].SurveyCode == "D")
                {
                    myViewModel[DG1.SelectedIndex].SurveyCode = myViewModel[DG1.SelectedIndex].SurveyDivision;
                }
                else
                {
                    myViewModel.RemoveAt(DG1.SelectedIndex);
                }
            }
            resetText();
        }
        //*****************************************************************
        // 취소버튼클릭
        //*****************************************************************
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DefaultState();
            resetText();
        }
        //*****************************************************************
        // 저장 버튼 클릭 
        //*****************************************************************
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < myViewModel.Count; i++)
            {
                //입력
                if(myViewModel[i].SurveyCode == "A")
                {
                    Sql.InsertSelectSurvey(myViewModel[i], "dkxltks25 박재홍");
                }
                else if(myViewModel[i].SurveyCode == "U")
                {
                    Sql.UpdateSelectSurvey(myViewModel[i],"dkxltks25 박재홍");

                }
                else if(myViewModel[i].SurveyCode == "D")
                {
                    Sql.DeleteSelectSurvey(myViewModel[i].SurveyId);
                }
                for(int j = 0; j < myViewModel[i].RDG.Count; j++)
                {
                    SelectSurveyViewModel.Dept dept = myViewModel[i].RDG[j];
                    if (dept.DeptCode == "C")
                    {
                        Sql.AddSelectSurvetDept(dept, myViewModel[i].SurveyId);
                    }
                }
                for (int j = myViewModel[i].LDG.Count-1; j >=0; j--)
                {
                    SelectSurveyViewModel.Dept dept = myViewModel[i].LDG[j];
                    if(dept.DeptCode == "C")
                    {
                        Sql.DeleteSelectSurveyDept(dept.DeptId,myViewModel[i].SurveyId);
                    }
                }

            }
            SelectTable();
        }
        //*****************************************************************
        // 전체 조회 
        //*****************************************************************
        private void SelectTable()
        {
            Sql.SelectSelectSurvey(myViewModel);
            LDG.ItemsSource = new BindingList<SelectSurveyViewModel.Dept>();
            RDG.ItemsSource = new BindingList<SelectSurveyViewModel.Dept>();
        }
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //*****************************************************************
        // 조회버튼 클릭
        //*****************************************************************
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SelectTable();
        }
        //*****************************************************************
        // DG1 셀렉트 체인지
        //*****************************************************************
        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DG1.SelectedIndex < 0)
            {
                return;
            }
            UpdateAndDeleteState();
            SurveyInfo.DataContext = myViewModel[DG1.SelectedIndex];
            Console.WriteLine(myViewModel[DG1.SelectedIndex].FinishTime);
            //학과 등록및 학과 수정

            if (myViewModel[DG1.SelectedIndex].SurveyCode != "A" && myViewModel[DG1.SelectedIndex].SurveyCode != "D")
            {
                LDG.ItemsSource = myViewModel[DG1.SelectedIndex].LDG;
                RDG.ItemsSource = myViewModel[DG1.SelectedIndex].RDG;
            }
            else
            {
                LDG.ItemsSource = new BindingList<SelectSurveyViewModel.Dept>();
                RDG.ItemsSource = new BindingList<SelectSurveyViewModel.Dept>();
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //*****************************************************************
        // LDG 값 이동
        //*****************************************************************
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (DG1.SelectedIndex < 0)
            {
                return;
            }
            IList items = LDG.SelectedItems;
            if (items.Count >= 1)
            {
                List<int> indexArray = new List<int>();
                foreach (SelectSurveyViewModel.Dept item in items)
                {
                    for (int i = 0; i < myViewModel[DG1.SelectedIndex].LDG.Count; i++)
                    {
                        if (myViewModel[DG1.SelectedIndex].LDG[i].DeptId == item.DeptId)
                        {
                            if (string.IsNullOrEmpty(item.DeptDvision))
                            {
                                item.DeptDvision = item.DeptCode;
                                item.DeptCode = "C";
                            }
                            else
                            {
                                item.DeptCode = item.DeptDvision;
                                item.DeptDvision = string.Empty;
                            }
                            myViewModel[DG1.SelectedIndex].RDG.Insert(myViewModel[DG1.SelectedIndex].RDG.Count, item);
                            indexArray.Add(i);
                        }
                    }
        
                }
                for (int i = indexArray.Count - 1; i >= 0; i--)
                {
                    myViewModel[DG1.SelectedIndex].LDG.RemoveAt(indexArray[i]);
                }
            }
        }
        //*****************************************************************
        // RDG값이동
        //*****************************************************************
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(DG1.SelectedIndex < 0)
            {
                return; 
            }
            IList items = RDG.SelectedItems;
            if (items.Count >= 1)
            {
                List<int> indexArray = new List<int>();
                foreach (SelectSurveyViewModel.Dept item in items)
                {
                    for (int i = 0; i < myViewModel[DG1.SelectedIndex].RDG.Count; i++)
                    {
                        if (myViewModel[DG1.SelectedIndex].RDG[i].DeptId == item.DeptId)
                        {
                            if (string.IsNullOrEmpty(item.DeptDvision))
                            {
                                item.DeptDvision = item.DeptCode;
                                item.DeptCode = "C";
                            }
                            else
                            {
                                item.DeptCode = item.DeptDvision;
                                item.DeptDvision = string.Empty;
                          
                            }
                            myViewModel[DG1.SelectedIndex].LDG.Insert(myViewModel[DG1.SelectedIndex].LDG.Count, item);
                            indexArray.Add(i);
                        }
                    }

                }
                for (int i = indexArray.Count - 1; i >= 0; i--)
                {
                    myViewModel[DG1.SelectedIndex].RDG.RemoveAt(indexArray[i]);
                }
            }
        }

        private void DG1Button_Click(object sender, RoutedEventArgs e)
        {
            new CreateSurvey(myViewModel[DG1.SelectedIndex].SurveyId, myViewModel[DG1.SelectedIndex].SurveyDescrip,myViewModel[DG1.SelectedIndex].SurveyName).ShowDialog();
        }

        private void DownloadExcel_Click(object sender, RoutedEventArgs e)
        {
            //myViewModel[DG1.SelectedIndex].SurveyId;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
