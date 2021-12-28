using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class LoadCollectionScript : MonoBehaviour
{
    public Text progress;
    public RectTransform progressBar;

    public bool[] collectionOpened ;
    private RectTransform info_panel;
    private RectTransform control_panel;
    private RectTransform collection_panel;

    public GameObject Container;
    public Button ButtonPrefab;
    public Text collectionElementText;
    public Sprite locTex;

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

        info_panel = GameObject.Find("Panel_collection_element").GetComponent<RectTransform>();
        control_panel = GameObject.Find("Panel_control").GetComponent<RectTransform>();
        collection_panel = GameObject.Find("Panel_collection").GetComponent<RectTransform>();

        collectionOpened = new bool[] { false, false, false, false, false, false, false, false };
        var loadedModels = APIcontrol.LoadObject();
        progress.text = loadedModels.Length + " / " + collectionOpened.Length + " ☆ ";
        var coef = loadedModels.Length / collectionOpened.Length * 100;
        progressBar.sizeDelta = new Vector2(progressBar.rect.width * coef, progressBar.rect.height);
        for (int i = 0; i < loadedModels.Length; i++)
            collectionOpened[loadedModels[i]] = true;

        Buttons = new List<Button>();
        string path = "Prefebs/";
        var prefabs = Resources.LoadAll(path);

        // Debug.Log(collectionOpened);

        // show collection
        for (int i = 0; i < prefabs.Length; i++)
        {
            var prefabItem = prefabs[i];
            Button button = GameObject.Instantiate(ButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            button.transform.localScale = new Vector3(scale, scale, scale);
            button.transform.SetParent(Container.transform);

            // text
            button.GetComponentInChildren<Text>().text = prefabItem.name;

            // image 
            GameObject imgPanel = new GameObject("Panel");
            Image img = imgPanel.AddComponent<Image>();
            Sprite tex = Resources.Load<Sprite>("Markers/" + prefabItem.name);
            img.overrideSprite = tex;
            imgPanel.transform.localScale = new Vector3(scale, scale, scale);
            imgPanel.transform.SetParent(button.transform);

            //disabling button
            if (!collectionOpened[i])
            {
                button.interactable = false;
                // loc logo
                GameObject locPanel = new GameObject("Panel");
                Image locImg = locPanel.AddComponent<Image>();
                locImg.overrideSprite = locTex;
                locPanel.transform.localScale = new Vector3(scale * 0.4f, scale * 0.5f, scale);
                locPanel.transform.position = new Vector3(-50 / 81.2f, 45 / 81.2f, 0);
                    //+= new Vector3(-50, 45, 0);
                locPanel.transform.SetParent(button.transform);
            }

            button.onClick.AddListener(() => { ClickHandle(prefabItem.name, prefabItem); });

            Buttons.Add(button);
        }

    }

    public void ClickHandle(string s, Object pref)
    {
        info_panel.DOAnchorPos(new Vector2(0, 0), 0.5f);
        control_panel.DOAnchorPos(new Vector2(0, -500), 1);
        collection_panel.DOAnchorPos(new Vector2(0, -1000), 1);
        GameObject o = Instantiate(pref, new Vector3(0, 0, 10), Quaternion.identity) as GameObject;

        o.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        o.transform.position = new Vector3(0, -1000 / 81.2f, 0);
        o.transform.SetParent(info_panel);

        collectionElementText.text = s;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
