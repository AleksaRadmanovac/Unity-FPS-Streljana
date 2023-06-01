using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private TextMeshProUGUI textScore;
    private TextMeshProUGUI textLifes;
    private TextMeshProUGUI textFinalScore;
    private TextMeshProUGUI textAmmo;
    private GameObject gameoverScreen;
    private bool gameoverShown = false;
    

    void Start()
    {
        textScore = GameObject.Find("textScore").GetComponent<TextMeshProUGUI>();
        textLifes = GameObject.Find("textLifes").GetComponent<TextMeshProUGUI>();
        gameoverScreen = GameObject.FindWithTag("GameoverScreen");
        textAmmo = GameObject.Find("textAmmo").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        if (!gameoverShown)
        {
            textScore.text = "Score: " + IgracMovement.score;
            textLifes.text = "Lifes remaining: " + IgracMovement.lifes;
            textAmmo.text = ShootingScript.ammo + "/30";
        }
        if (GameManager.isOver && !gameoverShown)
        {
            textFinalScore = gameoverScreen.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            textFinalScore.text = 
                textFinalScore.text + IgracMovement.score;
            gameoverShown = true;
        }
    }
}
