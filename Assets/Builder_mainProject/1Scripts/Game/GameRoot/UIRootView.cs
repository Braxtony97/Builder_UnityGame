using System.Collections;
using UnityEngine;

namespace Assets.Builder_mainProject._1Scripts.Game.GameRoot
{
    public class UIRootView : MonoBehaviour // Для управления экранами
    {
        [SerializeField] private GameObject _loadingScreen;

        private void Awale()
        {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }
    }
}