using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float minForce = 10;
    private const float maxForce = 15;
    private const float minTorque = -10;
    private const float maxTorque = 10;
    private const float minXPos = -3;
    private const float maxXPos = 3;
    private const float ySpawnPos = -2;
    private Rigidbody targetRB;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem expParticle;
   
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //gameManager = FindObjectOfType<GameManager>();
        targetRB = GetComponent<Rigidbody>();
        RandomForce();
        RandomTorque();
        RandSpawnnPos();
    }
    void RandomForce()
    {
        targetRB.AddForce(Vector3.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
    }
    void RandomTorque()
    {
        targetRB.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }
    void RandSpawnnPos()
    {
        transform.position = new Vector3(Random.Range(minXPos, minXPos), ySpawnPos);
    }
    private void OnMouseDown()
    {
        if(gameManager.gameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(expParticle, transform.position, expParticle.transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Hazard"))
        {
            gameManager.GameOver();
        }
    }
}
