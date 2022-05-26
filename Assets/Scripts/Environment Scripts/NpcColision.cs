using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcColision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //create collision trigger
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "NPC")
        {
            Debug.Log("NPC has collided with wall");
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            //set velocity to 0
            rb.velocity = Vector2.zero;
        }
    }
}
