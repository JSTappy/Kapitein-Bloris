using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnDelay = 1f;
    public float spawnDelayRandomness = 0.5f;
    public float spawnHeight = 5f;
    public float spawnHeightRandomness = 2f;
    public float spawnWidth = 10f;
    public float spawnWidthRandomness = 5f;

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            spawnTimer = 0f;
            SpawnBird();
        }
    }

    void SpawnBird()
    {
        float spawnDelay = Random.Range(this.spawnDelay - spawnDelayRandomness, this.spawnDelay + spawnDelayRandomness);
        float spawnHeight = Random.Range(this.spawnHeight - spawnHeightRandomness, this.spawnHeight + spawnHeightRandomness);
        float spawnWidth = Random.Range(this.spawnWidth - spawnWidthRandomness, this.spawnWidth + spawnWidthRandomness);

        Vector3 spawnPosition = transform.position + new Vector3(spawnWidth, spawnHeight, 0f);
        Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
    }
}
