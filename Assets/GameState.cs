using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private bool mouseOver = false;
    private bool hasPPEBoots = false;
    private bool completeRoom1PasswordPuzzle = false;

    public bool isSprayerUnlocked = false;
    private bool hasSprayer = false;
    private bool isLensUnlocked = false;

    private bool HoldingWetCore = false;
    public int Core2_Piece_Selected = 0;

    //Check Mouse Over State
    public bool GetMouseOver()
    {
        return mouseOver;
    }

    public void SetMouseOver(bool mo)
    {
        mouseOver = mo;
    }


    //Check if player has collected PPE Boots
    public bool GetPPEState()
    {
        return mouseOver;
    }

    public void SetPPEState(bool ppe)
    {
        hasPPEBoots = ppe;
    }


    public bool GetRoom1PasswordPuzzle()
    {
        return completeRoom1PasswordPuzzle;
    }

    public void SetRoom1PasswordPuzzle(bool cp)
    {
        completeRoom1PasswordPuzzle = cp;

        Debug.Log("WORKED!!");
    }



    public bool GetIsSprayerUnlocked()
    {
        return isSprayerUnlocked;
    }

    public void SetIsSprayerUnlocked(bool sp)
    {
        isSprayerUnlocked = sp;

        
    }


    public bool GetSprayer()
    {
        return hasSprayer;
    }

    public void SetSprayer(bool sp)
    {
        hasSprayer = sp;

        
    }


    public bool GetIsLensUnlocked()
    {
        return isLensUnlocked;
    }

    public void SetIsLensUnlocked(bool sp)
    {
        isLensUnlocked = sp;
    }


    public bool GetIsHoldingWetCore()
    {
        return HoldingWetCore;
    }

    public void SetIsHoldingWetCore(bool wc)
    {
        HoldingWetCore = wc;
    }

    public int GetSelectedCore2()
    {
        return Core2_Piece_Selected;
    }

    public void SetSelectedCore2(int wc)
    {
        Core2_Piece_Selected = wc;
    }

}
