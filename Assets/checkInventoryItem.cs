using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class checkInventoryItem : MonoBehaviour
{
    public Camera mainCam;
    private GameObject buttonPressed;
    public bool holdingSomething = false;

    //Hand Lens Variables
    public GameObject HandLens;
    public bool isHandLensActive = false;
    private GameObject activeHandLens;

    //Spray Bottle Variables
    public GameObject SprayBottle;
    public bool isSprayBottleActive = false;
    private GameObject activeSprayBottle;





    public void OnInventoryClick()
    {
        buttonPressed = EventSystem.current.currentSelectedGameObject;
        Debug.Log(buttonPressed.name.ToString());

        if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "HandLens")
        {
            
            if (isHandLensActive == false && holdingSomething == false)
            {               
                activeHandLens = Instantiate(HandLens, Input.mousePosition, Quaternion.identity);                  
                isHandLensActive = true;
                holdingSomething = true;
            }
            else
            {
                Destroy(activeHandLens.gameObject);
                isHandLensActive = false;
                holdingSomething = false;
            }
        }


        else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "spraybottle")
        {
            if (isSprayBottleActive == false && holdingSomething == false)
            {
                activeSprayBottle = Instantiate(SprayBottle, Input.mousePosition, Quaternion.identity);
                isSprayBottleActive = true;
                holdingSomething = true;
            }
            else
            {
                Destroy(activeSprayBottle.gameObject);
                isSprayBottleActive = false;
                holdingSomething = false;
            }
        }
        
    }

    private void Update()
    {
        ItemFollowCam(isHandLensActive, activeHandLens, 0);
        ItemFollowCam(isSprayBottleActive, activeSprayBottle, 100);

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

