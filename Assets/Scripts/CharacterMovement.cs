using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public float speed = 6f;
	public float turnSpeed = 60f;
	public float turnSmoothing = 15f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody rb;

	void Awake()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
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
		rb.MovePosition(transform.position + movement);

		if (lh != 0f || lv != 0f) {
			Rotate(lh, lv);
		}
	}

	void Rotate(float lh, float lv)
	{
		Vector3 targetDirection = new Vector3(lh, 0f, lv);
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		rb.MoveRotation(newRotation);
	}

	void Animate(float lh, float lv)
	{
		bool isRunning = lh != 0f || lv != 0f;
		anim.SetBool("isRunning", isRunning);
	}
}
