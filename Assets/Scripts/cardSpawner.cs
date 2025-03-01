using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardSpawner : MonoBehaviour
{
    public Transform canvas;
    public Transform[] spawnPoints;
    public List<GameObject> roleCards;
    public Dialogue dialogue;


    // Start is called before the first frame update
    void Start(){
        spawnCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCard() {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Debug.Log("loop num " + i);
            int cardToChoose = Random.Range(0, roleCards.Count);
            Debug.Log(cardToChoose);
            GameObject cardToSpawn = roleCards[cardToChoose];
            roleCards.Remove(cardToSpawn);
            Instantiate(cardToSpawn, spawnPoints[i].position, Quaternion.identity, canvas);
        }

        dialogue.NextLine();
    }

}
