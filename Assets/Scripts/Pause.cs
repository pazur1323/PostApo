using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    public bool isPaused = false;

    private void Start() {

        pauseCanvas.enabled = false;
    }
    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isPaused){

                Debug.Log("Paused");
                pauseCanvas.enabled = true;
                Time.timeScale = 0;
                isPaused = !isPaused;
            }
            else{
                Debug.Log("Unpaused");
                pauseCanvas.enabled = false;
                Time.timeScale = 1;
                isPaused = !isPaused;
            }
        }
    }

    public void Unpause(){
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
        isPaused = !isPaused;
    }

    public void Exit(){
        Application.Quit();
    }
}
