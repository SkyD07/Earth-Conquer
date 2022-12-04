using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod1Body : MonoBehaviour
{
    private Rigidbody rb;
    public Mod1 enemy;
    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ammo"))
        {
            enemy.hpMonster -= 20;
        }
    }
}
