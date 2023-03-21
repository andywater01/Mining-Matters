using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;
using TMPro;

public class checkInventoryItem : MonoBehaviour
{
    public Camera mainCam;
    private GameObject buttonPressed;
    public bool holdingSomething = false;
    public GameState gs;
    public TextMeshProUGUI topText;

    //Hand Lens Variables
    public GameObject HandLens;
    public bool isHandLensActive = false;
    private GameObject activeHandLens;

    //Spray Bottle Variables
    public GameObject SprayBottle;
    public bool isSprayBottleActive = false;
    private GameObject activeSprayBottle;

    //Sieve Variables
    public GameObject Sieve;
    public bool isSieveActive = false;
    private GameObject activeSieve;
    public GameObject SieveInShaker;

    //CorePieces2 Variables
    public GameObject[] core2_pieces;

    public CinemachineVirtualCamera VC_brokenCoreTable;

    //Minging Cycle Puzzle Variables
    public List<GameObject> puzzlePieces = new List<GameObject>();
    private bool isHoldingPiece = false;
    private int PieceIndex = 0;
    public CinemachineVirtualCamera VC_MiningCycle_VC;
    public int piecesPlaced = 0;

    //Saw Blade Variables
    public GameObject SawBlade;
    public bool isSawBladeActive = false;
    private GameObject activeSawBlade;
    public GameObject BrokenSawBlade;
    public GameObject NewSawBlade;
    public CinemachineVirtualCamera VC_SawTable;

    //Saw Cores
    public GameObject SawCoreUncut1;
    public GameObject SawCoreUncut2;
    public GameObject SawCoreUncut3;
    public GameObject SawCoreUncut4;

    public GameObject CutCore;

    public CinemachineVirtualCamera VC_SendTable;

    public GameObject CoreInSendBox;
    public GameObject CoreInResultsBox;

