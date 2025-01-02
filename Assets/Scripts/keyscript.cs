using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyscript : MonoBehaviour
{
    [SerializeField] int KeyNo;
    [SerializeField] GameObject ActivatedKey;

    private void Awake()
    {
        ActivatedKey = transform.GetChild(0).gameObject;
    }

    private void Start()
    {//
        //int checkkey = Helper.GetKeyCount(KeyNo);
        //if (checkkey != 0)
        //{
        //    ActivatedKey.SetActive(true);
        //}
        //else
        //{
        //    ActivatedKey.SetActive(false);

        //}

        int totalkeyearn = manager.instance.GetTotalKeyEarn();
        if(KeyNo < totalkeyearn)
        {
            ActivatedKey.SetActive(true);
        }
        else
        {
            ActivatedKey.SetActive(false);
        }
    }
}
