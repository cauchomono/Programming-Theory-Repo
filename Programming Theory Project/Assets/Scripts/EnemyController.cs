using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Units // Inheritance
{
    private PlayerController target; //Encapsulaption
    private Vector3 targetPosition; //Encapsulaption

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<PlayerController>();
        speed = 1.5f;
        unitRb = GetComponent<Rigidbody>();
        
    }
    protected override void Look() // Polymorphism
    {
        targetPosition = target.unitPosition - transform.position;
        transform.rotation = Quaternion.LookRotation(targetPosition, Vector3.up);
    }

    protected override void move() // Polymorphisms
    {
        unitDirection = Vector3.forward;
        unitPosition = ObtainPosition();

        base.move();

    }
    

}
