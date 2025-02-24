using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static bool dialogueValid = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool get_dialogueValid() {
        return dialogueValid;
    
    }   
}
