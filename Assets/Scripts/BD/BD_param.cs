using MySql.Data.MySqlClient;
using UnityEngine;

public class BD_param : MonoBehaviour
{
    public static MySqlConnection BD_con()
    {
        string ds = "127.0.0.1";
        string port = "3306";
        string usr = "root";
        string pass = "root";
        string db = "algoritm";
        return BD_connection.BD_con(ds,port,usr,pass,db);
    }
}
