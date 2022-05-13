using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Login : MonoBehaviour
{
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;

    [SerializeField] Button submitButton;

    [SerializeField] GoToScene sceneManager;

    private void Start()
    {
        submitButton.interactable = false;
    }

    // Start is called before the first frame update
    public void CallLogin()
    {
        StartCoroutine(Logging());
    }

    IEnumerator Logging()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php",form);

        yield return www;

        if (www.text.Split('\t')[0] == "0")
        {
            WebFetchDatabase.instance.CurrUsername = username.text;
            WebFetchDatabase.instance.CurrScore = int.Parse(www.text.Split('\t')[1]);
            sceneManager.goToScene(3);
        }
        else
        {
            Debug.Log($"Login failed. Error {www.text}");
        }
    }

    public void VerifyInput()
    {
        submitButton.interactable = (username.text.Length >= 8 && password.text.Length >= 8);
    }
}
