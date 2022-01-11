using UnityEngine;

public class FruitPiece : MonoBehaviour {
  public GameObject left;
  public GameObject right;
  private Rigidbody LeftRigidBody;
  private Rigidbody RightRigidBody;
  private readonly float _rotationSpeed = 15f;

  private void Start() {
    LeftRigidBody = left.GetComponentInChildren(typeof(Rigidbody)) as Rigidbody;
    RightRigidBody = right.GetComponentInChildren(typeof(Rigidbody)) as Rigidbody;

    LeftRigidBody.AddForce(transform.right * 2, ForceMode.Impulse);
    RightRigidBody.AddForce(transform.up * 2, ForceMode.Impulse);
  }

  private void Update() {
    left.transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    right.transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
  }

}
