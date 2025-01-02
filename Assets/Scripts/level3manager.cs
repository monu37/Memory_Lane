using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class level3manager : MonoBehaviour
{
    public static level3manager instance;

    [SerializeField] bool IsGameStart;
    [SerializeField] GameObject DialougePanel;
    [SerializeField] GameObject EnvironmentPanel;   
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject WinPanel;

    [SerializeField] int WinCount;
    [SerializeField] bool CollectWife;
    [SerializeField] GameObject WifePopup;
    [SerializeField] float DefaultWifePosX, AnimWifePosX;
    [SerializeField] GameObject SonPopup;
    [SerializeField] bool CollectSon;
    [SerializeField] float DefaultSonPosX, AnimSonPosX;
    [SerializeField] GameObject DaughterPopup;
    [SerializeField] bool CollectDaughter;
    [SerializeField] float DefaultDaughterPosY, AnimDaughterPosY;
    [SerializeField] GameObject FoundPopup;
    [SerializeField] float DefaultFoundPopupPosY, AnimFoundPopupPosY;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audiomanager.instance.level3bgsound();
        GamePanel.SetActive(false);
        EnvironmentPanel.SetActive(true);
    }

    public void startgame()
    {
        DialougePanel.SetActive(false);
        GamePanel.SetActive(true);
        EnvironmentPanel.SetActive(false);

        Invoke(nameof(showpopup), 1f);
    }

    public void win()
    {
        audiomanager.instance.winsound();
        //GamePanel.SetActive(false);
        //EnvironmentPanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    public void showpopup()
    {
        StartCoroutine(showpopupcoroutine());
    }

    IEnumerator showpopupcoroutine()
    {
        showrandompopup();
        yield return new WaitForSeconds(Random.Range(2f,5f));
        StartCoroutine(showpopupcoroutine());
    }

    void showrandompopup()
    {
        int ran = Random.Range(0, 11);

        if (ran > 5 && ran <8 ) //son
        {
            if (!CollectSon)
            {
                SonPopup.transform.DOLocalMoveX(AnimSonPosX, Random.Range(0.5f, 1f)).OnComplete(() =>
                {
                    SonPopup.transform.DOLocalMoveX(DefaultSonPosX, 3f);
                });
            }
        }
        else if(ran <= 5) //wife
        {
            if (!CollectWife)
            {
                WifePopup.transform.DOLocalMoveX(AnimWifePosX, Random.Range(0.5f, 1f)).OnComplete(() =>
                {
                    WifePopup.transform.DOLocalMoveX(DefaultWifePosX, 3f);
                });
            }
        }
        else if (ran >= 8) //daughter
        {
            if (!CollectDaughter)
            {
                DaughterPopup.transform.DOLocalMoveY(AnimDaughterPosY, Random.Range(0.5f, 1f)).OnComplete(() =>
                {
                    DaughterPopup.transform.DOLocalMoveY(DefaultDaughterPosY, 3f);
                });
            }
        }
    }

    public bool GetSon()
    {
        return CollectSon;
    }

    public void setson(bool b)
    {
        CollectSon = b;
    }


    public bool GetDaughter()
    {
        return CollectDaughter;
    }

    public void setdaughter(bool b)
    {
        CollectDaughter = b;
    }

    public bool Getwife()
    {
        return CollectWife;
    }
    public void setwife(bool b)
    {
        CollectWife = b;
    }

    public void foundpopuptext(string s)
    {
        FoundPopup.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = s;

        FoundPopup.transform.DOLocalMoveY(AnimFoundPopupPosY, 1f).OnComplete(() =>
        {
            Invoke(nameof(goingback), 1f);
        });
    }

    void goingback()
    {
        FoundPopup.transform.DOLocalMoveY(DefaultFoundPopupPosY, 3f).OnComplete(() =>
        {
            manager.instance.gamestatusplaying();

            if(WinCount <= 3)
            {
                WinCount += 1;
            }

            if(WinCount >= 3)
            {
                win();
            }
        });
    }

    public void nextbtn()
    {
        audiomanager.instance.clicksound();

        print("load hub");
        print("Get all key");
        int currentkey = manager.instance.GetTotalKeyEarn();
        if (currentkey == 2)
        {
            currentkey += 1;
        }

        manager.instance.setkeytearn(currentkey);
        manager.instance.setalbumopen(1);

        manager.instance.gamestatusplaying();
        SceneManager.LoadScene("hub");
    }
}
