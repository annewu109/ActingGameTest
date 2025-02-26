using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textComponent;
    private string[] sentences = {
    "Hello there! I’m so glad you’ve decided to join our company. I’m the Director here, and I’m always looking for new talent.", 
    "During your time here, you will pass through three rounds of auditions, each for progressively harder roles. The experience you gather with your starting roles will inform your chances later on.",
    "Who knows? Maybe you can be among the ones who make it to the top!",
    "Now, I know you don’t have a lot of experience in the entertainment industry, so how about this? Instead of just throwing you into your first audition, I’ll give you a chance to hone your skills.",
    "Singing and dancing are both vital skills you’ll need for a lot of roles. Which one would you like to train?",
    "Good luck!",
    "Looks like you’re getting the hang of it!",
    "Now that you have some experience, let’s move onto your first round of auditions. I have three roles that you may be suited for.",
    "Remember, your vocal and dance skills will factor into your probability of cinching the role!",
    "Which role would you like to audition for?",
    ""
    // , "Good choice! Let me get everything set up for your audition..."
    };

    private string[] first_audition_fail = {
        "Well, thank you for your audition. That was certainly an interesting performance!",
        "Unfortunately, we’ve decided to go with someone else for this role…",
        "But don’t worry! Although experience certainly helps with casting, you’ll still have plenty of opportunities with your next two auditions, so don’t be discouraged.",
        "don’t neglect your singing and dancing skills, either! Some roles require great vocal skills, some dance, some both… regardless, it’s important to give it your best and do well in training!",
        "Report back here next week for your next audition. Director B will walk you through it. I’ve heard she’s pretty hard on her performers, so… good luck!"
    };

    private string[] first_audition_succeed = {
        "Wow… that was an amazing performance! The role is yours!",
        "Congratulations on passing your first audition! I know it’s only a small role, but I’m sure this will lead to bigger and brighter opportunities.",
        "Some experience in the industry does give you a higher chance of getting bigger roles in the future, after all.",
        "But don’t neglect your singing and dancing skills, either! Some roles require great vocal skills, some dance, some both… regardless, it’s important to give it your best and do well in training!",
        "Report back here next week for your next audition. Director B will walk you through it. I’ve heard she’s pretty hard on her performers, so… good luck!" };
        
    public float textSpeed;
    private static int index; 
    private bool dialogueValid;

    public Button buttonSing;
    public Button buttonDance;

    public GameObject canvas;
    public GameObject dialogueEventSystem;

    public GameObject director;
    public Animator director_anim;

    private bool audition_passed = false;


    void Start(){
        DontDestroyOnLoad(gameObject);
        textComponent.text = string.Empty;
        StartDialogue();
        buttonSing.gameObject.SetActive(false);
        buttonDance.gameObject.SetActive(false);
        SceneManager dm = gameObject.GetComponent<SceneManager>();

    }

    void setSentences(string[] lines) {
        sentences = lines;
    }
 
    void Update(){
        if (index == 5) {
            buttonSing.gameObject.SetActive(true);
            buttonDance.gameObject.SetActive(true);
        }

        else if (index == 9) {
            //SceneManager.LoadScene("Anne-Work");
        }

        else if (index == 11) {
            
            if (audition_passed) {
                sentences = first_audition_succeed;
            }
            else {
                sentences = first_audition_fail;
            }
            
            index = 0;
        }

        if (UnityEngine.SceneManagement.SceneManager.sceneCount <= 1) {
            canvas.SetActive(true);
            dialogueEventSystem.SetActive(true);
        }

        if (textComponent.text == sentences[index]) {
            director_anim.Play("Rest");
        }

        if (index != 5) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (textComponent.text == sentences[index]) {
                        NextLine();
                }
                else {
                    StopAllCoroutines();
                    textComponent.text = sentences[index]; 
                }
            
                }
        }

    }

    public static int getIndex() {
        return index;
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine() {
    
        director_anim.Play("anim1");
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

    public void hideButtons() {
        index = 6;
        buttonSing.gameObject.SetActive(false);
        buttonDance.gameObject.SetActive(false);

        canvas.SetActive(false);
        dialogueEventSystem.SetActive(false);
    }


}
