using Snowdrama.Spring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialSpringTest : MonoBehaviour
{
    public SpringConfiguration config;
    public SpringRadial radialSpring;
    public bool run;
    public float targetToSet;
    [Header("Debug:")]
    public float debugOut;
    // Start is called before the first frame update
    void Start()
    {
        radialSpring = new SpringRadial(config);
    }

    // Update is called once per frame
    void Update()
    {
        radialSpring.Update(Time.deltaTime);
        if (run)
        {
            run = false;
            radialSpring.SetTarget(targetToSet);
        }
        debugOut = radialSpring.GetValue();

        this.transform.rotation = Quaternion.AngleAxis(debugOut, Vector3.forward);
    }
}
