using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public bool touchable = true;

    public Image myMeter;
    public float multiplier = 0.05f;

    public Launch launchObject;

    public LayerMask layerMask;

    void Update()
    {
        RaycastHit hit;
        Ray ray;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            
            print("Hit something");
            
            if (Input.GetButton("Fire1"))
            {
                myMeter.fillAmount += 1f * multiplier *Time.deltaTime;
                print("tapped something");
                touchable = true;
            }

            if (Input.GetButtonUp("Fire1"))
            {

                launchObject.power = myMeter.fillAmount;
                launchObject.Shoot();
                touchable = false;


            }

            if (!touchable)
            {
                myMeter.fillAmount -= 1f * multiplier * Time.deltaTime;
            }

        }

        else
        {
            myMeter.fillAmount -= 1f * multiplier * Time.deltaTime;
        }

    }
}