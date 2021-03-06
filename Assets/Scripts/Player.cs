using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance; 

    AudioSource destructionAudio;

    public AudioClip destructionClip;

    public Text destructionText;
    public Text pointsText;
    public int points = 0;

    private Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        destructionAudio = GetComponent<AudioSource>();

        if (instance == null) 
            instance = this;
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {

        Destruction();
    }    
    
    //'Player's' destruction procedure
    void Destruction()
    {
        destructionText.text = "Game Over";
        destructionAudio.clip = destructionClip;
        destructionAudio.Play();
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object 
        Destroy(gameObject);
    }

    void FixedUpdate() {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMove, verticalMove);
        rb.velocity = movement * speed;
    }
}
















