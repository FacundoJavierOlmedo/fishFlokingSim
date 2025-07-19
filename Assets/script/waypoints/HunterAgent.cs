using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAgent : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.Subscribe(EnumNotify.Notifications.enemyfound, Enemyfound);
    }
    private void OnDisable()
    {
        EventManager.Unsuscribe(EnumNotify.Notifications.enemyfound, Enemyfound);
    }
    // Start is called before the first frame update
    public List<Transform> waypoints = new List<Transform>();
    public float speed;
    public Vector3 _velocity;

    private StateMachine _fsm = new StateMachine();

   

    public float maxEnergy;

    public float energyRecovery;

    public float viewDistance;


    public Vector3 nextpositiontest;



    [HideInInspector]
    public GameObject bird;
    
    [HideInInspector]
    public float energy;

    
    private void Start()
    {
        EventManager.TriggerEvents(EnumNotify.Notifications.playerFind, this.gameObject);

        energy = maxEnergy;

        StateShoot shoot = new StateShoot(this, _fsm);
        StateRest rest = new StateRest(this, _fsm);
        StatePatrol patrol = new StatePatrol(this, _fsm);

        _fsm.AddState(EnumStates.patrol, patrol);
        _fsm.AddState(EnumStates.rest, rest);
        _fsm.AddState(EnumStates.shoot, shoot);


        _fsm.ChangeState(EnumStates.patrol);

       

       
    }
    private void Update()
    {

        
        
        transform.forward = transform.position*Time.deltaTime;
        _fsm.Update();
    }

    public void Enemyfound (params object[] p)
    {
        bird = (GameObject)p[0];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        
    }

}
