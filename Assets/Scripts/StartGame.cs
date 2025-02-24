using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGamePlay()
    {
        SceneManager.LoadScene("dialogue_scene");  // Make sure "GameScene" is the name of your game scene
    }
}
