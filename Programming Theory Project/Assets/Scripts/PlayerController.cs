using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Units
{   private float rotationSpeed = 3;
    
    Vector3 playerDirection;
    Rigidbody playerRb;
    private void Start()
    {
        speed = 3;
        unitRb = GetComponent<Rigidbody>();
    }
    protected override void Look()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(speed  * horizontalInput * Vector3.up);
    }

    protected override void move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        unitDirection = new Vector3(0, 0, verticalInput);
        unitDirection = transform.TransformDirection(playerDirection);

       
        unitRb.MovePosition(unitPosition + speed * unitDirection * Time.deltaTime);

    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            Destroy(other.gameObject);
        }
    }
    
}
