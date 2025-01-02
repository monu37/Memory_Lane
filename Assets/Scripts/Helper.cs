using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public static int GetFirstTime()
    {
        return PlayerPrefs.GetInt("FirstTime");
    }
    public static void setfirsttime(int i)
    {
        PlayerPrefs.SetInt("FirstTime", i);
    }

    //
    //public static int GetKeyCount(int i)
    //{
    //    return PlayerPrefs.GetInt("Keys" + i);
    //}
    //public static void setkeycount(int i, int j)
    //{
    //    PlayerPrefs.SetInt("keys" + i, j);
    //}

    public static int GetTotalKey()
    {
        return PlayerPrefs.GetInt("totalkey");
    }
    public static void settotalkey(int i)
    {
        PlayerPrefs.SetInt("totalkey", i);
    }

}
