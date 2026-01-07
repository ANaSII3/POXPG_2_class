using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    public float chaseDistance = 4f;
    public float attackDistance = 1f;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    public float waitTime = 2f;

    private int currentPoint = 0;
    private int direction = 1; 
    private float waitTimer = 0f;

    [Header("References")]
    public Transform player;
    public Animator anim;

    [Header("Attack")]
    public int damage = 10;
    public float attackCooldown = 1.5f;
    public float lastAttackTime;

    void Start()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null)
        {
            Patrol();
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackDistance)
        {
            Attack();
        }
        else if (distance <= chaseDistance)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    

    void Idle()
    {
        anim.SetBool("IsMoving", false);
    }

    void Patrol()
    {
        if (patrolPoints == null || patrolPoints.Length < 2)
        {
            Idle();
            return;
        }

        Transform target = patrolPoints[currentPoint];
        float distance = Vector2.Distance(transform.position, target.position);

        
        if (distance <= 0.2f)
        {
            Idle();
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                waitTimer = 0f;
                currentPoint += direction;

                // Разворот в конце маршрута
                if (currentPoint >= patrolPoints.Length)
                {
                    direction = -1;
                    currentPoint = patrolPoints.Length - 2;
                }
                else if (currentPoint < 0)
                {
                    direction = 1;
                    currentPoint = 1;
                }
            }

            return;
        }

        
        anim.SetBool("IsMoving", true);

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        Flip(target.position.x - transform.position.x);
    }

    void Chase()
    {
        anim.SetBool("IsMoving", true);

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        Flip(player.position.x - transform.position.x);
    }

    void Attack()
    {
        anim.SetBool("IsMoving", false);

        if (Time.time < lastAttackTime + attackCooldown)
            return;

        anim.SetTrigger("Attack");

        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.TakeDamage(damage);
        }

        lastAttackTime = Time.time;
    }

    
    void Flip(float directionX)
    {
        if (Mathf.Abs(directionX) < 0.01f) return;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(directionX) * Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}