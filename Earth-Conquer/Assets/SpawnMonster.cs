using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject monster;
    public AudioClip audio;
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
            AudioSource.PlayClipAtPoint(audio, transform.position, 1);
            Destroy(gameObject);
            foreach (Transform pos in spawnPos)
            {
                Instantiate(monster, pos.position, pos.rotation);
            }
        }
    }
}
