using UnityEngine;

public class FruitPiece : MonoBehaviour {
  private Rigidbody fruitPiece;
  private float _rotationSpeed = 15f;

  private void Start() {
    fruitPiece = GetComponent<Rigidbody>();
    fruitPiece.AddForce(transform.up * 5, ForceMode.Impulse);
  }

  private void Update() {
    fruitPiece.transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
  }

}
