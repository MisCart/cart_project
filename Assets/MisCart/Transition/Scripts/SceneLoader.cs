using UnityEngine;

namespace Transition
{
    public static class SceneLoader
    {
        private static TransitionManager _transitionManager;
        private static TransitionManager TransitionManager
        {
            get
            {
                if (_transitionManager != null)
                {
                    return _transitionManager;
                }

                Initialize();
                return _transitionManager;
            }
        }

        public static void Initialize()
        {
            if (TransitionManager.Instance == null)
            {
                var resource = Resources.Load("Prefabs/TransitionManager");
                Object.Instantiate(resource);
            }
            _transitionManager = TransitionManager.Instance;
        }

        //　シーン遷移処理中か
        public static bool IsTransitionRunning
        {
            get { return TransitionManager.IsRunning; }
        }

        public static void LoadScene(Model.GameScenes scene, Model.GameScenes[] additiveLoadScenes = null)
        {
            TransitionManager.StartTransaction(scene, additiveLoadScenes);
        }
    }
}