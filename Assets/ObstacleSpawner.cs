using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Content;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameManager gm;
    public GameObject obstaclePrefab;
    public float spawnRate = 1.5f;
    public float xRange = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        xRange = Camera.main.orthographicSize * Screen.width / Screen.height -.5f;
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnRate);
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);

        GameObject newCard = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        Card c = newCard.GetComponent<Card>();

        int rank;
        bool isRed;
        int nextRank = GameManager.instance.nextExpectedRank;
        bool nextIsRed = !GameManager.instance.currentIsRed;

        if (Random.value < 0.6f)
        {
            rank = nextRank;
            isRed = nextIsRed;
        }
        else
        {
            rank = Random.Range(1, 14);
            isRed = Random.value > 0.5f;
        }

        c.SetCard(rank,isRed);

    }
}
