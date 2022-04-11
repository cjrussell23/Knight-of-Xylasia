using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _trackingTarget;
    [SerializeField] private float _leftWorldBoundary;
    private void Start() {
        if(_trackingTarget == null) {
            _trackingTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        transform.position = new Vector3(_trackingTarget.position.x, 0, transform.position.z);
        if( transform.position.x < _leftWorldBoundary){
            transform.position = new Vector3(_leftWorldBoundary, 0, transform.position.z);
        }
    }
}
