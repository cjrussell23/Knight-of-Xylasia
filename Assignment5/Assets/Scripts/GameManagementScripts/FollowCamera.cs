using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _trackingTarget;
    [SerializeField] private float _leftWorldBoundary;
    [SerializeField] private float _rightWorldBoundary;
    [SerializeField] private bool _rightBoundary = false;
    [SerializeField] private bool _leftBoundary = true;
    private void Start() {
        if(_trackingTarget == null) {
            _trackingTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(_trackingTarget.position.x, 0, transform.position.z);
        if( _leftBoundary && transform.position.x < _leftWorldBoundary){
            transform.position = new Vector3(_leftWorldBoundary, 0, transform.position.z);
        }
        else if( _rightBoundary && transform.position.x > _rightWorldBoundary){
            transform.position = new Vector3(_rightWorldBoundary, 0, transform.position.z);
        }
    }
}
