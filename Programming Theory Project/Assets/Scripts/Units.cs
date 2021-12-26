using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Units : MonoBehaviour // Inheritance
{
    protected float speed; //Encapsulaption
    public Vector3 unitPosition { get; protected set; } //Encapsulaption
    protected Rigidbody unitRb; //Encapsulaption
    protected  Vector3 unitDirection; //Encapsulaption


    protected virtual void move() // Abstraction and refactoring
    {
        unitDirection = transform.TransformDirection(unitDirection);
        unitRb.MovePosition(unitPosition + speed * unitDirection * Time.deltaTime);
    }

    protected virtual Vector3 ObtainPosition() // Abstraction and refactoring
    {
        unitPosition = transform.position;
        return unitPosition;
    }

    
       
    protected abstract void Look(); // Abstraction and refactoring

    private void LateUpdate()
    {
        move(); // Abstraction and refactoring
    }

    private void Update()
    {
        Look(); // Abstraction and refactoring
    }


}
