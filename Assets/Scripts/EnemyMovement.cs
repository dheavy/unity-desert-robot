using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
  Transform player;
  NavMeshAgent nav;

  public MotherShip motherShip;
  //private PlayerInventory inventory;

  void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    motherShip = GameObject.FindGameObjectWithTag("MotherShip").GetComponent<MotherShip>();
    nav = GetComponent<NavMeshAgent>();
    // inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
  }

  void Update()
  {
    if (motherShip.collectedEnergy != motherShip.neededEnergy) {
      nav.SetDestination(player.position);
    } else {
      nav.enabled = false;
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player") {
      // motherShip.totalEnergy -= inventory.collectedEnergy;
      // inventory.collectedEnergy = 0;
    }
  }
}
