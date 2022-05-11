using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemy;

    private float zPos = 100,
        spawnSpeed = 2;

    int LineRange = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnSpeed);
            int randomEnemy = Random.Range(0, enemy.Count);
            int randomLinePos = Random.Range(-LineRange, LineRange+1);
            Vector3 spawnPos = new Vector3(randomLinePos * 5, enemy[randomEnemy].transform.position.y, zPos);
            Instantiate(enemy[randomEnemy], spawnPos, enemy[randomEnemy].transform.rotation);
        }
    }
}
