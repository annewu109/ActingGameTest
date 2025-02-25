//NOTE the scene with the rhythm game must be named game_scene.

//note - when transitiong out of game_scene, game_scene should be unloaded
// using unload_scene, rather than dialogue_scene being loaded -
// b/c game scene is loaded additively.

using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public Button smallCardOne;
    public Button smallCardTwo;
    public Button smallCardThree;
    
    public string smallRole;
    public string medRole;

    bool small = false;
    private static int index;
    


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        smallCardOne.gameObject.SetActive(false);
        smallCardTwo.gameObject.SetActive(false);
        smallCardThree.gameObject.SetActive(false);

        smallCardOne.onClick.AddListener(() => buttonClicked("small role one"));
        smallCardTwo.onClick.AddListener(() => buttonClicked("small role two"));
        smallCardThree.onClick.AddListener(() => buttonClicked("small role three"));

        Dialogue dm = gameObject.GetComponent<Dialogue>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 10) {
            buttonHandler();
        }
    }

    public static int setIndex() {
        return index;
    }

    public void buttonHandler() {
        smallCardOne.gameObject.SetActive(true);
        smallCardTwo.gameObject.SetActive(true);
        smallCardThree.gameObject.SetActive(true);
    }

    void buttonClicked(string role) {
        smallRole = role;
        index = 11;
        smallCardOne.gameObject.SetActive(false);
        smallCardTwo.gameObject.SetActive(false);
        smallCardThree.gameObject.SetActive(false);
    }


//scene stuff

    public void scene_changer(string scene_name){
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name);
        
    }

    public void scene_changer_additive(string scene_name){
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        
    }

    public void unload_scene(string scene_name) {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene_name);
    }
 
}

