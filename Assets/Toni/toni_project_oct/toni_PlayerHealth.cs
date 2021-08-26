using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class toni_PlayerHealth : MonoBehaviour
{
    public float Health = 100;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (Health <= 0)
        {
            return;
        }

        Health -= damage;
        if (Health <= 0)
        {
            Death();
        }
    }
        private void Death()
        {
            _animator.SetTrigger("Death");
        }
 }