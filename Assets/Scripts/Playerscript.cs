using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    Animator Anim;
    [SerializeField] float Speed;
    Vector3 PlayerSize;
    [SerializeField]Pose OriginPos;
    bool IsBoundary;
    private void Awake()
    {
        Anim = GetComponent<Animator>();

        PlayerSize = transform.localScale;

        OriginPos.position = transform.localPosition;
        OriginPos.rotation = transform.localRotation;
    }

    public void resetpostoorigin()
    {
        transform.localPosition = OriginPos.position;
        transform.localRotation = OriginPos.rotation;
    }

    private void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(manager.instance.GameStatus == manager.Status.playing)
        {

            if (Horizontal > 0) //move right
            {
                Anim.SetBool("IsWalkingLeft", false);
                Anim.SetBool("IsWalkingRight", true);
                Anim.SetBool("IsWalkingUp", false);
                Anim.SetBool("IsWalkingDown", false);
                transform.position += new Vector3(Speed * Time.deltaTime, 0);
                //transform.localScale = new Vector3(PlayerSize.x, PlayerSize.y, PlayerSize.z);

            }
            else if (Horizontal < 0) //move left
            {
                Anim.SetBool("IsWalkingLeft", true);
                Anim.SetBool("IsWalkingRight", false);
                Anim.SetBool("IsWalkingUp", false);
                Anim.SetBool("IsWalkingDown", false);
                transform.position -= new Vector3(Speed * Time.deltaTime, 0);
                //transform.localScale = new Vector3(-PlayerSize.x, PlayerSize.y, PlayerSize.z);

            }


            if (vertical > 0) //move up
            {
                Anim.SetBool("IsWalkingLeft", false);
                Anim.SetBool("IsWalkingRight", false);
                Anim.SetBool("IsWalkingUp", true);
                Anim.SetBool("IsWalkingDown", false);
                transform.position += new Vector3(0,Speed * Time.deltaTime, 0);
                //transform.localScale = new Vector3(PlayerSize.x, PlayerSize.y, PlayerSize.z);

            }
            else if (vertical < 0) //move down
            {
                Anim.SetBool("IsWalkingLeft", false);
                Anim.SetBool("IsWalkingRight", false);
                Anim.SetBool("IsWalkingUp", false);
                Anim.SetBool("IsWalkingDown", true);
                transform.position -= new Vector3(0,Speed * Time.deltaTime, 0);
                //transform.localScale = new Vector3(PlayerSize.x, PlayerSize.y, PlayerSize.z);

            }

            else
            {
                transform.position += Vector3.zero;
            }

            if (!IsBoundary)
            {
                if (Horizontal != 0)
                {
                   
                }
                else //idle
                {
                    Anim.SetBool("IsWalkingLeft", false);
                    Anim.SetBool("IsWalkingRight", false);

                }

                if (vertical != 0)
                {
                }
                else
                {

                    Anim.SetBool("IsWalkingUp", false);
                    Anim.SetBool("IsWalkingDown", false);
                }
            }

        }
    }

    public void leftwalk()
    {
        Anim.SetBool("IsWalkingLeft", true);
        Anim.SetBool("IsWalkingRight", false);
        Anim.SetBool("IsWalkingUp", false);
        Anim.SetBool("IsWalkingDown", false);
        transform.position -= new Vector3(Speed * Time.deltaTime, 0);
        //transform.localScale = new Vector3(-PlayerSize.x, PlayerSize.y, PlayerSize.z);


    }

    //public void walkanim()
    //{
    //    Anim.SetBool("IsWalking", true);
    //}

    public void stopwalk()
    {
        Anim.SetBool("IsWalkingLeft", false);
        Anim.SetBool("IsWalkingRight", false);
        //Anim.SetBool("IsWalkingUp", false);
        //Anim.SetBool("IsWalkingDown", true);

    }



    public void rightwalk()
    {
        Anim.SetBool("IsWalkingLeft", false);
        Anim.SetBool("IsWalkingRight", true);
        Anim.SetBool("IsWalkingUp", false);
        Anim.SetBool("IsWalkingDown", false);
        transform.position += new Vector3(Speed * Time.deltaTime, 0);

        //walkanim();
    }
    
    public void upwalk()
    {
        Anim.SetBool("IsWalkingLeft", false);
        Anim.SetBool("IsWalkingRight", false);
        Anim.SetBool("IsWalkingUp", true);
        Anim.SetBool("IsWalkingDown", false);
        transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
    }
    
    public void downwalk()
    {
        Anim.SetBool("IsWalkingLeft", false);
        Anim.SetBool("IsWalkingRight", false);
        Anim.SetBool("IsWalkingUp", false);
        Anim.SetBool("IsWalkingDown", true);
        transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
    }

    public void setboundary(bool b)
    {
        //if (b)
        //{
        //    Anim.SetBool("IsWalkingUp", false);
        //    Anim.SetBool("IsWalkingDown", false);
        //    Anim.SetBool("IsWalkingUp", false);
        //    stop anim
        //}
        //else
        //{
        //    walk
        //    Anim.SetBool("IsWalkingUp", false);
        //    Anim.SetBool("IsWalkingDown", false);
        //    Anim.SetBool("IsWalkingUp", false);
        //}
        IsBoundary = b;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (manager.instance.GameStatus == manager.Status.Instruction)
        {

            if (col.tag == "LeftPoint")
            {
                instructionscript.instance.leftinstuctioncompleted();
            }
            if (col.tag == "RightPoint")
            {
                instructionscript.instance.rightinstuctioncompleted();

            }
            if (col.tag == "UpPoint")
            {
                instructionscript.instance.upinstuctioncompleted();

            }
            if (col.tag == "DownPoint")
            {
                instructionscript.instance.downinstuctioncompleted();

            }
        }
    }
}
