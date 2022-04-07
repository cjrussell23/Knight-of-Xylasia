using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float length;
    private float startpos;
    private float offset = 10;
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _parallaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (_camera.transform.position.x + offset) * (1- _parallaxEffect);
        float distance = _camera.transform.position.x * _parallaxEffect;
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
