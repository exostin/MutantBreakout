﻿using UnityEngine;
using UnityEngine.SceneManagement;

//author: B_Live

public class DamageHandler : MonoBehaviour
{
    public int GameOverScene;

    public StatsHandler statsHandler;
    public enum DamageType
    {
        deadly_surface
    }

    public void DealDamage(DamageType damageType, float damageAmount, GameObject damageReceiver)
    {
        Health Target = damageReceiver.GetComponent<Health>();

        float health_Target = Target.health;

        health_Target -= damageAmount;

        Target.health = health_Target;

        if (health_Target <= 0)
        {
            Die(damageReceiver);
            statsHandler.SetKillConter(damageReceiver);
        }
    }

    public void Die(GameObject deadlydamageReceiver)
    {
        if (deadlydamageReceiver.tag == "Player")
        {
            SceneManager.LoadScene(GameOverScene);
        }
        else
        {
            Destroy(this);
        }
    }
}