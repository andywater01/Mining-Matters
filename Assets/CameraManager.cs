using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera Room1_Main;
    public CinemachineVirtualCamera Room1_Computer;
    public CinemachineVirtualCamera Room1_BrokenCoreShackTable;
    public Camera mainCam;

    // Update is called once per frame
    void Update()
    {
        SwitchCameraPriority();
    }



    


    //This function controls which camera view is currently active
    public void SwitchCameraPriority()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Room1_Main.Priority = 1;
            Room1_Computer.Priority = 0;
            
        }

        //Gets reference to gameObject that is clicken on
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }



    }

    //Shoots Raycast to look at object and change the camera
    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Check if you clicked on the Room1 Computer. If you did, switch camera views
            if (hit.transform.gameObject.tag == "Room1_Computer")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 1;
            }

            else if (hit.transform.gameObject.tag == "Room1_BrokenCoreTable")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 1;
                Room1_Computer.Priority = 0;
            }


        }

    }


}


