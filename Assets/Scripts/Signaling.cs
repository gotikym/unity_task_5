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
        _audioSource.Play();
        StartChangeVolume(_maxVolume);
    }

    public void DownVolume()
    {
        StartChangeVolume(_minVolume);
    }

    private void StartChangeVolume(float targetVolume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

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