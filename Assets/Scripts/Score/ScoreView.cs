using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += ChangeDisplay;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= ChangeDisplay;
    }

    private void ChangeDisplay()
    {
        _text.text = _scoreCounter.Score.ToString();
    }
}