using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	[SerializeField] int m_maxHealth = 100;
	[SerializeField] TextMeshProUGUI m_healthUI;
	[SerializeField] TextMeshProUGUI m_maxHealthUI;
	[SerializeField] GameObject m_restartMenu;


	// Current Health
	private int m_curHealth = 100;
	private SpriteRenderer m_sr;

	void Awake()
	{
		m_curHealth = m_maxHealth;

		UpdateHealthUI();
		m_maxHealthUI.text = "/" + m_maxHealth.ToString();
	}

	void Start()
	{
		m_sr = GetComponent<SpriteRenderer>();
	}

	public void TakeDamage(int damage)
	{
		m_curHealth -= damage;
		if (m_curHealth <= 0) {
			Dead();
		}

		StartCoroutine(ShowHurtEffect());
		UpdateHealthUI();
	}

	private IEnumerator ShowHurtEffect()
	{
		m_sr.color = Color.red;
		yield return new WaitForSeconds(0.3f);
		m_sr.color = Color.white;
	}

	private void UpdateHealthUI()
	{
		m_healthUI.text = m_curHealth.ToString();
	}

	public void Recovery(int point)
	{
		m_curHealth += point;
		if (m_curHealth > m_maxHealth) {
			m_curHealth = m_maxHealth;
		}

		UpdateHealthUI();
	}

	public void Dead()
	{
		Time.timeScale = 0;
		m_restartMenu.SetActive(true);
	}
}
