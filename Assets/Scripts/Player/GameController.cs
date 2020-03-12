using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject player;
    public GameObject restartButton;
    public GameObject canonTrail;
    public GameObject audioController;

    //Play once
    private bool cannonSound = false; 

    void Update() {
        PlayerDead(); //
        PlayerActive(); //Start Game
        PlayerDoubleStarted(); //Out of the cannon  
    }

    void PlayerDead() {
        if (player.GetComponent<Player>().GetDead()) {
            restartButton.SetActive(true);   
        }
    }
    void PlayerActive() {
        if (player.GetComponent<Player>().GetActive()) {
            canonTrail.SetActive(false);
        }
    }
    void PlayerDoubleStarted() { 
        if (player.GetComponent<Player>().GetDoubleStarted()) {
            if (!cannonSound) {
                canonTrail.SetActive(true);
                audioController.GetComponent<AudioManager>().Play("Cannon");
                cannonSound = true;
            }
            
        }
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
