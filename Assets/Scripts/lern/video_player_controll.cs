using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video_player_controll : MonoBehaviour
{
    //Скрипт для управление видеороликом
    [SerializeField] VideoPlayer _player;    
    [SerializeField] Slider _slider;
    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (_player.isPlaying)
            {
                _player.Pause();
            }
            else
            {
                _player.Play();
            }
        }
        _slider.maxValue = (float)_player.clip.length;
        if (Input.GetMouseButtonDown(0))
        {
            _player.time = _slider.value;
        }
        else
        {
            _slider.value = (float)_player.time;
        }        
    }
}
