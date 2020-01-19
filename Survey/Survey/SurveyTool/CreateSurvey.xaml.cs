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
using Newtonsoft.Json.Linq;

namespace Survey.SurveyTool
{
    /// <summary>
    /// CreateSurvey.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CreateSurvey : Window
    {
        
        BindingList<SurveyViewModel> myViewModel;

        private string s_id = "";
        private string s_name = "";
        private string s_descrip = "";
        private string Data = "";
        //0 신규 1 기존
        private int State = 0;
       // Application.Current.MainWindow = this;

        public CreateSurvey(string id, string name,string Descript)
        {
            InitializeComponent();
            Application.Current.MainWindow = this;

            myViewModel = new BindingList<SurveyViewModel>();
            DG1.ItemsSource = myViewModel;
            s_id = id;
            s_name = name;
            s_descrip = Descript;
            ManageSql Sql = new ManageSql();
            Data = Sql.selectSurvey(s_id);
            Console.WriteLine("---------테스트");
            Console.WriteLine(Data);
            if (!string.IsNullOrEmpty(Data))
            {
                State = 1;
                LoadSurvey(Data);
            }
            //ConnectWeb();
            //CreateTableColumn();

        }
        //***********************************************
        //저장된 설문지 데이터 불러오기
        //***********************************************
        private void LoadSurvey(string json)
        {
            JObject Data = JObject.Parse(json);
            //Console.WriteLine(Data["item"]);
            try
            {
                foreach (JObject item in Data["item"])
                {
                    if (string.IsNullOrEmpty(item["Option"].ToString()))
                    {

                    }
                    else
                    {
                        SurveyViewModel temp = new SurveyViewModel();
                        //temp.SurveyDescrip = string.IsNullOrEmpty(item["Descrip"].ToString()) ? "" : item["Descrip"].ToString();
                        temp.SurveyTitle = item["Title"].ToString();
                        temp.SurveyOption = item["OptionName"].ToString();
                        //객관식
                        if (item["Option"].ToString() == "2")
                        {
                            JArray items = JArray.Parse(item["item"].ToString());
                            for (int i = 0; i < items.Count; i++)
                            {
                                SurveyViewModel.Item tempItem = new SurveyViewModel.Item();
                                tempItem.SurveyItem = items[i].ToString();
                                temp.SurveyItem.Insert(temp.SurveyItem.Count, tempItem);
                            }
                        }
                        //객관식2
                        if (item["Option"].ToString() == "3")
                        {
                            JArray items = JArray.Parse(item["item"].ToString());
                            for (int i = 0; i < items.Count; i++)
                            {
                                SurveyViewModel.Item tempItem = new SurveyViewModel.Item();
                                tempItem.SurveyItem = items[i].ToString();
                                temp.SurveyItem.Insert(temp.SurveyItem.Count, tempItem);
                            }
                        }
                        //그리드
                        if (item["Option"].ToString() == "4")
                        {
                            JObject items = JObject.Parse(item["item"].ToString());
                            JArray row = JArray.Parse(items["Row"].ToString());
                            JArray Column = JArray.Parse(items["Column"].ToString());

                            for (int i = 0; i < row.Count; i++)
                            {
                                SurveyViewModel.Item tempItem = new SurveyViewModel.Item();

                                tempItem.SurveyRow = row[i].ToString();
                                temp.SurveyItem.Insert(temp.SurveyItem.Count, tempItem);
                            }
                            for (int i = 0; i < Column.Count; i++)
                            {
                                SurveyViewModel.Item tempItem = new SurveyViewModel.Item();
                                tempItem.SurveyColumn = Column[i].ToString();
                                temp.SurveyItem.Insert(temp.SurveyItem.Count, tempItem);

                            }
                        }
                        myViewModel.Insert(myViewModel.Count, temp);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void ConnectWeb(string json)
        {
            string url = "file:///C:/Users/USER/Desktop/survey/Form.html?"+json;
            //Console.WriteLine(url);
            //web.Navigate(url);
            Uri u = new Uri(url);
            web.Navigate(u);
        }
       
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        //***********************************************
        //Add버튼 클릭
        //***********************************************
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //***********************************************
        //저장 버튼 클릭 화면에 입력된 데이터 JSON 변경
        //***********************************************
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var FormData = new JObject();
            var Title = new JObject();
            Title.Add("Title",s_name );
            Title.Add("Descrip",s_descrip);
            var Item = new JArray();
            for(int i = 0; i < myViewModel.Count; i++)
            {
                
                var SurveySubject = new JObject();
                SurveySubject.Add("Title", myViewModel[i].SurveyTitle);
                SurveySubject.Add("Descrip", myViewModel[i].SurveyDescrip);
                SurveySubject.Add("Option", myViewModel[i].OptionNumber);
                SurveySubject.Add("OptionName", myViewModel[i].SurveyOption);
                if (myViewModel[i].SurveyOption != "단답형" && myViewModel[i].SurveyOption != "장문형")
                {

                    var SurveyRow = new JArray();
                    var SurveyColumn = new JArray();
                    var SurveyItem = new JArray();
                    var SurveyItemRowAndColumn = new JObject();
                    for (int j = 0; j < myViewModel[i].SurveyItem.Count; j++)
                    {
                        if (myViewModel[i].SurveyOption == "객관식1" || myViewModel[i].SurveyOption == "객관식2"  )
                        {
                            SurveyItem.Add(myViewModel[i].SurveyItem[j].SurveyItem);

                        }
                        else if (myViewModel[i].SurveyOption == "그리드")
                        {
                            if (!string.IsNullOrEmpty(myViewModel[i].SurveyItem[j].SurveyRow))
                            {
                                SurveyRow.Add(myViewModel[i].SurveyItem[j].SurveyRow);
                            }
                            if (!string.IsNullOrEmpty(myViewModel[i].SurveyItem[j].SurveyColumn))
                            {
                                SurveyColumn.Add(myViewModel[i].SurveyItem[j].SurveyColumn);
                            }
                        }
                    }
                    SurveyItemRowAndColumn.Add("Row",SurveyRow);
                    SurveyItemRowAndColumn.Add("Column", SurveyColumn);
                    if(myViewModel[i].SurveyOption == "그리드")
                    {
                        SurveySubject.Add("item", SurveyItemRowAndColumn);
                    }   
                    else
                    {
                        SurveySubject.Add("item", SurveyItem);
                    }
                }
                Item.Add(SurveySubject);
            }
            FormData.Add("Title", Title);
            FormData.Add("item", Item);
            string str_json = JsonConvert.SerializeObject(FormData);
            string Url = "&Collection=" + str_json;
            Console.WriteLine(str_json);
            ConnectWeb(Url);
            ManageSql Sql = new ManageSql();
            //Console.WriteLine(s_id);
            //저장
            if (State == 0)
            {
                Sql.insertSurvey(str_json, s_id);
                State = 1;
                return;
            }
            //업데이트
            if(State == 1)
            {
                Sql.updateSurvey(str_json, s_id);
            }

        }   

        #region 데이터 그리드 뷰 제어

        //***********************************************
        //데이터 그리드 뷰의 셀렉트 변경
        //***********************************************
        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SurveyOption값
            try
            {
                switch (myViewModel[DG1.SelectedIndex].SurveyOption)
                {

                    case "객관식1":
                        CreateTableColumn(1);
                        break;
                    case "객관식2":
                        CreateTableColumn(2);
                        break;
                    case "그리드":
                        CreateTableColumn(3);
                        break;
                    default:
                        CreateTableColumn(0);
                        break;
                }
            }catch(Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            

        }
        //***********************************************
        //DG2의 동적 컬럼 생성
        //***********************************************
        private void CreateTableColumn(int columnCase)
        {
            DG2.Columns.Clear();

            BindingList<SurveyViewModel.Item> test = myViewModel[DG1.SelectedIndex].SurveyItem;
            DG2.ItemsSource = myViewModel[DG1.SelectedIndex].SurveyItem;
            DataGridTextColumn textColumn = new DataGridTextColumn();
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            test.Clear();
            //객관식 ||  주관식 columncase 1 ,2
            if (columnCase == 1)
            {
                textColumn.Header = "항목";
                textColumn.Binding = new Binding("SurveyItem");

                DG2.Columns.Add(textColumn);
            }
            else if (columnCase == 2)
            {
                textColumn.Header = "항목";
                textColumn.Binding = new Binding("SurveyItem");
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
        //DG2의 동적 컬럼명 변경
        //***********************************************
        private void ChangedColumnName(int columnCase)
        {
            DG2.Columns.Clear();
            //단답형 OR 주관식
            if (columnCase == 0)
                return;
            
            DG2.ItemsSource = myViewModel[DG1.SelectedIndex].SurveyItem;

            //입력구분

            DataGridTextColumn InputCode = new DataGridTextColumn();
            InputCode.Binding = new Binding("SurveyInputCode");
            InputCode.Header = "입력구분";
            InputCode.IsReadOnly = true;
            DG2.Columns.Add(InputCode);
            // 항목 OR 로우 OR 컬럼
            DataGridTextColumn textColumn = new DataGridTextColumn();
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            //객관식 ||  주관식 columncase 1 ,2
            if (columnCase == 1)
            {
                
                textColumn.Header = "항목";
                textColumn.Binding = new Binding("SurveyItem");

                DG2.Columns.Add(textColumn);
            }
            else if (columnCase == 2)
            {
                textColumn.Header = "항목";
                textColumn.Binding = new Binding("SurveyItem");
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
            try
            {
                DG2.ItemsSource = myViewModel[DG1.SelectedIndex].SurveyItem;
                switch (myViewModel[DG1.SelectedIndex].SurveyOption)
                {

                    case "객관식1":
                        ChangedColumnName(1);
                        break;
                    case "객관식2":
                        ChangedColumnName(2);
                        break;
                    case "그리드":
                        ChangedColumnName(3);
                        break;
                    default:
                        ChangedColumnName(0);
                        break;
                }
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.ToString());
            }
        }
        //***********************************************
        //DG1 Add 버튼
        //***********************************************
        private void DG1_AddButton_Click(object sender, RoutedEventArgs e)
        {
            myViewModel.Insert(myViewModel.Count, new SurveyViewModel { SurveyCode = "S" });
        }

        #endregion

        #region DG2제어
        //***********************************************
        //DG2 Add버튼
        //***********************************************
        private void DG2_AddButton_Click(object sender, RoutedEventArgs e)
        { 
            SurveyViewModel.Item Temp = new SurveyViewModel.Item { SurveyInputCode = ""};
            if(DG1.SelectedIndex < 0)
            {
                return;
            }
            myViewModel[DG1.SelectedIndex].SurveyItem.Insert(
                myViewModel[DG1.SelectedIndex].SurveyItem.Count,
                Temp);
        }
        #endregion

        private void DG1_DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DG2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
