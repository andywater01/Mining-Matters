using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleInteraction : MonoBehaviour
{
    public Camera mainCam;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }
    }




    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Checks if you click on the button
            if (hit.transform.gameObject.tag == "Button")
            {
                //play button click animation
                hit.transform.gameObject.GetComponent<Animation>().Play(animation: "ButtonPress");
            }





        }

    }
}
