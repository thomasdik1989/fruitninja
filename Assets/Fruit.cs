using UnityEngine;

public class Fruit : MonoBehaviour {

  public GameObject fruitSlicedPrefab;
  private GameObject fruitPieces;
  public GameObject ExplosionPrefab;
  public ScoreManager scoreManager;

  public float startForce = 12f;
  public int points = 10;

  private Rigidbody2D rb;

  public void Awake() {
    scoreManager = (ScoreManager)ScoreManager.Instance;
  }

  public void OnEnable() {
    rb = GetComponent<Rigidbody2D>();
    rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.tag != "Blade") {
      return;
    }
    Vector3 heading = (collision.transform.position - transform.position).normalized;
    Quaternion rotation = Quaternion.LookRotation(heading);

    scoreManager.AppendScore(points);
    gameObject.SetActive(false);
    GameObject vfx = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    vfx.GetComponent<ParticleSystem>().Play();
    fruitPieces = Instantiate(fruitSlicedPrefab, transform.position, rotation);
    fruitPieces.SetActive(true);
    Destroy(fruitPieces, 4f);
  }

}
