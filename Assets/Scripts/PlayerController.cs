using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float _speed;
    [SerializeField] 
    private bool _isMouseClick;
    [SerializeField] 
    private float _speedChangeValue = 0.1f;
    [SerializeField] 
    private int _attackIndex;

    private Animator _animator;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsMouseClick = Animator.StringToHash("IsMouseClick");
    private static readonly int AttackIndex = Animator.StringToHash("AttackIndex");


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _speed += _speedChangeValue;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _speed -= _speedChangeValue;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _isMouseClick = true;
            _animator.SetBool(IsMouseClick, _isMouseClick);
            _attackIndex = Random.Range(1, 3);
            _animator.SetInteger(AttackIndex, _attackIndex);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isMouseClick = false;
            _animator.SetBool(IsMouseClick, _isMouseClick);
        }

        _animator.SetFloat(Speed, _speed);
    }
}