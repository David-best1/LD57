using System.Collections.Generic;
using UnityEngine;

public class MonsterSound : MonoBehaviour
{
    public List<AudioClip> monsterSounds;

    // Минимальное и максимальное время между звуками (в секундах)
    public float minTimeBetweenSounds = 3f;
    public float maxTimeBetweenSounds = 10f;

    private AudioSource audioSource;
    private float nextSoundTime;

    void Start()
    {
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();

        if (!audioSource)
        {
            Debug.LogError("No AudioSource found on this GameObject.");
        }
        SetNextSoundTime();
    }

    void Update()
    {
        if (Time.time >= nextSoundTime)
        {
            PlayRandomSound();
            SetNextSoundTime();
        }
    }

    private void PlayRandomSound()
    {
        if (monsterSounds.Count > 0 && audioSource != null)
        {
            int randomIndex = Random.Range(0, monsterSounds.Count);
            audioSource.PlayOneShot(monsterSounds[randomIndex]);
        }
    }

    // Устанавливаем следующее время для воспроизведения звука
    private void SetNextSoundTime()
    {
        nextSoundTime = Time.time + Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
    }
}