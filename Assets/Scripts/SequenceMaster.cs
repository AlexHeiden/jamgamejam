using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SequenceMaster : MonoBehaviour
{
    public static SequenceMaster Instance { get; private set; }

    private TextMeshPro scoreText;
    private List<int> sequence;
    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        scoreText = GameObject.Find("Text").GetComponent<TextMeshPro>();
        sequence = new List<int>();
        score = 0;
        NextSequence();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && MatchKey(1)) RemoveElement();
        if (Input.GetKeyDown(KeyCode.S) && MatchKey(2)) RemoveElement();
        if (Input.GetKeyDown(KeyCode.D) && MatchKey(3)) RemoveElement();
        if (Input.GetKeyDown(KeyCode.H) && MatchKey(4)) RemoveElement();
        if (Input.GetKeyDown(KeyCode.J) && MatchKey(5)) RemoveElement();
        if (Input.GetKeyDown(KeyCode.K) && MatchKey(6)) RemoveElement();
    }

    private bool MatchKey(int key)
    {
        return sequence.Count > 0 && sequence[sequence.Count - 1] == key;
    }

    private void RemoveElement()
    {
        sequence.RemoveAt(sequence.Count - 1);
        if (sequence.Count == 0)
        {
            score++;
            NextSequence();
        }
    }

    private void NextSequence()
    {
        sequence.Clear();
        for (int i = 0; i < 6; i++)
        {
            sequence.Add(Random.Range(1, 7));
        }
    }

    public List<int> GetSequence()
    {
        return sequence;
    }
}