using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SequenceMaster : MonoBehaviour
{
    private List<int> sequence;
    private int score;

    private void Awake()
    {
        sequence = new List<int>();
    }

    private void NextSequence()
    {
        sequence = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            sequence.Add(Random.Range(1, 7));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && sequence.Count > 0 && sequence[sequence.Count - 1] == 1)
        {
            RemoveElement();
        }
        if (Input.GetKeyDown(KeyCode.S) && sequence.Count > 0 && sequence[sequence.Count - 1] == 2)
        {
            RemoveElement();
        }
        if (Input.GetKeyDown(KeyCode.D) && sequence.Count > 0 && sequence[sequence.Count - 1] == 3)
        {
            RemoveElement();
        }
        if (Input.GetKeyDown(KeyCode.H) && sequence.Count > 0 && sequence[sequence.Count - 1] == 4)
        {
            RemoveElement();
        }
        if (Input.GetKeyDown(KeyCode.J) && sequence.Count > 0 && sequence[sequence.Count - 1] == 5)
        {
            RemoveElement();
        }
        if (Input.GetKeyDown(KeyCode.K) && sequence.Count > 0 && sequence[sequence.Count - 1] == 6)
        {
            RemoveElement();
        }
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

    public List<int> getSequence()
    {
        return sequence;
    }
}
