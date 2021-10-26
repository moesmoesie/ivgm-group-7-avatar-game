using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    private GameObject[] fountains;
    public WeaponController weaponControl;
    private float playerAmmo;
    private GameObject water;
    public GameObject waterWand;
    private float timer = 1;
    private bool countdownStarted = false;
    public AudioSource fill;
    public float pitch=0.8f;
    public GameObject startFountain;
    // Start is called before the first frame update
    void Start()
    {
        fountains = GameObject.FindGameObjectsWithTag("Water");
        foreach (GameObject fountain in fountains)
            fountain.SetActive(false);
        startFountain.SetActive(true);
    }

    bool countdown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1;
            return true;
        }
        else
            return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(waterWand!=null)
        {
            
            playerAmmo = weaponControl.currentAmmoRatio * weaponControl.maxAmmo;
            if (GameObject.FindGameObjectsWithTag("Water").Length == 0 && playerAmmo == 0 && !weaponControl.isCharging)
            {
                fountains[Random.Range(0, fountains.Length)].SetActive(true);
            }
            water = GameObject.FindGameObjectWithTag("Water");
            if (water != null)
            {
                if (Vector3.Distance(waterWand.transform.position, water.transform.position) < 5)
                {
                    countdownStarted = true;
                    water.GetComponent<fountain>().defaultParticles.SetActive(false);
                    water.GetComponent<fountain>().particleEmitters.SetActive(true);
                }
            }
            if(countdownStarted)
            {
                fill.pitch = pitch;
                if (!fill.isPlaying)
                    fill.Play(0);
                pitch += 0.4f * Time.deltaTime;
                water.transform.position -= new Vector3(0,0.4f,0) * Time.deltaTime;
                if (countdown())
                {
                    water.transform.position = water.transform.parent.gameObject.transform.position;
                    water.GetComponent<fountain>().defaultParticles.SetActive(true);
                    water.GetComponent<fountain>().particleEmitters.SetActive(false);
                    weaponControl.UseAmmo(-1);
                    water.SetActive(false);
                    countdownStarted = false;
                    pitch = 0.8f;
                }
            }
        }
    }
}
