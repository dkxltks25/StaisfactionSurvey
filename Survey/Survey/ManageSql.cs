using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Survey.ViewModel;
using System.ComponentModel;
namespace Survey
{
    class ManageSql
    {
        private static MySqlCommand cmd;
        private static MySqlConnection conn;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        private static string connectionString;

        /// <summary>
        /// Mysql 커넥션
        /// </summary>
        public ManageSql()
        {
            server = "localhost";
            database = "survey";
            uid = "root";
            password = "dkxltks25";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
        }

        #region 공통 연결
        private void connectionOpen()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        #endregion

        /// <summary>
        /// SHA512 암호화 방식
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
        /// <summary>
        /// SHA256 암호화 방식 주민등록번호 암호화
        /// </summary>
      
        /// <summary>
        /// SHA256 복호화 방식 주민등록번호 복호화
        /// </summary>
        #region 관리자
        //***************************************************
        //관리자 테이블 생성
        //***************************************************
        public void createAdminTable()
        {
            string sql = "create table if not exists SASU_ADM  (\n" +
                        "\tadm_id varchar(5) primary key,\n" +
                        "    adm_pw char(128),\n" +
                        "    adm_name varchar(20),\n" +
                        "    adm_right char(1),\n" +
                        "    datasys datetime,\n" +
                        "    datasys2 varchar(1),\n" +
                        "    datasys3 varchar(20)\n" +
                        ");\n" +
                        " ";
            connectionOpen();
            try
            {
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }

        }
        //***************************************************
        //관리자 아이디 생성
        //***************************************************
        public int createAdmin(AdminViewModel Data, string datasys3)
        {
            string sql = "insert into SASU_ADM (adm_id, adm_pw, adm_name,adm_right, datasys, datasys2, datasys3) " +
                            "values (@v1, @v2,@v3,@v4,now(),'A',@v6);";
            int result = 0;
            try
            {

                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@v1", Data.AdminId);
                cmd.Parameters.AddWithValue("@v2", SHA512(Data.AdminPassword));
                cmd.Parameters.AddWithValue("@v3", Data.AdminName);
                cmd.Parameters.AddWithValue("@v4", Data.AdminSGrade);
                cmd.Parameters.AddWithValue("@v6", datasys3);
                result = cmd.ExecuteNonQuery();
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                result = 0;
            }
            finally
            {
                cmd = null;
                conn.Close();

            }
            return result;

        }
        //***************************************************
        //관리자 정보 업데이트
        //***************************************************
        public int UpdateAdmin(AdminViewModel Data, string sys3)
        {
            string sql = "update SASU_ADM set adm_pw = @pass, adm_name =@name, adm_right=@right, datasys = now() , datasys2 = 'U', datasys3 = @sys3 where adm_id =@id;";
            connectionOpen();
            int result = 0;
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pass", SHA512(Data.AdminPassword));
                cmd.Parameters.AddWithValue("@name", Data.AdminName);
                cmd.Parameters.AddWithValue("@right", Data.AdminSGrade);
                cmd.Parameters.AddWithValue("@sys3", sys3);
                cmd.Parameters.AddWithValue("@id", Data.AdminId);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return 0;
        }
        //***************************************************
        //관리자 조회
        //***************************************************
        public void SelectAdmin(BindingList<AdminViewModel> myViewModel)
        {
            string sql = "Select * from sasu_adm";
            try
            {
                connectionOpen();
                myViewModel.Clear();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine(myViewModel.Count);
                    AdminViewModel temp = new AdminViewModel
                    {
                        AdminCode = "S",
                        AdminId = reader["adm_id"].ToString(),
                        AdminPassword = reader["adm_pw"].ToString(),
                        AdminName = reader["adm_name"].ToString(),
                        AdminDivision = "S",
                        AdminSGrade = reader["adm_right"].ToString(),

                    

                    };
                    myViewModel.Insert(myViewModel.Count, temp);
                }
            } catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
        }
        //***************************************************
        //관리자 정보 삭제
        //***************************************************


        #endregion

