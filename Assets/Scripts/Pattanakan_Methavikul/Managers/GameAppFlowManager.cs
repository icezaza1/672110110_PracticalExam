using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pattanakan_Methavikul.Managers
{
    public class GameAppFlowManager : Singleton<GameAppFlowManager>
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        public void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

