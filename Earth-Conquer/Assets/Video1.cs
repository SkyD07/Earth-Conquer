using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video1 : MonoBehaviour
{
    public float timer = Time.time; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 40) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
