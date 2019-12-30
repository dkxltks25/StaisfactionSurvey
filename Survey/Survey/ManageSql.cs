using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
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

    }
}
