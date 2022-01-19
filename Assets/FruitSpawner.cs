using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class FruitSpawner : MonoBehaviour {
  public GameObject[] fruitPrefabs;
  public Transform[] spawnPoints;
  private ObjectPool<GameObject> pool;

  public float minDelay = .1f;
  public float maxDelay = 1f;

  private void Start() {
    pool = new ObjectPool<GameObject>(() => {
      int fruitType = Random.Range(0, fruitPrefabs.Length);
      return Instantiate(fruitPrefabs[fruitType]);
    }, fruit => {
      fruit.SetActive(true);
      int spawnIndex = Random.Range(0, spawnPoints.Length);
      Transform spawnPoint = spawnPoints[spawnIndex];
      Transform transform = fruit.GetComponentInParent(typeof(Transform)) as Transform;
      transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
    }, fruit => {
      fruit.SetActive(false);

    }, fruit => {
      Destroy(fruit, 5f);
    }, false, 30, 100);
    StartCoroutine(SpawnFruits());
  }

  IEnumerator SpawnFruits() {
    while (true) {
      float delay = Random.Range(minDelay, maxDelay);
      yield return new WaitForSeconds(delay);

      GameObject spawnedFruit = pool.Get();
      StartCoroutine(DelayedHideGameObject(spawnedFruit, 4f));
    }
  }

  private IEnumerator DelayedHideGameObject(GameObject target, float time) {
    yield return new WaitForSeconds(time);
    if (target != null) {
      target.SetActive(false);
      pool.Release(target);
    }
  }

}

