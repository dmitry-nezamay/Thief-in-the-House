using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Thief : MonoBehaviour
{
    private static float _speedInsideHouse = 1f;
    private static float _speedOutsideHouse = 4f;

    [SerializeField] private GameObject _path;

    private BoxCollider2D _boxCollider;
    private SpriteRenderer _spriteRenderer;
    private PointOfPath[] _points;
    private PointOfPath _nextPoint;

    public float Speed { get; private set; }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _points = _path.GetComponentsInChildren<PointOfPath>();

        if (_points.Length > 0)
            _nextPoint = _points[0];

        Speed = _speedOutsideHouse;
    }

    private void Update()
    {
        if (_nextPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _nextPoint.transform.position, Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PointOfPath>(out PointOfPath pointOfPath))
        {
            int pointIndex = Array.IndexOf(_points, _nextPoint);

            if (pointIndex != -1)
            {
                if (pointIndex == _points.Length - 1)
                    _nextPoint = _points[0];
                else
                    _nextPoint = _points[pointIndex + 1];
            }

            _spriteRenderer.flipX = (_nextPoint.transform.position.x < transform.position.x);
        }

        if (collision.TryGetComponent<House>(out House house))
        {
            Speed = _speedInsideHouse;
            house.OnThiefInsideHouse();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<House>(out House house))
        {
            Speed = _speedOutsideHouse;
            house.OnThiefOutsideHouse();
        }
    }
}
