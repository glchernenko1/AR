using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadCollectionScript : MonoBehaviour
{
    public bool[] collectionOpened;

    public GameObject Container;
    public Button ButtonPrefab;
    private List<Button> Buttons;
    private float scale = 0.01231527f;

    public void setOpened(int i)
    {
        Debug.Log(collectionOpened);
        collectionOpened[i] = true;

        Debug.Log("*opening*");
        Debug.Log(collectionOpened);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start!");
        collectionOpened = new bool []{ false, true, false, true, false, true, false, true };

        Buttons = new List<Button>();
        string path = "Prefebs/";
        var prefabs = Resources.LoadAll(path);
        foreach (var p in prefabs)
        {
            Button button = GameObject.Instantiate(ButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            button.transform.localScale = new Vector3(scale, scale, scale);
            button.transform.SetParent(Container.transform);

            //interface
            button.GetComponentInChildren<Text>().text = p.name;

            GameObject panel = new GameObject("Panel");
            Image i = panel.AddComponent<Image>();
            Sprite tex = Resources.Load<Sprite>("Markers/illustration1");
            
            Debug.Log(tex);
            i.overrideSprite = tex;
            
            panel.transform.localScale = new Vector3(scale, scale, scale);
            panel.transform.SetParent(button.transform);

            

            Buttons.Add(button);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
