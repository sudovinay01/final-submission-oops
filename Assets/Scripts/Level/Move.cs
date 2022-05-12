using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    protected float speed = 10;

    private float zLimit = -5;

    private LevelManager levelManager;

    private int increaseSpeedAfter = 20;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (levelManager.isGameActive)
        {
            MoveObject();
        }
        
    }

    void MoveObject()
    {
        //Debug.Log(speed * Mathf.Ceil(levelManager.scoreData / 20) + speed);
        transform.Translate(Vector3.back * Time.deltaTime * (speed * Mathf.Ceil(levelManager.scoreData / increaseSpeedAfter) + speed));
        if (transform.position.z < zLimit)
        {
            Destroy(gameObject);
        }
    }
}
