using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonScript : MonoBehaviour
{
    //Timer that determines player score
    public float timer;

    public float star1Time, star2Time, star3Time;

    public int starsGained;
    static int starsRecord; 

    public bool gameOver = false;

    public GameObject levelScreen;
    public GameObject[] stars;
    public int nextLevel;

    public GameManager gameManager;

    public string levelName;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(!gameOver)
        {
            timer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy" && !gameOver)
        {
            gameOver = true;
            levelScreen.SetActive(true);
            
            for(int i=0; i<stars.Length; i++)
            {
                stars[i].SetActive(false);
            }

            if(timer > star1Time)
            {
                starsGained = 1;
            }

            if (timer > star2Time)
            {
                starsGained = 2;
            }

            if (timer > star3Time)
            {
                starsGained = 3;
            }

            // Check if new score is hiscore
            if(starsGained > starsRecord)
            {
                starsRecord = starsGained;
                PlayerPrefs.SetInt(levelName, starsRecord);
            }

            gameManager.level1Stars = starsRecord;

            StartCoroutine(StarsAppear());
        }
    }

    public IEnumerator StarsAppear()
    {
        for (int i = 0; i < starsGained; i++)
        {           
            yield return new WaitForSeconds(1f);
            stars[i].SetActive(true);
        }
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
