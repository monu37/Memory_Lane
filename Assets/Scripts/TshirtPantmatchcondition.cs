using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TshirtPantmatchcondition : MonoBehaviour
{
    [SerializeField] bool IsTshirt;
    [SerializeField] bool IsPant;

    //
    [SerializeField] GameObject Correct;
    [SerializeField] GameObject InCorrect;
    [SerializeField] bool IsCorrectMatched;

    private void Start()
    {
        Correct.SetActive(false);
        InCorrect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!IsCorrectMatched)
        {
            if (IsTshirt)
            {
                if (col.tag == "Tshirt")
                {
                    if (col.GetComponent<movascript>().GetCorrectCollection() == true)
                    {
                        col.gameObject.SetActive(false);
                        Correct.SetActive(true);
                        Correct.GetComponent<Image>().sprite = col.GetComponent<Image>().sprite;
                        IsCorrectMatched = true;
                    }
                    else
                    {
                        IsCorrectMatched = false;
                        InCorrect.SetActive(true);
                        col.GetComponent<movascript>().resetpos(InCorrect);
                    }

                }
                else if (col.tag == "Pant")
                {
                    IsCorrectMatched = false;
                    InCorrect.SetActive(true);
                    col.GetComponent<movascript>().resetpos(InCorrect);

                }
            }
            else if (IsPant)
            {
                if (col.tag == "Pant")
                {
                    if (col.GetComponent<movascript>().GetCorrectCollection() == true)
                    {
                        IsCorrectMatched = true;
                        col.gameObject.SetActive(false);
                        Correct.SetActive(true);
                        Correct.GetComponent<Image>().sprite = col.GetComponent<Image>().sprite;
                    }
                    else
                    {
                        IsCorrectMatched = false;
                        InCorrect.SetActive(true);
                        col.GetComponent<movascript>().resetpos(InCorrect);

                    }


                }
                else if (col.tag == "Tshirt")
                {
                    IsCorrectMatched = false;
                    InCorrect.SetActive(true);
                    col.GetComponent<movascript>().resetpos(InCorrect);
                }
            }
        }
        else
        {
            col.GetComponent<movascript>().resetpos(InCorrect);
        }
       
        level1manager.instance.checktotalmatched();
    }

    public bool GetCorrectMatched()
    {
        return IsCorrectMatched;
    }
    public void reset()
    {
        if (Correct.activeInHierarchy)
        {
            Correct.SetActive(false);
        }

        if (InCorrect.activeInHierarchy)
        {
            InCorrect.SetActive(false);
        }

        if (IsCorrectMatched)
        {
            IsCorrectMatched = false;
        }
    }

}
