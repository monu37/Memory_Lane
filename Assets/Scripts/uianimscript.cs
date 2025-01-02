using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uianimscript : MonoBehaviour
{
    public void animon()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void animoff()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
