using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public int index;
    bool first = true;

    public void Update()
    {
        if (!first)
        {
            Debug.Log("index: "+index);
            APIcontrol.SaveObject(index);
            first = true;
        }
    }

    public void Start()
    {
        first = false;
    }

    /*public void Awake()
    {
        Debug.Log("Awake" + index);
        if (!first)
        {
            Debug.Log("Awake");
            APIcontrol.SaveObject(index);
        }
            //saveObject.GetComponent<APIcontrol>().SaveObject(index);
        first = false;
    }*/
}
