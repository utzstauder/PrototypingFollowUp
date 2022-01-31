using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnPlayerDeath += PlayerHealth_OnPlayerDeath;
            playerHealth.OnHpChanged += PlayerHealth_OnHpChanged;
        }
    }

    private void PlayerHealth_OnHpChanged(int newHp, int prevHp, int maxHp)
    {
        Debug.Log(newHp / (float)maxHp);
    }

    private void PlayerHealth_OnPlayerDeath()
    {
        Debug.Log("PLAYER DIED");
    }
}
