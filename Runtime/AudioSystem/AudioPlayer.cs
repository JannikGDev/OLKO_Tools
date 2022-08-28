using UnityEngine;

namespace AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField]
        ObjectReference audioPlayerReference;

        private AudioSource audioSource;

        public float Volume
        {
            get => audioSource.volume;
            set => audioSource.volume = value;
        }

        private void OnEnable()
        {
            if (audioPlayerReference.Value == null)
                audioPlayerReference.Value = this.gameObject;
            else
                Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            if (audioPlayerReference.Value == this.gameObject)
                audioPlayerReference.Value = null;
        }

        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            audioSource = this.GetComponent<AudioSource>();
        }

        public void PlayMusic(AudioClip clip)
        {
            audioSource.Stop();

            if (clip == null)
                return;

            audioSource.clip = clip;
            audioSource.Play();
            audioSource.loop = true;
        }
    }
}
