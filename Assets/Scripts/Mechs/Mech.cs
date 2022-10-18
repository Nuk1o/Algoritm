using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using list_n;

public class Mech : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private LineRenderer line = new LineRenderer();
    private RectTransform _rect;
    CompositeDisposable disposables = new CompositeDisposable();

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Взял");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Тащит");
        _rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Отпустил");        
        //_controll.add_list_c(gameObject);
        Debug.Log(gameObject);
    }

    public void line_b(GameObject _cube1, GameObject _cube2)
    {
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.SetPosition(0, _cube1.transform.position);
        line.SetPosition(1, _cube2.transform.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Клик");
    }
}
