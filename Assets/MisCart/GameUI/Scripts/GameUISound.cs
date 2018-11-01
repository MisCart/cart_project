using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;

namespace GameUI
{
	public class GameUISound : MonoBehaviour
	{
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip[] clips;

        public void PlayWin(){
            audioSource.clip = clips[0];
            audioSource.loop = true;
            audioSource.Play();
        }

        public void PlayLose(){
            audioSource.clip = clips[1];
            audioSource.loop = true;
            audioSource.Play();
        }
	}
}
