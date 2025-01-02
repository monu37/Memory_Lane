using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager instance;

    [SerializeField] AudioSource BgSource, ClickSource;
    [SerializeField] AudioClip LobbyClip;
    [SerializeField] AudioClip ButtonClip;
    [SerializeField] AudioClip Level1Clip;
    [SerializeField] AudioClip WinClip;
    [SerializeField] AudioClip HubClip;
    [SerializeField] AudioClip Level3Clip;
    [SerializeField] AudioClip Level2Clip;
    [SerializeField] AudioClip OpenChestClip;


    private void Awake()
    {
        instance = this;
    }

    public void clicksound()
    {
        ClickSource.PlayOneShot(ButtonClip);
    }
    public void level1bgsound()
    {
        BgSource.clip = Level1Clip;
        BgSource.Play();
        BgSource.loop = true;
    }
    public void lobbyandinstructionbgsound()
    {
        BgSource.clip = LobbyClip;
        BgSource.Play();
        BgSource.loop = true;
    }
    public void level2bgsound()
    {
        BgSource.clip = Level2Clip;
        BgSource.Play();
        BgSource.loop = true;
    }
    public void level3bgsound()
    {
        BgSource.clip = Level3Clip;
        BgSource.Play();
        BgSource.loop = true;
    }
    public void Hubbgsound()
    {
        BgSource.clip = HubClip;
        BgSource.Play();
        BgSource.loop = true;
    }
    public void openchestsound()
    {
        ClickSource.PlayOneShot(OpenChestClip);
    }
    public void winsound()
    {
        ClickSource.PlayOneShot(WinClip);
    }
}
