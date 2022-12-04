using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poin1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(GameObject.FindWithTag("spawn1"));
        }
    }
}
