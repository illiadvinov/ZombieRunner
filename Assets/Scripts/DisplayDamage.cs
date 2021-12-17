using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damage;
    [SerializeField] float timeImpact = .3f;
    PlayerHealth playerHealth;
    void Start()
    {
        damage.enabled = false;
    }

    public void ShowDamage()
    {
        StartCoroutine(ShowBlood());
    }

    IEnumerator ShowBlood()
    {
        damage.enabled = true;
        yield return new WaitForSeconds(timeImpact);
        damage.enabled = false;
    }
}
