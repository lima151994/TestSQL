using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text usernameDisplay;
    [SerializeField] TMP_Text scoreDisplay;

    public void SetName()
    {
        usernameDisplay.text = $"Username: {WebFetchDatabase.instance.CurrUsername}";
    }

    public void SetScore()
    {
        scoreDisplay.text = $"Score: {WebFetchDatabase.instance.LocalScore.ToString()}";
    }

    public void IncreasePoint()
    {
        WebFetchDatabase.instance.LocalScore++;
        SetScore();
    }

    void Start()
    {
        SetName();
        SetScore();
    }
}
