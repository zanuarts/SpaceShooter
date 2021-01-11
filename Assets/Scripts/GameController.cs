﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float wavWait;

    public Text ScoreText;
    private int score;

    void Start(){
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    IEnumerator SpawnWaves(){
        yield return new WaitForSeconds (startWait);
        while(true){
            for(int i=0; i<hazardCount; i++){
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (wavWait);
        }
    }

    public void AddScore ( int newScoreValue){
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore(){
        ScoreText.text = "Score: " + score;
    }
}
