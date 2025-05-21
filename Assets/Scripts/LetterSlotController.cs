using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LetterSlotManager : MonoBehaviour
{
    public List<Button> letterButtons;

    private List<char> currentSequence = new List<char>();
    private List<char> displayedSequence = new List<char>(); // предыдущее состояние
    private int currentIndex = 0;

    void Update()
    {
        currentSequence.Clear();
        // 🟡 Пример: получаем новые данные каждый кадр
        List<int> inputFromBackend = SequenceMaster.Instance.GetSequence();

        foreach (int num in inputFromBackend)
        {
            char letter = (char)('a' + num - 1);
            currentSequence.Add(letter);
        }

        for (int i = 0; i < letterButtons.Count; i++)
        {
            letterButtons[i].GetComponentInChildren<Text>().text = currentSequence[i].ToString();
        }
        
        //UpdateLetterSlots(inputFromBackend);
        //HandleKeyboardInput();
    }
}