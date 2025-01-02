using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestscript : MonoBehaviour
{
    public static chestscript instance;

    [SerializeField] GameObject LockedChestPanel;
    [SerializeField] GameObject UnlockChestPanel;
    [SerializeField] GameObject WinPanel;

    [SerializeField] GameObject ChestObj;
    [SerializeField] Button OpenBtn;
    [SerializeField] Button closewinBtn;

    [SerializeField] GameObject[] wineffect;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(manager.instance.GetTotalKeyEarn() >= 3)
        {
            UnlockChestPanel.SetActive(true);
            LockedChestPanel.SetActive(false); 
            WinPanel.SetActive(false);
        }
        else
        {
            UnlockChestPanel.SetActive(false);
            LockedChestPanel.SetActive(true);
            WinPanel.SetActive(false);
        }

        //
        OpenBtn.onClick.RemoveAllListeners();
        OpenBtn.onClick.AddListener(() => clickbtn());

        //
        closewinBtn.onClick.RemoveAllListeners();
        closewinBtn.onClick.AddListener(() => closewin());
    }

    void clickbtn()
    {
        for (int i = 0; i < wineffect.Length; i++)
        {
            wineffect[i].SetActive(true);
        }
        audiomanager.instance.clicksound();
        ChestObj.GetComponent<Animator>().SetBool("Open_chest", true);
        Invoke(nameof(win), 1f);
    }

    void win()
    {
        WinPanel.SetActive(true);
    }

    void closewin()
    {
        WinPanel.SetActive(false);
    }
}
