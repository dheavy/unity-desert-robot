using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
  Transform player;
  NavMeshAgent nav;

  private MotherShip _motherShip;
  private PlayerInventory _playerInventory;

  void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    nav = GetComponent<NavMeshAgent>();

    _motherShip = GameObject.FindGameObjectWithTag("MotherShip").GetComponent<MotherShip>();
    _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
  }

  void Update()
  {
    if (_motherShip.collectedEnergy != _motherShip.neededEnergy) {
      print("xx");
      nav.SetDestination(player.position);
    } else {
      nav.enabled = false;
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player") {
      _motherShip.totalEnergy -= _playerInventory.collectedEnergy;
      _playerInventory.collectedEnergy = 0;
    }
  }
}
