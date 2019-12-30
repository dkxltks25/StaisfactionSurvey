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
namespace Survey
{
    /// <summary>
    /// AdminManagementPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdminManagementPage : Window
    {
        public AdminManagementPage()
        {
            InitializeComponent();
            DefaultButtonState();
        }

        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StudentNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        //하단 메세지 창
        private void DockMessageStateChange(String Message)
        {

        }

        //normal
        private void DefaultButtonState()
        {
            InfoButton.IsEnabled = true;
            AddButton.IsEnabled = true;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            CheckButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
        }
        //Add, update ,Cancel을 누른 후
        private void DataChangeButtonState()
        {
            InfoButton.IsEnabled = true;
            AddButton.IsEnabled = false;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            CheckButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
        }
        //데이터 클리후
        private void UpdateAndAddButtonState()
        {
            InfoButton.IsEnabled = true;
            AddButton.IsEnabled = false;
            UpdateButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
            CheckButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
        }
        
        //info 버튼
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //Add 버튼
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DataChangeButtonState();
            Sql sql = new Sql();
            Console.WriteLine(sql.SHA512("dkxltks25"));

        }
        //Update 버튼 클릭
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DataChangeButtonState();

        }
        //Cancel 버튼 클릭
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataChangeButtonState();

        }
        //Check 버튼 클릭
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            DefaultButtonState();
        }
        //Cancel 버튼 클릭
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DefaultButtonState();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
