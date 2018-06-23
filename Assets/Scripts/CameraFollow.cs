using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  // Distance player can move before the camera follows.
  public float xMargin = 0.5f;
  public float zMargin = 0.5f;

  // Easing when camera catches up with its target.
  public float xEase = 4f;
  public float zEase = 4f;

  // Coordinates boundaries the camera can have — used to offset camera within parent rig.
  public Vector3 maxXAndZ;
  public Vector3 minXAndZ;

  private Transform player;

  void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  bool IsAboveXMargin()
  {
    return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
  }

  bool IsAboveZMargin()
  {
    return Mathf.Abs(transform.position.z - player.position.z) > zMargin;
  }

  void FixedUpdate()
  {
    TrackPlayer();
  }

  void TrackPlayer()
  {
    float targetX = transform.position.x;
    float targetZ = transform.position.z;

    if (IsAboveXMargin()) {
      targetX = Mathf.Lerp(transform.position.x, player.position.x, xEase * Time.deltaTime);
    }

    if (IsAboveZMargin()) {
      targetZ = Mathf.Lerp(transform.position.z, player.position.z, zEase * Time.deltaTime);
    }

    targetX = Mathf.Clamp(targetX, minXAndZ.x, maxXAndZ.x);
    targetZ = Mathf.Clamp(targetZ, minXAndZ.z, maxXAndZ.z);
    transform.position = new Vector3(targetX, transform.position.y, targetZ);
  }
}
