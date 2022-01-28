using UnityEngine;
using UnityEngine.VFX;

public class Bomb : Destructable {

  public GameObject smokePrefab;
  public GameObject distortionPrefab;
  public GameObject sparksPrefab;
  public GameObject embersPrefab;
  public GameObject hemiSphereBurstPrefab;

  private readonly float _rotationSpeed = 100f;

  private void Update() {
    transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.tag != "Blade") {
      return;
    }

    scoreManager.SubtractScore(points);

    gameObject.SetActive(false);
    GameObject smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity);
    smoke.GetComponent<VisualEffect>().Play();

    GameObject distortion = Instantiate(distortionPrefab, transform.position, Quaternion.identity);
    distortion.GetComponent<VisualEffect>().Play();

    GameObject sparks = Instantiate(sparksPrefab, transform.position, Quaternion.identity);
    sparks.GetComponent<ParticleSystem>().Play();

    GameObject embers = Instantiate(embersPrefab, transform.position, Quaternion.identity);
    embers.GetComponent<ParticleSystem>().Play();

    GameObject hemiSphereBurst = Instantiate(hemiSphereBurstPrefab, transform.position, Quaternion.identity);
    hemiSphereBurst.GetComponent<ParticleSystem>().Play();
  }

}
