using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent (typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private List<KeyDependencies> keyDependencies;

     private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (!Input.anyKeyDown)
            return;
        
        foreach (var key in keyDependencies)
        {
            if (!Input.GetKeyDown(key.keyCode))
                continue;
            
            _animator.SetTrigger(key.keyTrigger);
            break;
        }
    }
}

[Serializable]
public struct KeyDependencies
{
    public KeyCode keyCode;
    public string keyTrigger;
}
