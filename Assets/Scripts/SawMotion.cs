using UnityEngine;

public class SawMotion : MonoBehaviour {
    [SerializeField] float sawMotionSpeed = 2.0f;

    void Start() {
        float xCoord = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        transform.position = new Vector3(xCoord, transform.position.y, transform.position.z);
    }

    void Update() {
        transform.Translate(Vector3.right * sawMotionSpeed * Time.deltaTime);
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
