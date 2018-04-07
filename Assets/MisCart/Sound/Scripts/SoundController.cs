using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MisCart
{
    public static class SoundController
    {
        private static SoundManager _soundManager;
        private static SoundManager SoundManager
        {
            get
            {
                if (_soundManager != null)
                {
                    return _soundManager;
                }

                Initialize();
                return _soundManager;
            }
        }

        /// <summary>
        /// インスタンスが無かった場合はResourcesで生成し使いまわす。
        /// </summary>
        static void Initialize()
        {
            if (SoundManager.Instance == null)
            {
                var prefab = Resources.Load("Prefabs/SoundManager");
                UnityEngine.Object.Instantiate(prefab);
            }
            _soundManager = SoundManager.Instance;
        }

        public static void PlayBGM(Model.BGM bgm, Action onStart = null, Action onFinish = null)
        {
            SoundManager.PlayBGM(bgm, onStart, onFinish);
        }

        public static void PlaySE(Model.SE se, Action onStart = null, Action onFinish = null)
        {
            SoundManager.PlaySE(se, onStart, onFinish);
        }

        public static void StopSE(Model.SE se, int fade = 0)
        {
            SoundManager.StopSE(se, fade);
        }

        public static void StopBGM(Model.BGM bgm, int fade = 0)
        {
            SoundManager.StopBGM(bgm, fade);
        }

        public static void StopAll(float fade = 0f)
        {
            SoundManager.StopAll(fade);
        }
    }
}