    public void OnInventoryClick()
    {
        buttonPressed = EventSystem.current.currentSelectedGameObject;
        Debug.Log(buttonPressed.name.ToString());

        if (buttonPressed.GetComponent<Image>().sprite != null)
        {
            if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "HandLens")
            {

                if (isHandLensActive == false && holdingSomething == false)
                {
                    activeHandLens = Instantiate(HandLens, Input.mousePosition, Quaternion.identity);
                    isHandLensActive = true;
                    holdingSomething = true;
                    topText.text = ("Can be used to get a closer look at items");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                else
                {
                    if (isHandLensActive == true)
                        Destroy(activeHandLens.gameObject);
                    isHandLensActive = false;
                    holdingSomething = false;
                    topText.text = ("Hand Lens is Back in Inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
            }


            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "spraybottle")
            {
                if (isSprayBottleActive == false && holdingSomething == false)
                {
                    activeSprayBottle = Instantiate(SprayBottle, Input.mousePosition, Quaternion.identity);
                    isSprayBottleActive = true;
                    holdingSomething = true;
                    topText.text = ("Click to Spray Water");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                else
                {
                    Destroy(activeSprayBottle.gameObject);
                    isSprayBottleActive = false;
                    holdingSomething = false;
                    topText.text = ("Spray Bottle is Back in Inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
            }

            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "InspectedCore")
            {
                if (VC_brokenCoreTable.Priority > 0)
                {
                    foreach (GameObject core in core2_pieces)
                    {
                        core.SetActive(true);
                        gs.SetSelectedCore2(0);
                        gs.SetIsHoldingWetCore(false);

                    }
                    buttonPressed.GetComponent<Image>().sprite = null;
                    buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                    
                }

                else if (VC_SawTable.Priority > 0 && gs.GetHasPlacedInspectCore() == false)
                {
                    if (gs.GetisSawBladeFixed() == true && gs.GetSawPower() == true && gs.GetIsWaterOn() == true)
                    {
                        // Spawn Core on Saw Blade Location
                        if (gs.GetSelectedCore2() == 1)
                        {
                            SawCoreUncut1.SetActive(true);
                            SawCoreUncut2.SetActive(false);
                            SawCoreUncut3.SetActive(false);
                            SawCoreUncut4.SetActive(false);
                            gs.SetHasPlacedInspectCore(true);
                            gs.SetIsHoldingWetCore(false);
                            buttonPressed.GetComponent<Image>().sprite = null;
                            buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                        }
                        else if (gs.GetSelectedCore2() == 2)
                        {
                            SawCoreUncut1.SetActive(false);
                            SawCoreUncut2.SetActive(true);
                            SawCoreUncut3.SetActive(false);
                            SawCoreUncut4.SetActive(false);
                            gs.SetHasPlacedInspectCore(true);
                            gs.SetIsHoldingWetCore(false);
                            buttonPressed.GetComponent<Image>().sprite = null;
                            buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                        }
                        else if (gs.GetSelectedCore2() == 3)
                        {
                            SawCoreUncut1.SetActive(false);
                            SawCoreUncut2.SetActive(false);
                            SawCoreUncut3.SetActive(true);
                            SawCoreUncut4.SetActive(false);
                            gs.SetHasPlacedInspectCore(true);
                            gs.SetIsHoldingWetCore(false);
                            buttonPressed.GetComponent<Image>().sprite = null;
                            buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                        }
                        else if (gs.GetSelectedCore2() == 4)
                        {
                            SawCoreUncut1.SetActive(false);
                            SawCoreUncut2.SetActive(false);
                            SawCoreUncut3.SetActive(false);
                            SawCoreUncut4.SetActive(true);
                            gs.SetHasPlacedInspectCore(true);
                            gs.SetIsHoldingWetCore(false);
                            buttonPressed.GetComponent<Image>().sprite = null;
                            buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                        }

                        else
                        {
                            Debug.Log("Not holding core");
                        }

                        Debug.Log(gs.GetSawPower() + " " + gs.GetisSawBladeFixed() + " " + gs.GetHasPlacedInspectCore());

                        if (gs.GetSawPower() == true && gs.GetisSawBladeFixed() == true && gs.GetHasPlacedInspectCore() == true && gs.GetIsWaterOn() == true)
                        {
                            //*Play Saw Sound And Cut the Core Here*
                            if (SawCoreUncut1.activeInHierarchy == true)
                            {
                                CutCore.SetActive(true);
                                Debug.Log("The core has been cut!");
                                SawCoreUncut1.SetActive(false);
                            }
                            else if (SawCoreUncut2.activeInHierarchy == true)
                            {
                                CutCore.SetActive(true);
                                Debug.Log("The core has been cut!");
                                SawCoreUncut2.SetActive(false);
                            }
                            else if (SawCoreUncut3.activeInHierarchy == true)
                            {
                                CutCore.SetActive(true);
                                Debug.Log("The core has been cut!");
                                SawCoreUncut3.SetActive(false);
                            }
                            else if (SawCoreUncut4.activeInHierarchy == true)
                            {
                                CutCore.SetActive(true);
                                Debug.Log("The core has been cut!");
                                SawCoreUncut4.SetActive(false);
                            }

                            
                           
                            Debug.Log("Selected Core Reset to 0");
                        }
                    }
                    else
                    {
                        topText.text = ("The water must be on, the saw blade must be fixed, and the power must be turned on.");
                    }
                    
                }

                else
                {
                    topText.text = ("You can't use this item here");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                
            }

            //Sieve
            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "SievesImage")
            {

                if (isSieveActive == false && holdingSomething == false)
                {
                    gs.SetIsHoldingSieve(true);
                    activeSieve = Instantiate(Sieve, Input.mousePosition, Quaternion.identity);
                    isSieveActive = true;
                    holdingSomething = true;
                    topText.text = ("Sieve can be used to sift and seperate sediment");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                else
                {
                    gs.SetIsHoldingSieve(false);
                    Destroy(activeSieve.gameObject);
                    isSieveActive = false;
                    holdingSomething = false;
                    topText.text = ("Sieve is Back in Inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
            }

            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "PuzzleBox")
            {
                if (isHoldingPiece == false && holdingSomething == false)
                {
                    if (puzzlePieces.Count > 0 && puzzlePieces != null)
                        PuzzlePiece();
                }
                else
                {
                    puzzlePieces[PieceIndex].SetActive(false);
                    holdingSomething = false;
                    isHoldingPiece = false;
                    topText.text = ("Puzzle Piece back in box");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                
            }


            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "SawBlade")
            {
                if (isSawBladeActive == false && holdingSomething == false)
                {
                    gs.SetIsHoldingSawBlade(true);
                    activeSawBlade = Instantiate(SawBlade, Input.mousePosition, Quaternion.identity);
                    isSawBladeActive = true;
                    holdingSomething = true;
                    topText.text = ("Fix the Diamond Cutter");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                else
                {
                    gs.SetIsHoldingSawBlade(false);
                    Destroy(activeSawBlade.gameObject);
                    isSawBladeActive = false;
                    holdingSomething = false;
                    topText.text = ("Saw Blade back in inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
            }

            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "InspectCoreCut")
            {
                if (VC_SendTable.Priority == 1)
                {
                    CoreInSendBox.SetActive(true);
                    buttonPressed.GetComponent<Image>().sprite = null;
                    buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                    gs.SetholdingCutCore(false);
                    StartCoroutine(RecieveCoreResults());
                }
                else
                {
                    topText.text = "Be careful with this, it needs to be sent off and examined for gold.";
                }
            }
        }


        



        else
        {
            topText.text = ("You have nothing in this inventory slot.");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }




    }

    public void PuzzlePiece()
    {
        int piece = (int)Random.Range(0, puzzlePieces.Count - 1);
        if (puzzlePieces[piece].activeInHierarchy == false)
        {
            puzzlePieces[piece].SetActive(true);
            Debug.Log("The piece # is: " + piece);
            //puzzlePieces.RemoveAt(piece);
            isHoldingPiece = true;
            holdingSomething = true;
            PieceIndex = piece;
        }
        else
        {
            //PuzzlePiece();
            Debug.Log("Not acceptable piece location in list");
        }
        //Debug.Log(puzzlePieces.Count);
        
    }


    public void PutAwayButton()
    {      
        //Hand Lens       
        if (isHandLensActive == true && holdingSomething)
        {
            Destroy(activeHandLens.gameObject);
            isHandLensActive = false;
            holdingSomething = false;
            topText.text = ("Hand Lens is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        //SprayBottle
        if (isSprayBottleActive == true && holdingSomething)
        {
            Destroy(activeSprayBottle.gameObject);
            isSprayBottleActive = false;
            holdingSomething = false;
            topText.text = ("Spray Bottle is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        if (isSieveActive == true && holdingSomething)
        {
            Destroy(activeSieve.gameObject);
            isSieveActive = false;
            holdingSomething = false;
            topText.text = ("Sieve is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        if (isHoldingPiece == true && holdingSomething)
        {
            puzzlePieces[PieceIndex].SetActive(false);
            holdingSomething = false;
            isHoldingPiece = false;
            topText.text = ("Puzzle Piece back in box");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        if (isSawBladeActive == true && holdingSomething)
        {
            Destroy(activeSawBlade.gameObject);
            isSawBladeActive = false;
            holdingSomething = false;
            topText.text = ("Saw Blade is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }
    }


    private void Update()
    {
        ItemFollowCam(isHandLensActive, activeHandLens, 0, true, 2.0f);
        ItemFollowCam(isSprayBottleActive, activeSprayBottle, 100, true, 2.0f);
        ItemFollowCam(isSieveActive, activeSieve, 0, true, 2.0f);
        if (puzzlePieces.Count > 0)
            ItemFollowCam(isHoldingPiece, puzzlePieces[PieceIndex], 0, false, 0.7f);

        if (BrokenSawBlade.activeInHierarchy == true)
            ItemFollowCam(isSawBladeActive, activeSawBlade, 0, true, 2.0f);




        if (isSieveActive == true)
        {
            if (gs.GetIsHoldingSieve() == false)
            {
                Destroy(activeSieve.gameObject);
                isSieveActive = false;
                topText.text = ("Sieve is in place and ready to sift");
                topText.GetComponent<UAP_BaseElement>().SelectItem();
                gs.SetHasPlacedSieve(true);
                holdingSomething = false;
            }
        }

        //Spray the spray bottle when left click mouse
        if (Input.GetMouseButton(0) && isSprayBottleActive)
        {
            activeSprayBottle.GetComponentInChildren<ParticleSystem>().Play();
        }
        if (Input.GetMouseButtonUp(0) && isSprayBottleActive)
        {
            activeSprayBottle.GetComponentInChildren<ParticleSystem>().Stop();
        }


        //Check if holding saw blade and click broken one
        if (Input.GetMouseButtonDown(0) && isSawBladeActive)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                //Check if you collect the PPE Boots
                if (hit.transform.gameObject.tag == "BrokenSawBlade")
                {
                    BrokenSawBlade.SetActive(false);
                    NewSawBlade.SetActive(true);
                    gs.SetisSawBladeFixed(true);
                    gs.SetIsHoldingSawBlade(false);
                    gs.SetHasSawBlade(false);
                    Destroy(activeSawBlade);
                    topText.text = "The Blade has been fixed!";
                }
            }
        }


        //Check if clicking on jigsaw puzzle
        if (Input.GetMouseButtonDown(0) && VC_MiningCycle_VC.Priority == 1 && gs.GetJigSawDone() == false)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                //Check if you collect the PPE Boots
                if (hit.transform.gameObject.tag == "PuzzleLocation" && isHoldingPiece == true)
                {
                    puzzlePieces[PieceIndex].transform.position = hit.transform.position + new Vector3(0.0f, 0.0f, 0.0f);
                    puzzlePieces[PieceIndex].GetComponent<BoxCollider>().enabled = true;



                    puzzlePieces.RemoveAt(PieceIndex);
                    isHoldingPiece = false;
                    holdingSomething = false;
                    Debug.Log("Piece Index: " + PieceIndex);
                    piecesPlaced++;

                    if (piecesPlaced == 49)
                    {
                        gs.SetPlacedAllPieces(true);
                    }
                }

                else if (hit.transform.gameObject.tag == "PuzzlePiece" && isHoldingPiece == false)
                {
                    puzzlePieces.Add(hit.transform.gameObject);
                    hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
                    hit.transform.gameObject.SetActive(false);
                    isHoldingPiece = false;
                    holdingSomething = false;
                    piecesPlaced--;

                    if (piecesPlaced < 49)
                    {
                        gs.SetPlacedAllPieces(false);
                    }
                }
            }
        }


    }


    public void ItemFollowCam(bool isItemActive, GameObject activeItem, int yoffset, bool followRot, float distance)
    {
        if (isItemActive == true)
        {
            var mousePos = Input.mousePosition - new Vector3(0, yoffset, 0);
            var camRot = mainCam.transform.localRotation;
            activeItem.transform.position = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));
            if (followRot == true)
                activeItem.transform.localRotation = mainCam.transform.localRotation;
        }
    }





    IEnumerator RecieveCoreResults()
    {
        CoreInResultsBox.SetActive(false);
        CoreInSendBox.SetActive(true);
        topText.text = "Core Analysis Sending!";
        yield return new WaitForSeconds(2);
        topText.text = "Core Analysis Recieved!";
        CoreInSendBox.SetActive(false);
        CoreInResultsBox.SetActive(true);
        if (gs.GetSelectedCore2() == 4)
        {
            Debug.Log("This core contained the correct amount of gold!");
            gs.SetfoundGoldCore(true);
        }
        else
        {
            Debug.Log("This is fools gold. Check another sample.");
        }
        gs.SetHasPlacedInspectCore(false);
        gs.SetSelectedCore2(0);
        StopCoroutine(RecieveCoreResults());
        
        


    }

}

