using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRest : IState
{
    private HunterAgent _hunter;
    private StateMachine _fsm;
    public StateRest(HunterAgent a, StateMachine fsm)
    {
        _hunter = a;
        _fsm = fsm;

    }
    public void OnEnter()
    {
        Debug.Log("entre al enter rest");
    }

    public void OnExit()
    {
        Debug.Log("entre al exit rest");
    }

    public void OnUpdate()
    {
        
        _hunter.energy += Time.deltaTime * _hunter.energyRecovery;
        if(_hunter.energy>_hunter.maxEnergy)
        {
            _fsm.ChangeState(EnumStates.patrol);
        }
      
       // _hunter.nextposition=_hunter.transform.position;
    }

    
}
