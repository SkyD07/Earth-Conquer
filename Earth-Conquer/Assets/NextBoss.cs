using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBoss : MonoBehaviour
{
    public AudioClip audio;
    public GameObject boss;
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
            boss.SetActive(true);
            Destroy(gameObject);
        }
    }
}
