using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;
    public TextMeshProUGUI[] bestTexts;

    private int _best;
    private int _score;

    private void Start()
    {
        _best = PlayerPrefs.GetInt("HighScore");
        UpdateTexts();
    }

    public void IncrementScore()
    {
        _score++;
        if (_score > _best)
        {
            _best = _score;
            PlayerPrefs.SetInt("HighScore", _best);
        }

        UpdateTexts();
    }

    private void UpdateTexts()
    {
        foreach (TextMeshProUGUI scoreText in scoreTexts) scoreText.text = _score.ToString();

        foreach (TextMeshProUGUI bestText in bestTexts) bestText.text = _best.ToString();
    }
}