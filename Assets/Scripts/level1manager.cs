using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1manager : MonoBehaviour
{
    public static level1manager instance;

    [SerializeField] TextMeshProUGUI TotalCollectText;

    [Header("Match Condition")]
    [SerializeField] int TotalMatched;
    [SerializeField] int CurrentMatched;
    [SerializeField] TshirtPantmatchcondition TshirtMatchConditions;
    [SerializeField] TshirtPantmatchcondition PantMatchConditions;

    [SerializeField] GameObject EnvironmentPanel;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject WinPanel;

    [SerializeField] GameObject ParentClotheObj;
    [SerializeField] List<GameObject> AllClothesChild;

    //[SerializeField] GameObject ClosedWardrobe;
    [SerializeField] GameObject OpenWardrobe;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audiomanager.instance.level1bgsound();
        CurrentMatched = 0;

        //
        for (int i = 0; i < AllClothesChild.Count; i++)
        {
            AllClothesChild[i].GetComponent<movascript>().setchildno(i);
        }

        EnvironmentPanel.SetActive(true);
        GamePanel.SetActive(false);

        settotalcollect();

    }

    public void checktotalmatched()
    {
        if(CurrentMatched >= TotalMatched)
        {
            Invoke(nameof(win), .5f);

        }
        else
        {
            if (TshirtMatchConditions.GetCorrectMatched() && PantMatchConditions.GetCorrectMatched())
            {
                CurrentMatched += 1;

                Invoke(nameof(resetcondition), .4f);
            }

            if (TotalMatched == CurrentMatched)
            {
                Invoke(nameof(win), .5f);
            }
        }
        settotalcollect();
    }

    void win()
    {
                audiomanager.instance.winsound();
        WinPanel.SetActive(true);
        print("You win this round");
    }
    void resetcondition()
    {
        TshirtMatchConditions.reset();
        PantMatchConditions.reset();
    }

    public void nextbtn()
    {
                audiomanager.instance.clicksound();
        //
        print("load next level");
        print("Get one key");
        int currentkey = manager.instance.GetTotalKeyEarn();
        if (currentkey == 0)
        {
            currentkey += 1;
        }

        manager.instance.setkeytearn(currentkey);   
        manager.instance.setalbumopen(1);

        manager.instance.gamestatusplaying();
        SceneManager.LoadScene("hub");
    }

    public void pickclothes(GameObject obj)
    {
                audiomanager.instance.clicksound();
        obj.transform.SetAsLastSibling();

        //
        //Transform childToMove = ParentClotheObj.transform.GetChild(childno);

        //// 
        //Transform lastChild = ParentClotheObj.transform.GetChild(ParentClotheObj.transform.childCount - 1);

        //// 
        //int tempSiblingIndex = childToMove.GetSiblingIndex();
        //childToMove.gameObject.GetComponent<movascript>().setchildno(lastChild.GetSiblingIndex());
        //childToMove.SetSiblingIndex(lastChild.GetSiblingIndex());

        //lastChild.SetSiblingIndex(tempSiblingIndex);
        //lastChild.gameObject.GetComponent<movascript>().setchildno(tempSiblingIndex);


    }

    void settotalcollect()
    {
        TotalCollectText.text = "COLLECT: " + CurrentMatched + "/"+ TotalMatched;
    }

    public void startgame()
    {
                audiomanager.instance.clicksound();
        EnvironmentPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void wardrobeopen(bool b)
    {
                audiomanager.instance.clicksound();
        OpenWardrobe.SetActive(b);

    }
}
