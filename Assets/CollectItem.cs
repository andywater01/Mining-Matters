using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    //Main text at top of screen
    public TextMeshProUGUI TopText;
    public GameState gs;
    public string Message;
    public Camera mainCam;

    public Image[] Inventory;
   

    public Sprite itemImage;

    //Adding the audio source and a toggle to avoid playback
    //AudioSource audioSource;
    //private bool checkSoundToggle = true;
    


    //If Mouse is over this gameobject
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
            
           
        }
    }

    //Start Method simply for audio init 
    public void Start()
    {
        //Init audio source 
        //audioSource = GetComponent<AudioSource>();
    }

    public void AddToInventory()
    {

    }



    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Check if you collect the PPE Boots
            if (hit.transform.gameObject.tag == "PPE_Boots")
            {
                gs.SetPPEState(true);
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        break;
                    }
                }

                //Plays audio for putting on the PPE Boots
                //if(gs.GetPPEState() == true && checkSoundToggle == true)
                //{
                    //audioSource.Play();
                    //checkSoundToggle = false; //ensures the sound doesn't repeat

                //}
            }

            //Check if you collect the sprayer
            else if (hit.transform.gameObject.tag == "Sprayer" && gs.GetIsSprayerUnlocked() == true)
            {
                gs.SetSprayer(true);
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        break;
                    }
                }
            }

            //Check if you collect the Hand Lens
            else if (hit.transform.gameObject.tag == "HandLens")
            {
                gs.SetIsLensUnlocked(true);
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        break;
                    }
                }
            }


            //Check if you collect the Hand Lens
            else if (hit.transform.gameObject.tag == "InspectCore" && gs.GetIsHoldingWetCore() == false)
            {
                Debug.Log(hit.transform.gameObject.GetComponent<Renderer>().material.name);
                if (hit.transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed (Instance)"))
                {
                    if (hit.transform.gameObject.name == "CorePieceToInspect1")
                        gs.SetSelectedCore2(1);
                    else if (hit.transform.gameObject.name == "CorePieceToInspect2")
                        gs.SetSelectedCore2(2);
                    else if (hit.transform.gameObject.name == "CorePieceToInspect3")
                        gs.SetSelectedCore2(3);
                    else if (hit.transform.gameObject.name == "CorePieceToInspect4")
                        gs.SetSelectedCore2(4);

                    gs.SetIsHoldingWetCore(true);
                    for (int i = 0; i <= Inventory.Length; i++)
                    {
                        if (Inventory[i].sprite == null)
                        {
                            Inventory[i].sprite = itemImage;
                            Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                            TopText.text = (Message);
                            this.gameObject.SetActive(false);
                            break;
                        }
                    }
                }
                else
                {
                    TopText.text = ("These cores are too dry. It is hard to tell if its gold or not");
                }
                
            }

            //Inspect Core
            else if (hit.transform.gameObject.tag == "InspectCore")
            {
                gs.SetHasSafetyGlasses(true);

                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        break;
                    }
                }
            }


            //Check if you collect the Sieve
            else if (hit.transform.gameObject.tag == "Sieve" && gs.GetHasPlacedSieve() == false)
            {
                gs.SetHasSieve(true);
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);                       
                        break;
                    }
                    
                }
            }


            //Check if you collect the Safety Goggles
            else if (hit.transform.gameObject.tag == "Safety Glasses")
            {
                gs.SetHasSafetyGlasses(true);
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        break;
                    }

                }
            }

            else if (hit.transform.gameObject.tag == "Door1")
            {
                TopText.text = (Message);
            }

            //Check if you collect the Puzzle Box
            else if (hit.transform.gameObject.tag == "PuzzleBox" && gs.GetHasPuzzleBox() == false)
            {
                gs.SetHasPuzzleBox(true);
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        break;
                    }

                }
            }


            if (hit.transform.gameObject.tag == "DustMask")
            {
                gs.SetHasDustMask(true);
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        break;
                    }
                }

                
            }

        }

    }

}
