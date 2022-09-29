using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int level1Stars;
    public int level2Stars;
    public int level3Stars;
    public int level4Stars;
    public int level5Stars;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if(gameManager != null)
        {
            Destroy(gameObject);
        }

        level1Stars = PlayerPrefs.GetInt("level1StarsRecord");
        level2Stars = PlayerPrefs.GetInt("level2StarsRecord");
        level3Stars = PlayerPrefs.GetInt("level3StarsRecord");
        level4Stars = PlayerPrefs.GetInt("level4StarsRecord");
        level5Stars = PlayerPrefs.GetInt("level5StarsRecord");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetRecords()
    {
        PlayerPrefs.SetInt("level1StarsRecord",0);
        level1Stars = PlayerPrefs.GetInt("level1StarsRecord");
        PlayerPrefs.SetInt("level2StarsRecord",0);
        PlayerPrefs.SetInt("level3StarsRecord",0);
        PlayerPrefs.SetInt("level4StarsRecord",0);
        PlayerPrefs.SetInt("level5StarsRecord",0);
    }
}
