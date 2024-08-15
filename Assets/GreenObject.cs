using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenObject : MonoBehaviour
{
    public static int health = 4;
    public static Material matBlink;
    public static Material matDefault;
    public static SpriteRenderer spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("HealthFlashing", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        
       
       
    }

    // Update is called once per frame
    void Update()
    {   /*
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("HealthFlashing", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        */
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Knife"))
        {
            Destroy(collision.gameObject);//нож в момент попадания исчезает
            health--;

            spriteRend.material = matBlink;

            if (health <= 0)
            {
                //kill
                KillEnemy();
            }
            else
            {
                Invoke("ResetMaterial", .2f);
            }
        }
        
    }

    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }
    

     public  void KillEnemy()
    {
        Destroy(gameObject);
    }
}
