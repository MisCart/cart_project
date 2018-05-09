using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MisCart
{
    public class SoundInfo
    {
        int counter;
        public AudioClip AudioClip  { get; private set; }
        public int RetainCount  { get { return counter; } }
        public bool NoReference { get { return counter == 0; } }

        public SoundInfo(AudioClip clip)
        {
            AudioClip = clip;
        }

        public void Retain()
        {
            counter++;
        }

        public void Release()
        {
            counter = Mathf.Max(0, counter - 1);
        }

        public void Unload()
        {
            Resources.UnloadAsset(AudioClip);
            AudioClip = null;
        }
    }

    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] GameObject soundPlayerPrefab;
        List<SoundPlayer> playerPool = new List<SoundPlayer>();
        Dictionary<string, SoundInfo> soundCache = new Dictionary<string, SoundInfo>();

        /// <summary>
        /// キャッシュの削除
        /// </summary>
        void RemoveCache(string key)
        {
            // 未利用のオーディオのみ破棄する
            if(soundCache[key].NoReference)
            {
                soundCache[key].Unload();
                soundCache.Remove(key);
            }
        }

        override protected void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// SEの再生
        /// </summary>
        public void PlaySE(Model.SE se, Action onStart = null, Action onFinish = null)
        {
            var soundPlayer = GetFreeSoundPlayer();
            soundPlayer.Setup(Model.AudioType.SE);
            soundPlayer.OnStart = onStart;
            soundPlayer.OnFinish = onFinish;

            var key = se.ToString();
            soundPlayer.Key = key;
            AudioClip clip = Resources.Load("Sounds/SE/"+key) as AudioClip;

            if (clip == null)
            {
                Debug.LogFormat("{0} was not found", key);
                return;
            }

            StartCoroutine(Play(soundPlayer, key, clip, false));
        }

        /// <summary>
        /// BGMの再生
        /// </summary>
        public void PlayBGM(Model.BGM bgm, Action onStart = null, Action onFinish = null)
        {
            var soundPlayer = GetFreeSoundPlayer();
            soundPlayer.Setup(Model.AudioType.BGM);
            soundPlayer.OnStart = onStart;
            soundPlayer.OnFinish = onFinish;

            var key = bgm.ToString();
            soundPlayer.Key = key;
            AudioClip clip = Resources.Load("Sounds/BGM/"+key) as AudioClip;

            StartCoroutine(Play(soundPlayer, key, clip, true));
        }

        IEnumerator Play(SoundPlayer soundPlayer, string key, AudioClip clip, bool loop)
        {
            SoundInfo sound = null;
            yield return null;

            if (soundCache.TryGetValue(key, out sound))
            {
                if (sound.AudioClip.loadState != AudioDataLoadState.Loaded)
                {
                    Debug.LogFormat("Sound Load State Error [{0}]", sound.AudioClip.loadState);
                    RemoveCache(key);
                    sound = null;
                }

            }

            if (sound == null)
            {
                sound = new SoundInfo(clip);
                soundCache.Add(key, sound);
            }

            bool playable = true;

            // 再生中または停止のステータのの場合はPlayの実行を行わない
            playable &= soundPlayer.State != SoundState.Play;
            playable &= soundPlayer.State != SoundState.Stop;

            // 負荷対策で同じ音は10個までに制限する
            playable &= sound.RetainCount <= 10;

            if(playable && sound != null)
            {
                sound.Retain();
                soundPlayer.SetActive(true);
                soundPlayer.Play(sound.AudioClip, loop);

                while(soundPlayer.IsPlaying){ yield return null; }

                soundPlayer.Stop();
                soundPlayer.SetActive(false);
                sound.Release();
            }
            else
            {
                soundPlayer.OnStart();
                soundPlayer.OnFinish();
            }

            // BGMは再生が止まったらキャッシュから破棄
            if(soundPlayer.Type == Model.AudioType.BGM){
                RemoveCache(key);
            }
            soundPlayer.Clear();
        }

        /// <summary>
        /// BGMの再生停止
        /// </summary>
        public void StopBGM(Model.BGM bgm, float fade = 0f)
        {
            var key = bgm.ToString();
            Stop(key, fade);
        }

        /// <summary>
        /// SEの再生停止
        /// </summary>
        public void StopSE(Model.SE se, float fade = 0f)
        {
            var key = se.ToString();
            Stop(key, fade);
        }

        /// <summary>
        /// すべてのサウンドを停止
        /// </summary>
        public void StopAll(float fade = 0f)
        {
            foreach (var sound in playerPool.Where(sound => sound.IsActive)) {
                sound.Stop(fade);
            }
        }

        /// <summary>
        /// 再生の停止
        /// </summary>
        void Stop(string key, float fade = 0f)
        {
            var query = playerPool.Where(sound => sound.IsActive && sound.Key == key);

            foreach (var sound in query) {
                sound.Stop(fade);
            }
        }

        /// <summary>
        /// Free状態のSoundPlayerを取得
        /// </summary>
        SoundPlayer GetFreeSoundPlayer()
        {
            var soundPlayer = playerPool.Find(sound => sound.State == SoundState.Free);

            if(soundPlayer == null)
            {
                var obj = Instantiate(soundPlayerPrefab);
                obj.transform.localScale = Vector3.one;
                obj.transform.localPosition = Vector3.zero;
                obj.name = "SoundPlayer";
                obj.transform.SetParent(transform);

                soundPlayer = obj.GetComponent<SoundPlayer>();
                soundPlayer.Clear();
                soundPlayer.SetActive(false);
                playerPool.Add(soundPlayer);
            }

            return soundPlayer;
        }
    }

}