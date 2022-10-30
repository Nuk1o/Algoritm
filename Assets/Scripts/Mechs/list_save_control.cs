using System.Collections.Generic;
using UnityEngine;
public class List_save_control : MonoBehaviour
{
    public List<GameObject> _list = new List<GameObject>();

    private void Update()
    {
        //Debug.Log(_list.Count);
        if (_list.Count >= 2)
        {
            GameObject _g1 = _list[0];
            GameObject _g2 = _list[1];
            Mech mech = new Mech();
            mech.line_b(_g1, _g2);
        }
    }

    public void add_list_c(GameObject _obj)
    {
        _list.Add(_obj);
        Debug.Log("Кол-во: " + _list.Count);
    }
}
