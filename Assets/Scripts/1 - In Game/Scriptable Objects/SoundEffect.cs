using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect", menuName = "SoundEffect", order = 0)]
public class SoundEffect : ScriptableObject {
    public AudioClip[] audioClips;

    public AudioClip GetAudioClip()
    {
        return audioClips[Random.Range(0, audioClips.Length)];
    }
}