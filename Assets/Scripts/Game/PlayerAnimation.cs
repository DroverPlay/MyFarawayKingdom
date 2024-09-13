using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    public bool isRun { private get; set; }
    public bool isJump { private get; set; }

    public bool isFly { private get; set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.SetBool("isRun", isRun);
        _animator.SetBool("isJump", isJump);
        _animator.SetBool("isFly", isFly);

    }

}
