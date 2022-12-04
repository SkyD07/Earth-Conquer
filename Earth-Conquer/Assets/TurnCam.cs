using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCam : MonoBehaviour
{
    public float turnSpeed;
    private float rotation = 0f;
    private Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation -= Input.GetAxis ("Mouse Y") * turnSpeed;
        rotation = Mathf.Clamp (rotation, -35.0f, 17.0f);
        rot = transform.eulerAngles;
        rot.x = rotation;
        transform.eulerAngles = rot;
    }
}
