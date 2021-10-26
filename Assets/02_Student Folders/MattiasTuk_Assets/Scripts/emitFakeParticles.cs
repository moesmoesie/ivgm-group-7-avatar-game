using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emitFakeParticles : MonoBehaviour
{
    public GameObject particle;
    private float timer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Instantiate(particle,transform.position,Quaternion.identity);
            timer = 0.1f;
        }
    }
}
