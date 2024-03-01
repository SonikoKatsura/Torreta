using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] GameObject enemy;
    public float timeBetweenGenerations = 1, spawnLineLength = 2;
    private float enemyVelocity = 1f;

    void Start() {
        StartCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy() {
        while (true) {
            float randomPosY = Random.Range(transform.position.y - spawnLineLength, transform.position.y + spawnLineLength);
            GameObject newEnemy = Instantiate(enemy, new Vector2(transform.localPosition.x, randomPosY), Quaternion.identity);
            newEnemy.transform.SetParent(null);
            newEnemy.GetComponent<BugMotion>().bugSpeed = enemyVelocity;
            yield return new WaitForSeconds(timeBetweenGenerations);
        }
    }

    public void increaseDifficulty(float reduceSpawnTime, float velocityIncrease) {
        if (timeBetweenGenerations >= 0.5) timeBetweenGenerations -= reduceSpawnTime;
        enemyVelocity += velocityIncrease;
    }
}
