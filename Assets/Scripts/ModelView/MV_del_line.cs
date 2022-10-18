using UnityEngine;

public class MV_del_line : MonoBehaviour
{
    //Удаление линии
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(CurMousePos, Vector2.zero);
            Debug.Log(hit.collider);
            if (hit.collider != null)
            {
                Debug.Log("Hit: "+hit.collider.gameObject);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
