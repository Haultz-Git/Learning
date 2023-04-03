using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform[] Lanes;
    [SerializeField] int[] randomLanes;


    [Header("Values")]
    [SerializeField] float spawnRate;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    [ContextMenu("Spawn enemy")]
    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnRate);
        RandomizeLanes();
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[i]);
            enemy.transform.position = new Vector3(Lanes[i].position.x,transform.position.y,0);
        }
        StartCoroutine(SpawnEnemy());
    }

    private void RandomizeLanes()
    {
        Transform temp;
        for (int i = 0; i < Lanes.Length; i++)
        {
            if (i + 1 == Lanes.Length)
                return;
            int rand = Random.Range(i + 1, Lanes.Length);
            temp = Lanes[i];
            Lanes[i] = Lanes[rand];
            Lanes[rand] = temp;
        }
    }
}
