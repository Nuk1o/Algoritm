using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class Login_view : MonoBehaviour
{
    [SerializeField] InputField _login;
    [SerializeField] InputField _password;
    [Space]
    [Header("Menu")]
    [SerializeField] GameObject _auth;
    [SerializeField] GameObject _admin;
    [SerializeField] GameObject _student;
    public void btn_click_login()
    {
        BD_base base1 = new BD_base();
        var login_str = _login.text;
        var password_str = _password.text;        
        var salt = new byte[] { 0x000, 0x001, 0x002, 0x003, 0x004, 0x005, 0x006, 0x007, 0x008, 0x009, 0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015 };
        var iv = new byte[] { 0x0016, 0x0017, 0x0018, 0x0019, 0x0020, 0x0021, 0x0022, 0x0023, 0x0024, 0x0025, 0x0026, 0x0027, 0x0028, 0x0029, 0x0030, 0x0031 };

        var encrypted = Pass_encryption.Encrypt(Encoding.UTF8.GetBytes(login_str),password_str,salt,iv);//зашифровал
        //Debug.Log($"Пароль: {Convert.ToBase64String(encrypted)}");
        
        var decrypted = Pass_encryption.Decrypt(encrypted, password_str, salt, iv);//Расшифровал
        //Debug.Log($"Логин:{Encoding.UTF8.GetString(decrypted)}");
        
        string login_s = Encoding.UTF8.GetString(decrypted);
        string pass_s =  Convert.ToBase64String(encrypted);
        string role = base1.login_user(pass_s);
        Debug.Log(role);

        switch (role)
        {
            case null:
                Debug.Log("Вход не возможен");
                break;
            case "admin":
                _auth.SetActive(false);
                _admin.SetActive(true);
                break;
            case "student":
                _auth.SetActive(false);
                _student.SetActive(true);
                break;
        }
    }
}
