using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject Target;
    public Vector3 TargetOffset;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position + TargetOffset, Speed * Time.deltaTime);
    }
}
