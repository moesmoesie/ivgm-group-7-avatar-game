using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillStaffParticles : MonoBehaviour
{
    private GameObject wandMuzzle;
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        wandMuzzle = GameObject.FindGameObjectWithTag("wandMuzzle");
        transform.rotation = Quaternion.LookRotation((cam.transform.position- transform.position).normalized);
        transform.position = Vector3.MoveTowards(transform.position, wandMuzzle.transform.position, 50f * Time.deltaTime);
        if (Vector3.Distance(transform.position, wandMuzzle.transform.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
