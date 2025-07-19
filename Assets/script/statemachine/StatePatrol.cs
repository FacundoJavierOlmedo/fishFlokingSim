using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : IState
{
    // Start is called before the first frame update
    private int index;
    private Transform _transform;
    private float _speed;
    private StateMachine _fsm;
    
    private float _viewpoint;
    private float _maxforce = 0.75f;
    private bool cheker;
    private FishAgent fishtarget;

    private Vector3 _velocity;

    private HunterAgent hunter;

    List<Transform> _waypoints = null;

    public StatePatrol (HunterAgent a , StateMachine fsm)
    {
        hunter = a;
        
        _fsm = fsm;
    }
    public void OnEnter()
    {
        _viewpoint = hunter.viewDistance;
        _waypoints = hunter.waypoints;
        _transform = hunter.transform;
        _speed = hunter.speed;
        _transform.LookAt(_waypoints[index].position);


    }

    public void OnExit()
    {
        Debug.Log("salidepatrol");
    }

    public void OnUpdate()
    {

        Vector3 dir = _waypoints[index].position - _transform.position;
        cheker = false;

        foreach (var fishagent in FishPool.instance.allFish)
        {

            Vector3 dist = (fishagent.transform.position - _transform.position);
            if (dist.magnitude < _viewpoint)
            {
                
                fishtarget = fishagent;
                cheker = true;

            }
           
        }

        if(cheker)
        {

            _fsm.ChangeState(EnumStates.shoot);

        }
        else
        {
            _transform.LookAt(_waypoints[index].position);
            dir.y = 0;
            _transform.position += dir.normalized * _speed * Time.deltaTime;
        }

        if (dir.magnitude < 1.5)
        {

            index++;
            if (_waypoints.Count - 1 < index)
            {
                index = 0;
            }

            _transform.LookAt(_waypoints[index].position);
           // hunter.nextposition =hunter.transform.position+ _waypoints[index].position*Time.deltaTime*_speed;

        }
        if (hunter.energy < 0)
        {
            _fsm.ChangeState(EnumStates.rest);
        }
        hunter.energy -= Time.deltaTime;
        // Input.GetKeyDown(KeyCode.Escape)
    }


}
