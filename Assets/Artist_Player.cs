using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artist_Player : MonoBehaviour
{
    public float speed;
    public float jumpForce = 7f;
    private Rigidbody2D _body;
    bool canJump;
    bool canWallJump;
    //public float gravity = -9.8f;

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&canJump)
        {
            //_body.velocity = new Vector2(_body.velocity.x, jumpForce);
            DoJump();
        }
    }
    public void DoJump()
    {
        _body.velocity = new Vector2(_body.velocity.x, jumpForce);
    }
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);//задаем движение влево-вправо
        _body.velocity = movement;
        //movement.y -= gravity * Time.deltaTime;
        Jump();
        if (canWallJump == true)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife"))
        {
            Destroy(collision.gameObject);//нож в момент попадания исчезает
            GreenObject.health--;

            GreenObject.spriteRend.material = GreenObject.matBlink;

            if (GreenObject.health <= 0)
            {
                //kill
                //GreenObject.KillEnemy();
            }
            else
          
            {
                Invoke("ResetMaterial", .5f);
            }
        }

    }
    void ResetMaterial()
    {
        GreenObject.spriteRend.material = GreenObject.matDefault;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            canWallJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            canWallJump = true;
        }
    }
   
}
