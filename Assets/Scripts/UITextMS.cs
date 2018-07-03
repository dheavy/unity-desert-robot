using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]

public class UITextMS : MonoBehaviour
{
  [SerializeField]
  private MotherShip _motherShip;
  private Text _label;

  void Awake()
  {
    _label = GetComponent<Text>();
  }

  void Update()
  {
    _label.text = _motherShip.collectedEnergy + " / " + _motherShip.neededEnergy;
  }
}
