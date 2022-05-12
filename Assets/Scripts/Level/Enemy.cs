using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Move
{
    [SerializeField] private GameObject enemyBody;

    [SerializeField] private int points;

    private float rotationSpeed = 500;

    //start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public int GetPoints()
    {
        return points;
    }

    // update is called once per frame
    protected override void Update()
    {
        
        enemyBody.transform.Rotate(Vector3.right, Time.deltaTime * rotationSpeed);
        base.Update();
    }
}
