using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Logout : MonoBehaviour
{
    [SerializeField] GoToScene sceneManager;

    private void Start()
    {
    
    }

    // Start is called before the first frame update
    public void CallLogout()
    {
        StartCoroutine(Saving());
    }

    IEnumerator Saving()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", WebFetchDatabase.instance.CurrUsername);
        form.AddField("score", WebFetchDatabase.instance.LocalScore);

        WWW www = new WWW("http://localhost/sqlconnect/logout.php",form);

        yield return www;

        Debug.Log(form.data.ToString());

        if (www.text== "0")
        {
            
            Debug.Log("Logout Succesfully.");
            sceneManager.goToScene(0);
            
        }
        else
        {
            Debug.Log($"Logout failed. Error {www.text}");
        }
    }

 
}
