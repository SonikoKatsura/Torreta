using UnityEngine;

public class BulletController : MonoBehaviour {

    void Start() {
        GameObject.Find("GameManager").GetComponent<GameManager>().shots++;
        GameObject.Find("GameManager").GetComponent<GameManager>().UpdateShots();
    }

    void Update() {

    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }
}
