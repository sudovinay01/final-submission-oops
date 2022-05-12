using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSideSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    private float pauseTimeMinimun = 0f,
    pauseTimeMaximum = 2f;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private IEnumerator SpawnObjects()
    {
        while (levelManager.isGameActive)
        {
            //Debug.Log(pauseTimeMaximum - (Mathf.Ceil(levelManager.scoreData / 20) * 0.2f));
            //transform.localPosition
            yield return new WaitForSeconds(Random.Range(pauseTimeMinimun, pauseTimeMaximum));

            int randomObject = Random.Range(0,objects.Count);

            
            Vector3 spawnPos = new Vector3(transform.position.x,objects[randomObject].transform.position.y+transform.position.y, transform.position.z);
            Quaternion rotation = transform.rotation;

            GameObject spawnObject = Instantiate(objects[randomObject], spawnPos, rotation);
            // INHERITANCE
            spawnObject.AddComponent<Move>();
            Destroy(spawnObject.GetComponent<Rigidbody>());
        }
    }
}
