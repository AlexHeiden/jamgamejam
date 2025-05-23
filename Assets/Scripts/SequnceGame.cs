using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SequenceGame : MonoBehaviour
{
    [SerializeField] private Button[] inputButtons; // Buttons to press
    [SerializeField] private TextMeshProUGUI[] buttonLabels; // Text on buttons
    [SerializeField] private TextMeshProUGUI[] numberTexts; // Sequence display
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip successClip;
    [SerializeField] private TextMeshProUGUI scoreText;

    private List<int> sequence = new();
    private int inputIndex;
    private int score;

    private void Start()
    {
        // Attach button listeners
        for (int i = 0; i < inputButtons.Length; i++)
        {
            int buttonIndex = i;
            inputButtons[i].onClick.AddListener(() => OnButtonPressed(buttonIndex));
        }

        GenerateSequence();
        ApplyButtonNumbers();
        DisplaySequence();
    }

    private void OnButtonPressed(int buttonIndex)
    {
        // Get the number on this button
        if (!int.TryParse(buttonLabels[buttonIndex].text, out int value))
        {
            Debug.LogError("Invalid button label.");
            return;
        }

        if (sequence[inputIndex] == value)
        {
            StartCoroutine(FlashColor(numberTexts[inputIndex], Color.green));
            inputIndex++;

            if (inputIndex >= sequence.Count)
            {
                audioSource.PlayOneShot(successClip);
                score += 100;
                scoreText.text = score.ToString();

                GenerateSequence();
                ApplyButtonNumbers();
                DisplaySequence();
            }
        }
        else
        {
            foreach (var text in numberTexts)
                StartCoroutine(FlashColor(text, Color.red));

            score -= 100;
            scoreText.text = score.ToString();
            inputIndex = 0;
        }
    }

    private void GenerateSequence()
    {
        sequence = new List<int> { 1, 2, 3, 4 };
        Shuffle(sequence);
        inputIndex = 0;
    }

    private void ApplyButtonNumbers()
    {
        // Randomize button labels
        List<int> buttonValues = new List<int> { 1, 2, 3, 4 };
        Shuffle(buttonValues);

        for (int i = 0; i < buttonLabels.Length; i++)
        {
            buttonLabels[i].text = buttonValues[i].ToString();
        }
    }

    private void DisplaySequence()
    {
        for (int i = 0; i < numberTexts.Length; i++)
        {
            numberTexts[i].text = sequence[i].ToString();
        }
    }

    private void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            (list[i], list[rnd]) = (list[rnd], list[i]);
        }
    }

    private IEnumerator FlashColor(TextMeshProUGUI text, Color color)
    {
        Color originalColor = text.color;
        text.color = color;
        yield return new WaitForSeconds(0.3f);
        text.color = originalColor;
    }
}
