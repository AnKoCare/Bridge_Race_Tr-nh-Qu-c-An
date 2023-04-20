using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : IState<Character>
{
    public void OnEnter(Character t)
    {
        t.OnClimbEnter();
    }

    public void OnExecute(Character t)
    {
        t.OnClimbExecute();
    }

    public void OnExit(Character t)
    {
        t.OnClimbExit();
    }
}
