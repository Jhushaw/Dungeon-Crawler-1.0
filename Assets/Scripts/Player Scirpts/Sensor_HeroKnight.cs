using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sensor_HeroKnight : MonoBehaviour {

    private int m_ColCount = 0;
    public Text damageTxt;
    private GameObject HeroKnight;
    private Animator HeroKnightAnimator;
    private float deathTimer= 2.5f;
    private bool isDead = false;
    private CurrentRoomDetails currentRoomDetails;

    void Start()
    {
        currentRoomDetails = GameObject.Find("Level").GetComponent<CurrentRoomDetails>();
        damageTxt = GameObject.Find("DamageTxt").GetComponent<Text>();
        HeroKnight = GameObject.Find("HeroKnight");
        HeroKnightAnimator = HeroKnight.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //check if the object that entered the trigger is a door
        if (!other.gameObject.transform.IsChildOf(currentRoomDetails.currentRoom.transform)){
            if (other.gameObject.tag == "Door")
            {
                CameraMovement CameraMover = GameObject.Find("Main Camera").GetComponent<CameraMovement>();

                //TODO: move the camera to that door's parent room center position
                GameObject nextRoom = other.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                currentRoomDetails.SetCurrentRoom(nextRoom);
                CameraMover.MoveCamera(nextRoom.transform.position.x, nextRoom.transform.position.y);
            }
        }
        HeroKnight script = HeroKnight.GetComponent<HeroKnight>();
        //check if character is not rolling or blocking
        if (!script.m_rolling && !script.isBlocking)    
        {
            //check if collider is an npc and has not died yet
            if (other.tag == "NPC" && m_ColCount < 9)
            {
                //take damage
                m_ColCount++;
                damageTxt.text = "Damage Taken: " + m_ColCount;
                HeroKnightAnimator.SetTrigger("Hurt");
                //check if character is npc and is about to die
            } else if (other.tag == "NPC"){
                //kill character
                isDead = true;
                HeroKnightAnimator.SetTrigger("Death");
                damageTxt.text = "You Died!";
            }
        }

    }

    void Update()
    {
        if (isDead)
        {
            deathTimer -= Time.deltaTime;
        }
        if (deathTimer <= 0)
        {
            Destroy(HeroKnight);
        }


    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     m_ColCount--;
    // }
}
