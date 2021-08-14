using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandsManager : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject endButton;
    public TextMeshProUGUI commandText;
    private Queue<string> moves = new Queue<string>();

    //For the trigger
    public GameObject startButton;
    public Moveset moveset;

    void Start()
    {
        startButton.SetActive(true);
        continueButton.SetActive(false);
        endButton.SetActive(false);
    }

    public void StartMoveset(Moveset m)
    {
        moves.Clear();
        foreach (string sentence in m.moves)
        {
            moves.Enqueue(sentence);
        }

        DisplayNextCommand();
    }

    public void DisplayNextCommand()
    {
        continueButton.SetActive(true);
        if (moves.Count == 0)
        {
            EndCommands();
            return;
        }

        string sentence = moves.Dequeue();
        commandText.text = sentence;
    }

    void EndCommands()
    {
        continueButton.SetActive(false);
        endButton.SetActive(true);
    }

    public void TriggerCommands()
    {
        FindObjectOfType<CommandsManager>().StartMoveset(moveset);
        startButton.SetActive(false);
    }

}
