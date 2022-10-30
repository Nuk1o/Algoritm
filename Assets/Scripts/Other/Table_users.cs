using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Table_users : MonoBehaviour //Запись пользователей в таблицу
{
    [SerializeField] GameObject _place;
    [SerializeField] Text _login;
    [SerializeField] Text _role;

    private void Start()
    {
        BD_base base1 = gameObject.AddComponent<BD_base>();
        int count_usr = base1.count_a_users();
        Debug.Log(count_usr);
        for (int i = 1; i <= count_usr; i++)
        {
            string name = base1.login_usr(i);
            Text _add_new = Instantiate(_login, _login.transform.position - new Vector3(0,i*100,0),quaternion.identity, _place.transform);
            _add_new.text = name;
        }

        for (int i = 1; i <= count_usr; i++)
        {
            string name = base1.role_usr_id(i);
            Text _add_new = Instantiate(_role, _role.transform.position - new Vector3(0, i * 100, 0), quaternion.identity, _place.transform);
            _add_new.text = name;
        }
    }
}
