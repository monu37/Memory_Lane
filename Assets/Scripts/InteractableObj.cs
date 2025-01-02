using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    public static InteractableObj instance;

    [SerializeField] bool IsChest;
    [SerializeField] bool IsPhotoAlbum;
    [SerializeField] bool IsComputerActivated;
    [SerializeField] bool IsWardrobeActivated;
    [SerializeField] bool IsPianoActivated; //daughter
    [SerializeField] bool IsCurtainActivated;  //son
    [SerializeField] bool IsCupboardActivated; //wife

    //GameObject PressSpaceObj;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //PressSpaceObj = manager.instance.GetPressPrefab();
    }

    public bool GetPhotoAlbumActivated()
    {
        return IsPhotoAlbum;
    }
    public bool GetComputerAcivated()
    {
        return IsComputerActivated;
    }
    
    public bool GetWardrobeAcivated()
    {
        return IsWardrobeActivated;
    }
    
    public bool GetChestActivated()
    {
        return IsChest;
    }
    
    public bool GetPianoActivated()
    {
        return IsPianoActivated;
    }
    
    public bool GetCurtainActivated()
    {
        return IsCurtainActivated;
    }
    
    public bool GetCupboardActivated()
    {
        return IsCupboardActivated;
    }

    public void showtext()
    {
        manager.instance.spacepanelonoff(true);
        //PressSpaceObj.SetActive(true);
        //if (PressPopup)
        //{
        //    PressPopup.SetActive(true);
        //}
        //else
        //{
        //    //GameObject presstext = gamemanager.instance.GetPressPrefab();
        //    //PressPopup = Instantiate(presstext, transform.position, Quaternion.identity);
        //    //PressPopup.transform.SetParent(transform, false);
        //}


    }


    public void hidetext()
    {
        manager.instance.spacepanelonoff(false);
        //PressSpaceObj.SetActive(false);
    }
   
}
