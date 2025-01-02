using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    [SerializeField] GameObject PressAnyKeyPanel;
    [SerializeField] GameObject InstructionPanel;
    [SerializeField] GameObject ReadyToGoPanel;
    [SerializeField] TextMeshProUGUI ReadyCountDownText;
    [SerializeField] float CountDown;
    float DefaultCountDown; 
    [SerializeField] GameObject[] EnvironmentObjs;

    [SerializeField] GameObject ChestPanel;
    [SerializeField] GameObject PhotoAlbumPanel;

    [SerializeField] GameObject ChestObj, AlbumObj;

    //public manager.Status GameStatus;

    [SerializeField] GameObject Level2Obj;
    [SerializeField] GameObject Level3Obj;

    private void Awake()
    {
        instance = this;
        //GameStatus = Status.Waiting;

        DefaultCountDown = CountDown;
    }

    private void Start()
    {
        if (Helper.GetFirstTime() == 0)
        {
            audiomanager.instance.lobbyandinstructionbgsound();

            environmentonoff(false);
            ReadyCountDownText.text = CountDown.ToString();
        }
        else
        {
            audiomanager.instance.Hubbgsound();

            environmentonoff(true);
        }

        PressAnyKeyPanel.SetActive(true);
        InstructionPanel.SetActive(false);
        ReadyToGoPanel.SetActive(false);

        int totalkey = manager.instance.GetTotalKeyEarn();

        if (totalkey == 0)
        {
            Level2Obj.SetActive(false);
            Level3Obj.SetActive(false);
        }
        else if (totalkey == 1)
        {
            Level2Obj.SetActive(true);
            Level3Obj.SetActive(false);
        }
        else if( totalkey >= 2)
        {
            Level2Obj.SetActive(true);
            Level3Obj.SetActive(true);
        }

        int albumopen = manager.instance.GetOpenAlbumCount();
        if (albumopen == 0)
        {
            PhotoAlbumPanel.SetActive(false);
        }
        else
        {
            PhotoAlbumPanel.SetActive(true);
            PressAnyKeyPanel.SetActive(false);
            manager.instance.setalbumopen(0);

        }

        StartCoroutine(highc());
    }

    void highlight()
    {
        ChestObj.transform.DOScale(new Vector3(1.15f, 1.15f, 1.15f), 1f).OnComplete(() =>
        {
            ChestObj.transform.DOScale(new Vector3(1f, 1f, 1f), 1f).OnComplete(() =>
            {
                AlbumObj.transform.DOScale(new Vector3(1.15f, 1.15f, 1.15f), 1f).OnComplete(() =>
                {
                    AlbumObj.transform.DOScale(new Vector3(1f, 1f, 1f), 1f);
                });
            });
        });
    }

    IEnumerator highc()
    {
        if(manager.instance.GetTotalKeyEarn() == 1)
        {
            highlight();
            yield return new WaitForSeconds(4f);
            StartCoroutine(highc());
        }
       
    }
    void environmentonoff(bool b)
    {
        for (int i = 0; i < EnvironmentObjs.Length; i++)
        {
            EnvironmentObjs[i].SetActive(b);
        }
    }

    private void Update()
    {
        if (Input.anyKey && manager.instance.GameStatus == manager.Status.Waiting)
        {
            print("key or mouse pressed");
            if (Helper.GetFirstTime() == 0)
            {
                audiomanager.instance.clicksound();

                manager.instance.GameStatus = manager.Status.Instruction;
                InstructionPanel.SetActive(true);
            }
            else
            {
                audiomanager.instance.clicksound();

                manager.instance.GameStatus = manager.Status.playing;
            }

            PressAnyKeyPanel.SetActive(false);

        }

        if(manager.instance.GameStatus == manager.Status.ReadyToGo)
        {
            if (CountDown > 0)
            {
                CountDown -= Time.deltaTime;
                int count = (int)CountDown;

                if (CountDown <= 0)
                {
                    CountDown = 0;
                    setreadytogopanelonoff(false);
                    environmentonoff(true);
                    manager.instance.GameStatus = manager.Status.playing;
                }

                ReadyCountDownText.text = count.ToString();
            }
        }

        //
        //if (PressButtonPrefab.activeInHierarchy)
        //{
        //    //press space
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        print("button pressed");
        //        PhotoAlbumPanel.SetActive(true);
        //        PressButtonPrefab.SetActive(false);
        //    }
        //}
    }

    public void setreadytogopanelonoff(bool b)
    {
        ReadyToGoPanel.SetActive(b);
    }

    //
    //public GameObject GetPressPrefab()
    //{
    //    return PressButtonPrefab;
    //}


    //
    public void onoffchestpanel(bool b)
    {
                audiomanager.instance.clicksound();
        if (!b)
        {
            manager.instance.gamestatusplaying();//
        }
        ChestPanel.SetActive(b);
    }

    public void winthegame()
    {

    }
    
    //
    public void onoffphotopanel(bool b)
    {
                audiomanager.instance.clicksound();
        if (!b)
        {
            manager.instance.gamestatusplaying();
        }
        PhotoAlbumPanel.SetActive(b);
    }

    //load level
    public void level1()
    {
                audiomanager.instance.clicksound();
        SceneManager.LoadScene("level1");
        manager.instance.gamestatusplaying();
    }
    public void level2()
    {
                audiomanager.instance.clicksound();
        SceneManager.LoadScene("level2");
        manager.instance.gamestatusplaying();
    }
    public void level3()
    {
                audiomanager.instance.clicksound();
        SceneManager.LoadScene("level3");
        manager.instance.gamestatusplaying();
    }
}
