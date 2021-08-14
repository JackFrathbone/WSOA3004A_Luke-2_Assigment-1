using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandsManager : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject endButton;
    public Text commandText;
    private Queue<string> instructions;

    void Start()
    {
        continueButton.SetActive(false);
        endButton.SetActive(false);
        instructions = new Queue<string>();
    }

    public void StartCommand(Commands commands)
    {
        instructions.Clear();
        foreach (string sentence in commands.commandSet)
        {
            instructions.Enqueue(sentence);
        }

        DisplayNextCommand();
    }

    public void DisplayNextCommand()
    {
        continueButton.SetActive(true);
        if (instructions.Count == 0)
        {
            EndCommands();
            return;
        }

        string sentence = instructions.Dequeue();
        commandText.text = sentence;
    }

    void EndCommands()
    {
        continueButton.SetActive(false);
        endButton.SetActive(true);
    }

}
