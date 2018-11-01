
using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Collections;
using System.Diagnostics;
using DG.Tweening;
using MisCart;

namespace MisCart
{
    // サウンドの状態
    public enum SoundState
    {
        Free,
        Load,
        Play,
        Stop
    }

    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;
        DG.Tweening.Tween stopFade;

        //サウンドが再生したときに呼ばれるメソッド
        public Action OnStart;

        //サウンドが停止したときに呼ばれるメソッド
        public Action OnFinish;

        public SoundState State { get; private set; }
        public Model.AudioType Type   { get; private set; }

        //サウンド名
        public string Key   { get; set; }

        public bool IsPlaying   { get { return audioSource.isPlaying; } }
        public bool IsActive    { get { return State == SoundState.Load || State == SoundState.Play; } }

        public void SetActive(bool value)
        {
            this.gameObject.SetActive(value);
        }

        /// <summary>
        /// サウンド情報のセット
        /// </summary>
        public void Setup(Model.AudioType audioType)
        {
            State = SoundState.Load;
            Type = audioType;
        }

        /// <summary>
        /// サウンドの再生
        /// </summary>
        public void Play(AudioClip clip, bool loop, float volume)
        {
            try
            {
                State = SoundState.Play;
                audioSource.volume = volume;
                audioSource.clip = clip;
                audioSource.loop = loop;
                audioSource.Play();
            }
            catch(Exception e)
            {
                Log(e);
            }
            finally
            {
                if (OnStart != null)
                {
                    OnStart();
                    OnStart = null;
                }
            }
        }

        /// <summary>
        /// 徐々に音量を小さくしてから停止する
        /// </summary>
        public void Stop(float time)
        {
            if(time == 0f)
            {
                stopFade = null;
                Stop();
            }
            else if(stopFade == null)
            {
                stopFade = audioSource.DOFade(0f, time);
                stopFade.OnComplete(() => {
                    stopFade = null;
                    Stop();
                });
            }
        }

        /// <summary>
        /// 再生の停止
        /// </summary>
        public void Stop()
        {
            // ステートが逆行しないようにする
            if(SoundState.Stop < State)
            {
                return;
            }

            try
            {
                State = SoundState.Stop;
                if(stopFade != null)
                {
                    stopFade.Kill();
                    stopFade = null;
                }
                if(IsPlaying)
                {
                    audioSource.Stop();
                }
            }
            catch(Exception e)
            {
                Log(e);
            }
            finally
            {
                if (OnFinish != null)
                {
                    OnFinish();
                    OnFinish = null;
                }
            }
        }

        /// <summary>
        /// サウンド情報の削除
        /// </summary>
        public void Clear()
        {
            State = SoundState.Free;

            audioSource.volume = 0f;
            audioSource.clip = null;
            OnStart = null;
            OnFinish = null;
        }

        [Conditional("UNITY_EDITOR")]
        public static void Log(object o)
        {
            UnityEngine.Debug.Log(o);
        }

    }
}
