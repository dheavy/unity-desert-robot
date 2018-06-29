using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MotherShip : MonoBehaviour
{
  public int collectedEnergy = 0;
  public int neededEnergy;
  public int totalEnergy;
  public float difficultyPercentage = 0.5f;
  public float restartDelay = 3f;
  public GameObject[] _energies;

  private PlayerInventory _playerInventory;
  private Animator _anim;
  private float _restartTimer;

  void Awake()
  {
    _energies = GameObject.FindGameObjectsWithTag("Energy");
    _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

    totalEnergy = _energies.Length;
    neededEnergy = Mathf.RoundToInt(totalEnergy * difficultyPercentage);
  }

  void Update()
  {
    // if (totalEnergy < neededEnergy || collectedEnergy == neededEnergy) {

    //   _restartTimer += Time.deltaTime;

    //   if (_restartTimer >= restartDelay) {
    //     Application.LoadLevel(Application.loadedLevel);
    //   }
    // }
  }

  void OnTriggerEnter(Collider other)
  {
    if (_playerInventory.collectedEnergy != 0) {
      collectedEnergy += _playerInventory.collectedEnergy;
      _playerInventory.collectedEnergy = 0;
    }

    if (collectedEnergy == neededEnergy) {
      print("You win!");
    }
  }
}
