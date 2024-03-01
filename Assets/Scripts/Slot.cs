using UnityEngine;

public class Slot : MonoBehaviour {
    private Inventory inventory;
    [SerializeField] int slotIndex;

    private void Start() {
        inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
    }

    void Update() {
        if (transform.childCount <= 0) inventory.isFull[slotIndex] = false;
    }


    public void Dropitem() {
        foreach (Transform child in transform) Destroy(child.gameObject);
    }
}
