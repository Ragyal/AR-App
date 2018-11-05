using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject videoControls;

    public Image playImage;
    public Sprite playSprite;
    public Sprite pauseSprite;

    public Image soundImage;
    public Sprite soundSprite;
    public Sprite muteSprite;

    public VideoPlayer videoPlayer;
    public Animator animator;


    private void OnEnable()
    {
        bool isOK = true;


        if (!this.videoControls)
        {
            Debug.LogError("UIManager wurde kein Canvas zugewiesen. UIManager wurde disabled.");
            isOK = false;
        }

        if (!this.playImage)
        {
            Debug.LogError("UIManager wurde kein PlayImage zugewiesen. UIManager wurde disabled.");
            isOK = false;
        }

        if (!this.playSprite)
        {
            Debug.LogError("UIManager wurde kein PlaySprite zugewiesen. UIManager wurde disabled.");
            isOK = false;
        }

        if (!this.pauseSprite)
        {
            Debug.LogError("UIManager wurde kein PauseSprite zugewiesen. UIManager wurde disabled.");
            isOK = false;
        }

        if (!this.soundImage)
        {
            Debug.LogError("UIManager wurde kein SoundImage zugewiesen. UIManager wurde disabled.");
            isOK = false;
        }

        if (!this.soundSprite)
        {
            Debug.LogError("UIManager wurde kein SoundSprite zugewiesen. UIManager wurde disabled.");
            isOK = false;
        }

        if (!this.muteSprite)
        {
            Debug.LogError("UIManager wurde kein MuteSprite zugewiesen. UIManager wurde disabled.");
            isOK = false;
        }

        if (!this.videoPlayer)
        {
            Debug.LogError("UIManager wurde kein VideoPlayer zugewiesen. UIManager wurde disabled.");
            isOK = false;
        }


        if (!isOK)
            this.enabled = false;
    }

    // Use this for initialization
    private void Start()
    {
        this.videoPlayer.SetDirectAudioMute(0, false);
        this.UpdateSoundButton(true);
        this.UpdatePlayButton(false);
	}
	
	// Update is called once per frame
	private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            this.animator.SetTrigger("play");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            this.animator.SetTrigger("reset");
        }
	}


    public void TogglePlay()
    {
        if (this.videoPlayer.isPlaying)
        {
            this.videoPlayer.Pause();
            this.UpdatePlayButton(false);
        }
        else
        {
            this.videoPlayer.Play();
            this.UpdatePlayButton(true);
        }
    }

    public void ToggleSound()
    {
        if (this.videoPlayer.GetDirectAudioMute(0))
        {
            this.videoPlayer.SetDirectAudioMute(0, false);
            this.UpdateSoundButton(true);
        }
        else
        {
            this.videoPlayer.SetDirectAudioMute(0, true);
            this.UpdateSoundButton(false);
        }
    }

    public void RewindVideo()
    {
        this.videoPlayer.frame = 0;
    }


    public void EnableControls()
    {
        this.videoControls.SetActive(true);
        if (!this.videoPlayer.isPlaying)
        {
            this.videoPlayer.Play();
            this.UpdatePlayButton(true);
        }
    }

    public void DisableControls()
    {
        this.videoControls.SetActive(false);
        if (this.videoPlayer.isPlaying)
        {
            this.videoPlayer.Pause();
            this.UpdatePlayButton(false);
        }
    }

    private void UpdatePlayButton(bool status)
    {
        if (status)
        {
            this.playImage.sprite = this.pauseSprite;
        }
        else
        {
            this.playImage.sprite = this.playSprite;
        }
    }

    private void UpdateSoundButton(bool status)
    {
        if (status)
        {
            this.soundImage.sprite = this.soundSprite;
        }
        else
        {
            this.soundImage.sprite = this.muteSprite;
        }
    }
}
