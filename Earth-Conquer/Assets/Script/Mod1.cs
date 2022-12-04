using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod1 : MonoBehaviour
{
    private Animator anim;
	private float speed;
    public float run;
    public GameObject thePlayer;
    public float targetDistance;
    public float allowedDistance = 1;
    public float dist;
    public RaycastHit shot;
    public float timer = Time.time;
    public float time = 1.0f;
    public int hpMonster = 200;
    public AudioClip gotHit;
    public int k=0;
    private Rigidbody rb;
    AudioSource audioData;
    public Rigidbody limb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger ("battle", 1);
        anim.SetInteger ("moving", 1);
        thePlayer = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero; 
		transform.LookAt(thePlayer.transform);
        timer += Time.deltaTime;
        dist = Vector3.Distance(thePlayer.transform.position, transform.position);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot) && hpMonster > 0)
        {
            targetDistance = shot.distance;
            if (dist >= allowedDistance)
            {
                speed = run;
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, speed);
                if ( timer >= time )
                {
                    anim.SetInteger ("moving", 1);
                    timer = 0;
                }
                else anim.SetInteger ("moving", 0);
                time = 1;
            }
            else
            {
                speed = 0;
                if ( timer >= time )
                {
                    anim.SetInteger ("moving", 2);
                    timer = 0;                  
                }
                else anim.SetInteger ("moving", 0);
                time = 1.5f;
            }
        }  
        else if (hpMonster <= 0)
        {
            if (k == 0)
            {
                time = 0;
                k = 1;
            }
            speed = 0;
            if (timer >= time)
            {
                Destroy(limb.GetComponent<Rigidbody>());
                anim.SetInteger ("moving", 9);
                Destroy(gameObject, 1.25f);
                AudioSource.PlayClipAtPoint(gotHit, transform.position, 1);
                timer = 0;
            }
            else anim.SetInteger ("moving", 0);
            time = 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ammo"))
        {
            speed = 0.01f;
            hpMonster -= 20;
        }
    }
}
