using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<BoxCollider2D>())
        {
            //print(col.name);
            if (col.gameObject.GetComponent<InteractableObj>())
            {
                // for chest
                if (col.gameObject.GetComponent<InteractableObj>().GetChestActivated())
                {
                    manager.instance.setchestactivate(true);
                    col.gameObject.GetComponent<InteractableObj>().showtext();
                }
                // for photo album
                else if (col.gameObject.GetComponent<InteractableObj>().GetPhotoAlbumActivated())
                {
                    manager.instance.setphotoalbumactivate(true);
                    col.gameObject.GetComponent<InteractableObj>().showtext();
                }

                //for computer
                else if (col.gameObject.GetComponent<InteractableObj>().GetComputerAcivated())
                {
                    manager.instance.setcomputeractiavted(true);
                    col.gameObject.GetComponent<InteractableObj>().showtext();
                }

                //for wardrobe
                else if (col.gameObject.GetComponent<InteractableObj>().GetWardrobeAcivated())
                {
                    manager.instance.setwardrobeactivated(true);
                    col.gameObject.GetComponent<InteractableObj>().showtext();
                    //level1manager.instance.wardrobeopen(true);
                }

                //for piano
                else if (col.gameObject.GetComponent<InteractableObj>().GetPianoActivated())
                {
                    if (!level3manager.instance.GetDaughter())
                    {
                        manager.instance.setpianoactivate(true);
                        col.gameObject.GetComponent<InteractableObj>().showtext();
                        //level1manager.instance.wardrobeopen(true);
                    }

                }
                //for cupboard
                else if (col.gameObject.GetComponent<InteractableObj>().GetCupboardActivated())
                {
                    if (!level3manager.instance.Getwife())
                    {
                        manager.instance.setcupboardactivate(true);
                        col.gameObject.GetComponent<InteractableObj>().showtext();
                        //level1manager.instance.wardrobeopen(true);
                    }
                }
                //for curtains
                else if (col.gameObject.GetComponent<InteractableObj>().GetCurtainActivated())
                {
                    if (!level3manager.instance.GetSon())
                    {
                        manager.instance.setcurtainactivate(true);
                        col.gameObject.GetComponent<InteractableObj>().showtext();
                        //level1manager.instance.wardrobeopen(true);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<BoxCollider2D>())
        {
            //print(col.name);
            if (col.gameObject.GetComponent<InteractableObj>())
            { 
                // for chest
                if (col.gameObject.GetComponent<InteractableObj>().GetChestActivated())
                {
                    manager.instance.setchestactivate(false);
                    col.gameObject.GetComponent<InteractableObj>().hidetext();
                }

                //for photo
                else if (col.gameObject.GetComponent<InteractableObj>().GetPhotoAlbumActivated())
                {
                    manager.instance.setphotoalbumactivate(false);
                    col.gameObject.GetComponent<InteractableObj>().hidetext();
                }

                //for computer
                else if (col.gameObject.GetComponent<InteractableObj>().GetComputerAcivated())
                {
                    manager.instance.setcomputeractiavted(false);
                    col.gameObject.GetComponent<InteractableObj>().hidetext();
                }

                //for wardrobe
                else if (col.gameObject.GetComponent<InteractableObj>().GetWardrobeAcivated())
                {
                    manager.instance.setwardrobeactivated(false);
                    col.gameObject.GetComponent<InteractableObj>().hidetext();
                    //level1manager.instance.wardrobeopen(false);
                }

                //for piano
                else if (col.gameObject.GetComponent<InteractableObj>().GetPianoActivated())
                {
                    manager.instance.setpianoactivate(false);
                    col.gameObject.GetComponent<InteractableObj>().hidetext();
                    //level1manager.instance.wardrobeopen(true);
                }
                //for cupboard
                else if (col.gameObject.GetComponent<InteractableObj>().GetCupboardActivated())
                {
                    manager.instance.setcupboardactivate(false);
                    col.gameObject.GetComponent<InteractableObj>().hidetext();
                    //level1manager.instance.wardrobeopen(true);
                }
                //for curtains
                else if (col.gameObject.GetComponent<InteractableObj>().GetCurtainActivated())
                {
                    manager.instance.setcurtainactivate(false);
                    col.gameObject.GetComponent<InteractableObj>().hidetext();
                    //level1manager.instance.wardrobeopen(true);
                }
            }
        }
    }
}
