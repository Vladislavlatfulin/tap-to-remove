using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LevelVictoryMenu: MonoBehaviour
    {
        [SerializeField] private Button restartLevel;
        [SerializeField] private Button nextlevel;
        private Level.Level _level;

        [Inject]
        private void Constructor(Level.Level level)
        {
            _level = level;
            _level.OnLevelOver += OnActivationLevelVictoryMenu; 
            // меню должна подписываться на событие до активации, тут хз где подписываться и отписываться
        }

        private void OnEnable()
        {
            restartLevel.onClick.AddListener(OnRestartLevel);
            nextlevel.onClick.AddListener(OnLoadNextLevel);
        }

        private void OnDisable()
        {
            restartLevel.onClick.RemoveListener(OnRestartLevel);
            nextlevel.onClick.RemoveListener(OnLoadNextLevel);
        }

        private void OnRestartLevel()
        {
            gameObject.SetActive(false);
            _level.LevelStart();
            Time.timeScale = 1f;
        }

        private void OnLoadNextLevel()
        {
            
        }
        
        public void OnActivationLevelVictoryMenu()
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }
    }
}