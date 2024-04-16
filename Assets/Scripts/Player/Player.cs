using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = default;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        this.UpdateAsObservable().Where(_ =>
                (Input.GetAxis("Horizontal") != 0) ||
                (Input.GetAxis("Vertical") != 0))
            .Subscribe(_ => Move());
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _rb.velocity = new Vector3(x, 0, z) * moveSpeed;
    }
}