        #region 부서 및 학과
        //***************************************************
        //부서 및 학과 생성 result 1 이상 성공 0 실패 
        //*************************************************** 
        public int InsertDept(DeptViewModel data, string admin)
        {
            string sql = "insert into SASU_DEPT values(@id,@name,now(),'A',@admin)";
            int result = 0;
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", data.DeptId);
                cmd.Parameters.AddWithValue("@name", data.DeptName);
                cmd.Parameters.AddWithValue("@admin", admin);
                result = cmd.ExecuteNonQuery();
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                result = 0;
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return result;
        }
        //***************************************************
        //부서 및 학과 업데이트 result 1 이상 성공 0 실패 
        //*************************************************** 
        public int UpdateDept(DeptViewModel data, string admin)
        {
            
            string sql = "update SASU_DEPT set dept_name = @name, datasys1 = now(),datasys2 = 'U',datasys3=@admin where DEPT_id = @id";
            int result = 0;
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", data.DeptName);
                cmd.Parameters.AddWithValue("@admin", admin);
                cmd.Parameters.AddWithValue("@id", data.DeptId);
                Console.WriteLine(cmd.CommandText);
                result = cmd.ExecuteNonQuery();
                Console.WriteLine("-------------성공");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("-------------a-a");
                result = 0;
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return result;
        }
        //***************************************************
        //부서 및 학과 삭제 result 1 이상 성공 0 실패 
        //*************************************************** 
        public int DeleteDept(DeptViewModel data)
        {
            string sql = "delete from SASU_DEPT where dept_id = @id";
            int result = 0;
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                result = 0;
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return result;
        }
        //***************************************************
        //부서 및 학과 조회  
        //*************************************************** 
        public void SelectDept(BindingList<DeptViewModel> myViewModel,string id)
        {
            string sql = "select * from SASU_DEPT where dept_id like '%"+id+"%'";
            Console.WriteLine(sql);
            try
            {
                myViewModel.Clear();
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.FieldCount);
                    myViewModel.Insert(myViewModel.Count, new DeptViewModel
                    {
                        DeptCode = "S",
                        DeptId = reader["Dept_id"].ToString(),
                        DeptName = reader["Dept_name"].ToString()
                    });
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
        }
        public List<string> SelectDeptNameList()
        {
            string sql = "SELECT DEPT_NAME FROM SASU_DEPT;";
            List<string> TempList = new List<string>();
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TempList.Add(reader["DEPT_NAME"].ToString());
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return TempList;
        }
        #endregion

