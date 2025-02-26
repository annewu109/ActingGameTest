using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGamePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("emma_work");  // Make sure "GameScene" is the name of your game scene
    }
}
