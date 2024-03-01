using System.Collections;
using UnityEngine;

public class BugMotion : MonoBehaviour {
    [SerializeField] float circleAttackRadius = 0.1f, attackDelay = 0.68f;
    [SerializeField] int damageValue = 10;
    [SerializeField] GameObject hitPoint;
    [SerializeField] GameObject target;
    [SerializeField] float detectionDistance = 0.5f, offsetDistance = 0.2f;
    public float bugSpeed = 1;
    bool executingCoroutine = false;

    Rigidbody2D rb;
    Animator animator;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update() {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        transform.up = direction;

        if (!IsDetectingPlayer()) rb.velocity = direction * bugSpeed;
        else {
            SetAnimation("attacking");
            rb.velocity = Vector2.zero;
            if (!executingCoroutine) StartCoroutine(WaitAndAttack());
        }
    }

    public void SetAnimation(string name) {
        AnimatorControllerParameter[] parametros = animator.parameters;
        foreach (var item in parametros) animator.SetBool(item.name, false);
        animator.SetBool(name, true);
    }

    bool IsDetectingPlayer() {
        Vector2 direction = ((Vector2)target.transform.position - (Vector2)transform.position).normalized;

        Vector2 endPoint = (Vector2)transform.position + direction * detectionDistance;

        Debug.DrawLine((Vector2) transform.position + direction * offsetDistance, endPoint, Color.black);

        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + direction * offsetDistance, direction, detectionDistance - offsetDistance);

        return hit.collider != null && hit.collider.CompareTag("Player");
    }

    IEnumerator WaitAndAttack() {
        executingCoroutine = true;
        yield return new WaitForSeconds(attackDelay);
        Hit();
        executingCoroutine = false;
    }

    public void Hit() {
        Collider2D collider = Physics2D.OverlapCircle(hitPoint.transform.position, circleAttackRadius);
        if (collider != null) 
            if (collider.CompareTag("Player")) GameObject.Find("GameManager").GetComponent<GameManager>().TakeDamage(damageValue);
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(hitPoint.transform.position, circleAttackRadius);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision != null && collision.collider.CompareTag("Trap")) Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }

    void OnDestroy() {
        GameObject.Find("GameManager").GetComponent<GameManager>().kills++;
        GameObject.Find("GameManager").GetComponent<GameManager>().UpdateKills();
        GameObject.Find("Instantiator").GetComponent<ItemCreator>().GenerateItem(transform);
    }
}
