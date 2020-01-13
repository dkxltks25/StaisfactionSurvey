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

namespace Survey
{
    /// <summary>
    /// AdminMainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdminMainPage : Window
    {
        public AdminMainPage()
        {
            InitializeComponent();
           
            
        }

        //Select값 변경 
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // SelectChange
           var data =e.NewValue as TreeViewItem;
           String HeaderValue = data.Header.ToString();
           if(HeaderValue == "학생관리")
            {
               // StudentAdmin studentadmin = new StudentAdmin();
                //studentadmin.Show();
            }
           else if(HeaderValue == "부서 관리")
            {
                DepartmentAdmin departmentadmin = new DepartmentAdmin();
                departmentadmin.Show();
            }
           //설문지 관리
           else if(HeaderValue == "설문지조회")
            {
            }
           //설문지 생성
           else if(HeaderValue == "설문지생성")
            {
                
            }
           else if(HeaderValue == "관리자 관리")
            {
                AdminManagementPage admp = new AdminManagementPage();
                admp.Show();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
 }

