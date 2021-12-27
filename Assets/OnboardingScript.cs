using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OnboardingScript : MonoBehaviour
{
    public RectTransform panel, registration, login, control_panel;
    public RectTransform rect;
    public RectTransform img1, img2, img3;
    public bool isLoggedIn;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        panel.DOAnchorPos(Vector2.zero, 0f);
        control_panel.DOAnchorPos(new Vector2(0, -700), 0f);
        count = 1;
        isLoggedIn = false; //!!!!!!!!!
    }

    public void Next()
    {
        if (count == 1)
        {
            rect.DOAnchorPos(new Vector2(0, -4.4f), 0.25f);
            img1.DOAnchorPos(new Vector2(-300, 218f), 0.25f);
            img2.DOAnchorPos(new Vector2(0, 218f), 0.25f);
            img3.DOAnchorPos(new Vector2(300, 218f), 0.25f);
            count++;
        }
        else if (count == 2)
        {
            rect.DOAnchorPos(new Vector2(34, -4.4f), 0.25f);
            img1.DOAnchorPos(new Vector2(-600, 218f), 0.25f);
            img2.DOAnchorPos(new Vector2(-300, 218f), 0.25f);
            img3.DOAnchorPos(new Vector2(0, 218f), 0.25f);
            count++;
        }
        else 
        {
            panel.DOAnchorPos(new Vector2(0, 2000), 0.5f);
            if (isLoggedIn)
            {
                control_panel.DOAnchorPos(new Vector2(0, -320), 0f);
            }
            else
            {
                login.DOAnchorPos(new Vector2(0, 1000), 1f);
                registration.DOAnchorPos(new Vector2(0, 0), 1f);
            }
        }
    }

    public void LogIn()
    {
        login.DOAnchorPos(new Vector2(0, 0), 1f);
        registration.DOAnchorPos(new Vector2(0, 1000), 1f);
    }

    public void Register()
    {
        login.DOAnchorPos(new Vector2(0, 1000), 1f);
        registration.DOAnchorPos(new Vector2(0, 0), 1f);
    }

    public void LoggedIn()
    {
        login.DOAnchorPos(new Vector2(0, 1000), 1f);
        registration.DOAnchorPos(new Vector2(0, 1000), 1f);

        isLoggedIn = true;
        control_panel.DOAnchorPos(new Vector2(0, -320), 0f);
    }

    public void UnLoggedIn()
    {
        login.DOAnchorPos(new Vector2(0, 0), 1f);
        registration.DOAnchorPos(new Vector2(0, 0), 1f);

        isLoggedIn = false;
        control_panel.DOAnchorPos(new Vector2(0, 0), 0f);
    }
}
