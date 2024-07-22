using Assets.Builder_mainProject._1Scripts.Game.Gameplay.Root;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Builder_mainProject._1Scripts.Game.GameRoot
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private Coroutines _coroutines;
        private UIRootView _uiRoot;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] // ���� ����� 1 �� ��������� - ��������� �����
        public static void AutostartGame()
        {
            Application.targetFrameRate = 60; // ���-�� ���. � ������� �� ������� = 30
            Screen.sleepTimeout = SleepTimeout.NeverSleep; // ����� �� ����� ������� ���� �� ������ �� ����

            _instance = new GameEntryPoint();
            _instance.RunGame(); 
        }

        private GameEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
            _uiRoot = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == Scenes.GAMEPLAY)
            {
                _coroutines.StartCoroutine(LoadAndStartGamePlay());
                return;
            }
            if (sceneName != Scenes.BOOT) 
            {

            }

#endif
            _coroutines.StartCoroutine(LoadAndStartGamePlay());
        }

        private IEnumerator LoadAndStartGamePlay()
        {
            _uiRoot.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT); // ��������� ������ �����, ��� �� ���� ����� unity
            yield return LoadScene(Scenes.GAMEPLAY);


            yield return new WaitForSeconds(2);


            var sceneEntryPoint = Object.FindObjectOfType<GameplayEntryPoint>();
            sceneEntryPoint.Run();

            _uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}

