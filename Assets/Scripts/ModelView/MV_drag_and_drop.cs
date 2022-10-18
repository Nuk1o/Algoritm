using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class MV_drag_and_drop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private GameObject _right_panel;//Панель где находятся блоки
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private bool block_respawn = false;//Блок был зареспавнен?
    private Vector3 _start_pos_block;//Позиция блока где он был взят
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)//Клик по блоку
    {
        Debug.Log("Click");
        _start_pos_block = gameObject.transform.position;
        if (Input.GetMouseButtonDown(1))//Клик правой кнопкой. Удаляем блок
        {
            Destroy(this.gameObject);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)//Подняли блок
    {
        Debug.Log("Взял");
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)//Отпустили блок
    {
        Debug.Log("Отпустил");
        _canvasGroup.blocksRaycasts = true;
        Vector3 centr = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);//Отцентровали блок
        Vector3 left = new Vector3(-3, gameObject.transform.position.y, gameObject.transform.position.z);//Отцентровали блок
        Vector3 right = new Vector3(3, gameObject.transform.position.y, gameObject.transform.position.z);//Отцентровали блок
        Debug.Log(gameObject.transform.position.x);
        if(gameObject.transform.position.x < 2 && gameObject.transform.position.x > -2)
        {
            Debug.Log("Центр");
            gameObject.transform.position = centr;
        }
        if (gameObject.transform.position.x >= 2)
        {
            Debug.Log("Право");
            gameObject.transform.position = right;
        }
        if (gameObject.transform.position.x <= -2)
        {
            Debug.Log("Лево");
            gameObject.transform.position = left;
        }
        
        
        if (block_respawn == false)//Зареспавнили новый блок в панель
        {
            Instantiate(gameObject, _start_pos_block, quaternion.identity,_right_panel.transform);
            block_respawn = true;
        }
        //Debug.Log("Центр: "+gameObject.transform.position);
        if (gameObject.transform.position.y > 2.7f)//Ограничение по высоте
        {
            gameObject.transform.position = new Vector3(0, 2.7f, 0);
        }

        if (gameObject.transform.position.y < -3.9f)
        {
            gameObject.transform.position = new Vector3(0, -3.9f, 0);
        }
    }

    public void OnDrag(PointerEventData eventData)//Перетаскивает блок
    {
        Debug.Log("Тащит");
        _rectTransform.anchoredPosition += eventData.delta;
    }
}