using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour {
  private Label ScoreLabel;
  private int score = 0;

  private static ScoreManager _instance;
  public static ScoreManager Instance {
    get {
      if (_instance == null) {
        GameObject go = new GameObject("ScoreManager");
        go.AddComponent<ScoreManager>();
      }
      return _instance;
    }
  }

  public void Awake() {
    _instance = this;
  }

  public void OnEnable() {
    VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    ScoreLabel = root.Q<Label>("score-label");
  }

  public void AppendScore(int points) {
    score += points;
    UpdateScoreLabel();
  }

  public void SubtractScore(int points) {
    score -= points;
    UpdateScoreLabel();
  }

  public void UpdateScoreLabel() {
    ScoreLabel.text = $"Score: {score}";
  }

}
