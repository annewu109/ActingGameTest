using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textComponent;
    public static string[] sentences;
    public static string[] passedBranch;
    public static string[] failedBranch;
    public GameHandler myGH;

    private string[] level1dialogue = {
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
    "    ",
    "Good choice! Let me get everything set up for your audition..."
    };

    private string[] first_audition_fail = {
        "Well, thank you for your audition. That was certainly an interesting performance!",
        "Unfortunately, we’ve decided to go with someone else for this role…",
        "But don’t worry! Although experience certainly helps with casting, you’ll still have plenty of opportunities with your next two auditions, so don’t be discouraged.",
        "don’t neglect your singing and dancing skills, either! Some roles require great vocal skills, some dance, some both… regardless, it’s important to give it your best and do well in training!",
        "Report back here next week for your next audition. Director B will walk you through it. I’ve heard she’s pretty hard on her performers, so… good luck!",
    };

    private string[] first_audition_succeed = {
        "Wow… that was an amazing performance! The role is yours!",
        "Congratulations on passing your first audition! I know it’s only a small role, but I’m sure this will lead to bigger and brighter opportunities.",
        "Some experience in the industry does give you a higher chance of getting bigger roles in the future, after all.",
        "But don’t neglect your singing and dancing skills, either! Some roles require great vocal skills, some dance, some both… regardless, it’s important to give it your best and do well in training!",
        "Report back here next week for your next audition. Director B will walk you through it. I’ve heard she’s pretty hard on her performers, so… good luck!",
    };

    private string[] level_2_dialogue = {
        "Welcome back! It’s good to see you again!",
        "For your second audition, I’ve found some slightly harder roles for you. But don’t worry, I’m confident you can do well!",
        "Again, I’m going to give you an opportunity to train your vocal or dance skills before we get started again. Which would you like to practice?",
        "Good luck!",
        "Your skills are improving by the day! Now, let’s get into our audition. With these bigger roles, you’ll really get a taste of the acting industry!",
        "Which role would you like to audition for?",
        "    ",
        "Good choice! Let me get everything set up for your audition..."
    };

    private string[] second_audition_passed = {
        "Amazing job! Your performance really touched me. The role is yours!",
        "Wow, you’re really moving up in the industry. More and more people have been asking about you.",
        "Report back next month for your last audition. I might just have your breakout role on hand!",
    };

    private string[] second_audition_failure = {
        "You brought passion to your performance as always. Unfortunately, we’ve decided to go with someone else…",
        "Don’t worry! Keep working on your singing and dancing skills, and with a little luck, you’ll get another opportunity soon!",
        "Report back next month for your last audition. I might just have your breakout role on hand!",
    };

    private string[] level_3_dialogue = {
        "Welcome back to the studio! Are you ready for your final audition?",
        "I have to say, I’ve got three really special roles for you today, so you’d better put on your best performance!",
        "Can’t improve without practicing, though. I know you’ve been working hard on your skills, so show me what you’ve got!",
        "Good luck!",
        "Alright, it’s time to move on to your final audition. You’ve been with this studio for a while, and I think you’ve proven yourself worthy of trying out for one of these roles.",
        "Relax, take a deep breath, and think of everything you’ve made it through so far. You’ve got this!",
        "Which role would you like to audition for?",
        "    ",
        "Good choice! Let me get everything set up for your audition..."
    };

    private string[] third_audition_succeed = {
        "Wow… that was amazing! You’ve really come a long way. The role is yours!",
        "To see someone under my company make it so far…soon your face will be appearing all over the city!",
        "This isn’t the end, though. If you want to do good in this role, you’ll have to keep working hard.",
        "I look forward to seeing what you’ll accomplish!",
    };

    string[] third_audition_failure = {
        "I can definitely see improvement in your technique! Unfortunately, there were a lot of contenders for this role, and we’ve decided to go with someone else…",
        "Don’t be discouraged! For a role this big, it’s normal not to make it on your first try.",
        "No matter what, you’ve made your first steps into the acting industry, and that’s something to celebrate!",
        "I can’t wait to see what you’ll accomplish in the future!",
    };
    
    // public struct dialogueBranch {
    //     public dialogueBranch(string[] d, string[] p, string[]f, int r, int a, int e) {
    //         dialogue = d;
    //         passed = p;
    //         failed = f;
    //         rhythmGameIndex = r;
    //         auditionIndex = a;
    //         endIndex = e;

    //     }
    //     public string[] dialogue;
    //     public string[] passed;
    //     public string[] failed;
    //     public int rhyhmGameIndex;
    //     public int auditionIndex;
    //     public int endIndex;
    //     //  = 5;
    //     //     auditionIndex = 9;
    //     //     endIndex = 4;
    // };

        // public struct dialogueBranch {
        //     public string[] dialogue;
        //     public string[] passed;
            // public string[] failed;
            // public int rhyhmGameIndex;
            // public int auditionIndex;
            // public int endIndex;
        //  = 5;
        //     auditionIndex = 9;
        //     endIndex = 4;
    // };

    // dialogueBranch myB = new dialogueBranch(level1dialogue)

    // public dialogueBranch branchOne = new dialogueBranch(level1dialogue,
    // first_audition_succeed, first_audition_fail, 5, 9, 4);
    // branchOne.dialogue = level1dialogue;
    // branchOne.passed = first_audition_succeed;
    // branchOne.failed = first_audition_fail;
    // branchOne.rhyhmGameIndex = 5;
    // branchOne.auditionIndex = 9;
    // branchOne.endIndex = 4;
    
    // public dialogueBranch branchTwo;
    // branchTwo.dialogue = level_2_dialogue;
    // branchTwo.passed = first_audition_succeed;
    // branchTwo.failed = first_audition_fail;
    // branchTwo.rhyhmGameIndex = 5;
    // branchTwo.auditionIndex = 9;
    // branchTwo.endIndex = 4;

    // public dialogueBranch currentBranch = new dialogueBranch();

    public float textSpeed;
    public static int index; 

    public Button buttonSing;
    public Button buttonDance;

    public cardSpawner cs;

    public GameObject director;
    public Animator director_anim;

    public int rhythmGameIndex;
    public int auditionIndex;
    public int endIndex;

    public static Dialogue instance;



    void Start(){
        DontDestroyOnLoad(gameObject);
        textComponent.text = string.Empty;
        instance = this;
        
        buttonSing.gameObject.SetActive(false);
        buttonDance.gameObject.SetActive(false);

        if (GameHandler.level == 0) {
            index = 0;
            sentences = level1dialogue;
            passedBranch = first_audition_succeed;
            failedBranch = first_audition_fail;

            rhythmGameIndex = 5;
            auditionIndex = 9;
            endIndex = 4; //why does it end at index 4?
        }

        StartDialogue();
    }

    void reset_branch() {
        if (GameHandler.level == 1) {
            index = 0;
            sentences = level_2_dialogue;
            passedBranch = second_audition_passed;
            failedBranch = second_audition_failure;

            rhythmGameIndex = 3;
            auditionIndex = 5;
            endIndex = 2;
        }
        else if (GameHandler.level == 2) {
            index = 0;
            sentences = level_3_dialogue;
            passedBranch = third_audition_succeed;
            failedBranch = third_audition_failure;

            rhythmGameIndex = 3;
            auditionIndex = 6;
            endIndex = 3;
        }
        else if (GameHandler.level == 3) {
            print("GAME OVER");
        }
        
    }

    void Update(){
        if (index == rhythmGameIndex) {
            buttonSing.gameObject.SetActive(true);
            buttonDance.gameObject.SetActive(true);
        }

        else if (index == auditionIndex) {
            cs.spawnCard();
        }

        else if (index == auditionIndex+2) {
            if (GameHandler.passedAudition) {
                sentences = passedBranch;
            }
            else {
                sentences = failedBranch;
            }

            index = 0;
        }

        else if ((sentences == passedBranch || sentences == failedBranch) && (index == endIndex)) {
            index = 0;
            myGH.StartGame();
            reset_branch();
            
        }

        if (textComponent.text == sentences[index]) {
            director_anim.Play("Rest");
        }

        if (!/*index != 5 ||*/ (index == 9 || index == 10)) {
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
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine() {
    
        director_anim.Play("new_anim");
        foreach(char c in sentences[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine() {
        if (index < sentences.Length - 1) {
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
    }

    public void incrementIndex() {
        index++;
    }


}

