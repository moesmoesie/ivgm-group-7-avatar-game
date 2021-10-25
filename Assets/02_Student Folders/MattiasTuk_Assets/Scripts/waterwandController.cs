using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterwandController : MonoBehaviour
{
    private GameObject control;
    private controller controller;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<WeaponController>().UseAmmo(1);
        control = GameObject.Find("control");
        controller = control.GetComponent<controller>();
        controller.waterWand = gameObject;
        controller.weaponControl = GetComponent<WeaponController>();
    }
}
