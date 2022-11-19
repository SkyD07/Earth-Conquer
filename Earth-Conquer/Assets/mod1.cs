using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod1 : MonoBehaviour
{
    private Animator anim;
	private CharacterController controller;
	private int battle_state = 1;
	public float speed = 6.0f;
	public float runSpeed = 3.0f;
	public float turnSpeed = 60.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private float w_sp = 0.0f;
	private float r_sp = 0.0f;
    public GameObject thePlayer;
    public float targetDistance;
    public float allowedDistance = 1;
    public GameObject theNpc;
    public RaycastHit shot;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController> ();
        anim.SetInteger ("battle", 1);
    }

    // Update is called once per frame
    void Update()
    {
		transform.LookAt(thePlayer.transform);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if (targetDistance >= allowedDistance)
            {
                speed = 0.1f;
                anim.SetInteger ("moving", 2);
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, speed);
            }
            else
            {
                anim.SetInteger ("moving", 0);
                speed = 0;
            }
        }  
    }
}
