using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool used = false;
    public GameObject knife;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0, 0, 0));
        transform.localScale = new Vector3(1, 1, 1);
        knife = GameObject.Find("Knife");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !used)
        {
            rb.AddForce(new Vector3(0, -2500, 0), ForceMode2D.Force);
            used = true;
        }
    }
}
