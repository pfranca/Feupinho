using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject player;
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start() {
        Debug.Log(player.GetComponent<Player>().GetDead());
    }

    // Update is called once per frame
    void Update(){
        if (player.GetComponent<Player>().GetDead()) {
            restartButton.SetActive(true);
        }
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
