using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    Animator anim;

    public HealthBar healthBar;

    public bool IsDead = false;

    

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        

    }

    public void SetHealth(int value)
    {
      currentHealth = Mathf.Clamp(value, 0, maxHealth);

      if (healthBar != null)
      {
          healthBar.SetHealth(currentHealth);
      }

      if(currentHealth <= 0 && !IsDead)
      {
          Die();
      }
        
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void Die()
    {
        if(IsDead) return;
        
        IsDead = true;
        Debug.Log("Player is Dead!");

        Animator anim = GetComponent<Animator>();
        if(anim != null)
        {
            anim.SetTrigger("IsDead");
        }

        Invoke(nameof(ReloadScene), 1f);
    }

    public void Heal(int amount)
    {
        if(IsDead) return;

        SetHealth(currentHealth + Mathf.Abs(amount));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        damage = Mathf.Abs(damage);

        if (currentHealth <= 0)
        {
            Die();
        }
        
        SetHealth(currentHealth - damage);
        Debug.Log("Player took" + damage + "damage. Health now: " + currentHealth);
        
    }

    private void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
