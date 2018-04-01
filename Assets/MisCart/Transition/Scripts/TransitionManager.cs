using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Transition
{
	public class TransitionManager : SingletonMonoBehaviour<TransitionManager>
	{
        Model.GameScenes currentGameScene;

        // シーン遷移処理を実行中であるか
        bool isRunning = false;

        //　蓋絵のアニメーションを実行中か
        bool isFading = false;

        bool isSwichedScene = false;

        //蓋絵
		[SerializeField] UICanvas uiCanvas;
        [SerializeField] FadeImage image;

		public static UICanvas UI { get { return Instance.uiCanvas; } }
        public Model.GameScenes CurrentGameScene { get { return currentGameScene; } }
        public bool IsRunning { get { return isRunning; } }

        override protected void Awake()
        {
            //このオブジェクトが消えないようにする
            DontDestroyOnLoad(gameObject);

            try
            {
                //現在のシーンを取得する
                currentGameScene = (Model.GameScenes)Enum.Parse(typeof(Model.GameScenes), SceneManager.GetActiveScene().name, false);
            }
            catch
            {
                Debug.Log("現在のシーンの取得に失敗");
                currentGameScene = Model.GameScenes.Title;
            }

            //アクティブなシーンが切り替わったことを通知する
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        void TransitionReset()
        {
            isRunning = false; 
            isFading = false; 
            isSwichedScene = false;
        }

        public void StartTransaction(Model.GameScenes nextScene, Model.GameScenes[] additiveLoadScenes)
        {
            if (isRunning) return;
            TransitionReset();
            StartCoroutine(TransitionCoroutine(nextScene, additiveLoadScenes));
        }

        /// <summary>
        /// シーン遷移処理の本体
        /// </summary>
        private IEnumerator TransitionCoroutine(Model.GameScenes nextScene, Model.GameScenes[] additiveLoadScenes)
        {
            isRunning = true;
            image.raycastTarget = true;

            //蓋絵で画面を隠す
            isFading = true;
            UI.Fade.FadeIn(1f, () => isFading = false);

            //トランジションアニメーションが終了するのを待つ
            while(isFading){ yield return null;}

            //メインとなるシーンをSingleで読み込む
            var main = SceneManager.LoadSceneAsync(nextScene.ToString());

            //追加シーンがある場合は一緒に読み込む
            if (additiveLoadScenes != null)
            {
                //additiveLoadScenes.Select(scene => SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Additive));
                foreach(var item in additiveLoadScenes)
                {
                    SceneManager.LoadSceneAsync(item.ToString(), LoadSceneMode.Additive);
                }
            }

            //使ってないリソースの解放とGCを実行
            Resources.UnloadUnusedAssets();
            GC.Collect();
            yield return null;

            //現在シーンを設定
            currentGameScene = nextScene;

            while(!isSwichedScene){ yield return null; }

            //蓋絵を開く方のアニメーション開始
            isFading = true;
            UI.Fade.FadeOut(1f, () => isFading = false);

            //蓋絵が開ききるのを待つ
            while(isFading){ yield return null; }
            TransitionReset(); 
        }

        void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            isSwichedScene = true;
        }
	}
}