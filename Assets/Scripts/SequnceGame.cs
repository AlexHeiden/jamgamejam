using System.Collections;

namespace DefaultNamespace
{
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    public class SequenceGame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] numberTexts; // 4 TextMeshProUGUI objects
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip successClip;
        [SerializeField] private TextMeshProUGUI scoreText;

        private List<int> sequence = new();
        private int inputIndex;
        private int score;

        private void Start()
        {
            GenerateSequence();
            DisplaySequence();
        }

        private void Update()
        {
            if (inputIndex >= sequence.Count) return;

            if (Input.GetKeyDown(KeyCode.Alpha1)) CheckInput(1);
            if (Input.GetKeyDown(KeyCode.Alpha2)) CheckInput(2);
            if (Input.GetKeyDown(KeyCode.Alpha3)) CheckInput(3);
            if (Input.GetKeyDown(KeyCode.Alpha4)) CheckInput(4);
        }

        private void GenerateSequence()
        {
            sequence.Clear();
            for (int i = 0; i < 4; i++)
            {
                sequence.Add(Random.Range(1, 5));
            }

            inputIndex = 0;
        }

        private void DisplaySequence()
        {
            for (int i = 0; i < numberTexts.Length; i++)
            {
                numberTexts[i].text = i < sequence.Count ? sequence[i].ToString() : "";
            }
        }
    

    private void CheckInput(int input)
        {
            if (sequence[inputIndex] == input)
            {
                StartCoroutine(FlashColor(numberTexts[inputIndex], Color.green));
                inputIndex++;

                if (inputIndex >= sequence.Count)
                {
                    Debug.Log("Correct sequence!");
                    audioSource.PlayOneShot(successClip);
                    score += 100;
                    scoreText.text = score.ToString();
                    
                    GenerateSequence();
                    DisplaySequence();
                }
            }
            else
            {
                Debug.Log("Wrong input!");
                inputIndex = 0;
                // Optional: flash red or reset
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

}