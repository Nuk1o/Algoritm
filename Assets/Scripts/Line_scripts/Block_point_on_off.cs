using UnityEngine;
using UnityEngine.EventSystems;
public class Block_point_on_off : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject _point_up, _point_down, _point_left, _point_right;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _point_up.SetActive(true);
        _point_down.SetActive(true);
        _point_left.SetActive(true);
        _point_right.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _point_up.SetActive(false);
        _point_down.SetActive(false);
        _point_left.SetActive(false);
        _point_right.SetActive(false);
    }
    void Start()
    {
        _point_up.SetActive(false);
        _point_down.SetActive(false);
        _point_left.SetActive(false);
        _point_right.SetActive(false);
    }
}
