using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MV_text_input : MonoBehaviour, IPointerDownHandler
{
    [Header("Текст в блок")]
    [SerializeField] private GameObject _go_txt;
    [SerializeField] private Text _txt;
    [SerializeField] private InputField _input;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.clickCount == 2) {
            Debug.Log("Click_tetx");
            _input.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Пробел");
            }
            else
            {
                _go_txt.name = _input.text;
                _txt.text = _input.text;
                _input.gameObject.SetActive(false);
            }
        }
    }
}
