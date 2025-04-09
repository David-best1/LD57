using System.Collections.Generic;
using UnityEngine;

public class MonsterSound : MonoBehaviour
{
    public List<AudioClip> monsterSounds;

    // ����������� � ������������ ����� ����� ������� (� ��������)
    public float minTimeBetweenSounds = 3f;
    public float maxTimeBetweenSounds = 10f;

    private AudioSource audioSource;
    private float nextSoundTime;

    void Start()
    {
        // �������� ��������� AudioSource
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

    // ������������� ��������� ����� ��� ��������������� �����
    private void SetNextSoundTime()
    {
        nextSoundTime = Time.time + Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
    }
}