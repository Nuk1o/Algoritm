using UnityEngine;
using UnityEngine.EventSystems;

public class MV_point_enter_exit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Точки")]
    [SerializeField] private GameObject point_top;
    [SerializeField] private GameObject point_down;
    [SerializeField] private GameObject point_left;
    [SerializeField] private GameObject point_right;
    public void OnPointerEnter(PointerEventData eventData)
    {
        point_top.SetActive(true);
        point_down.SetActive(true);
        point_left.SetActive(true);
        point_right.SetActive(true);
        Debug.Log("Мышка внутри блока");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        point_top.SetActive(false);
        point_down.SetActive(false);
        point_left.SetActive(false);
        point_right.SetActive(false);
        Debug.Log("Мышка вышла за блок");
    }
}
