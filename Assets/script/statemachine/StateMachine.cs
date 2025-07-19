using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    

    private IState _currentState;

    public Dictionary<EnumStates, IState> Allstates =new Dictionary<EnumStates, IState>();
    public void Update()
    {
        

        if (_currentState != null) _currentState.OnUpdate();

    
    }
    
    public void ChangeState(EnumStates newState)
    {
    
        if(!Allstates.ContainsKey(newState))
        {
            return;
        }
        _currentState?.OnExit();
        _currentState = Allstates[newState];
        _currentState.OnEnter();
       
    }



    public void AddState(EnumStates  a, IState state)
    {
        if (!Allstates.ContainsKey(a)) Allstates.Add(a, state);
    }
}
public enum EnumStates
{
    patrol,
    rest,
    shoot
}
