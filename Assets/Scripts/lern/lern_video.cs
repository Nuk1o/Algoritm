using UnityEngine;
using UnityEngine.Video;

public class lern_video : MonoBehaviour 
{
    //������ ��� ��������� �����
    [SerializeField] VideoPlayer _player;
    [SerializeField] VideoClip _clip;
    public void video_play ()
    {
        _player.clip = _clip;
        _player.Play();
    }
}
