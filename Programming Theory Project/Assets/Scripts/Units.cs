using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Units : MonoBehaviour
{
    public float speed;
    public Vector3 unitPosition { get; protected set; }
    protected Rigidbody unitRb;
    protected  Vector3 unitDirection;

    private void Start()
    {
        unitRb = GetComponent<Rigidbody>();
    }
    protected abstract void move();
        
     
       
    protected abstract void Look();

    private void LateUpdate()
    {
        move();
    }

    private void Update()
    {
        unitPosition = transform.position;
        Look();
    }


}
