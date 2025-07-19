using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAgent : MonoBehaviour
{
    public float maxSpeed;
    public float maxForce;
    [HideInInspector]
    public Vector3 _velocity;
    public float viewDistance;
    public float separationDistance;

    public float arriveradius;

    
    public float CohesionWeight;
    public float SeparationWeight;
    public float aligmentWeight;
    public float arriveWeight;
    public float evadeWeight;

   





    // Start is called before the first frame update
    void Start()
    {
        Vector3 dir = new Vector3(Random.Range(-40f, 40f), 0, Random.Range(511f, 426f));
        dir = dir.normalized * maxSpeed;

        // Vector3 steering = dir - _velocity;
        AddForce(dir);
        FishPool.instance.AddFish(this);


    }

    // Update is called once per frame
    void Update()
    {
        Checkbound();
        AddForce(Separation() * SeparationWeight);
        AddForce(Aligment() * aligmentWeight);
        AddForce(Cohesion() * CohesionWeight);
        AddForce(arrive()* arriveWeight);
        AddForce(Evade() * evadeWeight);
       


        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }
    void AddForce(Vector3 force)
    {
        _velocity += Vector3.ClampMagnitude(force, maxSpeed);
    }
    Vector3 Evade()
    {
        Vector3 a = new Vector3();


        Vector3 dist = FishPool.instance.hunter.transform.position - transform.position;

        if (dist.magnitude < viewDistance)
        {
            
            a =FishPool.instance.hunter.transform.position-transform.position;
            
         

            a *= -1;
            a = a.normalized * maxSpeed;
            
            a.y = 0;
            



            Vector3 steering = Vector3.ClampMagnitude(a - _velocity, maxForce);
            
            return steering;

        }



        return a;

    }
    Vector3 arrive()
    {
        Vector3 desired = new Vector3();
        float speed = maxSpeed;
        float dist = Vector3.Distance(transform.position, FishPool.instance.food.transform.position);
        if (dist <= viewDistance)
        {

            desired = ( FishPool.instance.food.transform.position- transform.position);
            desired.y = 0;
            if(dist <= arriveradius)
             {
                // speed = Mathf.Lerp(0, maxSpeed, Vector3.Distance(transform.position, FishPool.instance.food.transform.position)/ arriveradius); 
                speed = maxSpeed * (dist / arriveradius);
                desired *= speed;

            }
          


            Vector3 steering = Vector3.ClampMagnitude(desired - _velocity, maxForce);
            return steering;

        }

     

        return desired;

    }


    Vector3 Separation()
    {
        Vector3 desired = new Vector3();

        int count = 0;

        foreach(var fishagent in FishPool.instance.allFish)
        {
            if (fishagent == this) continue;

            Vector3 dist = (fishagent.transform.position - transform.position);
            if(dist.magnitude< separationDistance)
            {
              
                desired.x += dist.x;
                desired.z += dist.z;
                count++;

            }
        }
        if (count <= 0) return desired;
     
        desired /= count;
   
        return (CalculatedSteering(-desired* SeparationWeight, count));

    }


    Vector3 Cohesion()
    {
        Vector3 desired = new Vector3();

        int count = 0;

        foreach (var fishagent in FishPool.instance.allFish)
        {
            if (fishagent == this) continue;

            if(Vector3.Distance(transform.position, fishagent.transform.position)<viewDistance)
            {
                desired.x += fishagent.transform.position.x;
                desired.z += fishagent.transform.position.z;
                count++;
            }

           
        }
        if (count <= 0) return desired;

        desired /= count;
        desired = desired - new Vector3(transform.position.x, desired.y, transform.position.z);

        return(CalculatedSteering(desired* CohesionWeight, count));

    }



    public  Vector3 CalculatedSteering(Vector3 desire, float count)
    {
      
        desire.Normalize();
        desire *= maxSpeed;
        Vector3 steering = Vector3.ClampMagnitude(desire - _velocity, maxForce / count);
        return steering;
    }




    Vector3 Aligment()
    {
        Vector3 desire = new Vector3();
        int count = 0;
        foreach (var Fishagent in FishPool.instance.allFish)
        {
            if (Fishagent == this) continue;

           if(Vector3.Distance(transform.position, Fishagent.transform.position)<viewDistance)
            {
                desire.x += Fishagent._velocity.x;
                desire.z += Fishagent._velocity.z;
                count++;
                
            }
        }
        if (count == 0) return desire;
        desire /= count;
        return(CalculatedSteering(desire* aligmentWeight, count));

    }

    void Checkbound()
    {
        Vector3 newposition = transform.position;
        if (transform.position.z < 426) newposition.z = 511;
        if (transform.position.z > 511) newposition.z = 426;
        if (transform.position.x > 40) newposition.x = -40;
        if (transform.position.x < -40) newposition.x = 40;

        transform.position = newposition;


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, separationDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, arriveradius);
    }

}
