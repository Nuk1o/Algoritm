using UnityEngine;
using UnityEngine.Video;

public class Lern_video : MonoBehaviour 
{
    //Скрипт для включения видео
    [SerializeField] VideoPlayer _player;
    [SerializeField] VideoClip _clip;
    public void video_play ()
    {
        _player.clip = _clip;
        _player.Play();
    }
}
