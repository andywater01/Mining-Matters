using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class puzzleInteraction : MonoBehaviour
{
    public Camera mainCam;
    public CinemachineVirtualCamera CoreTableCam;

    public GameObject[] CorePieceLocations;
    public int index = 0;

    public TextMeshProUGUI PasswordLetter1;
    public TextMeshProUGUI PasswordLetter2;
    public TextMeshProUGUI PasswordLetter3;
    public TextMeshProUGUI PasswordLetter4;

    public bool correctPassword = true;

    public string password;
    

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
            //Can only interact with core pieces if user is on the right camera looking at the table
            if (CoreTableCam.Priority > 0)
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


    public void SetPasswordGuess()
    {
        
        
    }


    // Attached to button on computer screen. On Click Event.
    public void CheckPasswordRoom1()
    {
        
        if (correctPassword == false)
        {
            password = "mine";


            if ((PasswordLetter1.text + PasswordLetter2.text + PasswordLetter3.text + PasswordLetter4.text) == password)
            {
                // The correct password was entered on room1 computer.
                Debug.Log("Correct Password");
                correctPassword = true;
            }
            else
            {
                Debug.Log("Incorrect Password");
                Debug.Log(PasswordLetter1.text + PasswordLetter2.text + PasswordLetter3.text + PasswordLetter4.text);
            }
        }
    }



}
