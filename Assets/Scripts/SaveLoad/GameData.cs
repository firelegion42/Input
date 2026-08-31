using System;
using UnityEngine;


[Serializable]
public class GameData
{
    public int bulletCount;
    public float maxHealth;
    public float movementSpeed;
    public int jumpSpeed;
    public float bulletSpeed;
    public float currentHealth;

    public GameData()   {    }

    public GameData(PlayerSettings settings)
    {
        bulletCount = settings.bulletCount;
        maxHealth = settings.maxHealth;
        movementSpeed = settings.movementSpeed;
        jumpSpeed = settings.jumpSpeed;
        bulletSpeed = settings.bulletSpeed;

        currentHealth = settings.maxHealth;
    }

    

}