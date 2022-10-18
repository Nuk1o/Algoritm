using UnityEngine;
using UnityEngine.EventSystems;

public class Items_slot : MonoBehaviour, IDropHandler
{
    //Блок внутри объекта
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Подкинули");
    }
}
