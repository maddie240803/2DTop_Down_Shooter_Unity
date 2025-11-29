using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationspeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarness _PlayerAwarness;
    private Vector2 _targetDirection;
    private float  _changeDirectionCooldown;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _PlayerAwarness = GetComponent<PlayerAwarness>();
        _targetDirection = transform.up;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectonChange();
        HanldePlayerTargeting();
    }
    private void HandleRandomDirectonChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;
        if(_changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }
    private void HanldePlayerTargeting()
    {
        if (_PlayerAwarness.AwareOfplayer)
        {
            _targetDirection = _PlayerAwarness.DirectionToPlayer;
        }

    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationspeed * Time.deltaTime);
        _rigidbody.SetRotation(rotation.eulerAngles.z);
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = transform.up * _speed;
    }
}