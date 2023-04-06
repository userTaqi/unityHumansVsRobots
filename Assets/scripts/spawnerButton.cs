using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerButton : MonoBehaviour
{
    public GameObject scientistPrefab;
    public void SpawnIt(){
        Instantiate(scientistPrefab, transform.position, Quaternion.identity);
        
    }
}
