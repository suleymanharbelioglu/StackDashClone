using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _target;
    public Vector3 _offset;
    public float _lerp;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position  - _target.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 _desPos = Vector3.Lerp(transform.position, _target.position + _offset, _lerp*Time.fixedDeltaTime);
        transform.position = _desPos;
        
    }
}
