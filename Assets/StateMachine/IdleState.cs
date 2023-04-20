using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    public void OnEnter(Character t)
    {
        t.OnIdleEnter();
    }

    public void OnExecute(Character t)
    {
        t.OnIdleExecute();
    }

    public void OnExit(Character t)
    {
        t.OnIdleExit();
    }

}
