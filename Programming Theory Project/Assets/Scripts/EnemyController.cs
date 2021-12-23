using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Units
{
    private PlayerController target;
    
    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<PlayerController>();
        speed = 1;
        unitRb = GetComponent<Rigidbody>();
        
    }
    protected override void Look()
    {

        transform.rotation = Quaternion.LookRotation(target.unitPosition);
    }

    protected override void move()
    {
        unitDirection = Vector3.forward;
        unitRb.MovePosition(unitPosition + speed * unitDirection * Time.deltaTime);
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
