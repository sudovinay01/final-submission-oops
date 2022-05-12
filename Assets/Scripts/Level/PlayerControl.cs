using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerMoverDistance = 5,
        XLimit = 10,
        rotationSpeed = 500;

    [SerializeField] ParticleSystem particle;
    //private float particleDuration = 0.5f,
    //    particleSpeed = 50;

    [SerializeField]
    private GameObject playerBody; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        playerBody.transform.Rotate(Vector3.right, Time.deltaTime * rotationSpeed);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(playerMoverDistance, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-playerMoverDistance, 0, 0));
        }

        if(transform.position.x < -XLimit)
        {
            transform.position = new Vector3(-XLimit, transform.position.y, 0);
        }
        if (transform.position.x > XLimit)
        {
            transform.position = new Vector3(XLimit, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("other "+other.tag+" : "+other.name);
        if(other.tag == "Enemy")
        {
            //particle.main.duration. = particleDuration;
            particle.Play();
            //Debug.Log(other.gameObject.GetComponent<Enemy>().GetPoints());
            Destroy(other.gameObject);
        }
    }
}
