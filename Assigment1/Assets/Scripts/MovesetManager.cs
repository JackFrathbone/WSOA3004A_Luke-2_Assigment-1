using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class MovesetManager : MonoBehaviour
{
    //This list will contain each move that makes up the entire level (later this list will be fed into by some other system that generates lists)
    public Moveset moveset;
    private List<string> _moves;

    private string _currentMove;
    private int _onMove;

    private bool _hasStarted;

    //For the audio feedback
    private AudioSource _audio;
    public AudioClip pass;
    public AudioClip fail;

    //Keep this script in the same object as UIVisuals
    private UIVisuals _visuals;

    public GameObject endScreen;
    private TextMeshProUGUI _scoreText;

    //For the score
    private int _scoreTotal;
    private int _scoreCurrent;

    //For the timed turn
    private bool _hasMoved;
    public float turnTimerAmount;

    public GameObject failPopup;

    private void Start()
    {
        //Fills the list in with the currently assigned moveset object
        _moves = moveset.moves;

        _visuals = GetComponent<UIVisuals>();
        _scoreText = endScreen.GetComponentInChildren<TextMeshProUGUI>();

        _audio = GetComponent<AudioSource>();
    }

    public void StartMoveset()
    {
        _hasMoved = false;

        //For restarting, hide the end screen & reset values
        endScreen.SetActive(false);

        _hasStarted = true;

        _onMove = 0;
        _currentMove = _moves[_onMove];

        _scoreTotal = _moves.Count;
        _scoreCurrent = _scoreTotal;

        Debug.Log("Current move: " + _currentMove);

        StartCoroutine("TurnTimer");
    }

    private void NextMove(bool passed)
    {
        if (_hasMoved)
        {
            StopAllCoroutines();
            _hasMoved = false;
        }
        else
        {
            _hasMoved = false;
        }


        _onMove++;

        if (_onMove > _moves.Count-1)
        {
            EndMoveset();
            return;
        }
        else
        {
            _currentMove = _moves[_onMove];
        }

        //For the score
        if (!passed)
        {
            _scoreCurrent--;
        }

        Debug.Log("Current move: " + _currentMove);
        Debug.Log("Current Score:" + _scoreCurrent +" /" +_scoreTotal);

        StartCoroutine("TurnTimer");
    }

    private void EndMoveset()
    {
        _hasStarted = false;
        endScreen.SetActive(true);

        _scoreText.text = "You hit " + _scoreCurrent + "/" + _scoreTotal + " moves \n" + GetScorePercent();

        _visuals.HideArrow();
    }

    private string GetScorePercent()
    {
        float scorePercent = (float)_scoreCurrent / (float)_scoreTotal * 100f;
        print(scorePercent);

        return "You scored " + scorePercent + "%";
    }

    public void LookUp()
    {
        if (_hasStarted)
        {
            _visuals.ShowArrow("up", CurrentMoveCheck("up"));
        }
    }

    public void LookDown()
    {
        if (_hasStarted)
        {
            _visuals.ShowArrow("down", CurrentMoveCheck("down"));
        }
    }

    public void LookLeft()
    {
        if (_hasStarted)
        {
            _visuals.ShowArrow("left", CurrentMoveCheck("left"));
        }
    }

    public void LookRight()
    {
        if (_hasStarted)
        {
            _visuals.ShowArrow("right", CurrentMoveCheck("right"));
        }
    }

    private bool CurrentMoveCheck(string direction)
    {
        if(direction == _currentMove)
        {
            _hasMoved = true;
            NextMove(true);
            //For the pass feedback
            _audio.clip = pass;
            _audio.Play();
            return true;
        }
        _hasMoved = true;
        NextMove(false);
        //For the fail feedback
        Handheld.Vibrate();
        _audio.clip = fail;
        _audio.Play();
        return false;
    }

    private IEnumerator TurnTimer()
    {
        yield return new WaitForSeconds(turnTimerAmount);
        if (_hasMoved)
        {
            print(_hasMoved);
            yield break;
        }
        else
        {
            print("yee");
            failPopup.SetActive(true);
            NextMove(false);
            Handheld.Vibrate();
            _audio.clip = fail;
            _audio.Play();
        }
        yield return new WaitForSeconds(1f);
        failPopup.SetActive(false);
    }
}
