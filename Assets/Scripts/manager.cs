using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public static manager instance;

    public enum Status
    {
        Waiting,
        Instruction,
        ReadyToGo,
        playing,
        LevelGame
    }
    public manager.Status GameStatus;

    [SerializeField] int OpenAlbumAgain;

    [SerializeField] bool IsChest;
    [SerializeField] bool IsPhotoAlbum;
    [SerializeField] bool IsComputer;
    [SerializeField] bool IsWardrobe;
    [SerializeField] bool IsPiano; // daughter
    [SerializeField] bool IsCupboard; //wife
    [SerializeField] bool IsCurtain; //son

    //
    [SerializeField] GameObject PressSpacePanel;

    //
    [SerializeField] int TotalKeyEarn;
    private void Awake()
    {
        //Helper.setfirsttime(0);
        //PlayerPrefs.DeleteAll();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        TotalKeyEarn = Helper.GetTotalKey();

    }

    private void Start()
    {
    }

    private void Update()
    {
        if (PressSpacePanel.activeInHierarchy)
        {
            //press space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audiomanager.instance.clicksound();
                GameStatus = Status.LevelGame;
                if (IsChest)
                {
                    print("chest");
                    gamemanager.instance.onoffchestpanel(true);
                   
                }
                else if (IsPhotoAlbum)
                {
                    print("photo album");
                    gamemanager.instance.onoffphotopanel(true);
                    //PhotoAlbumPanel.SetActive(true);
                    //spacepanelonoff(false);
                }
                else if (IsComputer)
                {
                    print("level 2 game start");
                    level2manager.instance.startgame();
                    //spacepanelonoff(false);
                }
                
                else if (IsWardrobe)
                {
                    print("level 1 game start");
                    level1manager.instance.wardrobeopen(true);
                    //spacepanelonoff(false);
                    Invoke(nameof(startlevel1game), .2f);
                }
                
                else if (IsPiano)
                {
                    print("Piano");//daughter
                    level3manager.instance.setdaughter(true);
                    openpopup("I thought you couldn't find me, Dad");
                }
                
                else if (IsCupboard)
                {
                    print("Cupboard");//wife
                    level3manager.instance.setwife(true);
                    openpopup("Ops. You got me, honey");
                }
                
                else if (IsCurtain)
                {
                    print("Curtain");//son
                    level3manager.instance.setson(true);
                    openpopup("Papa. How'd you find me");
                }
                spacepanelonoff(false);
            }
        }

        clearallsavedata();
        quitgame();
    }

    void openpopup(string dialouge)
    {
        level3manager.instance.foundpopuptext(dialouge);
    }

    public void gamestatusplaying()
    {
        GameStatus = Status.playing;
    }

    void startlevel1game()
    {
        level1manager.instance.startgame();
    }

    public void spacepanelonoff(bool b)
    {
        PressSpacePanel.SetActive(b);
    }
    

    //
    public void setchestactivate(bool b)
    {
        IsChest = b;
    } 
    public void setphotoalbumactivate(bool b)
    {
        IsPhotoAlbum = b;
    } 
    public void setcomputeractiavted(bool b)
    {
        IsComputer = b;
    }
    public void setwardrobeactivated(bool b)
    {
        IsWardrobe = b;
    }
    public void setpianoactivate(bool b)
    {
        IsPiano = b;
    }
    public void setcupboardactivate(bool b)
    {
        IsCupboard = b;
    }
    public void setcurtainactivate(bool b)
    {
        IsCurtain = b;
    }



    public int GetOpenAlbumCount()
    {
        return OpenAlbumAgain;
    }

    public void setalbumopen(int i)
    {
        // i =0 // close, i==1 open
        //return OpenAlbumAgain;
        OpenAlbumAgain = i;
    }

    //
    public int GetTotalKeyEarn()
    {
        return TotalKeyEarn;
    }
    public void setkeytearn(int i)
    {
        TotalKeyEarn = i;
        Helper.settotalkey(i);
    }

    void clearallsavedata()
    {
        if(Input.GetKey( KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt))
        {
            PlayerPrefs.DeleteAll();
            print("clear all save data");
        }
    }

    void quitgame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
