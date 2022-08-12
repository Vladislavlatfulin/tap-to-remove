using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField] private string androidGameId = "4858336";
        [SerializeField] private string iosGameId = "4858337";
        [SerializeField] private bool testMode = true;
        private string _gameId;

        private void Awake()
        {
            IniatializeAds();
        }

        private void IniatializeAds()
        {
            _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iosGameId : androidGameId;
            Advertisement.Initialize(_gameId,testMode, this);
        }

        public void OnInitializationComplete()
        {
            Debug.Log("unity ads complete");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log("Unity ads failed");
        }
    }
}
