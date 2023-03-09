using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;

public class BrokenCoreInteraction : MonoBehaviour
{
    public Camera mainCam;
    public CinemachineVirtualCamera CoreTableCam;
    public GameState gs;

    
    public GameObject[] CorePieceLocations;
    public GameObject[] OriginalCorePieceLocations;
    //public bool[] CurrentTableLocations = { false, false, false, false };
    //public bool[] CurrentGroundLocations = { true, true, true, true };
    private string[] CurrentTableLocations = { "Empty", "Empty", "Empty", "Empty" };
    private string[] CurrentGroundLocations = { "Orange", "Red", "Yellow", "Blue" };
    public int index = 0;
    public int index2 = 0;

    public Text PasswordLetter1;
    public Text PasswordLetter2;
    public Text PasswordLetter3;
    public Text PasswordLetter4;

    public Canvas room1ComputerScreen;

    public GameObject room1Computer;
    public Material room1SolvedBackground;

    public Material[] computerMats;

    public bool correctPassword = false;

    public string password = "MINE";

    public string Guessedpassword;


    public GameObject[] brokenCores;
    public Material[] solvedMaterials;

    private bool puzzleSolved = false;


    private void Awake()
    {
        computerMats = room1Computer.GetComponent<Renderer>().sharedMaterials;
    }

    // Start is called before the first frame update
    void Start()
    {
        PasswordLetter1.GetComponentInParent<InputField>().onValidateInput +=
         delegate (string s, int i, char c) { return char.ToUpper(c); };

        PasswordLetter2.GetComponentInParent<InputField>().onValidateInput +=
         delegate (string s, int i, char c) { return char.ToUpper(c); };

        PasswordLetter3.GetComponentInParent<InputField>().onValidateInput +=
         delegate (string s, int i, char c) { return char.ToUpper(c); };

        PasswordLetter4.GetComponentInParent<InputField>().onValidateInput +=
         delegate (string s, int i, char c) { return char.ToUpper(c); };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }

        if (puzzleSolved == false)
        {
            if (CurrentTableLocations[0] == "Yellow" && CurrentTableLocations[1] == "Orange" && CurrentTableLocations[2] == "Blue" && CurrentTableLocations[3] == "Red")
            {
                Debug.Log("Correct Broken Core Order is on Table!");
                for (int i = 0; i < brokenCores.Length; i++)
                {
                    brokenCores[i].GetComponent<Renderer>().material = solvedMaterials[i];
                }
                puzzleSolved = true;
            }
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
                    for(int i = 0; i < 4; i++)
                    {
                        if(CurrentTableLocations[i] == "Empty")
                        {
                            hit.transform.position = CorePieceLocations[i].transform.position;
                            hit.transform.gameObject.tag = "BrokenCoreOnTable";
                            CurrentTableLocations[i] = hit.transform.gameObject.name;
                            Debug.Log("ACTIVATED!");
                            break;
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (CurrentGroundLocations[i] == hit.transform.gameObject.name)
                        {
                            CurrentGroundLocations[i] = "Empty";
                            break;
                        }
                    }
                }

                //Check if you clicked on a core piece
                else if (hit.transform.gameObject.tag == "BrokenCoreOnTable")
                {
                    Debug.Log("Drop Core");
                    for (int i = 0; i < 4; i++)
                    {
                        if (CurrentGroundLocations[i] == "Empty")
                        {
                            hit.transform.position = OriginalCorePieceLocations[i].transform.position;
                            hit.transform.gameObject.tag = "BrokenCore";
                            CurrentGroundLocations[i] = hit.transform.gameObject.name;
                            break;
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (CurrentTableLocations[i] == hit.transform.gameObject.name)
                        {
                            CurrentTableLocations[i] = "Empty";
                            break;
                        }
                    }

                }
                else
                {
                    Debug.Log(hit.transform.gameObject.tag);
                }
            }
            




        }

    }


    public void SetPasswordGuess()
    {

        Guessedpassword = PasswordLetter1.text + PasswordLetter2.text + PasswordLetter3.text + PasswordLetter4.text;
    }


    // Attached to button on computer screen. On Click Event.
    public void CheckPasswordRoom1()
    {
        if (correctPassword == false)
        {
            if (Guessedpassword == password)
            {
                // The correct password was entered on room1 computer.
                Debug.Log("Correct Password");
                correctPassword = true;

                room1ComputerScreen.gameObject.SetActive(false);
                computerMats[2] = room1SolvedBackground;
                room1Computer.GetComponent<Renderer>().sharedMaterials = computerMats;

                gs.SetRoom1PasswordPuzzle(true);
            }
            else
            {
                Debug.Log("Incorrect Password");
                Debug.Log(Guessedpassword);
            }
        }
    }


}
