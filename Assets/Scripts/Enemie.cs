using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPoint = 0;
    private Transform _target;


    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        _target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            _render.flipX = !_render.flipX;
            _currentPoint++;

            if (_currentPoint == _points.Length)
                _currentPoint = 0;
        }
    }
}
