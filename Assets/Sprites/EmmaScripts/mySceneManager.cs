using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static int index;
    
    // public GameObject canvas;
    // public GameObject dialogueEventSystem;

    void Start()
    {
        // canvas = GameObject.Find("Canvas");

        DontDestroyOnLoad(this.gameObject);
        Dialogue dm = gameObject.GetComponent<Dialogue>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (index == 10) {
        //     buttonHandler();
        // // }
        // if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "RhythmGame") {
        //     canvas.SetActive(true);
        // }

        // if (UnityEngine.SceneManagement.SceneManager.sceneCount <= 1) {
        //     canvas.SetActive(true);
        //     dialogueEventSystem.SetActive(true);
        // }

    }

    public void scene_changer(string scene_name){
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name);
        
    }

    public void scene_changer_additive(string scene_name){
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        // UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName(scene_name));
        

    }

    public void unload_scene(string scene_name) {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene_name);

    }
 
}

