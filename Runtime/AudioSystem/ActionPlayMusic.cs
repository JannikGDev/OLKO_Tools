using UnityEngine;

namespace AudioSystem
{
    public class ActionPlayMusic : MonoBehaviour
    {
        [SerializeField]
        ObjectReference audioPlayer;

        [SerializeField]
        AudioClip musicClip;

        [SerializeField]
        [Range(0,1)]
        float volume;

        public void Action_PlayMusic()
        {
            if (audioPlayer.Value == null)
                return;

            var player = audioPlayer.Value.GetComponent<AudioPlayer>();
            player.Volume = volume;
            player.PlayMusic(musicClip);
        }
    }
}
