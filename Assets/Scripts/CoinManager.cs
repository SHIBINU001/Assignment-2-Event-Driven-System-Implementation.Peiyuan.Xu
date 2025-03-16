using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public GameObject door;
    private bool doorDestoryed;

    void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

  
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
        GameObject coinTextObject = GameObject.FindGameObjectWithTag("CoinText");
        if (coinTextObject != null)
        {
            coinText = coinTextObject.GetComponent<Text>();
        }
    }

    void Update()
    {
        
        if (coinText != null)
        {
            coinText.text = "Coin Count: " + coinCount.ToString();
        }

       
        if (coinCount == 5 && !doorDestoryed)
        {
            doorDestoryed = true;
            Destroy(door);
        }
    }
}

