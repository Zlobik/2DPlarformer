using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private float _respawnTime;
    [SerializeField] private GameObject _coin;

    private Transform _fatherOfSpawns;
    private Transform[] _spawns;
    private float _countTime;
    private int _countCoins = 0;

    private void Start()
    {
        _fatherOfSpawns = transform;

        _spawns = new Transform[_fatherOfSpawns.childCount];

        for (int i = 0; i < _fatherOfSpawns.childCount; i++)
        {
            _spawns[i] = _fatherOfSpawns.GetChild(i);
        }
    }

    private void Update()
    {
        _countTime += Time.deltaTime;

        if (_countTime >= _respawnTime)
        {
            GameObject newCoin = Instantiate(_coin, _spawns[_countCoins].position, Quaternion.identity);
            newCoin.SetActive(true);

            _countCoins++;

            if (_countCoins == _spawns.Length)
                _countCoins = 0;

            _countTime = 0;
        }
    }
}
