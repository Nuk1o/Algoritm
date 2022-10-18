using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer line = new LineRenderer();    
    [SerializeField] GameObject _cube1, _cube2;
    private void Update()
    {
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.SetPosition(0,_cube1.transform.position);
        line.SetPosition(1, _cube2.transform.position);
    }
}
