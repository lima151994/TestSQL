using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebFetchDatabase : MonoBehaviour
{
    public static WebFetchDatabase instance;

    string currUsername;
    int currScore;
    int localScore;

    public string CurrUsername { 
        get => currUsername;
        set {
            currUsername = value;
            Debug.Log($"{currUsername} has logged in");    
        } 
    }
    public int CurrScore { get => currScore; set { currScore = value; localScore = currScore; } }
    public int LocalScore { get => localScore; set => localScore = value; }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
