using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnDelay = 3f;
    public float spawnDelayRandomness = 4f;
    public float spawnHeight = 5f;
    public float spawnHeightRandomness = 0.1f;
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
        Vector3 spawnRotation = new Vector3(0f, 270f, 0f);
        Instantiate(birdPrefab, spawnPosition, Quaternion.Euler(spawnRotation));
    }
}
