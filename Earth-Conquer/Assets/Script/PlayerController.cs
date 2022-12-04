using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    AudioSource audioData;
    public float moveSpeed = 10f;
    [Range(0f, 10f)]
    public float turnSpeed = 1f;
    public float shotForce = 1000f;
    public Rigidbody projectile;
    public Transform shotPos;
    public float time = 0.5f;
    public float timer = Time.time; 
    public float timeWalk = 0.5f;
    public float timerWalk = Time.time;
    public int hp = 100;
    public GameObject m_GotHitScreen;
    public AudioClip gotHit;
    public AudioClip die;
    public AudioClip walk;
    public AudioClip bossHit;
    public int varSound = 0;
    public ProgressBarCircle stats;
    public GameObject menu;
    private Rigidbody rb;
    public GameObject light;
   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero; 
        stats.BarValue = hp * 100 / 1000;
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float h1 = turnSpeed * Input.GetAxis("Mouse X");
        
        Destroy(GameObject.FindWithTag("boom"), 2);

        if (hp > 0)
        {
            gameObject.transform.Translate(h, 0f, v);
            transform.Rotate(0, h1, 0);
            
        }
        timer += Time.deltaTime;
        timerWalk += Time.deltaTime;

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal") )
        {
            if ( timerWalk >= timeWalk )
            {
                AudioSource.PlayClipAtPoint(walk, transform.position, 1);
                timerWalk = 0;
            }
            
        }

        if ( timer >= time )
        {
            if (Input.GetButton("Fire1"))
            {
                if (hp > 0)
                {
                    Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
                    shot.AddForce(shotPos.forward * shotForce);
                    timer = 0;
                }
            }
        } 
        Destroy(GameObject.FindWithTag("ammo"), 2);
        

        if (m_GotHitScreen != null && hp > 0)
        {
            if (m_GotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }

        if (hp <= 0 && varSound == 0)
        {
            AudioSource.PlayClipAtPoint(die, transform.position, 1);
            varSound = 1;
            var color = m_GotHitScreen.GetComponent<Image>().color;
            color.a = 0.8f;
            m_GotHitScreen.GetComponent<Image>().color = color;
        }

        if (hp <= 0){
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("hit"))
        {
            GotHurt();
            hp -= 15;
        }

        if (collision.collider.CompareTag("hit2"))
        {
            GotHurt();
            hp -= 30;
        }

        if (collision.collider.CompareTag("hit3"))
        {
            GotHurt();
            hp -= 50;
        }

        if (collision.collider.CompareTag("meteor"))
        {
            AudioSource.PlayClipAtPoint(bossHit, transform.position, 1);
            Instantiate(light, shotPos.position, shotPos.rotation);
            Destroy(collision.collider.gameObject);
            hp -= 100;
        }
    }

    void GotHurt()
    {
        if (hp > 0)
        {
            var color = m_GotHitScreen.GetComponent<Image>().color;
            color.a = 0.8f;
            AudioSource.PlayClipAtPoint(gotHit, transform.position, 1);
            m_GotHitScreen.GetComponent<Image>().color = color;
        }
        else hp = 0;     
    }
}
