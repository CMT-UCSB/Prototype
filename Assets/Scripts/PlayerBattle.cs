﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    public Canvas battleCanvas;

    public GameManager gm;

    private Animator animator;

    private int speed;
    private int intimidation;
    private float attackDamage;
    private float defenseBuff;
    private float maxHealth;
    public float currHealth;

    private void Awake()
    {
        battleCanvas = GameObject.Find("BattleCanvas").GetComponent<Canvas>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        animator = GetComponent<Animator>();

        if(gm.GetExperience() < 2.0f)
        {
            speed = 4;
            intimidation = 2;
            attackDamage = 2.0f;
            defenseBuff = 80.0f;
            maxHealth = 10.0f;
            currHealth = maxHealth;
        }

        //later

    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;

        if (currHealth <= 0.0f)
        {
            animator.SetInteger("damageLevel", 3);
        }

        else if ((currHealth / maxHealth) <= (1.0f / 3.0f))
        {
            animator.SetInteger("damageLevel", 2);
        }

        else if ((currHealth / maxHealth) <= (2.0f / 3.0f))
        {
            animator.SetInteger("damageLevel", 1);
        }

        else
        {
            animator.SetInteger("damageLevel", 0);
        }
    }

    public int GetSpeed()
    {
        return speed;
    }

    public int GetIntimidation()
    {
        return intimidation;
    }

    public float GetDefense(bool strongAgainst)
    {
        if(strongAgainst)
        {
            return defenseBuff;
        }

        return 0.0f;
    }

    public bool AttemptAttack()
    {
        animator.SetBool("isAttacking", true);
        Invoke("StopAttacking", 2);
        return true;
    }

    public void StopAttacking()
    {
        animator.SetBool("isAttacking", false); 
    }

}
