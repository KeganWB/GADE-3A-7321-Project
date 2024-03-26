using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private TextMeshProUGUI _endGameText;
    private int _playerScore = 0;
    private int _enemyScore = 0;
    public bool _blueFlagPickedUp = false;
    public bool _redFlagPickedUp = false;

    //References to flag base positions
    public Transform _blueFlagBasePosition;
    public Transform _redFlagBasePosition;

    //References to flag GameObjects
    public GameObject _blueFlag;
    public GameObject _redFlag;
    public Transform _redFlagSpawnPoint;

    public Transform _redFlagDropped;
    public Transform _blueFlagDropped;

    
    private int _winningScore = 5;

    void Start()
    {
        _endGameText = GameObject.FindGameObjectWithTag("EndGameText").GetComponent<TextMeshProUGUI>();
        _endGameText.enabled = false;
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject manager = new GameObject("GameManager");
                    instance = manager.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    // Called when the player picks up the blue flag
    public void PlayerPickedUpBlueFlag(GameObject flagObject)
    {
        _blueFlag = flagObject;
        _blueFlagPickedUp = true;

        // Parent the flag to the player so it follows the player's movement
        _blueFlag.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Called when the player returns the blue flag to its base
    public void PlayerReturnedBlueFlagAtBase()
    {
        if (_blueFlagPickedUp)
        {
            //Unparent the flag from the player
            _blueFlag.transform.parent = null;

            //Reset the flag position to the blue flag base
            _blueFlag.transform.position = _blueFlagBasePosition.position;
            _blueFlag.transform.rotation = _blueFlagBasePosition.rotation;

            //Score point for the player
            ScorePointForPlayer();
            _blueFlagPickedUp = false;
        }
    }

    //Called when the enemy AI picks up the red flag
    public void EnemyPickedUpRedFlag(GameObject flagObject)
    {
        Debug.Log("enemy picked up ()");
        _redFlag = flagObject;
        _redFlagPickedUp = true;

        //Parent the flag to the enemy AI so it follows the enemy's movement
        _redFlag.transform.parent = GameObject.FindGameObjectWithTag("Enemy").transform;
        
    }

    //Called when the enemy AI returns the red flag to its base
    public void EnemyReturnedRedFlagAtBase()
    {
        if (_redFlagPickedUp)
        {
            //Unparent the flag from the enemy AI
            _redFlag.transform.parent = null;

            //Reset the flag position to the RedFlagSpawn position
            Transform redFlagSpawn = GameObject.FindGameObjectWithTag("RedFlagSpawn").transform;
            _redFlag.transform.position = redFlagSpawn.position;
            _redFlag.transform.rotation = redFlagSpawn.rotation;

            //Score point for the enemy
            ScorePointForEnemy();
            _redFlagPickedUp = false;
        }
    }

    private void ScorePointForPlayer()
    {
        _playerScore++;
        CheckGameEnd();
        Debug.Log("Player Score: " + _playerScore);
    }

    private void ScorePointForEnemy()
    {
        _enemyScore++;
        CheckGameEnd();
        Debug.Log("Enemy Score: " + _enemyScore);
    }
    
    private void CheckGameEnd()
    {
        if (_playerScore >= _winningScore || _enemyScore >= _winningScore)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (_playerScore == _winningScore)
        {
            //You Won
            _endGameText.enabled = true;
            _endGameText.text = "You Win!";
        }
        else if (_enemyScore == _winningScore)
        {
            //You Lose
            _endGameText.enabled = true;
            _endGameText.text = "You Lose!";
        }
        
        Debug.Log("Game Over");
    }
}
