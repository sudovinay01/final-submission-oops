using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    [SerializeField] private List<GameObject> objects;

    //[SerializeField]
    private float xLimit = 11,
        zLimit = 6,
        pauseTimeMinimun = 0f,
        pauseTimeMaximum = 2f,
        fallZone = -5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectsStart());
    }

    // Update is called once per frame
    void Update()
    {

    }

    int RandomObjectIndex()
    {
        return Random.Range(0, objects.Count);
    }

    IEnumerator SpawnObjectsStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(pauseTimeMinimun, pauseTimeMaximum));

            int randomObject = RandomObjectIndex();

            Vector3 spawnPos;

            int randomSide = Random.Range(0, 4);
            switch (randomSide)
            {
                case 0:
                    spawnPos = SpawnRight(randomObject);
                    break;
                case 1:
                    spawnPos = SpawnLeft(randomObject);
                    break;
                case 2:
                    spawnPos = SpawnUp(randomObject);
                    break;
                case 3:
                    spawnPos = SpawnDown(randomObject);
                    break;
                default:
                    spawnPos = gameObject.transform.position;
                    break;
            }

            GameObject spawnobject = Instantiate(objects[randomObject], spawnPos, objects[randomObject].transform.rotation);

            Vector3 lookDirection = (transform.position - spawnobject.transform.position).normalized;
            spawnobject.GetComponent<Rigidbody>().AddForce(lookDirection * Random.Range(500, 1000));
            StartCoroutine(DestroyIfStill(spawnobject));
        }
    }

    Vector3 SpawnRight(int randomObject)
    {
         return new Vector3(xLimit, objects[randomObject].transform.position.y, Random.Range(-zLimit, zLimit));
    }
    Vector3 SpawnLeft(int randomObject)
    {
        return new Vector3(-xLimit, objects[randomObject].transform.position.y, Random.Range(-zLimit, zLimit));
    }

    Vector3 SpawnUp(int randomObject)
    {
        return new Vector3(Random.Range(-xLimit, xLimit), objects[randomObject].transform.position.y, zLimit);
    }

    Vector3 SpawnDown(int randomObject)
    {
        return new Vector3(Random.Range(-xLimit, xLimit), objects[randomObject].transform.position.y, -zLimit);
    }


    IEnumerator DestroyIfStill(GameObject obj)
    {
        Rigidbody objRB;

        while (obj != null)
        {

            yield return new WaitForSeconds(1);
            if(obj != null)
            {
                objRB = obj.GetComponent<Rigidbody>();
            }
            else
            {
                yield break;
            }
            
            if (objRB.velocity.x == 0 && objRB.velocity.y == 0 && objRB.velocity.z == 0)
            {
                //Debug.Log("1 Destroyed on Stop..."+objRB.velocity);
                Destroy(obj);
            }
            if(obj.transform.position.y < fallZone)
            {
                //Debug.Log("2 Destroyed on fall..."+ obj.transform.position.y));
                Destroy(obj);
            }
        }
    }
}
