using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SieveShake : MonoBehaviour
{
    public Camera mainCam;
    public GameState gs;
    public GameObject SieveInMachine;
    public Image[] Inventory;
    private bool isHoldingSediment = false;
    public GameObject JarOfSediment;
    public GameObject Sand;

    public void Update()
    {
        if ((gs.GetIsHoldingSieve() == true || gs.GetHasPlacedSieve() == true) && Input.GetMouseButtonDown(0))
            ShootRaycast();

        if (isHoldingSediment)
        {
            ItemFollowCam(isHoldingSediment, JarOfSediment, -50);
        }
    }

    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Check if you collect the PPE Boots
            if (hit.transform.gameObject.tag == "SieveShaker" && gs.GetIsHoldingSieve() == true)
            {
                SieveInMachine.gameObject.SetActive(true);
                
                gs.SetIsHoldingSieve(false);
                gs.SetHasSieve(false);

                foreach (Image item in Inventory)
                {
                    if (item.sprite.name == "SievesImage")
                    {
                        item.sprite = null;
                        break;
                    }
                }

            }
            else if (hit.transform.gameObject.tag == "SedimentJar" && gs.GetHasPlacedSieve() == true)
            {
                isHoldingSediment = true;
                Debug.Log("ClickingOnSediment");
                

            }

            if (isHoldingSediment == true && (hit.transform.gameObject.tag == "SieveShaker" || hit.transform.gameObject.tag == "Sieve") && gs.GetHasPlacedSieve() == true)
            {
                this.gameObject.GetComponent<Animation>().Play();
                JarOfSediment.gameObject.SetActive(false);
                Debug.Log("JarOfSediment Placed");

                //Sediment to Jar Logic Here

            }
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Sieve")
    //    {
    //        SieveInMachine.gameObject.SetActive(true);
    //        Destroy(collision.gameObject);
    //        gs.SetIsHoldingSieve(false);
    //        gs.SetHasSieve(false);
    //    }
    //}
}