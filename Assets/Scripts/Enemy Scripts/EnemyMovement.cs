using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float      m_speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // while colliding 2d
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 playerLocation = collision.gameObject.transform.position;
            Rigidbody2D parentsRigidBody = this.gameObject.transform.parent.GetComponent<Rigidbody2D>();
            parentsRigidBody.velocity = new Vector2(playerLocation.x - this.gameObject.transform.position.x, playerLocation.y - this.gameObject.transform.position.y).normalized * m_speed;
        }
        
    }

}
