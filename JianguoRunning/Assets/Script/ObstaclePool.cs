using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    private GameObject[] obstaclePool;
    private GameObject[] obstaclePool2;
    private GameObject[] obstaclePool3;
    private GameObject[] obstaclePool4;
    private GameObject[] obstaclePool5;
    private GameObject[] obstaclePool6;
    private GameObject[] obstaclePool7;
    private GameObject[] obstaclePool8;

    private Vector2 objectPoolPosition = new Vector2(-15.0f, -25.0f);
    private int poolSize = 3;
    private float timeSinceLastSpawned;
    private int currentColumn = 0;
    private float spawnXPosition = 15.0f;

    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefab3;
    public GameObject obstaclePrefab4;
    public GameObject obstaclePrefab5;
    public GameObject obstaclePrefab6;
    public GameObject obstaclePrefab7;
    public GameObject obstaclePrefab8;

    public int objectNumber = 3;
    public float spawnRate = 4.0f;
    public float obstacleMin = -0.5f;
    public float obstacleMax = 0f;

	void Start () {
        obstaclePool = new GameObject[poolSize];
        obstaclePool2 = new GameObject[poolSize];
        obstaclePool3 = new GameObject[poolSize];
        obstaclePool4 = new GameObject[poolSize];
        obstaclePool5 = new GameObject[poolSize];
        obstaclePool6 = new GameObject[poolSize];
        obstaclePool7 = new GameObject[poolSize];
        obstaclePool8 = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            obstaclePool[i] = Object.Instantiate(obstaclePrefab,objectPoolPosition,Quaternion.identity);
            obstaclePool2[i] = Object.Instantiate(obstaclePrefab2, objectPoolPosition, Quaternion.identity);
            obstaclePool3[i] = Object.Instantiate(obstaclePrefab3, objectPoolPosition, Quaternion.identity);
            obstaclePool4[i] = Object.Instantiate(obstaclePrefab4, objectPoolPosition, Quaternion.identity);
            obstaclePool5[i] = Object.Instantiate(obstaclePrefab5, objectPoolPosition, Quaternion.identity);
            obstaclePool6[i] = Object.Instantiate(obstaclePrefab6, objectPoolPosition, Quaternion.identity);
            obstaclePool7[i] = Object.Instantiate(obstaclePrefab7, objectPoolPosition, Quaternion.identity);
            obstaclePool8[i] = Object.Instantiate(obstaclePrefab8, objectPoolPosition, Quaternion.identity);
        }
	}
	
	void Update () {
        
        timeSinceLastSpawned += Time.deltaTime;//这里不能直接赋值，原因是Time.deltaTime是每帧运行的时间(虽然这个非固定)

        if (GameControl.instance.isOver == false && timeSinceLastSpawned >= spawnRate) 
        {
            int randomNum = Random.Range(1, objectNumber+1);
            timeSinceLastSpawned = 0f;
            if(randomNum == 1)
            {
                GObstacleSpawned(obstaclePool);
            }else if(randomNum == 2)
            {
                GObstacleSpawned(obstaclePool2);
            }else if(randomNum == 3)
            {
                GObstacleSpawned(obstaclePool3);
            }else if(randomNum == 4)
            {
                GObstacleSpawned(obstaclePool4);
            }else if(randomNum == 5)
            {
                GObstacleSpawned(obstaclePool5);
            }else if(randomNum == 6)
            {
                GObstacleSpawned(obstaclePool6);
            }else if(randomNum == 7)
            {
                GObstacleSpawned(obstaclePool7);
            }else if(randomNum == 8)
            {
                GObstacleSpawned(obstaclePool8);
            }
        }
	}

    public void ObstacleSpawned(GameObject[] obstaclePool)
    {
        float spawnYPosition = Random.Range(obstacleMin, obstacleMax);
        obstaclePool[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentColumn++;
        if (currentColumn >= poolSize)
        {
            currentColumn = 0;
        }
    }

    public void GObstacleSpawned(GameObject[] gobstaclePool)
    {
        gobstaclePool[currentColumn].transform.position = new Vector2(spawnXPosition, 0f);
        currentColumn++;
        if (currentColumn >= poolSize)
        {
            currentColumn = 0;
        }
    }
}
