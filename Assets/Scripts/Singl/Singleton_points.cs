using System.Collections.Generic;
using UnityEngine;

public class Singleton_points : MonoBehaviour
{
   public static Singleton_points instance { get; private set; }
   public static List<Vector3> _pos_points = new List<Vector3>();
   public static List<GameObject> _obj_joint = new List<GameObject>();
   public static List<GameObject> _obj_points = new List<GameObject>();
   public static List<GameObject> _obj_blocks = new List<GameObject>();
       private void Awake()
      {
         if (instance == null)
         {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
         }
         Destroy(this.gameObject);
      }
}