using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float baseHealth = 500f;
    [SerializeField] private GameObject gameOverScreen;

    void OnCollisionEnter2D(Collision2D enemy){
        if (enemy.gameObject.CompareTag("robot")){
            baseHealth -= 15f;
        }
        else if (enemy.gameObject.CompareTag("drone")){
            baseHealth -= 20f;
        }
    }
        
    void Update(){
        if (baseHealth == 0){
        BaseDied();
        }
    }

    public void BaseDied(){
        gameOverScreen.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
