using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] float m_speed = 3.0f;

	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	private Vector2 m_input;
	private Animator m_anim;

	// Start is called before the first frame update
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		m_anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Movements();
	}

	private void Movements()
	{
		m_input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		if (m_input.magnitude > 0) {
			rb2d.MovePosition(
				rb2d.position + (m_speed * Time.fixedDeltaTime * m_input)
			);

			FlipSprite();
		}

		PlayRunAnimation();

	}

	private void PlayRunAnimation()
	{
		m_anim.SetBool("IsRun", m_input.magnitude > 0);
	}

	private void FlipSprite()
	{
		sr.flipX = m_input.x < 0;

		//if (m_input.x < 0)
		//{
		//	sr.flipX = true;
		//} else
		//{
		//	sr.flipX = false;
		//}
	}
}
