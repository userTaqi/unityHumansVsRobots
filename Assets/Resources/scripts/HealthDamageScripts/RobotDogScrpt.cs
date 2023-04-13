using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDogScrpt : MonoBehaviour
{
    void OnCollisionEnter2D(){
        Destroy(gameObject);
    }
}
