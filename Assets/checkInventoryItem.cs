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
                }
                else
                {
                    if (isHandLensActive == true)
                        Destroy(activeHandLens.gameObject);
                    isHandLensActive = false;
                    holdingSomething = false;
                    topText.text = ("Hand Lens is Back in Inventory");
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
                }
                else
                {
                    Destroy(activeSprayBottle.gameObject);
                    isSprayBottleActive = false;
                    holdingSomething = false;
                    topText.text = ("Spray Bottle is Back in Inventory");
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
                else
                {
                    topText.text = ("You can't use this item here");
                }
                
            }

            //Sieve
            if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "SievesImage")
            {

                if (isSieveActive == false && holdingSomething == false)
                {
                    gs.SetIsHoldingSieve(true);
                    activeSieve = Instantiate(Sieve, Input.mousePosition, Quaternion.identity);
                    isSieveActive = true;
                    holdingSomething = true;
                    topText.text = ("Sieve can be used to sift and seperate sediment");
                }
                else
                {
                    gs.SetIsHoldingSieve(false);
                    Destroy(activeSieve.gameObject);
                    isSieveActive = false;
                    holdingSomething = false;
                    topText.text = ("Sieve is Back in Inventory");
                }
            }
        }

       
        else
        {
            topText.text = ("You have nothing in this inventory slot.");
        }

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
        }

        //SprayBottle
        if (isSprayBottleActive == true && holdingSomething)
        {
            Destroy(activeSprayBottle.gameObject);
            isSprayBottleActive = false;
            holdingSomething = false;
            topText.text = ("Spray Bottle is Back in Inventory");
        }

        if (isSieveActive == true && holdingSomething)
        {
            Destroy(activeSieve.gameObject);
            isSieveActive = false;
            holdingSomething = false;
            topText.text = ("Sieve is Back in Inventory");
        }

    }


    private void Update()
    {
        ItemFollowCam(isHandLensActive, activeHandLens, 0);
        ItemFollowCam(isSprayBottleActive, activeSprayBottle, 100);
        ItemFollowCam(isSieveActive, activeSieve, 0);

        if (isSieveActive == true)
        {
            if (gs.GetIsHoldingSieve() == false)
            {
                Destroy(activeSieve.gameObject);
                isSieveActive = false;
                topText.text = ("Sieve is in place and ready to sift");
                gs.SetHasPlacedSieve(true);
                holdingSomething = false;
            }
        }
        

        if (Input.GetMouseButton(0) && isSprayBottleActive)
        {
            activeSprayBottle.GetComponentInChildren<ParticleSystem>().Play();
        }
        if (Input.GetMouseButtonUp(0) && isSprayBottleActive)
        {
            activeSprayBottle.GetComponentInChildren<ParticleSystem>().Stop();
        }


    }


    public void ItemFollowCam(bool isItemActive, GameObject activeItem, int yoffset)
    {
        if (isItemActive == true)
        {
            var mousePos = Input.mousePosition - new Vector3(0, yoffset, 0);
            var camRot = mainCam.transform.localRotation;
            activeItem.transform.position = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 2.0f));
            activeItem.transform.localRotation = mainCam.transform.localRotation;
        }
    }

}

