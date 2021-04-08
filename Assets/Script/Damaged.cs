using UnityEngine;
using UnityEngine.AI;

public class Damaged : MonoBehaviour
{
    [Header("Monster Health")]
    public int maxHealth;
    public int currentHealth;
    public HPBar healthBar;
    [Header("Kill Gold")]
    public int goldOnDeath;
    Animator anim;
    GoldManager goldManager;
    NavMeshAgent agent;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        goldManager = GameObject.Find("Tower Cubes").GetComponent<GoldManager>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            MonsterDamaged(25);
        }
    }

    public void MonsterDamaged(int damage)
    {
        if (currentHealth < 25)
            MonsterDeath();

        if (currentHealth >= 25)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void MonsterDeath()
    {
        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject, .85f);
        agent.isStopped = true;
        anim.Play("Die");
        goldManager.Monsterdeathgold(goldOnDeath);

        if (Spawn.aliveMonsterCount > 0)
            Spawn.aliveMonsterCount--;
    }
}