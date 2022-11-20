using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod1 : MonoBehaviour
{
    private Animator anim;
	public float speed = 6.0f;
    public GameObject thePlayer;
    public float targetDistance;
    public float allowedDistance = 1;
    public RaycastHit shot;
    public float timer = Time.time;
    public float time = 2.0f;
    public PlayerStats n;
    public int hpMonster = 200;
    public int i = 1;
    public int j = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger ("battle", 1);
        anim.SetInteger ("moving", 1);
    }

    // Update is called once per frame
    void LateUpdate()
    {
		transform.LookAt(thePlayer.transform);
        timer += Time.deltaTime;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot) && hpMonster > 0)
        {
            targetDistance = shot.distance;
            if (targetDistance >= allowedDistance)
            {
                speed = 0.1f;
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, speed);
                if ( timer >= time )
                {
                    anim.SetInteger ("moving", 1);
                    timer = 0;
                }
                else anim.SetInteger ("moving", 0);
            }
            else
            {
                if ( timer >= time )
                {
                    int n = Random.Range (0, 3);
                    if (n == 1) anim.SetInteger ("moving", 2);
                    else if (n == 2) anim.SetInteger ("moving", 3);
                    else if (n == 3) anim.SetInteger ("moving", 4);  
                    timer = 0;
                    i += 1;
                }
                else anim.SetInteger ("moving", 0);
                speed = 0;   
                if (i != j)
                {
                    n.hp -= 20;
                    j = i;
                }
            }
        }  
        else
        {
            speed = 0;
            time = 10;
            if (timer >= time)
            {
                int n = Random.Range (0, 2);
                if (n == 1) anim.SetInteger ("moving", 8);
                else anim.SetInteger ("moving", 9);
                timer = 0;
                Destroy(gameObject, 1.25f);
            }
            else anim.SetInteger ("moving", 0);
        }
    }
}
