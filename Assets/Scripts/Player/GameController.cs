using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject player;
    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject cannonTrail;
    public GameObject audioController;

    //Play once
    private bool cannonSound = false; 

    void Update() {
        PlayerDead();
        PlayerActive(); //Start Playing
        PlayerDoubleStarted(); //Out of the cannon  
    }

    void PlayerDead() {
        if (player.GetComponent<Player>().GetDead()) {
            restartButton.SetActive(true);
            menuButton.SetActive(true);
        }
    }
    void PlayerActive() {
        if (player.GetComponent<Player>().GetActive()) {
            cannonTrail.SetActive(false);
        }
    }
    void PlayerDoubleStarted() { 
        if (player.GetComponent<Player>().GetDoubleStarted()) {
            if (!cannonSound) {
                cannonTrail.SetActive(true);
                audioController.GetComponent<AudioManager>().Play("Cannon");
                cannonSound = true;
            }
            
        }
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        Debug.Log("MENU");
    }
}
