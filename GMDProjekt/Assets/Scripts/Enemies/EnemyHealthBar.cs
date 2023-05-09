using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private RectTransform _transform;
    private Transform _cameraTransform;

    private Quaternion _rotation;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _cameraTransform = Camera.main.GetComponent<Transform>();
    }

    void Update()
    {
        RotateBar();
    }

    void RotateBar()
    {
        _transform.LookAt(_transform.position + _cameraTransform.rotation * Vector3.back,
                        _cameraTransform.rotation * Vector3.down);
    }




}
