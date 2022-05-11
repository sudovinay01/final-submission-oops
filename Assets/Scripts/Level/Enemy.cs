using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Move
{
    [SerializeField]
    private GameObject enemyBody;

    private float rotationSpeed = 500;
    //start is called before the first frame update
    void start()
    {

    }

    // update is called once per frame
    protected override void Update()
    {
        
        enemyBody.transform.Rotate(Vector3.right, Time.deltaTime * rotationSpeed);
        base.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collided with"+collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
