using System.Collections;
using UnityEngine;

public class ItemCreator : MonoBehaviour {
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float disappearTime = 2f;
    public float probability = 0.25f;

    void Start() {
        
    }


    void Update() {
        
    }

    public void GenerateItem(Transform dropPosition) {
        int options = prefabs.Length;
        int randomOption = Random.Range(0, options);

        float randomProb = Random.Range(0f, 1f);
        if (randomProb <= probability) { 
            GameObject newItem = Instantiate(prefabs[randomOption], dropPosition);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("DroppedItems"), LayerMask.NameToLayer("Default"));
            newItem.transform.SetParent(null);
            StartCoroutine(Despawn(newItem));
        }
    }

    IEnumerator Despawn(GameObject item) {
        yield return new WaitForSeconds(disappearTime);
        if (item == null) yield break;
        Color itemColor = item.GetComponent<SpriteRenderer>().color;
        for (float transparency = 0.01f; transparency < 1; transparency += 0.01f) {
            Color colorChange = new Color(itemColor.r, itemColor.g, itemColor.b, itemColor.a - transparency);
            item.GetComponent<SpriteRenderer>().color = colorChange;
            yield return new WaitForSeconds(0.003f);
        }
        if (item != null) Destroy(item);
    }
}
