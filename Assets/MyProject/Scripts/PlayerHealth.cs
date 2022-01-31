using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int initialHp = 3;

    int currentHp;

    public delegate void playerDeathDelegate();
    public event playerDeathDelegate OnPlayerDeath;

    public delegate void playerHpChangeDelegate(int newHp, int prevHp, int maxHp);
    public event playerHpChangeDelegate OnHpChanged;

    private void Awake()
    {
        currentHp = initialHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeHit(1);
        }
    }

    public void TakeHit(int damage)
    {
        int prevHp = currentHp;
        currentHp -= damage;

        OnHpChanged?.Invoke(currentHp, prevHp, initialHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO: update UI, etc.
        OnPlayerDeath?.Invoke();
    }
}
