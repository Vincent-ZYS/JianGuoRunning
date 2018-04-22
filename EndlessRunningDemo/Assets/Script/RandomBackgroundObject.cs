using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackgroundObject : MonoBehaviour
{
    private GameObject[] groupPool1;
    private GameObject[] groupPool2;
    private GameObject[] groupPool3;
    private GameObject[] groupPool4;
    private GameObject[] groupPool5;
    private GameObject[] groupPool6;
    private GameObject[] groupPool7;

    private int poolsize = 3;
    private int currentColumn = 0;
    private int groupLastNum;
    private float timeSinceLastSpawned2;
    private float groupspawnXposition = 22.0f;
    private Vector2 objectPoolPosition = new Vector2(-15.0f, -25.0f);

    public GameObject group1;
    public GameObject group2;
    public GameObject group3;
    public GameObject group4;
    public GameObject group5;
    public GameObject group6;
    public GameObject group7;

    public int groupObjectNumber = 2;
    public float groupSpawnRate = 12.0f;

    void Start()
    {
        groupPool1 = new GameObject[poolsize];
        groupPool2 = new GameObject[poolsize];
        groupPool3 = new GameObject[poolsize];
        groupPool4 = new GameObject[poolsize];
        groupPool5 = new GameObject[poolsize];
        groupPool6 = new GameObject[poolsize];
        groupPool7 = new GameObject[poolsize];

        for (int i = 0; i < poolsize; i++)
        {
            groupPool1[i] = Object.Instantiate(group1, objectPoolPosition, Quaternion.identity);
            groupPool2[i] = Object.Instantiate(group2, objectPoolPosition, Quaternion.identity);
            groupPool3[i] = Object.Instantiate(group3, objectPoolPosition, Quaternion.identity);
            groupPool4[i] = Object.Instantiate(group4, objectPoolPosition, Quaternion.identity);
            groupPool5[i] = Object.Instantiate(group5, objectPoolPosition, Quaternion.identity);
            groupPool6[i] = Object.Instantiate(group6, objectPoolPosition, Quaternion.identity);
            groupPool7[i] = Object.Instantiate(group7, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned2 += Time.deltaTime;

        if(GameControl.instance.isOver == false && timeSinceLastSpawned2 >= groupSpawnRate)
        {
            int randomNum = Random.Range(1, groupObjectNumber + 1);
            timeSinceLastSpawned2 = 0;
            RandomGroupObject(randomNum);
        }
    }

    private void RandomGroupObject(int randomNum)
    {

        if (randomNum == 1)
        {
            if (groupLastNum == randomNum)
            {
                randomNum += 1;
                RandomGroupObject(randomNum);
            }
            else
            {
                GroupSpawned(groupPool1);
                groupLastNum = 1;
            }
        }
        else if (randomNum == 2)
        {
            if (groupLastNum == randomNum)
            {
                randomNum += 1;
                RandomGroupObject(randomNum);
            }
            else
            {
                GroupSpawned(groupPool2);
                groupLastNum = 2;
            }
        }
        else if (randomNum == 3)
        {
            if (groupLastNum == randomNum)
            {
                randomNum += 1;
                RandomGroupObject(randomNum);
            }
            else
            {
                GroupSpawned(groupPool3);
                groupLastNum = 3;
            }
        }
        else if (randomNum == 4)
        {
            if (groupLastNum == randomNum)
            {
                randomNum += 1;
                RandomGroupObject(randomNum);
            }
            else
            {
                GroupSpawned(groupPool4);
                groupLastNum = 4;
            }
        }
        else if (randomNum == 5)
        {
            if (groupLastNum == randomNum)
            {
                randomNum += 1;
                RandomGroupObject(randomNum);
            }
            else
            {
                GroupSpawned(groupPool5);
                groupLastNum = 5;
            }
        }else if (randomNum == 6)
        {
            if (groupLastNum == randomNum)
            {
                randomNum += 1;
                RandomGroupObject(randomNum);
            }
            else
            {
                GroupSpawned(groupPool6);
                groupLastNum = 6;
            }
        }else if (randomNum == 7)
        {
            if (groupLastNum == randomNum)
            {
                randomNum = 1;
                RandomGroupObject(randomNum);
            }
            else
            {
                GroupSpawned(groupPool7);
                groupLastNum = 7;
            }
        }
}

    public void GroupSpawned(GameObject[] groupPool)
    {
        groupPool[currentColumn].transform.position = new Vector2(groupspawnXposition, 0f);
        currentColumn++;
        if (currentColumn >= poolsize)
        {
            currentColumn = 0;
        }
    }

    //private void RandomObject(int randomNum)
    //{
    //    if (randomNum == 1)
    //    {
    //        if (lastNum == randomNum)
    //        {
    //            randomNum += 1;
    //            RandomObject(randomNum);
    //        }
    //        else
    //        {
    //            ObjectSpawned(objectPool1);
    //            lastNum = 1;
    //        }
    //    }
    //    else if (randomNum == 2)
    //    {
    //        if (lastNum == randomNum)
    //        {
    //            randomNum += 1;
    //            RandomObject(randomNum);
    //        }
    //        else
    //        {
    //            ComputerSpawned(computerpool1);
    //            lastNum = 2;
    //        }
    //    }
    //    else if (randomNum == 3)
    //    {
    //        if (lastNum == randomNum)
    //        {
    //            randomNum += 1;
    //            RandomObject(randomNum);
    //        }
    //        else
    //        {
    //            ComputerSpawned(computerpool2);
    //            lastNum = 3;
    //        }
    //    }
    //    else if (randomNum == 4)
    //    {
    //        if (lastNum == randomNum)
    //        {
    //            randomNum += 1;
    //            RandomObject(randomNum);
    //        }
    //        else
    //        {
    //            ComputerSpawned(computerpool3);
    //            lastNum = 4;
    //        }
    //    }
    //    else if (randomNum == 5)
    //    {
    //        if (lastNum == randomNum)
    //        {
    //            randomNum += 1;
    //            RandomObject(randomNum);
    //        }
    //        else
    //        {
    //            FlowerSpawned(flowerPool);
    //            lastNum = 5;
    //        }
    //    }
    //    else if (randomNum == 6)
    //    {
    //        if (lastNum == randomNum)
    //        {
    //            randomNum = 1;
    //            RandomObject(randomNum);
    //        }
    //        else
    //        {
    //            FlowerSpawned(computerpool2);
    //            lastNum = 6;
    //        }
    //    }
    //}

    //public void ObjectSpawned(GameObject[] objectPool)
    //{
    //    float spawnYposition = Random.Range(objectMin, objectMax);
    //    objectPool[currentColumn].transform.position = new Vector2(spawnXposition, spawnYposition);
    //    currentColumn++;
    //    if (currentColumn >= poolsize)
    //    {
    //        currentColumn = 0;
    //    }
    //}

    //public void ComputerSpawned(GameObject[] computerPool)
    //{
    //    computerPool[currentColumn].transform.position = new Vector2(spawnXposition, 2.9f);
    //    currentColumn++;
    //    if (currentColumn >= poolsize)
    //    {
    //        currentColumn = 0;
    //    }
    //}

    //public void FlowerSpawned(GameObject[] flowerPool)
    //{
    //    flowerPool[currentColumn].transform.position = new Vector2(spawnXposition,2);
    //    currentColumn++;
    //    if(currentColumn >= poolsize)
    //    {
    //        currentColumn = 0;
    //    }
    //}
}
