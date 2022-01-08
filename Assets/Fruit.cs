using UnityEngine;

public class Fruit : MonoBehaviour {

  public GameObject fruitSlicedPrefab;
  public float startForce = 12f;

  private Rigidbody2D rb;

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
    rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.tag != "Blade") {
      return;
    }
    Vector3 heading = (collision.transform.position - transform.position).normalized;
    Quaternion rotation = Quaternion.LookRotation(heading);

    Destroy(gameObject);
    for (int pieces = 0; pieces < 2; pieces++) {
      GameObject piece = Instantiate(fruitSlicedPrefab, transform.position, rotation);
      piece.SetActive(true);
      Destroy(piece, 3f);
    }
  }

}
