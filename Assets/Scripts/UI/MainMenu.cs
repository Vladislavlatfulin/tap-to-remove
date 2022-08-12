using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Level;

namespace UI
{
    public class MainMenu: MonoBehaviour
    {
        [SerializeField] private Button startGame;
        [SerializeField] private Button mail;
        private Level.Level _level;

        [Inject]
        private void Constructor(Level.Level level)
        {
            _level = level;
        }
        
        private void OnEnable()
        {
            startGame.onClick.AddListener(OnStartGame);
            mail.onClick.AddListener(OnOpenMail);
        }

        private void OnDisable()
        {
            startGame.onClick.RemoveListener(OnStartGame);
            mail.onClick.RemoveListener(OnOpenMail);
        }

        private void OnOpenMail()
        {
            Application.OpenURL("https://t.me/latfulinvladislav");
        }

        private void OnStartGame()
        {
            gameObject.SetActive(false);
            _level.LevelStart();
            Time.timeScale = 1f;
        }
    }
}