using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToFollow : MonoBehaviour
{

    public GameObject target;

    public float followSpeed = 8f;

    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        RaycastHit hit;
        Ray ray;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Pallo seuraa kosketuksen jälkeä viiveellä. 
        if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
        {
            target.transform.position = Vector3.Lerp(target.transform.position, hit.point, followSpeed * Time.deltaTime);
        }
    }
}