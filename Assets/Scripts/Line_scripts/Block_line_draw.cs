using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block_line_draw : MonoBehaviour, IPointerDownHandler
{
    private LineRenderer lineRenderer;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Singleton_points._pos_points.Count < 2)
        {
            Singleton_points._pos_points.Add(this.gameObject.transform.position);
            Singleton_points._obj_joint.Add(gameObject.transform.parent.gameObject);
            Singleton_points._obj_points.Add(gameObject.transform.gameObject);
            Singleton_points._obj_blocks.Add(gameObject.transform.parent.gameObject);
        }

        if (Singleton_points._pos_points.Count == 2)
        {
            lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
            lineRenderer.startWidth = .1f;
            lineRenderer.endWidth = .1f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderer.material.color = Color.black;

            if ((Singleton_points._obj_blocks[1].transform.position.x < Singleton_points._obj_blocks[0].transform.position.x) || (Singleton_points._obj_blocks[0].transform.position.x < Singleton_points._obj_blocks[1].transform.position.x))
            {                
                if ((Singleton_points._obj_points[0].name == "point_left" && Singleton_points._obj_points[1].name == "point_top")|| (Singleton_points._obj_points[0].name == "point_left" && Singleton_points._obj_points[1].name == "point_down"))
                {
                    lineRenderer.positionCount = 3;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }
                else if ((Singleton_points._obj_points[0].name == "point_left" && Singleton_points._obj_points[1].name == "point_right")||(Singleton_points._obj_points[0].name == "point_right" && Singleton_points._obj_points[1].name == "point_left"))
                {
                    lineRenderer.positionCount = 4;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3((Singleton_points._pos_points[0].x + Singleton_points._pos_points[1].x) / 2, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(2, new Vector3((Singleton_points._pos_points[1].x + Singleton_points._pos_points[0].x) / 2, Singleton_points._pos_points[1].y, 0));
                    lineRenderer.SetPosition(3, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }
                else if ((Singleton_points._obj_points[0].name == "point_left" && Singleton_points._obj_points[1].name == "point_left") && (Singleton_points._obj_blocks[1].transform.position.x < Singleton_points._obj_blocks[0].transform.position.x))
                {
                    lineRenderer.positionCount = 4;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[1].x - 0.5f, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[1].x - 0.5f, Singleton_points._pos_points[1].y, 0));
                    lineRenderer.SetPosition(3, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }

                //Обратный вид
                else if ((Singleton_points._obj_points[0].name == "point_top" && Singleton_points._obj_points[1].name == "point_left")|| (Singleton_points._obj_points[0].name == "point_down" && Singleton_points._obj_points[1].name == "point_left"))
                {
                    lineRenderer.positionCount = 3;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[1].y, 0));
                    lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }

                else if ((Singleton_points._obj_points[0].name == "point_left" && Singleton_points._obj_points[1].name == "point_left") && (Singleton_points._obj_blocks[0].transform.position.x < Singleton_points._obj_blocks[1].transform.position.x))
                {
                    lineRenderer.positionCount = 4;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[0].x - 0.5f, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[0].x - 0.5f, Singleton_points._pos_points[1].y, 0));
                    lineRenderer.SetPosition(3, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }
            }

            if((Singleton_points._obj_blocks[1].transform.position.x > Singleton_points._obj_blocks[0].transform.position.x) || (Singleton_points._obj_blocks[0].transform.position.x > Singleton_points._obj_blocks[1].transform.position.x))
            {
                if ((Singleton_points._obj_points[0].name == "point_right" && Singleton_points._obj_points[1].name == "point_top") || (Singleton_points._obj_points[0].name == "point_right" && Singleton_points._obj_points[1].name == "point_down"))
                {
                    lineRenderer.positionCount = 3;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }
                else if ((Singleton_points._obj_points[0].name == "point_right" && Singleton_points._obj_points[1].name == "point_right") && (Singleton_points._obj_blocks[1].transform.position.x > Singleton_points._obj_blocks[0].transform.position.x))
                {
                    lineRenderer.positionCount = 4;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[1].x + 0.5f, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[1].x + 0.5f, Singleton_points._pos_points[1].y, 0));
                    lineRenderer.SetPosition(3, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }

                //Обратный вид
                else if ((Singleton_points._obj_points[0].name == "point_top" && Singleton_points._obj_points[1].name == "point_right") || (Singleton_points._obj_points[0].name == "point_down" && Singleton_points._obj_points[1].name == "point_right"))
                {
                    lineRenderer.positionCount = 3;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[1].y, 0));
                    lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }

                else if ((Singleton_points._obj_points[0].name == "point_right" && Singleton_points._obj_points[1].name == "point_right") && (Singleton_points._obj_blocks[1].transform.position.x < Singleton_points._obj_blocks[0].transform.position.x))
                {
                    lineRenderer.positionCount = 4;
                    lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[0].x + 0.5f, Singleton_points._pos_points[0].y, 0));
                    lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[0].x + 0.5f, Singleton_points._pos_points[1].y, 0));
                    lineRenderer.SetPosition(3, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
                }
            }

            else if((Singleton_points._obj_points[0].name == "point_right" && Singleton_points._obj_points[1].name == "point_right"))
            {
                lineRenderer.positionCount = 4;
                lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[0].x + 0.5f, Singleton_points._pos_points[0].y, 0));
                lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[0].x + 0.5f, Singleton_points._pos_points[1].y, 0));
                lineRenderer.SetPosition(3, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
            }

            else if ((Singleton_points._obj_points[0].name == "point_left" && Singleton_points._obj_points[1].name == "point_left"))
            {
                lineRenderer.positionCount = 4;
                lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[0].x - 0.5f, Singleton_points._pos_points[0].y, 0));
                lineRenderer.SetPosition(2, new Vector3(Singleton_points._pos_points[0].x - 0.5f, Singleton_points._pos_points[1].y, 0));
                lineRenderer.SetPosition(3, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
            }

            else
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, new Vector3(Singleton_points._pos_points[0].x, Singleton_points._pos_points[0].y, 0));
                lineRenderer.SetPosition(1, new Vector3(Singleton_points._pos_points[1].x, Singleton_points._pos_points[1].y, 0));
            }

            lineRenderer.AddComponent<Del_line>();
            lineRenderer.AddComponent<BoxCollider2D>();


            Singleton_points._pos_points.RemoveRange(0, 2);
            Singleton_points._obj_points.RemoveRange(0, 2);
            Singleton_points._obj_blocks.RemoveRange(0, 2);
            Debug.Log("Объектов в массиве: " + Singleton_points._obj_joint.Count);

            GameObject _block1, _block2;
            foreach (var VARIABLE in Singleton_points._obj_joint)
            {
                Debug.Log("Имя: " + VARIABLE.gameObject.name);
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
        Debug.Log("Counts: " + Singleton_points._pos_points.Count);
    }
}
