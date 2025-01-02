using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lobbymanager : MonoBehaviour
{
    private void Start()
    {
        audiomanager.instance.lobbyandinstructionbgsound();
    }

    public void startgame()
    {
        audiomanager.instance.clicksound();
        SceneManager.LoadScene("hub");
    }
}
