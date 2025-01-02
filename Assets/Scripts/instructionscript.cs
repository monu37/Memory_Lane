using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionscript : MonoBehaviour
{
    public static instructionscript instance;

    [SerializeField] GameObject LeftInstruction;
    bool LeftInst;
    [SerializeField] GameObject RightInstruction;
    bool RightInst;
    [SerializeField] GameObject UpInstruction;
    bool UpInst;
    [SerializeField] GameObject DownInstruction;
    bool DownInst;
    [SerializeField] bool LeftPoint, RightPoint, UpPoint, DownPoint;

    [SerializeField]GameObject player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void OnEnable()
    {
        LeftInstruction.SetActive(true);
        RightInstruction.SetActive(false);
        UpInstruction.SetActive(false);
        DownInstruction.SetActive(false);

        LeftInst = true;
        RightInst = false;
        UpInst = false;
        DownInst = false;
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (hor == 0)
        {
            player.GetComponent<Playerscript>().stopwalk();
        }
        if (manager.instance.GameStatus == manager.Status.Instruction)
        {
            if (LeftInst && !RightInst && !LeftPoint)
            {
                if (hor < 0)
                {
                    player.GetComponent<Playerscript>().leftwalk();
                }

            }
            else if (RightInst && !LeftInst && !RightPoint)
            {
                if (hor > 0)
                {
                    player.GetComponent<Playerscript>().rightwalk();
                }
            }
            
            else if (!RightInst && !LeftInst && UpInst )
            {
                if (ver > 0)
                {
                    player.GetComponent<Playerscript>().upwalk();
                }
            }
            else if (!RightInst && !LeftInst && !UpInst && DownInst)
            {
                if (ver < 0)
                {
                    player.GetComponent<Playerscript>().downwalk();
                }
            }

        }
    }

    public void leftinstuctioncompleted()
    {
        LeftInstruction.SetActive(false);
        LeftInst = false;
        RightInst = true;
        RightInstruction.SetActive(true);
    }
    public void rightinstuctioncompleted()
    {
        RightInstruction.SetActive(false);
        LeftInst = false;
        RightInst = false;
        UpInst = true;
        UpInstruction.SetActive(true);

        ////gamemanager.instance.EnvironmentObj.SetActive(true);
        //gamemanager.instance.setreadytogopanelonoff(true);
        //manager.instance.GameStatus = manager.Status.ReadyToGo;

        //Helper.setfirsttime(10);

        //player.GetComponent<Playerscript>().resetpostoorigin();
        //gameObject.SetActive(false);
    }
    public void upinstuctioncompleted()
    {
        UpInstruction.SetActive(false);
        LeftInst = false;
        RightInst = false;
        UpInst = false;
        DownInst = true;
        DownInstruction.SetActive(true);

        ////gamemanager.instance.EnvironmentObj.SetActive(true);
        //gamemanager.instance.setreadytogopanelonoff(true);
        //manager.instance.GameStatus = manager.Status.ReadyToGo;

        //Helper.setfirsttime(10);

        //player.GetComponent<Playerscript>().resetpostoorigin();
        //gameObject.SetActive(false);
    }
    public void downinstuctioncompleted()
    {
        DownInstruction.SetActive(false);
        LeftInst = false;
        RightInst = false;
        UpInst = false;
        DownInst = false;
        //DownInstruction.SetActive(true);

        //gamemanager.instance.EnvironmentObj.SetActive(true);
        gamemanager.instance.setreadytogopanelonoff(true);
        manager.instance.GameStatus = manager.Status.ReadyToGo;

        Helper.setfirsttime(10);

        player.GetComponent<Playerscript>().resetpostoorigin();
        gameObject.SetActive(false);
    }
}
