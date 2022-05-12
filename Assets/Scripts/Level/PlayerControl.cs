using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerMoverDistance = 5,
        XLimit = 10,
        rotationSpeed = 500;

    [SerializeField] ParticleSystem particleEnemy, particleWall;
    //private float particleDuration = 0.5f,
    //    particleSpeed = 50;

    [SerializeField]
    private GameObject playerBody;

    private LevelManager levelManager;

    
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.isGameActive)
        {
            MovePlayer();
        }
    }

    // ABSTRACTION
    private void MovePlayer()
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
        //Debug.Log("other " + other.tag + " : " + other.name);
        if (other.CompareTag("Enemy"))
        {
            particleEnemy.Play();
            levelManager.scoreData += other.gameObject.GetComponent<Enemy>().GetPoints();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            particleWall.Play();
            levelManager.helthData -= 1;
            if (levelManager.helthData <= 0)
            {
                Destroy(gameObject);
                levelManager.isGameActive = false;
                if(levelManager.scoreData > GameManager.Instance.bestScore)
                {
                    GameManager.Instance.bestScore = levelManager.scoreData;
                    GameManager.Instance.bestScorePlayer = GameManager.Instance.currentPlayerName;
                    GameManager.Instance.SaveScore();
                }
            }
        }
    }
}
