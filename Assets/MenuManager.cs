using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour {
  private Button startButton;
  private Button exitButton;

  public void OnEnable() {
    VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    startButton = root.Q<Button>("StartButton");
    startButton.clicked += () => {
      SceneManager.LoadScene("Start");
    };
    exitButton = root.Q<Button>("ExitButton");
    exitButton.clicked += () => {
      Debug.Log("Really");
      Application.Quit();
    };
  }
}
