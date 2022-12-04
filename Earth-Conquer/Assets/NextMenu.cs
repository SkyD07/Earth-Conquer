using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMenu : MonoBehaviour
{
    public GameObject menu;
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
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
            Destroy(gameObject);
        }
    }
}
