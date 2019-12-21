using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassExpand : MonoBehaviour
{
    float increment = 0;
    Vector3 scaleMin;
    Vector3 scaleMax;
    float t = 0;
    public float Duration;

    // Start is called before the first frame update
    void Start()
    {
        scaleMin = transform.localScale;
        scaleMax = new Vector3(1.77f, 1, 1.77f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager.Instance.IsPaused)
        {
            t += Time.deltaTime;
            increment =  Duration;
            transform.localScale = Vector3.Lerp(scaleMin, scaleMax, increment);

            
        }
    }
}
