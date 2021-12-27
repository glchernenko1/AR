using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class APIcontrol : MonoBehaviour
{
    public void Start()
    {
        login = PlayerPrefs.GetString("username");
        if (login != "")
        {
            Invoke("Next", 0.01f);
            Invoke("Next", 0.02f);
            Invoke("Next", 0.03f);
            Invoke("LoggedIn", 0.04f);
        }
    }

    void Next()
    {
        controller.GetComponent<OnboardingScript>().Next();
    }

    void LoggedIn()
    {
        login = PlayerPrefs.GetString("username");
        password = PlayerPrefs.GetString("password");
        LoadObject();
        Debug.Log(password);
        LoggingFunction(login, password);
    }

    Wrapper wrapper = new Wrapper();
    string login,
    password,
    refreshToken,
    access;
    bool isLoginOk,
        isRegistrationOk,
        isRefreshTokenOk;

    public Text passwordLoggingText;
    public Text loginLoggingText;
    public Text profileUsername;

    public GameObject controller;
    public GameObject controllerMainMenu;

    public Toggle confidential;
    public Text uesrnameError;
    public Text mailError;
    public Text passwrodError;
    public GameObject confidentialError;

    public GameObject dataErrorLog;
    public Text usernameRegistrationText;
    public Text mailRegistrationText;
    public Text passwordRegistrationText;

    public void LoggingFunction()
    {
        Debug.Log("-----------------------TestAPI------------------------------");
        password = passwordLoggingText.text;
        login = loginLoggingText.text;
        Debug.Log(login + " " + password);
        var tmp = wrapper.Login(login, password);
        Debug.Log(tmp);
        access = tmp.Item1;
        refreshToken = tmp.Item2;
        isLoginOk = tmp.Item3;
        if (isLoginOk)
        {
            profileUsername.text = login;
            controller.GetComponent<OnboardingScript>().LoggedIn();
            dataErrorLog.SetActive(false);
            SaveData(login, password);
        }
        else
        {
            dataErrorLog.SetActive(true);
        }
    }

    public void LoggingFunction(string login, string password)
    {
        Debug.Log("-----------------------TestAPI------------------------------");
        Debug.Log(login + " " + password);
        var tmp = wrapper.Login(login, password);
        Debug.Log(tmp);
        access = tmp.Item1;
        refreshToken = tmp.Item2;
        isLoginOk = tmp.Item3;
        if (isLoginOk )
        {
            profileUsername.text = login;//Добавление юзернейма, не должно быть тут, но увы
            controller.GetComponent<OnboardingScript>().LoggedIn();
        }
    }

    public void RegistrationFunction()
    {
        if (confidential.isOn)
        {
            confidentialError.SetActive(false);
            var registration = wrapper.Registrate(usernameRegistrationText.text, passwordRegistrationText.text, mailRegistrationText.text);
            Debug.Log(registration);
            Debug.Log(registration.Item1 + "Item1");
            if (registration.Item1)
            {
                LoggingFunction(usernameRegistrationText.text, passwordRegistrationText.text);
            }
            else
            {
                uesrnameError.text = registration.Item3 != null ? registration.Item3[0] : "";
                mailError.text = registration.Item2 != null ? registration.Item2[0] : "";
                passwrodError.text = registration.Item4 != null ? registration.Item4[0] : "";
            }
        }
        else
        {
            confidentialError.SetActive(true);
        }
    }

    public void LogOut()
    {
        PlayerPrefs.DeleteAll();
        login = "";
        password = "";
        Debug.Log("Data reset complete");
        controller.GetComponent<OnboardingScript>().UnLoggedIn();
    }

    public void SaveData(string username, string password)
    {
        Debug.Log("-----Save data-----");
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetString("password", password);
    }

    /// <summary>
    /// Не знаю для чего, мб понадобится для апишки
    /// </summary>
    /// <param name="obj">Массив всех сохраненных объектов</param>
    public void SaveAllObject(int[] obj)
    {
        PlayerPrefs.SetInt("objLenght", obj.Length);
        for (int i = 0; i < obj.Length; i++)
        {
            PlayerPrefs.SetInt("item" + i.ToString(), obj[i]);
        }
    }

    public static int[] LoadObject()
    {
        int lenght = PlayerPrefs.GetInt("objLenght");
        int[] objects = new int[lenght];
        Debug.Log("--------------Load Object----------------");
        for ( int i = 0; i<lenght;i++)
        {   
            objects[i] = PlayerPrefs.GetInt("item" + i);
            Debug.Log("Load object with id " + objects[i]);
        }
        Debug.Log(objects);
        return objects;
    }

    static public void SaveObject(int id)
    {
        bool can = true;
        Debug.Log("save id: " + id);
        int oldLenght = PlayerPrefs.GetInt("objLenght");
        if (oldLenght<1)
        {
            PlayerPrefs.SetInt("objLenght", 1);
            PlayerPrefs.SetInt("item"+ 0, id);
        }
        else
        {
            for( int i = 0; i < oldLenght;i++)
            {
                if (PlayerPrefs.GetInt("item"+i)==id)
                {
                    can = false;
                    break;
                }
            }
            if (can)
            {
                Debug.Log("Save object with id " + id);
                PlayerPrefs.SetInt("item" + oldLenght, id);
                oldLenght += 1;
                PlayerPrefs.SetInt("objLenght", oldLenght);
            }
        }
    }
}
