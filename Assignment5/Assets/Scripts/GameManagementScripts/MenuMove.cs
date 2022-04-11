using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    void Update()
    {
        transform.position = new Vector3(transform.position.x + _speed, transform.position.y, transform.position.z);
    }
    // This could be in its own script
    // Here for time savings
    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null) {
            Destroy(player);
        }
    }
}
