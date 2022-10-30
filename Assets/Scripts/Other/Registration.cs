using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour //Регистрация пользователя
{
    [SerializeField] InputField _login;//Логин
    [SerializeField] InputField _pass;//Пароль
    public void reg_click()
    {
        BD_base base1 = gameObject.GetComponent<BD_base>();
        if (_pass.text.Length < 3 || _login.text.Length < 3)//Если длинна логина или пароля меньше 3х символов
        {
            Debug.Log("Регистрация не работает!");
        }
        try
        {
            var login_str = _login.text;//Значение логина
            var password_str = _pass.text;//Значение пароля
            var salt = new byte[] { 0x000, 0x001, 0x002, 0x003, 0x004, 0x005, 0x006, 0x007, 0x008, 0x009, 0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015 };
            var iv = new byte[] { 0x0016, 0x0017, 0x0018, 0x0019, 0x0020, 0x0021, 0x0022, 0x0023, 0x0024, 0x0025, 0x0026, 0x0027, 0x0028, 0x0029, 0x0030, 0x0031 };

            var encrypted = Pass_encryption.Encrypt(Encoding.UTF8.GetBytes(login_str), password_str, salt, iv);//зашифровал
                                                                                                                  //Debug.Log($"Пароль: {Convert.ToBase64String(encrypted)}");

            var decrypted = Pass_encryption.Decrypt(encrypted, password_str, salt, iv);//Расшифровал
                                                                                          //Debug.Log($"Логин:{Encoding.UTF8.GetString(decrypted)}");

            string login_s = Encoding.UTF8.GetString(decrypted);
            string pass_s = Convert.ToBase64String(encrypted);

            base1.registration_user(login_s, pass_s);
        }
        catch
        {

        }
    }
}
