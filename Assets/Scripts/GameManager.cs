using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] Texture2D cursorTarget;

    [Header("HUD")]
    [SerializeField] TextMeshProUGUI shotsText;
    [SerializeField] TextMeshProUGUI killsText;
    [SerializeField] GameObject dialoguesObject;
    [SerializeField] GameObject HPBar;

    [Header("GameBalance")]
    [SerializeField] float reduceSpawnCut = 10;
    [SerializeField] float timeSpawnReduce = 0.1f;
    [SerializeField] float velocityIncrease = 0.5f;

    [Header("Attributes")]
    public int shots = 0;
    public int kills = 0;
    public float life = 100;
    public float maxLife = 100;
    bool canShoot = true;

    [Header("Inventory")]
    private Inventory inventory;
    [SerializeField] GameObject itemButton_1;
    [SerializeField] GameObject itemButton_2;

    void Start() {
        Vector2 hotspot = new Vector2 (cursorTarget.width/2, cursorTarget.height/2);
        Cursor.SetCursor(cursorTarget, hotspot, CursorMode.Auto);
        inventory = GetComponent<Inventory>();

        UpdateShots();
        UpdateKills();
    }


    void Update() {
        HPBar.GetComponent<Image>().fillAmount = life / maxLife;

        if (Input.GetMouseButton(0)) {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero);

            if (hit.collider != null) {
                if (hit.collider.CompareTag("spikeball_item")) {
                    if (dialoguesObject.activeSelf) dialoguesObject.GetComponent<DialogueController>().EndDialogue();
                    for (int i = 0; i < inventory.slots.Length; i++)
                        if (!inventory.isFull[i]) {
                            inventory.isFull[i] = true;

                            Instantiate(itemButton_1, inventory.slots[i].transform, false);
                            DisableFire();
                            Destroy(hit.collider.gameObject);
                            dialoguesObject.SetActive(true);
                            dialoguesObject.GetComponent<DialogueController>().StartDialogue("spikedball_item");
                            break;
                        }
                }
                if (hit.collider.CompareTag("sawblade_item")) {
                    if (dialoguesObject.activeSelf) dialoguesObject.GetComponent<DialogueController>().EndDialogue();
                    for (int i = 0; i < inventory.slots.Length; i++)
                        if (!inventory.isFull[i]) {
                            inventory.isFull[i] = true;

                            Instantiate(itemButton_2, inventory.slots[i].transform, false);
                            DisableFire();
                            Destroy(hit.collider.gameObject);
                            dialoguesObject.SetActive(true);
                            dialoguesObject.GetComponent<DialogueController>().StartDialogue("sawblade_item");
                            break;
                        }
                }
                if (hit.collider.CompareTag("Enemy")) EnableFire();
            }else EnableFire();
        }
    }

    public void UpdateShots() {
        shotsText.text = $"Disparos: {shots}";
    }

    public void UpdateKills() {
        killsText.text = $"Muertes: {kills}";
        if (kills != 0 && kills % reduceSpawnCut == 0) 
            GameObject.Find("SpawnPoint").GetComponent<Spawner>().increaseDifficulty(timeSpawnReduce, velocityIncrease);
    }

    public void DisableFire() { canShoot = false; }

    public void EnableFire() { canShoot = true; }

    public bool GetShootingStatus() { return canShoot; }

    public void TakeDamage(int damage) {
        life = Mathf.Clamp(life - damage, 0, maxLife);
    }

    public void Heal(int lifeRecovered) {
        life = Mathf.Clamp(life + lifeRecovered, 0, maxLife);
    }
}
