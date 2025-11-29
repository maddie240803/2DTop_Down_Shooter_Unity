using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarness : MonoBehaviour
{
   
    public bool AwareOfplayer {  get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarness;

    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        Vector2 enemytoPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemytoPlayerVector.normalized;

        if (enemytoPlayerVector.magnitude <= _playerAwarness)
        {
            AwareOfplayer = true;
        }
        else
        {
            AwareOfplayer = false;
        }
    }
}
