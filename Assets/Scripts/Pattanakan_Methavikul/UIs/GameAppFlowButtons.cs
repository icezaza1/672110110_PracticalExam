using UnityEngine;
using UnityEngine.SceneManagement;
using Pattanakan_Methavikul.Managers;

namespace Pattanakan_Methavikul.UIs
{
    public class GameAppFlowButtons : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            GameAppFlowManager.Instance.LoadScene(sceneName);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            GameAppFlowManager.Instance.LoadSceneAdditive(sceneName);
        }
        
        public void UnloadScene(string sceneName)
        {
            GameAppFlowManager.Instance.UnloadScene(sceneName);
        }
        
        public void ExitGame()
        {
            GameAppFlowManager.Instance.ExitGame();
        }
    }
}
