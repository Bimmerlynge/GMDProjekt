using System;
using UnityEngine;


public class ObjectToScreenOrientation : MonoBehaviour
{
    private Transform _transform;
    private Transform _cameraTransform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        _transform.LookAt(_transform.position + _cameraTransform.rotation * Vector3.back,
            _cameraTransform.rotation * Vector3.down);
    }
}
