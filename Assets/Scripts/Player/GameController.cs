using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject player;
    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject cannonTrail;
    public GameObject audioController;
    public GameObject mouse;

    //Play once
    private bool cannonSound = false;

    private void Start() {
        Cursor.visible = false;
        mouse.SetActive(false);
    }
    void Update() {
        PlayerDead();
        PlayerActive(); //Start Playing
        PlayerDoubleStarted(); //Out of the cannon  
        PlayerWin();
    }

    void PlayerDead() {
        if (player.GetComponent<Player>().GetDead()) {
            if (!player.GetComponent<Player>().isDissolving) {
                restartButton.SetActive(true);
                menuButton.SetActive(true);
            }
            mouse.SetActive(true);
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
    void PlayerWin() {
        if (player.GetComponent<Player>().GetWon()) {
            if (!player.GetComponent<Player>().isDissolving) {
                restartButton.SetActive(true);
                menuButton.SetActive(true);
            }
            mouse.SetActive(true);
        }
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
}
