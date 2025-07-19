using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateShoot : IState
{
    private HunterAgent hunter;
    private StateMachine _fsm;
    private Transform _transform;
    private float _speed;

    
    private float _viewpoint;
    private float _maxforce = 0.75f;
    private bool cheker;
    private FishAgent fishtarget;

    private Vector3 _velocity;
    List<Transform> _waypoints = null;
    private int index;
    public StateShoot(HunterAgent a, StateMachine fsm)
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
        
    }

    public void OnUpdate()
    {
        foreach (var fishagent in FishPool.instance.allFish)
        {

            Vector3 dist = (fishagent.transform.position - _transform.position);
            if (dist.magnitude < _viewpoint)
            {

                fishtarget = fishagent;
                cheker = true;

            }

        }
        if (cheker)
        {
            AddForce(pursuit(fishtarget));


        }
        else
        {
            _fsm.ChangeState(EnumStates.patrol);
        }
        if (hunter.energy < 0)
        {
            _fsm.ChangeState(EnumStates.rest);
        }
        hunter.energy -= Time.deltaTime;
        cheker = false;
    }
    Vector3 pursuit(FishAgent a)
    {





        Vector3 dist = fishtarget.transform.position - hunter.transform.position;
        Vector3 desire = fishtarget.transform.position + fishtarget._velocity * Time.deltaTime * dist.magnitude - _transform.transform.position;
        
        desire = desire.normalized * _speed;

        Vector3 steering = desire - _velocity;

        
        steering = Vector3.ClampMagnitude(steering, _maxforce/3);
        steering.y = 0;
       // hunter.nextposition = hunter.transform.position+steering*_speed;
       
        return steering;






    }
    void AddForce(Vector3 force)
    {
        _velocity += Vector3.ClampMagnitude(force, _speed);
     

        _transform.position += _velocity * Time.deltaTime;
        _transform.forward = _velocity;
    }
}
