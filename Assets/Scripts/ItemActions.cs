using UnityEngine;

public class ItemActions : MonoBehaviour {
    [SerializeField] GameObject spikedballTrap, sawTrap;

    public void SpawnSpikedball() {
        if (GameObject.FindGameObjectWithTag("SpikedballTrap") == null) {
            Instantiate(spikedballTrap);
            Destroy(this.gameObject);
        }
    }

    public void SpawnSaw() {
        if (GameObject.FindGameObjectWithTag("SawTrap") == null) {
            Instantiate(sawTrap);
            Destroy(this.gameObject);
        }
    }
}
