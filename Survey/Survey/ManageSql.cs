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
            createAdminTable();
        }

        #region 공통 연결
        private void connectionOpen()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
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
                cmd = new MySqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
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
        //***************************************************
        //관리자 아이디 생성
        //***************************************************
        public int createAdmin(AdminViewModel Data,string datasys3)
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
        //관리자 정보 업데이트
        //***************************************************
        public int UpdateAdmin(AdminViewModel Data,  string sys3)
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
            catch(Exception e1)
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
                    AdminViewModel temp =  new AdminViewModel
                    {
                        AdminCode = "S",
                        AdminId = reader["adm_id"].ToString(),
                        AdminPassword = reader["adm_pw"].ToString(),
                        AdminName = reader["adm_name"].ToString()

                    };
                    myViewModel.Insert(myViewModel.Count, temp);
                }
            }catch(Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        //***************************************************
        //관리자 정보 삭제
        //***************************************************


        #endregion
    }
}
