using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandsManager : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject endButton;
    public GameObject retryButton;
    public TextMeshProUGUI commandText;
    private Queue<string> moves = new Queue<string>();

    public Color textColor1;
    public Color textColor2;
    private bool onTextColor1;

    //For the trigger
    public GameObject startButton;
    public Moveset moveset;

    void Start()
    {
        startButton.SetActive(true);
        continueButton.SetActive(false);
        endButton.SetActive(false);
        retryButton.SetActive(false);
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
        #if UNITY_ANDROID
        Handheld.Vibrate();
        #endif

        continueButton.SetActive(true);
        if (moves.Count == 0)
        {
            EndCommands();
            return;
        }

        string sentence = moves.Dequeue();
        commandText.text = sentence;

        if (onTextColor1)
        {
            commandText.color = textColor1;
            onTextColor1 = false;
        }
        else
        {
            commandText.color = textColor2;
            onTextColor1 = true;
        }
    }

    void EndCommands()
    {
        continueButton.SetActive(false);
        endButton.SetActive(true);
        retryButton.SetActive(true);
        commandText.text = "";
    }

    public void TriggerCommands()
    {
        FindObjectOfType<CommandsManager>().StartMoveset(moveset);
        startButton.SetActive(false);
        endButton.SetActive(false);
        retryButton.SetActive(false);
    }

}
