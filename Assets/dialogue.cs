using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
 
public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textComponent;
    public string name;
    public string[] sentences;
    public float textSpeed;
    private int index;
    public Button buttonSing;
    public Button buttonDance;


    void Start(){
        textComponent.text = string.Empty;
        StartDialogue();
        buttonSing.gameObject.SetActive(false);
        buttonDance.gameObject.SetActive(false);

    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (textComponent.text == sentences[index]) {
                NextLine();
            }
            else {
                StopAllCoroutines();
                textComponent.text = sentences[index]; 
            }
        }

        if (index == 5) {
            buttonSing.gameObject.SetActive(true);
            buttonDance.gameObject.SetActive(true);
        }
        else if (index == 6) {
            buttonSing.gameObject.SetActive(false);
            buttonDance.gameObject.SetActive(false);
        }
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine() {
        foreach(char c in sentences[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if (index < sentences.Length - 1 ) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else {
            gameObject.SetActive(false);
        }
    }


}
