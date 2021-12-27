using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public RectTransform AR_panel, main_panel, collection_panel, profile_panel;
    public RectTransform control_panel;
    public Button main_button;
    public Button collection_button;
    public Button profile_button;
    enum Panel
    {
        AR,
        main,
        collection,
        profile
    }
    private Panel last_panel;

    // Start is called before the first frame update
    void Start()
    {
        last_panel = Panel.main;
        main_button.interactable = false;
    }

    public void SelectAR()
    {
        control_panel.DOAnchorPos(new Vector2(500, -320), 0.5f);

        AR_panel.DOAnchorPos(Vector2.zero, 0.5f);
        main_panel.DOAnchorPos(new Vector2(500, 0), 0.5f);
        collection_panel.DOAnchorPos(new Vector2(1000, 0), 0.5f);
        profile_panel.DOAnchorPos(new Vector2(1500, 0), 0.5f);

        main_button.interactable = true;
        collection_button.interactable = true;
        profile_button.interactable = true;
    }
    public void SelectMain()
    {
        control_panel.DOAnchorPos(new Vector2(0, -320), 0.5f);

        AR_panel.DOAnchorPos(new Vector2(-500, 0), 0.5f);
        main_panel.DOAnchorPos(Vector2.zero, 0.5f);
        collection_panel.DOAnchorPos(new Vector2(500, 0), 0.5f);
        profile_panel.DOAnchorPos(new Vector2(1000, 0), 0.5f);

        last_panel = Panel.main;
        main_button.interactable = false;
        collection_button.interactable = true;
        profile_button.interactable = true;
    }
    public void SelectCollection()
    {
        control_panel.DOAnchorPos(new Vector2(0, -320), 0.5f);

        AR_panel.DOAnchorPos(new Vector2(-1000, 0), 0.5f);
        main_panel.DOAnchorPos(new Vector2(-500, 0), 0.5f);
        collection_panel.DOAnchorPos(Vector2.zero, 0.5f);
        profile_panel.DOAnchorPos(new Vector2(500, 0), 0.5f);

        last_panel = Panel.collection;
        collection_button.interactable = false;
        profile_button.interactable = true;
        main_button.interactable = true;
    }
    public void SelectProfile()
    {
        control_panel.DOAnchorPos(new Vector2(0, -320), 0.5f);

        AR_panel.DOAnchorPos(new Vector2(-1500, 0), 0.5f);
        main_panel.DOAnchorPos(new Vector2(-1000, 0), 0.5f);
        collection_panel.DOAnchorPos(new Vector2(-500, 0), 0.5f);
        profile_panel.DOAnchorPos(Vector2.zero, 0.5f);

        last_panel = Panel.profile;
        profile_button.interactable = false;
        collection_button.interactable = true;
        main_button.interactable = true;
    }

    public void back()
    {
        switch (last_panel)
        {
            case Panel.main:
                SelectMain();
                break;
            case Panel.collection:
                SelectCollection();
                break;
            case Panel.profile:
                SelectProfile();
                break;
            default:
                SelectMain();
                break;
        }
    }

    public void ARPage()
    {

        SceneManager.LoadScene("ARscene");
    }

    public void Awake()
    {
        Debug.Log("I am awawke!");
        //SelectMain();
    }
}
