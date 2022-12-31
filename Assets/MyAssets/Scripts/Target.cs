using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 2f;
    private Animator animator;
    private ParticleSystem blood;
    private Collider collider;
    private UnityEngine.AI.NavMeshAgent agent;
    public bool die;
    public ZombieAudio zombieAudio;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        blood = GetComponentInChildren<ParticleSystem>();
        collider = GetComponent<Collider>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    public void DamageReceived(float damageAmount)
    {
        health -= damageAmount;
        blood.Play();
        if (health <= 0f)
        {
            zombieAudio.IsDie();
            agent.speed = 0;
            blood.Stop();
            collider.enabled=false;
            GenerateEnemies.generateEnemies.enemyCount--;
            animator.SetBool("Die", true);
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
