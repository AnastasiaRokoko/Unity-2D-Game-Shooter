using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
 



    public float distance = 1f;
    Artist_Player player;
    public float speed = -2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Artist_Player>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance);

        if (hit.collider != null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,speed);
        }
    }
}
