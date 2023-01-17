using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace visual_programming_butunleme
{
    public static class Veritabani
    {
        public static MySqlConnection connection = new MySqlConnection("Server=localhost;Database=okul;Uid=root;Pwd='';AllowUserVariables=True;UseCompression=True");
    }
}
