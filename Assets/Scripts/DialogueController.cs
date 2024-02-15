using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour {
    [SerializeField] float textSpeed = 0.05f, extraTimeOnScreen = 2f;
    [SerializeField] string[] textLines;
    [SerializeField] int lineIndex = 0;
    [SerializeField] TextMeshProUGUI dialogueText;

    void Start() {
        
    }


    void Update() {
        
    }

    public void StartDialogue(string item) {
        dialogueText.text = "";

        switch (item) {
            case "sawblade_item": lineIndex = 0; break;
            case "spikedball_item": lineIndex = 1; break;
            default: break;
        }

        StartCoroutine(WriteLine());
    }

    public void EndDialogue() {
        gameObject.SetActive(false);
    }

    IEnumerator WriteLine() {
        foreach (var letter in textLines[lineIndex].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(extraTimeOnScreen);
        EndDialogue();
    }
}
