using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int maxHealth = 100;

	private int currentHealth;
	private bool isDead;
	private void Awake()
	{
		currentHealth = maxHealth;
	}
	public void TakeDamage(int damage)
	{
		if(damage <= 0||isDead)
		{
			return;
		}

		currentHealth = Mathf.Max(currentHealth-damage,0);
		Debug.Log($"{gameObject.name} took {damage} damage.Current health :{currentHealth}");

		if(currentHealth == 0)
		{
			isDead = true;
			Die();
		}
	}
	
	[ContextMenu("Test Damage")]
	private void TestDamage()
	{
		TakeDamage(10);
	}
	private void Die()
	{
		Debug.Log($"{gameObject.name} died.");
	}

}