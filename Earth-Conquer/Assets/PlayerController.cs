using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    [Range(0f, 10f)]
    public float turnSpeed = 1f;
    public float shotForce = 1000f;
    public Rigidbody projectile;
    public Transform shotPos;
    public float time = 0.5f;
    public float timer = Time.time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        gameObject.transform.Translate(h, 0f, v);
        float h1 = turnSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h1, 0);
        timer += Time.deltaTime;

        if ( timer >= time )
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
                shot.AddForce(shotPos.forward * shotForce);
                timer = 0;
            }
        }
        Destroy(GameObject.FindWithTag("ammo"), 2);
    }
}
