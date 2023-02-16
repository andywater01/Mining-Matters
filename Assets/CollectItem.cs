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

    
    
    //If Mouse is over this gameobject
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
            
           
        }
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




        }

    }

}
