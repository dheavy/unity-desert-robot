using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]

public class UITextHero : MonoBehaviour
{
  public int playerEnergy;

  private Text _label;
  private PlayerInventory _playerInventory;

  void Awake()
  {
    _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    _label = GetComponent<Text>();
  }

  void Update()
  {
    playerEnergy = _playerInventory.collectedEnergy;
    _label.text = playerEnergy.ToString();
  }
}
