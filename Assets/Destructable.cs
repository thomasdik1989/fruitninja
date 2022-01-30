using UnityEngine;

public class Destructable : MonoBehaviour {
  public float startForce = 12f;
  public int points = 10;

  protected Rigidbody2D rb;
  protected ScoreManager scoreManager;

  protected void Awake() {
    scoreManager = (ScoreManager)ScoreManager.Instance;
  }

  protected void OnEnable() {
    rb = GetComponent<Rigidbody2D>();
    rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
  }

}
