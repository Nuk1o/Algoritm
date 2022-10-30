using System;
using SimpleAlgorithmsApp;
using UnityEngine;

class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public static LinkedList<GameObject> _linkedList = new LinkedList<GameObject>();
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