        #region 학생
        //***************************************************
        //학생 생성 result 1 이상 성공 0 실패 
        //*************************************************** 
        public int CreateStudent(StudentAdminViewModel Data,string Admin) 
        {
            string sql = "insert into SASU_STD values" +
                "(@num,@resno,@name,@sex,@dept,@phone,@email,@password,now(),'A',@admin); ";
            int result = 0;
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@num", Data.StudentNumber);
                cmd.Parameters.AddWithValue("@resno", Data.StudentResNumber);
                cmd.Parameters.AddWithValue("@name", Data.StudentName);
                cmd.Parameters.AddWithValue("@sex", Data.StudentSex);
                cmd.Parameters.AddWithValue("@dept", Data.StudentDept);
                cmd.Parameters.AddWithValue("@phone", Data.StudentPhone);
                cmd.Parameters.AddWithValue("@email", Data.StudentEmail);
                cmd.Parameters.AddWithValue("@password", SHA512(Data.StudentResNumber));
                cmd.Parameters.AddWithValue("@admin", Admin);
                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                result = 0;
            }
            finally
            {
                cmd = null;
                conn.Close();
                
            }
            return result;
        }
        //***************************************************
        //학생 업데이트 result 1 이상 성공 0 실패 
        //*************************************************** 
        public int UpdateStudent(StudentAdminViewModel Data,string admin)
        {
            int result = 0;
            string sql = "update SASU_STD set " +
                "stu_resno = @num, " +
                "stu_name = @name, " +
                "stu_resno = @resno " +
                "stu_sex = @sex, "+
                "stu_dept = @dept, "+
                "stu_phone = @phone "+
                "stu_email =@email ,"+
                "stu_password = @password "+
                "datasys1 = now(), " +
                "datasys2= 'U', " +
                "datasys3 = @admin " +
                "where stu_stuno = @num";
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@num", Data.StudentNumber);
                cmd.Parameters.AddWithValue("@resno", Data.StudentResNumber);
                cmd.Parameters.AddWithValue("@name", Data.StudentName);
                cmd.Parameters.AddWithValue("@sex", Data.StudentSex);
                cmd.Parameters.AddWithValue("@dept", Data.StudentDept);
                cmd.Parameters.AddWithValue("@phone", Data.StudentPhone);
                cmd.Parameters.AddWithValue("@email", Data.StudentEmail);
                cmd.Parameters.AddWithValue("@password", SHA512(Data.StudentPassword));
                cmd.Parameters.AddWithValue("@admin", admin);
                cmd.ExecuteNonQuery();
                result = 1;
                
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                result = 0;
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return result;
        }
        //***************************************************
        //학생 삭제 result 1 이상 성공 0 실패 
        //*************************************************** 
        public int DeleteStudent(StudentAdminViewModel Data)
        {
            int result = 0;
            string sql = "delete from SASU_STD WHERE stu_stuno =@num;";
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@num", Data.StudentNumber);
                cmd.ExecuteNonQuery();
                result = 1;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                result = 0;
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return result;
        }
        //***************************************************
        //학생 조회
        //*************************************************** 
        public void SelectStudent(BindingList<StudentAdminViewModel> myViewModel)
        {
            string sql = "Select * from SASU_STD";
            try
            {
                connectionOpen();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader =  cmd.ExecuteReader();
                myViewModel.Clear();
                while (reader.Read())
                {
                    //stu_stuno, stu_resno, stu_name, stu_sex, stu_dept, stu_phone, stu_email, stu_password, datasys1, datasys2, datasys3
                    string ResNo = reader["stu_resno"].ToString();

                    StudentAdminViewModel Data = new StudentAdminViewModel
                    {
                        StudentCode = "S",
                        StudentNumber = reader["stu_stuno"].ToString(),
                        StudentResNumber1 = ResNo.Substring(0, 6),
                        StudentResNumber2 = ResNo.Substring(6),
                        StudentEmail = reader["stu_email"].ToString(),
                        StudentName = reader["stu_name"].ToString(),
                        StudentPassword = reader["stu_password"].ToString(),
                        StudentPhone = reader["stu_phone"].ToString(),
                        StudentSex = reader["stu_sex"].ToString(),
                        StudentDept = reader["stu_dept"].ToString(),
                    };
                    myViewModel.Insert(myViewModel.Count, Data);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
        }
        #endregion

        #region SelectSurveyPage query
        //***************************************************
        //설문지 입력 1:성공 0:실패
        //*************************************************** 
        public int InsertSelectSurvey(SelectSurveyViewModel data,string admin)
        {
            connectionOpen();
            string sql = "insert into sasu_suv(adm_id, suv_name, suv_descrip, suv_stime, suv_ftime, datasys1, datasys2, datasys3) " +
                "value(@adminName, @SurveyName,@SurveyDescrip,@Stime,@Ftime,now(),'A',@admin);";
            int result = 0;
            try
            {
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@adminName", "dkxltks25");
                cmd.Parameters.AddWithValue("@SurveyName",data.SurveyName );
                cmd.Parameters.AddWithValue("@SurveyDescrip", data.SurveyDescrip);
                cmd.Parameters.AddWithValue("@Stime", data.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Ftime", data.FinishTime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@admin", admin);
                cmd.ExecuteNonQuery();
                result = 1;
            }catch(Exception e)
            {
                result = 0;
                Console.WriteLine(e.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return result;
        }
        //***************************************************
        //설문지 업데이트 1:성공 0:실패
        //*************************************************** 
        public int UpdateSelectSurvey(SelectSurveyViewModel data, string admin)
        {
            string sql = "update sasu_suv set \n" +
                     "suv_name = @name,\n" +
                     "suv_descrip = @descrip,\n" +
                     "suv_stime = @st,\n" +
                     "suv_ftime = @ft,\n" +
                     "datasys1 = now(),\n" +
                     "datasys2 = 'U',\n" +
                     "datasys3 = @admin where suv_suvId = @id;";
            int result = 0;
            connectionOpen();
            try
            {
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", data.SurveyName);
                cmd.Parameters.AddWithValue("@descrip", data.SurveyDescrip);
                cmd.Parameters.AddWithValue("@st", data.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@ft", data.FinishTime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@admin", admin);
                cmd.Parameters.AddWithValue("@id", data.SurveyId);
                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
                Console.WriteLine(e.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return result;
        }
        //***************************************************
        //설문지 삭제 1:성공 0:실패
        //*************************************************** 
        public int DeleteSelectSurvey(string Dataid)
        {
            string sql = "Delete from sasu_suv where suv_suvid =" + Dataid;
            connectionOpen();
            int result = 0;
            try
            {
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                result = 1; 
            }catch(Exception e)
            {
                result = 0;
                Console.WriteLine(e.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
            return result; 
        }
        //***************************************************
        //설문지 조회 1:성공 0:실패
        //*************************************************** 
        public void SelectSelectSurvey(BindingList<SelectSurveyViewModel> myViewModel)
        {
            string sql = "Select * from sasu_suv";
            connectionOpen();
            try
            {
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                myViewModel.Clear();
                while (reader.Read())
                {
                    SelectSurveyViewModel Temp = new SelectSurveyViewModel
                    {
                        SurveyCode = "S",
                        SurveyName = reader["suv_name"].ToString(),
                        SurveyDescrip = reader["suv_descrip"].ToString(),
                        SurveyId = reader["suv_suvid"].ToString(),
                        StartTime = Convert.ToDateTime(reader["suv_stime"]),
                        FinishTime = Convert.ToDateTime(reader["suv_ftime"]),
                    };
                    myViewModel.Insert(myViewModel.Count, Temp);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                cmd = null;
                conn.Close();
            }
        }
        #endregion
    }
}
