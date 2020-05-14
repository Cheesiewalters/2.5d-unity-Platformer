using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _livesText;
    private int _score = 0;
    private int _lives = 0;
    public void UpdateCoinDisplay(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateLives(int Lives)
    {
        _livesText.text = "Lives: " + Lives.ToString();
    }
}
