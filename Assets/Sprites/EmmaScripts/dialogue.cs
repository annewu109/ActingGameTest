using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textComponent;
    public string name;
    private string[] sentences = {
    "Hello there! I’m so glad you’ve decided to join our company. I’m Director LastName, and I’m always looking for new talent.", 
    "During your time here, you will pass through three rounds of auditions, each for progressively harder roles. The experience you gather with your starting roles will inform your chances later on.",
    "Who knows? Maybe you can be among the ones who make it to the top!",
    "Now, I know you don’t have a lot of experience in the entertainment industry, so how about this? Instead of just throwing you into your first audition, I’ll give you a chance to hone your skills.",
    "Singing and dancing are both vital skills you’ll need for a lot of roles. Which one would you like to train?",
    "",
    "Looks like you’re getting the hang of it!", "Now that you have some experience, let’s move onto your first round of auditions. I have three roles that you may be suited for.",
    "Remember, your vocal and dance skills will factor into your probability of cinching the role!",
    "Which role would you like to audition for?",
    "",
    "Good choice! Let me get everything set up for your audition..."
    };
    private string[] first_audition_success;
    private string[] first_audition_failure;

    public float textSpeed;
    private static int index; 
    private bool dialogueValid;

    public Button buttonSing;
    public Button buttonDance;
    public GameObject Panel;


    void Start(){
        DontDestroyOnLoad(gameObject);
        textComponent.text = string.Empty;
        StartDialogue();
        buttonSing.gameObject.SetActive(false);
        buttonDance.gameObject.SetActive(false);
        SceneManager dm = gameObject.GetComponent<SceneManager>();
    }

    void Update(){
        // DialogueManager dm = gameObject.GetComponent<DialogueManager>();
        // dialogueValid = DialogueManager.get_dialogueValid();
        
        if (index == 5) {
            buttonSing.gameObject.SetActive(true);
            buttonDance.gameObject.SetActive(true);
            // dialogueValid = false;

        }
        else if (index == 6) {
            buttonSing.gameObject.SetActive(false);
            buttonDance.gameObject.SetActive(false);

        }

        else if (index == 10) {
            Panel.gameObject.SetActive(false);
            index = SceneManager.setIndex();
        }


        else if (index == 11) {
            Panel.gameObject.SetActive(true);
        }

        // if (dialogueValid) {
            if (Input.GetKeyDown(KeyCode.Space)) {

                if (textComponent.text == sentences[index]) {
                    NextLine();
                }
                else {
                    StopAllCoroutines();
                    textComponent.text = sentences[index]; 
                }
        
            }
        // }


    }

    public static int getIndex() {
        return index;
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
