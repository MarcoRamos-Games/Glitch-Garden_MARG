using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel = null;
    [SerializeField] GameObject loseLabel = null;
    [SerializeField] float loadingTime = 5f;
    int numberOfAtackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        
        
    }

    public void AtackerSpawned()
    {
        numberOfAtackers++;
    }

    public void AtackerKilled()
    {
        numberOfAtackers--;
        if(numberOfAtackers <=0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        yield return new WaitForSeconds(loadingTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();
        
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AtackerSpawner[] spawnerArray = FindObjectsOfType<AtackerSpawner>();
        foreach (AtackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawing();
        }
    }
}
