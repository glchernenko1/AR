using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public int index;
    LoadCollectionScript lcs = new LoadCollectionScript();
    bool first = true;

    private void Awake()
    {
        if (!first)
            lcs.setOpened(index);
        first = false;
    }

    public void TestWrapper()
    {
       /* Wrapper wrapper = new Wrapper();
        var tmp = wrapper.Login("Tester33", "123123");
        Debug.Log(tmp);*/
    }
}
