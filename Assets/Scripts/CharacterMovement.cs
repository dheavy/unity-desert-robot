using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
	public float speed = 6f;
	public float turnSpeed = 60f;
	public float turnSmoothing = 15f;

	private Vector3 movement;
	private Animator _anim;
	private Rigidbody _rb;

	void Awake()
	{
		_anim = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float lh = Input.GetAxisRaw("Horizontal");
		float lv = Input.GetAxisRaw("Vertical");

		Move(lh, lv);
		Animate(lh, lv);
	}

	void Move(float lh, float lv)
	{
		movement.Set(lh, 0f, lv);
		movement = movement.normalized * speed * Time.deltaTime;
		_rb.MovePosition(transform.position + movement);

		if (lh != 0f || lv != 0f) {
			Rotate(lh, lv);
		}
	}

	void Rotate(float lh, float lv)
	{
		Vector3 targetDirection = new Vector3(lh, 0f, lv);
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(_rb.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		_rb.MoveRotation(newRotation);
	}

	void Animate(float lh, float lv)
	{
		bool isRunning = lh != 0f || lv != 0f;
		_anim.SetBool("isRunning", isRunning);
	}
}
