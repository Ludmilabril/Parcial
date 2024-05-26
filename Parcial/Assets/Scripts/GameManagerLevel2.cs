using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerLevel2 : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool winCondition = false;
    public static int actualPlayer = 0;
    public int targetsToWin = 2;

    public List<Controller_TargetLevel2> targets;
    public List<Controller_PlayerLevel2> players;

    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        SetConstraints();
    }

    void Update()
    {
        GetInput();
        CheckWin();
    }

    private void CheckWin()
    {
        int i = 0;
        foreach (Controller_TargetLevel2 t in targets)
        {
            if (t.playerOnTarget)
            {
                i++;
                // Debug.Log(i.ToString());
            }
        }
        if (i >= targetsToWin)
        {
            winCondition = true;
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (actualPlayer <= 0)
            {
                actualPlayer = players.Count - 1;
                SetConstraints();
            }
            else
            {
                actualPlayer--;
                SetConstraints();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (actualPlayer >= players.Count - 1)
            {
                actualPlayer = 0;
                SetConstraints();
            }
            else
            {
                actualPlayer++;
                SetConstraints();
            }
        }
    }

    private void SetConstraints()
    {
        foreach (Controller_PlayerLevel2 p in players)
        {
            if (p == players[actualPlayer])
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}
