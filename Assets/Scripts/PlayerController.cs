using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SurfaceEffector2D _surfaceEffector;

    private readonly float _maxAngularVelocity = 500f;
    private readonly float _boostedSpeed = 20f;
    private readonly float _normalSpeed = 10f;

    private readonly float _torque = 2f;

    private bool _canMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (_canMove)
        {
            RotatePlayer();
            BoostPlayer();
        }
    }

    private void BoostPlayer()
    {
        if (rb2d.velocity.magnitude < _boostedSpeed && Input.GetKey(KeyCode.UpArrow))
        {
            _surfaceEffector.speed = _boostedSpeed;
        }
        else
        {
            _surfaceEffector.speed = _normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (rb2d.angularVelocity < _maxAngularVelocity && Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(_torque);
        }
        else if (rb2d.angularVelocity > -_maxAngularVelocity && Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-_torque);
        }
    }

    public void CantMove()
    {
        _canMove = false;
    }
}
