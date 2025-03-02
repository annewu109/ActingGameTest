using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour {

      public static int progressStat;
      public static int singStat;
      public static int danceStat;
      public TMP_Text singText;
      public TMP_Text danceText;
      private string sceneName;
      public static int level;
      public static string lastLevelDied;  //allows replaying the Level where you died
      public static bool passedAudition;


      void Start(){
            //player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                singStat = 0;
                danceStat = 0;
                level = 0;
            }
            UpdateStatsDisplay();
            print("GameHandelr restart");
            print ("level at GH restart: " + level);
      }

      public void addSing(int points){
            singStat += points;
            UpdateStatsDisplay();
      }

      public void addDance(int points){
            danceStat += points;
            UpdateStatsDisplay();
      }
      public void UpdateStatsDisplay(){
            singText.text = "SINGING: " + singStat;
            danceText.text = "DANCING: " + danceStat;
      }

      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      public void ReturnToLevel1() {
            level++;
            // print("level: " + level);
            SceneManager.UnloadSceneAsync("RhythmGame");
            // SceneManager.LoadScene("Level1");
      }

      // Return to MainMenu
      public void MainMenu() {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
             // Reset all static variables here, for new games:
            singStat = 0;
            danceStat = 0;
      }

      // Replay the Level where you died
      public void ReplayLastLevel() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(lastLevelDied);
             // Reset all static variables here, for new games:
            
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }

      public void GoToSingGame(){
            SceneManager.LoadScene("RhythmGame", LoadSceneMode.Additive);
      }

      public void GoToDanceGame(){
            SceneManager.LoadScene("RhythmGame", LoadSceneMode.Additive);
      }
      
      public int getSceneCount() {
            return SceneManager.sceneCount;
      }

      public void calcStatGain(int points, string singOrDance) {
            int statGain = 0;
            if (points >= 10000) {
                  statGain = 4;
            }
            else if (points >= 8000) {
                  statGain = 3;
            }
            else if (points >= 6000) {
                  statGain = 2;
            }
            else if (points >= 4000) {
                  statGain = 1;
            }

            if (singOrDance == "sing") {
                  addSing(statGain);
            }
            else if (singOrDance == "dance") {
                  addDance(statGain);
            }
      }
      /*

      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();       //play Death animation
            lastLevelDied = sceneName;       //allows replaying the Level where you died
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            player.GetComponent<PlayerMove>().isAlive = false;
            player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
      }
*/
      
}