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

namespace Survey.SurveyTool
{
    /// <summary>
    /// CreateSurvey.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CreateSurvey : Window
    {
        public CreateSurvey()
        {
            InitializeComponent();
        }
        public void ConnectWeb()
        {
            string url = "file:///C:/Users/USER/Desktop/survey/index.html";
            web.Navigate(url);
        }
    }
   
}
