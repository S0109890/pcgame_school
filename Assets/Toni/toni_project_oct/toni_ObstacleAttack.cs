using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toni_ObstacleAttack : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;
    private bool _collidedWithPlayer;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("IsNearPlayer", true);
            print("enter trigger with _player");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == _player)
        {
            _collidedWithPlayer = true;
        }
        print("enter collided with _player");
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == _player)
        {
            _collidedWithPlayer = false;
        }
        print("exit collided with _player");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("IsNearPlayer", false);
        }
        print("exit trigger with _player");
    }

    private void Attack()
    {
        if (_collidedWithPlayer)
        {
            _player.GetComponent<toni_PlayerHealth>().TakeDamage(10);
        }
    }
}