using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleInteraction : MonoBehaviour
{
    public Camera mainCam;

    public GameObject[] CorePieceLocations;
    public int index = 0;
    

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
            //Check if you clicked on a core piece
            if (hit.transform.gameObject.tag == "BrokenCore")
            {
                Debug.Log("Grab Core");
                hit.transform.position = CorePieceLocations[index].transform.position;
                index++;
            }




        }

    }
}
