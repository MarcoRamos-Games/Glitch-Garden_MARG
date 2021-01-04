using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;

    Text startText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        startText = GetComponent<Text>();
        UpdateDisplay();
       

    }

    private void UpdateDisplay()
    {
        startText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        Lose();
    }

    private void Lose()
    {
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            
        }
    }
}
