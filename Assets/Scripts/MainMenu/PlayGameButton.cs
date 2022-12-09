using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu {
  public class PlayGameButton : MonoBehaviour {
    public string gameScene;
    private AsyncOperation _loadOperation;

    void Start() {
      GetComponent<Button>().onClick.AddListener(OpenMainScene);
      StartCoroutine(LoadMainScene());
    }

    private IEnumerator LoadMainScene() {
      _loadOperation = SceneManager.LoadSceneAsync(gameScene, LoadSceneMode.Single);
      _loadOperation.allowSceneActivation = false;
      while (!_loadOperation.isDone) {
        yield return null;
      }
    }
  
    private void OpenMainScene() {
      _loadOperation.allowSceneActivation = true;
    }
  }
}
