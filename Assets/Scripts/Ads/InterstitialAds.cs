using System;
using UnityEngine;
using UnityEngine.Advertisements;
namespace Ads
{
    public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [SerializeField] private string androidAdId = "Interstitial_Android";
        [SerializeField] private string iosAdId = "Interstitial_iOS";

        private string _adId;

        private void Awake()
        {
            _adId = (Application.platform == RuntimePlatform.Android) ? androidAdId : iosAdId;
            LoadAD();
        }

        private void LoadAD()
        {
            Debug.Log("Load ad" + _adId);
            Advertisement.Load(_adId, this);
        }

        public void ShowAD()
        {
            Debug.Log("Show ad" + _adId);
            Advertisement.Show(_adId, this);
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            throw new NotImplementedException();
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            throw new NotImplementedException();
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            throw new NotImplementedException();
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            throw new NotImplementedException();
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            throw new NotImplementedException();
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            LoadAD();
        }
    }
}