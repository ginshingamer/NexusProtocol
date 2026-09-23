using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] private Transform attackPoint;
	[SerializeField] private float attackRange = 1.5f;
	[SerializeField] private int attackDamage = 25;

	[SerializeField] private Transform weaponPivot;
	[SerializeField] private float swingDuration =0.2f;
	[SerializeField] private float swingAngle =120f;
	
	private bool isAttacking;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && !isAttacking)
		{
			StartCoroutine(Swing());
		}
	}
	private IEnumerator Swing()
	{
		isAttacking = true;

		float elapsedTime = 0f;
		bool hasDealtDamage = false;

		while (elapsedTime < swingDuration)
		{
        elapsedTime += Time.deltaTime;

        float progress = elapsedTime / swingDuration;
        float currentAngle = Mathf.Lerp(
            -swingAngle / 2f,
            swingAngle / 2f,
            progress
        );

        weaponPivot.localRotation = Quaternion.Euler(0f, currentAngle, 0f);

        if (!hasDealtDamage && progress >= 0.5f)
        {
            Attack();
            hasDealtDamage = true;
        }

        yield return null;
	   }
	   weaponPivot.localRotation = Quaternion.identity;
	   isAttacking = false;
	}
	private void Attack()
	{
		Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position,attackRange);
		
		foreach(Collider hitCollider in hitColliders)
		{
			Health targetHealth = hitCollider.GetComponentInParent<Health>();

			if(targetHealth == null || targetHealth.gameObject == gameObject)
			{
				continue;
			}

			targetHealth.TakeDamage(attackDamage);
		}
	}

	private void OnDrawGizmosSelected()
	{
		if(attackPoint == null)
		{
			return;
		}

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPoint.position,attackRange);
	}
}