using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Units // Inheritance

{   private float rotationSpeed = 3.0f; //Encapsulaption
    public AudioClip clipAudio;
    public AudioClip loseAudio;
    private AudioSource audioSource;

    Rigidbody playerRb; //Encapsulaption
    private void Start()
    {
        speed = 5;
        unitRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }
    protected override void Look()  // Polymorphism
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(rotationSpeed * horizontalInput * Vector3.up);
    }

    protected override void move() // Polymorphism
    {
        float verticalInput = Input.GetAxis("Vertical");
        unitDirection = new Vector3(0, 0, verticalInput);
        unitPosition = ObtainPosition();

        base.move();

    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(clipAudio);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(loseAudio);
            SceneManager.LoadScene(0);
        }
        
    }

}
