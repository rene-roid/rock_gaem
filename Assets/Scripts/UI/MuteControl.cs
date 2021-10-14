using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MuteControl : MonoBehaviour, IPointerClickHandler
{
    // Calling variables
    public Sprite MuteIcon, UnmuteIcon;
    public static bool musicIsMuted = false;

    void Awake()
    {
        this.transform.GetComponent<UnityEngine.UI.Image>().sprite = UnmuteIcon;
    }

    void Update()
    {
        // When M is clicked pause/unpause music
        if(Input.GetKeyDown(KeyCode.M)) { musicIsMuted = !musicIsMuted; }

        // Changing the icon if the music is paused or not
        if (musicIsMuted) { this.transform.GetComponent<UnityEngine.UI.Image>().sprite = MuteIcon; }
        else this.transform.GetComponent<UnityEngine.UI.Image>().sprite = UnmuteIcon;
    }

    // Detecting when the pointer is on the icon
    public void OnPointerClick(PointerEventData eventData)
    {
        // Setting mute mode or not
        if (this.GetComponent<UnityEngine.UI.Image>().sprite == UnmuteIcon) { musicIsMuted = true; } else musicIsMuted = false;
    }

}
