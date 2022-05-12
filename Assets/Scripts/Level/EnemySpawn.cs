using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemy,wall;

    private float zPos = 100,
        spawnSpeed = 2;

    int LineRange = 2,
        increaseSpeedAfter = 20;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnWalls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ABSTRACTION
    private IEnumerator SpawnEnemies()
    {
        while (levelManager.isGameActive)
        {
            
            yield return new WaitForSeconds(spawnSpeed - (Mathf.Ceil(levelManager.scoreData / 20) * 0.2f));
            int randomEnemy = Random.Range(0, enemy.Count);
            int randomLinePos = Random.Range(-LineRange, LineRange+1);
            Vector3 spawnPos = new Vector3(randomLinePos * 5, enemy[randomEnemy].transform.position.y, zPos);
            Instantiate(enemy[randomEnemy], spawnPos, enemy[randomEnemy].transform.rotation);
        }
    }

    // ABSTRACTION
    private IEnumerator SpawnWalls()
    {
        while (levelManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnSpeed - (Mathf.Ceil(levelManager.scoreData / increaseSpeedAfter) * 0.2f));
            int randomWall = Random.Range(0,wall.Count);
            Vector3 spawnPos = new Vector3(wall[randomWall].transform.position.x, wall[randomWall].transform.position.y, zPos);
            Instantiate(wall[randomWall], spawnPos, wall[randomWall].transform.rotation);
        }
    }
}
