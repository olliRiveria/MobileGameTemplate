using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject levelScreen;

    public void LevelScreenClose()
    {
        levelScreen.SetActive(false);
    }
}
