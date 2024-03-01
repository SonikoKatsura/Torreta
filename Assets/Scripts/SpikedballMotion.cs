using System.Collections;
using UnityEngine;

public class SpikedballMotion : MonoBehaviour {
    [SerializeField] GameObject forcePointRef;
    [SerializeField] float rotationForce = 30f, lifeSpan = 5f;

    void Update() {
        forcePointRef.GetComponent<Rigidbody2D>().velocity = forcePointRef.transform.right * rotationForce;
        StartCoroutine(DestroyAfterLifeSpan());
    }
    IEnumerator DestroyAfterLifeSpan() {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }
}
