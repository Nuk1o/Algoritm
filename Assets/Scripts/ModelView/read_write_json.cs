using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class read_write_json : MonoBehaviour//Чтение и запись в json файл
{
    [SerializeField] private Text _work_txt;
    [SerializeField] private Button _btn_prack;
    [Header("Result")]
    [SerializeField] private GameObject _Result_go;
    [SerializeField] private Text _result_txt;
    private List<string> _text_s = new List<string>();
    private List<string> _equal_s = new List<string>();
    private string name_work;

    private void Update()
    {
        _btn_prack.onClick.AddListener(delegate { Load_work(); });
    }

    private void Load_work()
    {
        _work_txt.text = "Загрузил";
        name_work = "MyBlock";
    }

    public void Save_json()
    {
        string PathJson = Path.Combine(Application.dataPath, $"{name_work}.json");
        foreach (var VARIABLE in Singleton._linkedList)
        {
            Debug.Log("JSON TAG: "+VARIABLE.gameObject.tag);
            Debug.Log("JSON NAME: "+VARIABLE.gameObject.transform.GetChild(0).gameObject.name);
            _text_s.Add(VARIABLE.gameObject.tag);
            _text_s.Add(VARIABLE.gameObject.transform.GetChild(0).gameObject.name);
        }
        Block_struct _blockStruct = new Block_struct()
        {
            _joining = this._text_s
        };
        string json = JsonUtility.ToJson(_blockStruct, true);
        File.WriteAllText(PathJson,json);
    }

    public void Read_json()
    {
        string PathJson = Path.Combine(Application.dataPath, $"{name_work}.json");
        string json = File.ReadAllText(PathJson);
        Block_struct _blockStruct = JsonUtility.FromJson<Block_struct>(json);
        this._text_s = _blockStruct._joining;
        
        foreach (var VARIABLE in Singleton._linkedList)
        {
            _equal_s.Add(VARIABLE.gameObject.tag);
            _equal_s.Add(VARIABLE.gameObject.transform.GetChild(0).gameObject.name);
        }
        
        bool isEqual = _text_s.SequenceEqual(_equal_s);
        Debug.Log(isEqual);
        if (isEqual == true)
        {
            _Result_go.SetActive(true);
            _result_txt.text = "<color=green>Верно</color>";
            Debug.Log("Верно сделал");
        }
        else
        {
            _Result_go.SetActive(true);
            _result_txt.text = "<color=red>Неверно</color>";
            Debug.Log("Неверно сделал");
        }
        _equal_s.Clear();
        _text_s.Clear();
    }
}

[System.Serializable]
public struct Block_struct
{
    public List<string> _joining;
}