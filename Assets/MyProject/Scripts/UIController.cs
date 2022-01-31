using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private void Start()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnHpChanged += PlayerHealth_OnHpChanged;
        }
    }

    private void PlayerHealth_OnHpChanged(int newHp, int prevHp, int maxHp)
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i + 1 < newHp);
        }
    }
}
