using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MV_point_line : MonoBehaviour, IPointerDownHandler
{
    private LineRenderer lineRenderer;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("click_point");
        if (Singleton_points._pos_points.Count < 2)
        {
            Singleton_points._pos_points.Add(this.gameObject.transform.position);
            Singleton_points._obj_joint.Add(gameObject.transform.parent.gameObject);
        }
        
        if (Singleton_points._pos_points.Count == 2)
        {
            Debug.Log("Рисовалка вкл");
            lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
            lineRenderer.AddComponent<Del_line>();
            lineRenderer.AddComponent<BoxCollider2D>();
            
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
            lineRenderer.startWidth = .05f;
            lineRenderer.endWidth = .05f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;   
            lineRenderer.material.color = Color.black;
            Debug.Log("Pos 1: "+Singleton_points._pos_points[0]);
            Debug.Log("Pos 2: "+Singleton_points._pos_points[1]);
            lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x,Singleton_points._pos_points[0].y,0));
            lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[1].x,Singleton_points._pos_points[1].y,0));
            Singleton_points._pos_points.RemoveRange(0,2);
            Debug.Log("Объектов в массиве: "+Singleton_points._obj_joint.Count);

            GameObject _block1, _block2;
            foreach (var VARIABLE in Singleton_points._obj_joint)
            {
                Debug.Log("Имя: "+VARIABLE.gameObject.name);
                Debug.Log(VARIABLE.gameObject.transform.GetChild(0).gameObject.name);
            }

            _block1 = Singleton_points._obj_joint[0];
            _block2 = Singleton_points._obj_joint[1];
            
            Singleton._linkedList.Add(_block1);
            Singleton._linkedList.Add(_block2);
            Singleton_points._obj_joint.Clear();
            foreach (var VARIABLE in Singleton._linkedList)
            {
                Debug.Log(VARIABLE.gameObject.tag);
                Debug.Log(VARIABLE.gameObject.transform.GetChild(0).gameObject.name);
            }
            //_objects.Clear();
        }
        Debug.Log("Counts: "+Singleton_points._pos_points.Count);
    }
} 