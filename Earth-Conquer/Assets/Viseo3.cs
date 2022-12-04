using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Viseo3 : MonoBehaviour
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
        if (timer >= 128) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }
}
