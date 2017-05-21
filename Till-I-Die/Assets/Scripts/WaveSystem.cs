using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSystem : MonoBehaviour
{
    public int Wave;
    public GameObject hazard;
    public GameObject[] SpawnPoints;
    public GameObject Enemies;
    private NavMeshAgent agent;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    private float waveWait;
    public bool GetNextWave = false;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = SpawnPoints[0].transform.position;
                Quaternion spawnRotation = Quaternion.identity;
                Enemies = Instantiate(hazard, spawnPosition, spawnRotation);
                agent = Enemies.GetComponent<NavMeshAgent>();
                agent.SetDestination(new Vector3(0, 0, 0));
                yield return new WaitForSeconds(spawnWait);
            }
            if (GetNextWave)
            {
                yield return null;
            }
        }
    }

    void Update()
    {

    }

    void StartWave()
    {

    }

    public void NextWave()
    {
        GetNextWave = true;
        Wave++;
    }
}
