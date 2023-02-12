using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _deltaVolume;

    private float _maxVolume = 1;
    private float _minVolume = 0;

    private Coroutine _coroutine;

    public void UpVolume()
    {
        if (_coroutine == null)
        {
            _audioSource.Play();
            StartCoroutine(_maxVolume);
        }
        else
        {
            StopCoroutine(_coroutine);
            StartCoroutine(_maxVolume);
        }
    }

    public void DownVolume()
    {
        StopCoroutine(_coroutine);
        StartCoroutine(_minVolume);
    }

    private void StartCoroutine(float targetVolume)
    {
        _coroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _deltaVolume * Time.deltaTime);

            yield return null;
        }
    }
}