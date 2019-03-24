using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicTimer : MonoBehaviour
{
    public MusicView musicView = null;
    public float musicDuration = 0;
    public float actualDuration = 0;
    public Image circle;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Starting music");
        musicView = GameObject.FindWithTag("Music").GetComponent<MusicView>();
        if (musicView == null)
        {
            Debug.LogError("MusicTimer: can't find MusicView!");
            return;
        }
       circle = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (musicView && musicView.midiFilePlayer.MPTK_IsPlaying && !musicView.midiFilePlayer.MPTK_IsPaused)
        {
            if (musicDuration == 0)
                musicDuration = musicView.midiFilePlayer.MPTK_Duration.Minutes * 60 + musicView.midiFilePlayer.MPTK_Duration.Seconds;
            actualDuration += Time.deltaTime;

            if (actualDuration == 0)
                circle.fillAmount = 0;
            circle.fillAmount = actualDuration / musicDuration;
        }
    }
}
