using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTrigger : MonoBehaviour
{
    public GameObject startButton;
    public Commands commands;

    private void Start()
    {
        startButton.SetActive(true);
    }

    public void TriggerCommands()
    {
        FindObjectOfType<CommandsManager>().StartCommand(commands);
        startButton.SetActive(false);
    }

}
