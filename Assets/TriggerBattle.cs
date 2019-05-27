using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattle : MonoBehaviour
{
    public string sceneToLoad;
    void OnTriggerEnter2D(Collider2D other){
        if(other.name != "Player")
            return;
        Destroy(GameObject.Find("Enemy"));
        Application.LoadLevel(sceneToLoad);
    }

    void LoadBattleScreen(){
        GameController.control.inBattle = true;
        Destroy(GameObject.Find("Enemy"));
        GameController.control.playerDead = true;
        Application.LoadLevel(sceneToLoad);
    }
}
