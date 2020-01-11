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
using Newtonsoft.Json;
using System.Data;

namespace Survey.SurveyTool
{
    /// <summary>
    /// CreateSurvey.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CreateSurvey : Window
    {
        
        BindingList<SurveyViewModel> myViewModel;
        string json = @"&Collection=" + "{\"Title\":{\"Title\":\"123\",\"Descrip\":\"123\"},\"item\":[{\"Title\":\"단답형\",\"Descrip\":\"설명\",\"Option\":\"0\",\"OptionName\":\"단답형\"},{\"Title\":\"장문형\",\"Descrip\":\"장문에 대한 서명을 적어주세요\",\"Option\":\"1\",\"OptionName\":\"장문형\"},{\"Title\":\"객관식 지문입니다.\",\"Option\":\"2\",\"OptionName\":\"객관식\",\"item\":[\"지문1\",\"지문2\",\"지문3\",\"지문4\",\"지문5\"]},{\"Title\":\"체크박스테스트\",\"Option\":\"3\",\"OptionName\":\"체크박스\"},{\"Title\":\"직선단계 테스트\",\"Option\":\"4\",\"OptionName\":\"직선단계\",\"item\":{\"Row\":[\"만족\",\"불만족\"],\"Column\":[\"얼마나 만족\",\"만족\"]}}]}";

        public CreateSurvey()
        {
            InitializeComponent();
            myViewModel = new BindingList<SurveyViewModel>();
            DG1.ItemsSource = myViewModel;
            ConnectWeb();
            //CreateTableColumn();
       
        }
        public void ConnectWeb()
        {
            string url = "file:///C:/Users/USER/Desktop/survey/Form.html?"+json;
            Console.WriteLine(url);
            web.Navigate(url);
        }
       
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            SurveyViewModel.Item Temp = new SurveyViewModel.Item { SurveyItem = "S" };
            Console.WriteLine(myViewModel[DG1.SelectedIndex].SurveyItem.Count);
            myViewModel[DG1.SelectedIndex].SurveyItem.Insert(
                myViewModel[DG1.SelectedIndex].SurveyItem.Count,
                Temp);
        }
        //***********************************************
        //Add버튼 클릭
        //***********************************************
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            myViewModel.Insert(myViewModel.Count, new SurveyViewModel { SurveyCode="S" });
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #region 데이터 그리드 뷰 제어

        //***********************************************
        //데이터 그리드 뷰의 셀렉트 변경
        //***********************************************
        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SurveyOption값
            switch (myViewModel[DG1.SelectedIndex].SurveyOption)
            {
               
                case "객관식1":
                    CreateTableColumn(1);
                    break;
                case "객관식2":
                    CreateTableColumn(1);
                    break;
                case "그리드":
                    CreateTableColumn(2);
                    break;
                default:
                    break;
            }

        }
        //***********************************************
        //DG2의 동적 컬럼 생성
        //***********************************************
        private void CreateTableColumn(int columnCase)
        {
            DG2.Columns.Clear();

            BindingList<SurveyViewModel.Item> test = myViewModel[DG1.SelectedIndex].SurveyItem;
            SurveyViewModel.Item t = new SurveyViewModel.Item { SurveyItem = "tt" };
            DG2.ItemsSource = myViewModel[DG1.SelectedIndex].SurveyItem;
            DataGridTextColumn textColumn = new DataGridTextColumn();
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            test.Clear();
            //객관식 ||  주관식 columncase 1 ,2
            if (columnCase == 1)
            {
                textColumn.Header = "항목";
                textColumn.Binding = new Binding("SurveyItem");
                test.Insert(test.Count, t);

                DG2.Columns.Add(textColumn);
            }
            else if (columnCase == 2)
            {
                textColumn.Header = "항목";
                textColumn.Binding = new Binding("SurveyItem");
                test.Insert(test.Count, t);
                DG2.Columns.Add(textColumn);
            }
            //그리드 columnCase 3
            else if (columnCase == 3)
            {
                textColumn.Header = "가로(행)";
                textColumn.Binding = new Binding("SurveyRow");
                DG2.Columns.Add(textColumn);

                textColumn1.Header = "세로(줄)";
                textColumn1.Binding = new Binding("SurveyColumn");
                DG2.Columns.Add(textColumn1);
            }
        }
        //***********************************************
        //DG1의 셀렉트 체인지 이벤트
        //***********************************************
        private void DG1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DG2.ItemsSource = myViewModel[DG1.SelectedIndex].SurveyItem;
        }
        #endregion


    }

}
