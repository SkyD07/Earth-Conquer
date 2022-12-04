using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public GameObject thePlayer;
    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 1000f;
    private int k;
    public float timer = Time.time;
    public float time = 10.0f;
    public float timerShout = Time.time;
    public float timeShout = 10.0f;
    public float timerLight = Time.time;
    public float timeLight = 10.0f;
    public float timerSpawn = Time.time;
    public float timeSpawn = 10.0f;
    public float timerDie = Time.time;
    public float timeDie = 10.0f;
    public AudioClip spawnFire;
    public AudioClip shotFire;
    public AudioClip shout;
    public int hp = 10000;
    public ProgressBar stats;
    public Transform[] spawnPos;
    public Transform[] spawnPos2;
    public Transform[] spawnPos3;
    public GameObject monster;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject light;
    private Animator anim;
    public GameObject even;
    private int berserk;
    private int danger;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetInteger ("battle", 1);
        anim.SetInteger ("moving", 0);
        k = 0;
        berserk = 0;
        danger = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        stats.BarValue = hp * 100 / 8000;

        timer += Time.deltaTime;
        timerShout += Time.deltaTime;
        timerLight += Time.deltaTime;
        timerSpawn += Time.deltaTime;
        timerDie += Time.deltaTime;
        transform.LookAt(thePlayer.transform);

        if (hp > 0)
        {
            if ( timerLight >= timeLight )
            {
                Instantiate(light, shotPos.position, shotPos.rotation);
                AudioSource.PlayClipAtPoint(spawnFire, transform.position, 1);
                timerLight = 0;
            } 
            Destroy(GameObject.FindWithTag("light"), 4);

            if ( timerShout >= timeShout )
            {
                anim.SetInteger ("moving", 1);
                AudioSource.PlayClipAtPoint(shout, transform.position, 1);
                timerShout = 2;
            } 
            else anim.SetInteger ("moving", 0);

            if ( timer >= time )
            {
                AudioSource.PlayClipAtPoint(shotFire, transform.position, 1);
                Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
                Vector3 shoot = (thePlayer.transform.position - shotPos.position).normalized;
                shot.AddForce(shoot * shotForce);
                timer = 4;
            } 
            Destroy(GameObject.FindWithTag("meteor"), 8);

            if ( timerSpawn >= timeSpawn )
            {
                foreach (Transform pos in spawnPos)
                {
                    Instantiate(monster, pos.position, pos.rotation);
                }
                timerSpawn = 0;
            } 

            if (hp <= 4000 && danger == 0){
                foreach (Transform pos in spawnPos2)
                {
                    Instantiate(monster2, pos.position, pos.rotation);
                }
                shotForce = 50000.0f;
                timeLight = 15;
                timeShout = 17;
                time = 18;
                danger = 1;
            }
            
            if (hp <= 800 && berserk == 0)
            {
                foreach (Transform pos in spawnPos3)
                {
                    Instantiate(monster3, pos.position, pos.rotation);
                }
                berserk = 1;
            }
        }
        else if (hp <= 0)
        {
            if (k == 0)
            {
                timeDie = 0;
                k = 1;
            }
            Destroy(GameObject.FindWithTag("mob1"));
            if (timerDie >= timeDie)
            {
                even.SetActive(true);
                anim.SetInteger ("moving", 2);
                Destroy(gameObject, 5);
                timerDie = 0;
            }
            else anim.SetInteger ("moving", 0);
            timeDie = 5;
        }
        
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ammo"))
        {
            Destroy(collision.collider.gameObject);
            hp -= 20;
        }
    }
}
