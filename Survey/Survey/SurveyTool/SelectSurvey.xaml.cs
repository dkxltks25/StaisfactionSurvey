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
namespace Survey.SurveyTool
{
    /// <summary>
    /// SelectSurvey.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SelectSurvey : Window
    {
        BindingList<SelectSurveyViewModel> myViewModel;
        int Btn_state = 0;
        public SelectSurvey()
        {
            InitializeComponent();
            SurveyInfo.DataContext = new SelectSurveyViewModel();
            myViewModel = new BindingList<SelectSurveyViewModel>();
            DG1.ItemsSource = myViewModel;
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
        private int btn_state = 0;
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
        }

        #endregion

      
        //*****************************************************************
        // Add버튼 클릭 
        //*****************************************************************

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            checkState();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {

            SelectSurveyViewModel data = (SelectSurveyViewModel)SurveyInfo.DataContext;
            Console.WriteLine(data.SurveyName);
            SelectSurveyViewModel temp = new SelectSurveyViewModel { };
            temp.SurveyName = data.SurveyName.ToString();
     
            myViewModel.Insert(myViewModel.Count, temp);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
