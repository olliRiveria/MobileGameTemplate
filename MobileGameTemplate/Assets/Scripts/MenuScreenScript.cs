using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenScript : MonoBehaviour
{

    // Variables for different pop-up screens
    public GameObject levelScreen;
    public GameObject levelsWindow;
    public GameObject optionsWindow;
    public GameObject startButton;
    public GameObject fadeScreen;

    // Variables for star images displayed on level buttons
    public GameObject[] level1StarImages;
    public GameObject[] level2StarImages;
    public GameObject[] level3StarImages;
    public GameObject[] level4StarImages;
    public GameObject[] level5StarImages;

    public ParticleSystem buttonParticles;

    public int nextLevel;

    public AudioSource startButtonAudio;
    public AudioSource myAudio;

    // Variables for sound effects
    public AudioClip   clickSound;
    public AudioClip   openSound;
    public AudioClip   yesSound;
    public AudioClip   noSound;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        levelScreen.SetActive(false);
        myAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void StartButton()
    {
        StartCoroutine(StartTimer());
    }

    // Funktio jossa on ajastin
    public IEnumerator StartTimer()
    {
        startButton.GetComponent<Animator>().SetTrigger("ButtonPressed");
        buttonParticles.Play();
        startButtonAudio.PlayOneShot(clickSound);
        yield return new WaitForSeconds(1f);
        startButton.SetActive(false);
        levelsWindow.SetActive(true);

        for(int i=0; i<gameManager.level1Stars; i++)
        {
            level1StarImages[i].SetActive(true);
        }

        for (int i = 0; i < gameManager.level2Stars; i++)
        {
            level2StarImages[i].SetActive(true);
        }

        for (int i = 0; i < gameManager.level2Stars; i++)
        {
            level2StarImages[i].SetActive(true);
        }

        for (int i = 0; i < gameManager.level3Stars; i++)
        {
            level3StarImages[i].SetActive(true);
        }

        for (int i = 0; i < gameManager.level3Stars; i++)
        {
            level3StarImages[i].SetActive(true);
        }
    }

    //Sulkeiden sisällä olevaa muuttujaa säädellään kentänvaihtonapeilla. 
    public void LevelScreenActive(int level)
    {
        levelScreen.SetActive(true);
        nextLevel = level;
    }

    public void LevelScreenClose()
    {
        myAudio.PlayOneShot(noSound);
        levelScreen.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsWindow.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsWindow.SetActive(false);
    }

    public void OpenLevel()
    {
        StartCoroutine(OpenLevelDelay());
    }

    // Viive jotta peli ennättää toistaa napin äänen ennen siirtymää
    public IEnumerator OpenLevelDelay()
    {
        myAudio.PlayOneShot(yesSound);
        fadeScreen.GetComponent<Animator>().SetBool("FadeIn", false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
    }
}
