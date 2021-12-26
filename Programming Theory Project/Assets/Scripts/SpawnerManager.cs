using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject point; //Encapsulaption
    public GameObject enemy; //Encapsulaption

    float xBoundary = 9; //Encapsulaption
    float zBoundary = 9; //Encapsulaption
    float yEnemyPosition; //Encapsulaption
    float yPointPosition; //Encapsulaption
    int level = 0; //Encapsulaption

    private void Start()
    {
        yEnemyPosition = enemy.transform.position.y;
        yPointPosition = point.transform.position.y;

        
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Point").Length <= 0)
        {
            level++;
            SpawnPoints();
            CleanEnemyWave();
            CreateEnemyWave(level);
            
        }

    }
    void SpawnPoints()// Abstraction and refactoring
    {
        Instantiate(point, RandomPointPosition(), point.transform.rotation);
    }

    void SpawnEnemies()// Abstraction and refactoring
    {
        Instantiate(enemy, RandomEnemyPosition(), enemy.transform.rotation);
    }

    float RandomX()// Abstraction and refactoring
    {
        return Random.Range(-xBoundary, xBoundary);
    }

    float RandomZ()// Abstraction and refactoring
    {
        return Random.Range(-zBoundary, zBoundary);
    }

    Vector3 RandomEnemyPosition()// Abstraction and refactoring
    {
        return new Vector3(RandomX(), yEnemyPosition, RandomZ());
    }

    Vector3 RandomPointPosition()// Abstraction and refactoring
    {
        return new Vector3(RandomX(), yPointPosition, RandomZ());
    }

    void CleanEnemyWave()// Abstraction and refactoring
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    void CreateEnemyWave(int level)// Abstraction and refactoring
    {
        for(int i = 0; i < level; i++)
        {
            SpawnEnemies();
        }
    }

   
}
