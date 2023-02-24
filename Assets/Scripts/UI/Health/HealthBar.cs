using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heart;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanget += OnHealthChendet;
    }

    private void OnDisable()
    {
        _player.HealthChanget -= OnHealthChendet;
    }

    private void OnHealthChendet(int value)
    {
        if(_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count;

            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if(value < _hearts.Count)
        {
            int deliteHealth = _hearts.Count - value;
            for (int i = 0; i < deliteHealth; i++)
            {
                DestroyHearth(_hearts[_hearts.Count-1]);
            }
        }
    }

    private void DestroyHearth(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heart, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}
