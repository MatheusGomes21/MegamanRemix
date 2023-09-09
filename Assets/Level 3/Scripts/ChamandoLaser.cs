using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamandoLaser : MonoBehaviour
{
    public GameObject laser;
    private float TempoLaser;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        TempoLaser = TempoLaser + Time.deltaTime;
        if (TempoLaser > 5)
        {
            Instantiate(laser, transform.position, Quaternion.identity);
            TempoLaser = 0;
        }
    }
}
