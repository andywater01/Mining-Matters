using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private bool mouseOver = false;
    private bool hasPPEBoots = true; // set back to false
    private bool completeRoom1PasswordPuzzle = false;

    public bool isSprayerUnlocked = false;
    private bool hasSprayer = false;
    private bool isLensUnlocked = false;

    private bool HoldingWetCore = false;
    public int Core2_Piece_Selected = 0;

    private bool hasSafetyGlasses = true; // set back to false

    private bool HasSieve = false;
    private bool isHoldingSieve = false;
    private bool hasPlacedSieve = false;

    private bool unlockedCabinetLock = false;

    private bool hasPuzzleBox;

    private bool PlacedAllPieces = false;
    private bool isJigSawDone = false;

    private bool hasDustMask = true; // set back to false

    private int currentRoom = 1;

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
        return hasPPEBoots;
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


    public bool GetHasSafetyGlasses()
    {
        return hasSafetyGlasses;
    }

    public void SetHasSafetyGlasses(bool sg)
    {
        hasSafetyGlasses = sg;
    }


    public bool GetHasSieve()
    {
        return HasSieve;
    }

    public void SetHasSieve(bool sv)
    {
        HasSieve = sv;
    }

    public bool GetIsHoldingSieve()
    {
        return isHoldingSieve;
    }

    public void SetIsHoldingSieve(bool hs)
    {
        isHoldingSieve = hs;
    }

    public bool GetHasPlacedSieve()
    {
        return hasPlacedSieve;
    }

    public void SetHasPlacedSieve(bool hs)
    {
        hasPlacedSieve = hs;
    }


    public bool GetHasUnlockedCabinetLock()
    {
        return unlockedCabinetLock;
    }

    public void SetHasUnlockedCabinetLock(bool cl)
    {
        unlockedCabinetLock = cl;
    }


    public bool GetHasPuzzleBox()
    {
        return hasPuzzleBox;
    }

    public void SetHasPuzzleBox(bool pb)
    {
        hasPuzzleBox = pb;
    }

    public bool GetPlacedAllPieces()
    {
        return PlacedAllPieces;
    }

    public void SetPlacedAllPieces(bool ap)
    {
        PlacedAllPieces = ap;
    }

    public bool GetJigSawDone()
    {
        return isJigSawDone;
    }

    public void SetJigSawDone(bool ap)
    {
        isJigSawDone = ap;
    }


    public bool GetHasDustMask()
    {
        return hasDustMask;
    }

    public void SetHasDustMask(bool dm)
    {
        hasDustMask = dm;
    }


    public int GetCurrentRoom()
    {
        return currentRoom;
    }

    public void SetCurrentRoom(int cr)
    {
        currentRoom = cr;
    }

}
