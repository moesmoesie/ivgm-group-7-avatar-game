//Credit to Blackthornprod for this code https://www.youtube.com/watch?v=8eWbSN2T8TE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol2 : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    Rigidbody m_Rigidbody;
    public float m_Thrust = 0.5f;

    public Transform[] moveSpots;
    private int nextSpot;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        nextSpot = 0;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);
        //m_Rigidbody.AddForce(moveSpots[nextSpot].position * m_Thrust, ForceMode.VelocityChange);
        m_Rigidbody.velocity = (moveSpots[nextSpot].position - transform.position);
        m_Rigidbody.velocity.Normalize();
        //m_Rigidbody.rotation = Quaternion.Euler(m_Rigidbody.velocity);
        transform.rotation = Quaternion.Euler(m_Rigidbody.velocity);

        if (Vector3.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                nextSpot++;
                if (nextSpot >= moveSpots.Length)
                    nextSpot = 0;
                waitTime = startWaitTime;
                //m_Rigidbody.velocity = new Vector3(0, 0, 0);
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
