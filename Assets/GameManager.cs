using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum Difficulty { Easy, Hard };
    public Difficulty currentDifficulty = Difficulty.Easy;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject gameOverMenu;

    [Header("Other")]
    public GameObject playerCard;
    public GameObject spawner;
    public Button startButton;
    public Button returnButton;

    [Header("Difficulty Buttons")]
    public Button easyButton;
    public Button hardButton;

    public int nextExpectedRank = 2;
    public bool currentIsRed = false;

    [Header("Gameplay")]
    public int points = 0;
    public int pointsToWin = 13;

    [Header("UI Text")]
    public TMP_Text gameOverText;




    public void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    public void StartGame()
    {
        points = 0;
        nextExpectedRank = 2;
        currentIsRed = false;

        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        playerCard.SetActive(true);
        spawner.SetActive(true);
        gameOverText.text = "";

        Card player = playerCard.GetComponent<Card>();
        player.SetCard(1, false);
    }

    public void EndGame(bool win)
    {
        playerCard.SetActive(false);
        spawner.SetActive(false);
        gameOverMenu.SetActive(true);

        gameOverText.text = win ? "You Win!" : "Game Over";
    }

    public void UpdatePlayerCard(int newRank, bool isNewRed)
    {
        if(newRank == 13)
        {
            nextExpectedRank = 1;
        }
        else {
            nextExpectedRank = newRank + 1;
        }
        
        currentIsRed = !isNewRed;
    }

    public void ReturnToMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    public void SelectEasy()
    {
        currentDifficulty = Difficulty.Easy;
        pointsToWin = 13;

        easyButton.GetComponent<Image>().color = Color.red;
        hardButton.GetComponent<Image>().color = Color.black;
    }

    public void SelectHard()
    {
        currentDifficulty = Difficulty.Hard;
        pointsToWin = 52;

        hardButton.GetComponent<Image>().color = Color.red;
        easyButton.GetComponent<Image>().color = Color.black;
    }


}
