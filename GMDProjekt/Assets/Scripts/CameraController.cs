using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - target.transform.position;
        transform.LookAt(target);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + _offset;
    }
}
