using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public GameObject[] ObstaclePlaces;
    public GameObject[] Obstacles;
    private Collider finishBox;
    void Start()
    {
        placeObstacles();
        finishBox = gameObject.GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            finishBox.enabled = false;
            StartCoroutine("Transfer");
    }

    IEnumerator Transfer()
    {
        yield return new WaitForSeconds(1);
        gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.position.x + 180, 0, 0);
        placeObstacles();
        finishBox.enabled = true;
    }

    void placeObstacles()
    {
        foreach (GameObject ObstaclePlace in ObstaclePlaces)
        {
            GameObject Obstacle = Obstacles[Random.Range(0, Obstacles.Length)];
            Instantiate(Obstacle, ObstaclePlace.transform);
        }
    }
}
