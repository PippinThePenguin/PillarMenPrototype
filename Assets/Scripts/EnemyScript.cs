using System;
using UnityEngine;
using UnityEngine.UI;

namespace PillarmanNamespace {
  public class EnemyScript : MonoBehaviour {
    public static event Action EnemyDied;
    public bool Alive = true;
    public float Health {
      get { return _health; }
      set {
        _health = value;
        if (_health <= 0) {
          _health = 0;
          _healthBar.value = _health;
          Die();
        } else if (_health >= _maxHealth) {
          _health = _maxHealth;
        } else if (Alive && !_healthBarActive) {
          _healthBar.gameObject.SetActive(true);
          _updateDelegat = RotateBar;
          _healthBarActive = true;
        }
        _healthBar.value = _health;
      }
    }
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _ragdollForce;
    [SerializeField] private bool _healthBarActive = false;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private SceneScript _scene;
    [SerializeField] private GameObject _ragdoll;
    [SerializeField] private GameObject _normal;
    [SerializeField] private Rigidbody _body;
    private float _health;
    private delegate void UpdateDelegat();
    private UpdateDelegat _updateDelegat;

    private void Awake() {
      EnemyDied = null;
      _updateDelegat = null;
    }
    private void Start() {
      Health = _maxHealth;
      Alive = true;
      transform.LookAt(_scene.WayPoint);

      _healthBar.maxValue = _maxHealth;
      _healthBar.minValue = 0f;
      _healthBar.value = _health;
      _healthBar.gameObject.SetActive(false);
    }
    private void Update() {
      if (_updateDelegat != null) {
        _updateDelegat();
      }
        
    }
    private void Die() {
      if (Alive) {
        Alive = false;
        _scene.GotOne(gameObject);
        if (_ragdoll != null) {
          _healthBar.gameObject.SetActive(false);
          _healthBarActive = false;
          _ragdoll.SetActive(true);
          _body.AddForce((UnityEngine.Random.value - 0.5f) * _ragdollForce, (UnityEngine.Random.value) * _ragdollForce, (UnityEngine.Random.value - 0.5f) * _ragdollForce);
          _normal.SetActive(false);
          transform.GetComponent<CapsuleCollider>().enabled = false;
        }
        EnemyDied?.Invoke();
      }
    }
    private void RotateBar() {
      _healthBar.transform.LookAt(Camera.main.transform);
    }
  }
}
  
