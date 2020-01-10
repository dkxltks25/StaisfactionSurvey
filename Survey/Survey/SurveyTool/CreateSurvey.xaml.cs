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

        private void CreateTableColumn()
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "First Name";
            textColumn.Binding = new Binding("FirstName");
            DG2.Columns.Add(textColumn);
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //***********************************************
        //Add버튼 클릭
        //***********************************************
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            myViewModel.Insert(myViewModel.Count, new SurveyViewModel { });
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
   
}
