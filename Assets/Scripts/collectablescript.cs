using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectablescript : MonoBehaviour
{
    public enum Option
    {
        IsPlayer,
        IsComputer
    }

    public Option CollectName;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (CollectName == Option.IsPlayer)
        {
            if (col.tag == "player gadgets")
            {
                level2manager.instance.setplayerpoint(1);
                correctcollect(col.gameObject);
            }
            if (col.tag == "gadgets")
            {
                incorrectcollect(col.gameObject);
                col.gameObject.SetActive(false);
            }

        }
        else if (CollectName == Option.IsComputer)
        {
            if (col.tag == "gadgets")
            {
                level2manager.instance.setcomputerpoint(1);
                correctcollect(col.gameObject);
            }
            if (col.tag == "player gadgets")
            {
                incorrectcollect(col.gameObject);
                col.gameObject.SetActive(false);
            }

        }
    }

    void correctcollect(GameObject Obj)
    {
        GetComponent<Image>().color = Color.green;
        //
        Obj.transform.DOScale(Vector3.zero, .5f).OnComplete(() =>
        {
            transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), .4f);//
            //transform.DOShakeScale(1f, 3, 2, 2);/

            Invoke(nameof(normalcolr), .4f);
        });
        
    }
    void incorrectcollect(GameObject Obj)
    {
        GetComponent<Image>().color = Color.red;
        //
        Obj.transform.DOScale(Vector3.zero, .5f).OnComplete(() =>
        {
            transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), .3f);
            //transform.DOShakeScale(1f, 3, 2, 2);

            Invoke(nameof(normalcolr), .4f);
        });
    }

    void normalcolr()
    {
        GetComponent<Image>().color = Color.white;

    }
}
