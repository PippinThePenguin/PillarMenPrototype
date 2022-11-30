using System;
using UnityEngine;

namespace PillarmanNamespace {
  public class InputEvents : MonoBehaviour {
    public static event Action<Touch> OnClickEvent;
    private delegate void UpdateDelegate();
    private UpdateDelegate _updateDelegate;
    private bool _newTap = true;

    private void Awake() {
      OnClickEvent = null;
      _updateDelegate = StartGame;
    }
    private void StartGame() {
      if (Input.touchCount > 0) {
        GetComponent<waypointMovement>().CheckForMove();
        _newTap = false;
        _updateDelegate = HandleTap;
      }
    }
    void Update() {
      _updateDelegate();
    }
    private void HandleTap() {
      if ((Input.touchCount > 0) && _newTap) {
        _newTap = false;
        OnClickEvent?.Invoke(Input.GetTouch(0));
      } else if (Input.touchCount == 0) {
        _newTap = true;
      }
    }
  }

}
