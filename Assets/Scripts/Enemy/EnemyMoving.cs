using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Transform _enemyTransform;
    private Transform _targetTransform;
    private bool _inTargetPlace = false;

    private Animator _animator;

    public void SetTargetPosition(Transform targetTransform) => _targetTransform = targetTransform;
    
    private void Start()
    {
        _enemyTransform = GetComponent<Transform>();
        _animator = GetComponentInChildren<Animator>();

        _animator.enabled = false;
    }
    
    private void Update()
    {
        MoveToTargetProcess();
    }

    private void MoveToTargetProcess()
    {
        if (_inTargetPlace) { _inTargetPlace = false; }
        
        MoveToTarget();
        
        if (_enemyTransform.position == _targetTransform.position)
        {
            _inTargetPlace = true;
            _animator.enabled = true;
        }
    }
    
    private void MoveToTarget()
    {
        float speed = _speed * Time.deltaTime;
        
        _enemyTransform.position = Vector3.MoveTowards(
            _enemyTransform.position, _targetTransform.position, speed);
    }
}
