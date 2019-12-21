using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject raptor;
    public int range = 3;
    public float delay = 15; //interval de spawn
    public float t { get; set; } = 0;

    void Update()
    {
        if (!Manager.Instance.IsPaused)
        {
            t += Time.deltaTime;
            if (delay < t)
            {
                t = 0;
                Instantiate(raptor, new Vector3(transform.position.x + Random.Range(-range, range + 1), transform.position.y, transform.position.z + Random.Range(-range, range + 1)), Quaternion.identity, null);
            }
        }
    }
}
