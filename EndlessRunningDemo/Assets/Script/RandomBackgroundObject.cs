using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackgroundObject : MonoBehaviour
{
    private GameObject[] groupPool1;
    private GameObject[] groupPool2;
    private GameObject[] groupPool3;
    private GameObject[] objectPool1;
    private GameObject[] objectPool2;
    private GameObject[] objectPool3;
    private GameObject[] computerpool1;
    private GameObject[] computerpool2;
    private GameObject[] computerpool3;
    private GameObject[] flowerPool;


    private int poolsize = 3;
    private int currentColumn = 0;
    private float timeSinceLastSpawned;
    private float spawnXposition = 14.0f;
    private Vector2 objectPoolPosition = new Vector2(-15.0f, -25.0f);

    public GameObject group1;
    public GameObject group2;
    public GameObject group3;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject computer1;
    public GameObject computer2;
    public GameObject computer3;
    public GameObject flower;

    public int objectNumber = 2;
    public float spawnRate = 8.0f;
    public float objectMin = 2.0f;
    public float objectMax = 4.0f;

    void Start()
    {
        groupPool1 = new GameObject[poolsize];
        groupPool2 = new GameObject[poolsize];
        groupPool3 = new GameObject[poolsize];
        objectPool1 = new GameObject[poolsize];
        objectPool2 = new GameObject[poolsize];
        objectPool3 = new GameObject[poolsize];
        computerpool1 = new GameObject[poolsize];
        computerpool2 = new GameObject[poolsize];
        computerpool3 = new GameObject[poolsize];
        flowerPool = new GameObject[poolsize];

        for (int i = 0; i < poolsize; i++)
        {
            groupPool1[i] = Object.Instantiate(group1, objectPoolPosition, Quaternion.identity);
            groupPool2[i] = Object.Instantiate(group2, objectPoolPosition, Quaternion.identity);
            groupPool3[i] = Object.Instantiate(group3, objectPoolPosition, Quaternion.identity);
            objectPool1[i] = Object.Instantiate(object1, objectPoolPosition, Quaternion.identity);
            objectPool2[i] = Object.Instantiate(object2, objectPoolPosition, Quaternion.identity);
            objectPool3[i] = Object.Instantiate(object3, objectPoolPosition, Quaternion.identity);
            computerpool1[i] = Object.Instantiate(computer1, objectPoolPosition, Quaternion.identity);
            computerpool2[i] = Object.Instantiate(computer2, objectPoolPosition, Quaternion.identity);
            computerpool3[i] = Object.Instantiate(computer3, objectPoolPosition, Quaternion.identity);
            flowerPool[i] = Object.Instantiate(flower, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.isOver == false && timeSinceLastSpawned >= spawnRate)
        {
            int randomNum = Random.Range(1, objectNumber + 1);
            timeSinceLastSpawned = 0;
            if(randomNum == 1)
            {
                ObjectSpawned(objectPool1);
            }else if(randomNum == 2)
            {
                ComputerSpawned(computerpool1);
            }else if(randomNum == 3)
            {
                ComputerSpawned(computerpool2);
            }else if(randomNum == 4)
            {
                ComputerSpawned(computerpool3);
            }else if(randomNum == 5)
            {
                FlowerSpawned(flowerPool);
            }else if(randomNum == 6)
            {
                FlowerSpawned(computerpool2);
            }else if(randomNum == 7)
            {
                GroupSpawned(groupPool1);
            }else if(randomNum == 8)
            {
                GroupSpawned(groupPool2);
            }else if(randomNum == 9)
            {
                GroupSpawned(groupPool3);
            }
        }
    }

    public void ObjectSpawned(GameObject[] objectPool)
    {
        float spawnYposition = Random.Range(objectMin, objectMax);
        objectPool[currentColumn].transform.position = new Vector2(spawnXposition, spawnYposition);
        currentColumn++;
        if (currentColumn >= poolsize)
        {
            currentColumn = 0;
        }
    }

    public void ComputerSpawned(GameObject[] computerPool)
    {
        computerPool[currentColumn].transform.position = new Vector2(spawnXposition, 2.9f);
        currentColumn++;
        if (currentColumn >= poolsize)
        {
            currentColumn = 0;
        }
    }

    public void  GroupSpawned(GameObject[] groupPool)
    {
        groupPool[currentColumn].transform.position = new Vector2(spawnXposition, 0f);
        currentColumn++;
        if (currentColumn >= poolsize)
        {
            currentColumn = 0;
        }
    }

    public void FlowerSpawned(GameObject[] flowerPool)
    {
        flowerPool[currentColumn].transform.position = new Vector2(spawnXposition,2);
        currentColumn++;
        if(currentColumn >= poolsize)
        {
            currentColumn = 0;
        }
    }
}
