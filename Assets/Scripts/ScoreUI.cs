using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class ScoreUI : MonoBehaviour
{
    int score;
    Label label;

    void OnEnable()
    {
        label = new Label();
        label.style.position = Position.Absolute;
        label.style.top = 16;
        label.style.left = 16;
        label.style.fontSize = 32;
        label.style.color = Color.white;
        label.style.unityFontStyleAndWeight = FontStyle.Bold;
        GetComponent<UIDocument>().rootVisualElement.Add(label);
        Refresh();
        Coin.Collected += OnCollected;
    }

    void OnDisable() => Coin.Collected -= OnCollected;

    void OnCollected()
    {
        score++;
        Refresh();
    }

    void Refresh() => label.text = $"Moedas: {score}";
}
