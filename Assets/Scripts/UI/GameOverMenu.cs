using Ads;
using Level.Blocks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Button = UnityEngine.UI.Button;

namespace UI
{
    public class GameOverMenu: MonoBehaviour
    {
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button restartSceneButton;
        private CentralBaseBlockView _centralBaseBlock;
        private Level.Level _level;
        private InterstitialAds _ads;

        [Inject]
        private void Constructor(CentralBaseBlockView centralBaseBlock, Level.Level level, InterstitialAds ads)
        {
            _ads = ads;
            _level = level;
            _centralBaseBlock = centralBaseBlock;
            _centralBaseBlock.OnPlayersSquareTouch += OnActivationGameOverMenu;
            // как до появления объекта подписаться и отписаться на событие другого? 
        }
        private void OnEnable()
        {
            restartLevelButton.onClick.AddListener(OnRestartLevel);
            restartSceneButton.onClick.AddListener(OnRestartScene);
        }

        private void OnDisable()
        {
            restartLevelButton.onClick.RemoveListener(OnRestartLevel);
            restartSceneButton.onClick.RemoveListener(OnRestartScene);
        }

        public void OnRestartScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            Time.timeScale = 1f;
        }

        public void OnRestartLevel()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            _level.LevelStart();
        }

        public void OnActivationGameOverMenu()
        {
            _ads.ShowAD();
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }
    }
}
