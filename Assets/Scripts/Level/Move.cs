using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;


    private float zLimit = -5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.z < zLimit)
        {
            Destroy(gameObject);
        }
    }
}
