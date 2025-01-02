using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Tshirt" || col.tag == "Pant")
        {
            col.GetComponent<movascript>().boundarycheck();
        }

        
    }

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            //col.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            //col.gameObject.GetComponent<Playerscript>().stopwalk();
            col.gameObject.GetComponent<Playerscript>().setboundary(true);
        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //col.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            //col.gameObject.GetComponent<Playerscript>().walkanim()/*;*/
            col.gameObject.GetComponent<Playerscript>().setboundary(false);

        }
    }


}
