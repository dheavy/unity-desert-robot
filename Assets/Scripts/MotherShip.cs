using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MotherShip : MonoBehaviour
{
  public int collectedEnergy = 0;
  public int neededEnergy;
  public int totalEnergy;

  public GameObject[] _energies;

  private PlayerInventory _playerInventory;

  void Awake()
  {
    _energies = GameObject.FindGameObjectsWithTag("Energy");
    _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

    totalEnergy = _energies.Length;
    // neededEnergy = Mathf.RoundToInt(totalEnergy * difficultPercentage);
  }

  void OnTriggerEnter(Collider other)
  {
    // if (_playerInventory.collectedEnergy != 0) {
    //   collectedEnergy += _playerInventory.collectedEnergy;
    //   _playerInventory.collectedEnergy = 0;
    // }
  }
}
