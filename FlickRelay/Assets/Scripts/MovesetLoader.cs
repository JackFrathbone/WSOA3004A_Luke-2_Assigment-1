using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesetLoader : MonoBehaviour
{
    public TMP_InputField codeInput;

    public Moveset moveset;
    private int _movesetSeed;

    private string[] _possibleMoves = { "up", "down", "left", "right" };

    private List<string> generatedMoveset = new List<string>();

    private TouchScreenKeyboard keyboard;

    public void LoadCode()
    {
        int seed = int.Parse(codeInput.text);

        Random.InitState(seed);

        if (seed.ToString().EndsWith("1"))
        {
            FillList(10);
        }
        else if (seed.ToString().EndsWith("2"))
        {
            FillList(15);
        }
        else
        {
            FillList(25);
        }
    }

    private void FillList(int input)
    {
        generatedMoveset.Clear();
        for (int i = 0; i < input; i++)
        {
            generatedMoveset.Add(RandomiseDirection());
        }

        moveset.moves.Clear();
        moveset.moves = new List<string>(generatedMoveset);
    }

    private string RandomiseDirection()
    {
        return _possibleMoves[Random.Range(0, 4)];
    }
}
