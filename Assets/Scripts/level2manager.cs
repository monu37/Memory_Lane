using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2manager : MonoBehaviour
{
    public static level2manager instance;

    [SerializeField] GameObject EnvironmentPanel;
    [SerializeField] GameObject GamePanel;
    [SerializeField] bool IsGameStart;
    //
    [SerializeField] GameObject Player;
    [SerializeField] TextMeshProUGUI PlayerPointText;
    [SerializeField] int PlayerPoint;
    [SerializeField] GameObject Computer;
    [SerializeField] TextMeshProUGUI ComputerPointText;
    [SerializeField] int ComputerPoint;
    [SerializeField] float Speed;

    //
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float TimerCount;

    //
    [SerializeField] GameObject WinPanel;

    private void Awake()
    {
        instance = this;
        IsGameStart = false;
    }

    private void Start()
    {
        audiomanager.instance.level2bgsound();
        EnvironmentPanel.SetActive(true);
        GamePanel.SetActive(false);

        TimerText.text = TimerCount.ToString();

        setplayerpoint(0);
        setcomputerpoint(0);
    }
    public void Update()
    {
        if (IsGameStart)
        {
            //for computer
            if (Input.GetKey(KeyCode.A))
            {
                //audiomanager.instance.clicksound();
                if (Computer.transform.localPosition.x <= spawnmanager.instance.GetMinX())
                {
                    
                }
                else
                {
                    Computer.transform.position -= new Vector3(Speed * Time.deltaTime, 0);
                }
            }  
            else if (Input.GetKey(KeyCode.D))
            {
                ////audiomanager.instance.clicksound();
                if (Computer.transform.localPosition.x >= spawnmanager.instance.GetMaxX())
                {

                }
                else
                {
                    Computer.transform.position += new Vector3(Speed * Time.deltaTime, 0);
                }
                
            }

            //for player
            if (Input.GetKey(KeyCode.J))
            {
                //audiomanager.instance.clicksound();
                if (Player.transform.localPosition.x <= spawnmanager.instance.GetMinX())
                {

                }
                else
                {
                    Player.transform.position -= new Vector3(Speed * Time.deltaTime, 0);
                }

               
            }
            else if (Input.GetKey(KeyCode.L))
            {
                //audiomanager.instance.clicksound();
                if (Player.transform.localPosition.x >= spawnmanager.instance.GetMaxX())
                {

                }
                else
                {
                    Player.transform.position += new Vector3(Speed * Time.deltaTime, 0);
                }
            }

            //timer
            if (TimerCount > 0)
            {
                TimerCount -= Time.deltaTime;
                int times = (int)TimerCount;
                TimerText.text = times.ToString();
                if (TimerCount <= 0)
                {
                    //you win//
                    print("You win");
                    win();
                   
                }
            }

        }
    }


    ////
    public bool GetGameStart()
    {
        return IsGameStart;
    }

    public void playbtn(GameObject obj)//
    {
        audiomanager.instance.clicksound();
        IsGameStart = true;
        obj.SetActive(false);
    }

    public void startgame()
    {
        audiomanager.instance.clicksound();
        GamePanel.SetActive(true);

    }

    void win()
    {
        audiomanager.instance.winsound();
        WinPanel.SetActive(true);
        IsGameStart = false;
    }

    public void nextbtn()
    {
        audiomanager.instance.clicksound();
        print("load next level");
        print("Get two key");
        int currentkey = manager.instance.GetTotalKeyEarn();
        if (currentkey == 1)
        {
            currentkey += 1;
        }

        manager.instance.setkeytearn(currentkey);
        manager.instance.setalbumopen(1);

        manager.instance.gamestatusplaying();
        SceneManager.LoadScene("hub");
    }
    //
    public void setplayerpoint(int i)
    {
        PlayerPoint += i;
        PlayerPointText.text = PlayerPoint.ToString();
    }
    public void setcomputerpoint(int i)
    {
        ComputerPoint += i;
        ComputerPointText.text = ComputerPoint.ToString();
    }
}
