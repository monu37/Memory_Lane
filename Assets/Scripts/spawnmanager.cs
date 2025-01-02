using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnmanager : MonoBehaviour
{
    public static spawnmanager instance;

    [SerializeField] GameObject SpawnComputerPrefabs;
    [SerializeField] GameObject SpawnPlayerPrefabs;
    [SerializeField] Sprite[] ComputerSprites;
    [SerializeField] Sprite[] PlayerSprites;
    //[SerializeField] BoxCollider2D bx;

    [SerializeField] Transform MinXPos, MaxXPos;
    [SerializeField] float MinX, MaxX;
    bool isPlayer;
    private void Awake()
    {
        instance = this;
        //bx = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(spawn), 1f, Random.Range(1f, 2f));


        //MinX = bx.bounds.min.x;
        //MaxX = bx.bounds.max.x;

        MinX = MinXPos.localPosition.x;
        MaxX = MaxXPos.localPosition.x;


    }

    void spawn()
    {
        if (level2manager.instance.GetGameStart())
        {
            GameObject spawnobj = null;
            if (Random.Range(0f, 3f) >= 2)// computer
            {
                spawnobj = SpawnComputerPrefabs;
                isPlayer = false;
            }
            else
            {
                isPlayer = true;
                spawnobj = SpawnPlayerPrefabs;
            }
            BoxCollider2D bx1 = GetComponent<BoxCollider2D>();
            

            float xaxis = Random.Range(MinX, MaxX);
            Vector3 newpos = new Vector3(xaxis, transform.position.y, transform.position.z);
            
            GameObject newobj = Instantiate(spawnobj, newpos, transform.rotation);
            newobj.transform.SetParent(transform, false);

            Image newimg = newobj.GetComponent<Image>();
            newimg.SetNativeSize();

            int ransprites = 0;
            //
            if (isPlayer) //player
            {
                ransprites = Random.Range(0, PlayerSprites.Length);
                newimg.sprite = PlayerSprites[ransprites];
            }
            else //spawns
            {
                ransprites = Random.Range(0, ComputerSprites.Length);
                newimg.sprite = ComputerSprites[ransprites];
            }
            

            RectTransform rt = newobj.GetComponent<RectTransform>();
            BoxCollider2D bx = newobj.GetComponent<BoxCollider2D>();

            bx.size = new Vector2(rt.rect.width, rt.rect.height);

        }
       
    }

    public float GetMinX()
    {
        return MinX;
    }
    public float GetMaxX()
    {
        return MaxX;
    }
}
