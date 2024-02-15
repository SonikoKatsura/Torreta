using UnityEngine;

public class ItemCreator : MonoBehaviour {
    [SerializeField] GameObject[] prefabs;
    public float probability = 0.25f;

    void Start() {
        
    }


    void Update() {
        
    }

    public void GenerateItem(Transform dropPosition) {
        int options = prefabs.Length;
        int randomOption = Random.Range(0, options);

        float randomProb = Random.Range(0, 1);

        if (randomProb <= probability) { 
            GameObject newItem = Instantiate(prefabs[randomOption], dropPosition);
            newItem.transform.SetParent(null);
        }
    }
}
