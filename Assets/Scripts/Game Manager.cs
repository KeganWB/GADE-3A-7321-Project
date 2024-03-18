using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int _playerScore = 0;
    private int _enemyScore = 0;
    private bool _blueFlagPickedUp = false;
    private bool _redFlagPickedUp = false;

    //References to flag base positions
    public Transform _blueFlagBasePosition;
    public Transform _redFlagBasePosition;

    //References to flag GameObjects
    private GameObject _blueFlag;
    private GameObject _redFlag;

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

    //Called when the player picks up the blue flag
    public void PlayerPickedUpBlueFlag(GameObject flagObject)
    {
        _blueFlag = flagObject;
        _blueFlagPickedUp = true;

        //Parent the flag to the player so it follows the player's movement
        _blueFlag.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("picked up");
    }

    //Called when the player returns the blue flag to its base
    public void PlayerReturnedBlueFlagAtBase()
    {
        if (_blueFlagPickedUp)
        {
            //Unparent the flag from the player
            _blueFlag.transform.parent = null;

            //Reset the flag position to its base
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

            //Reset the flag position to its base
            _redFlag.transform.position = _redFlagBasePosition.position;
            _redFlag.transform.rotation = _redFlagBasePosition.rotation;

            //Score point for the enemy
            ScorePointForEnemy();
            _redFlagPickedUp = false;
        }
    }

    private void ScorePointForPlayer()
    {
        _playerScore++;
        Debug.Log("Player Score: " + _playerScore);
    }

    private void ScorePointForEnemy()
    {
        _enemyScore++;
        Debug.Log("Enemy Score: " + _enemyScore);
    }
    
}
