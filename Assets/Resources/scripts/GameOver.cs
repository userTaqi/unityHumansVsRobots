using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    ///////////////////////////////////////////////////////GameOver
    private float baseHealth = 50;
    [SerializeField] private GameObject gameOverScreen;
    public bool gameAlive = true;

    void OnCollisionEnter2D(Collision2D enemy){
        if (enemy.gameObject.CompareTag("robot")){
            baseHealth -= 15;
        }
    }
    void OnTriggerEnter2D(Collider2D enemy){
        if (enemy.gameObject.CompareTag("drone")){
            baseHealth -= 20;
        }
    }
        
    void Update(){
        if (baseHealth <= 0){
        BaseDied();
        }
    }

    public void BaseDied(){
        gameOverScreen.SetActive(true);
        gameAlive = false;
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameAlive = true;
    }
}
