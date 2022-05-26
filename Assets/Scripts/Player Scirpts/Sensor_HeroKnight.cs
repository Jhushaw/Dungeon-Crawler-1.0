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

    void Start()
    {
        damageTxt = GameObject.Find("DamageTxt").GetComponent<Text>();
        HeroKnight = GameObject.Find("HeroKnight");
        HeroKnightAnimator = HeroKnight.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NPC" && m_ColCount < 9)
        {
            m_ColCount++;
            damageTxt.text = "Damage Taken: " + m_ColCount;
            HeroKnightAnimator.SetTrigger("Hurt");


        } else if (other.tag == "NPC"){
            isDead = true;
            HeroKnightAnimator.SetTrigger("Death");
            damageTxt.text = "You Died!";
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
