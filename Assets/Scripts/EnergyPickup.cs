using UnityEngine;
using System.Collections;

public class EnergyPickup : MonoBehaviour
{
  private PlayerInventory _playerInventory;

  void Awake()
  {
    _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player") {
      _playerInventory.collectedEnergy++;
      gameObject.SetActive(false);
    }
  }
}
