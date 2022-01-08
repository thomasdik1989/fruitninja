using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

  public GameObject BladeTrailPrefab;

  private bool IsCutting = false;
  private Rigidbody2D blade;
  private Camera MainCamera;
  private GameObject CurrentBladeTrail;
  private CircleCollider2D circleCollider2D;
  private Vector2 previousPosition;
  public float minCuttingVelocity = 0.001f;

  void Start() {
    MainCamera = Camera.main;
    blade = GetComponent<Rigidbody2D>();
    circleCollider2D = GetComponent<CircleCollider2D>();
  }

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      StartCutting();
    }
    else if (Input.GetMouseButtonUp(0)) {
      StopCutting();
    }

    if (IsCutting) {
      UpdateCut();
    }
  }

  void UpdateCut() {
    Vector2 newPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
    blade.position = newPosition;
    float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

    circleCollider2D.enabled = velocity > minCuttingVelocity;
    previousPosition = newPosition;
  }

  void StartCutting() {
    IsCutting = true;
    CurrentBladeTrail = Instantiate(BladeTrailPrefab, transform);
    circleCollider2D.enabled = false;
    previousPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
  }

  void StopCutting() {
    IsCutting = false;
    CurrentBladeTrail.transform.SetParent(null);
    Destroy(CurrentBladeTrail, 2f);
    circleCollider2D.enabled = false;
  }

}
