using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallscript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "destroyer")
        {
            gameObject.SetActive(false);
        }
    }
}
