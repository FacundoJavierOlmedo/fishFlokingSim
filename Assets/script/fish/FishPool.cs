using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPool : MonoBehaviour
{

    public static FishPool instance;
    public List<FishAgent> allFish = new List<FishAgent>();
    public HunterAgent hunter;
    public MoveFood food;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddFish (FishAgent b)
    {
      
        if(!allFish.Contains(b)) allFish.Add(b);
    }
}
