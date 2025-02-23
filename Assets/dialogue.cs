using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
 
public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textComponent;
    public string name;
    private string[] sentences = {"Hello there! I’m so glad you’ve decided to join our company. I’m Director LastName, \nand I’m always looking for new talent.",
    "During your time here, you will pass through three rounds of auditions, each for \nprogressively harder roles. The experience you gather with your starting roles \nwill inform your chances later on.",
    "Who knows? Maybe you can be among the ones who make it to the top!", "Now, I know you don’t have a lot of experience in the entertainment industry, so \nhow about this? Instead of just throwing you into your first audition, I’ll give \nyou a chance to hone your skills.",
    "Singing and dancing are both vital skills you’ll need for a lot of roles. Which one \nwould you like to train?", "", "Looks like you’re getting the hang of it!",
    "Now that you have some experience, let’s move onto your first round of auditions. \nI have three roles that you may be suited for.", 
    "Remember, your vocal and dance skills will factor into your probability \nof cinching the role!", "Which role would you like to audition for?"};
    public float textSpeed = 0.05f;
    private int index;
    public Button buttonSing;
    public Button buttonDance;


    void Start(){
        textComponent.text = "";
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
