using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
	[SerializeField] float m_speed = 3.0f;
	[SerializeField] int m_damage = 10;
	[SerializeField] float m_attackCooldown = 0.5f;

	private Rigidbody2D m_rb2d;
	private GameObject m_player;
	private float m_lastTimeAttack = 0.0f;

	// Start is called before the first frame update
	void Start()
	{
		m_rb2d = GetComponent<Rigidbody2D>();
		m_player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		Movements();
	}

	private void Movements()
	{
		m_rb2d.MovePosition(Vector2.MoveTowards(
			m_rb2d.position,
			m_player.transform.position,
			m_speed * Time.fixedDeltaTime
		));
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) {
			AttackToPlayer();
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) {
			AttackToPlayer();
		}
	}

	private void AttackToPlayer()
	{
		if (Time.time > m_lastTimeAttack + m_attackCooldown) {
			m_lastTimeAttack = Time.time;
			Health health = m_player.GetComponent<Health>();
			health.TakeDamage(m_damage);
		}

	}
}
