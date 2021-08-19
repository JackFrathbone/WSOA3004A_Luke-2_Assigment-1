using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveSetGenerator : MonoBehaviour
{
    //Accepted levels are "easy" "medium" "hard"
    private string _difficulty = "easy";
    //This is the seed
    private int _movesetSeed;
    public Moveset moveset;

    private string[] _possibleMoves = {"up","down","left","right"};

    private List<string> generatedMoveset = new List<string>();

    //For the visual stuff
    public TextMeshProUGUI joinCodeText;
    public TextMeshProUGUI difficultyText;

    private void Start()
    {
        difficultyText.text = "Current Difficulty: " + _difficulty;
    }

    public void SetDifficulty(string s)
    {
        _difficulty = s;
        difficultyText.text = "Current Difficulty: " + _difficulty;
    }

    public void GenerateMoveset()
    {
        //To create the seed
        _movesetSeed = Random.Range(1000,9999);
        _movesetSeed = int.Parse(_movesetSeed.ToString() + GetDifficultyNumber());

        Random.InitState(_movesetSeed);

        joinCodeText.text = _movesetSeed.ToString();

        switch(_difficulty){
            case "easy":
                FillList(10);
                break;
            case "medium":
                FillList(15);
                break;
            case "hard":
                FillList(25);
                break;
            default:
                Debug.Log("_difficulty string not spelt properly");
                break;
        }
    }

    //The input determines the length of the moveset
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
        return _possibleMoves[Random.Range(0,4)];
    }

    private string GetDifficultyNumber()
    {
        switch (_difficulty)
        {
            case "easy":
                return "1";
            case "medium":
                return "2";
            case "hard":
                return "3";
            default:
                return "8";
        }
    }
}
