using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour {
    [SerializeField] GameObject bulletPrefab, spawnPoint;
    [SerializeField] float bulletSpeed = 10;
    Vector2 mousePosition, worldMousePosition, pointDirection;
    bool canShoot;


    void Start() {
        
    }


    void Update() {
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        pointDirection = worldMousePosition - (Vector2) transform.position;
        transform.up = pointDirection.normalized;
        if (Input.GetMouseButtonDown(0)) StartCoroutine(checkShootAbility());
    }

    IEnumerator checkShootAbility() {
        yield return new WaitForEndOfFrame();
        canShoot = GameObject.Find("GameManager").GetComponent<GameManager>().GetShootingStatus();
        if (canShoot) {
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.transform);
            bullet.transform.SetParent(null);
            bullet.GetComponent<Rigidbody2D>().velocity = pointDirection.normalized * bulletSpeed;
        }
    }
}
