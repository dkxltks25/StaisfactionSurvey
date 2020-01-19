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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Survey
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            id.Text = Properties.Settings.Default.LoginId;
            Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/LoginImage1.jpg", UriKind.RelativeOrAbsolute));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check.IsChecked == true)
            {
                Properties.Settings.Default.LoginId = id.Text;
                Properties.Settings.Default.Save();
            }
            ManageSql sql = new ManageSql();
            if(sql.AdminLogin(id.Text, password.Password)== 1)
            {
                AdminMainPage adminmainpage = new AdminMainPage();
                adminmainpage.ShowDialog();
            }
            else
            {
                MessageBox.Show("아이디 혹은 비밀번호를 확인 해주세요");
            }


        }
    }
}
