using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MuteControl : MonoBehaviour, IPointerClickHandler
{

    public Sprite MuteIcon, UnmuteIcon;
    private AudioSource muteDetect;

    void Awake()
    {
        this.transform.GetComponent<UnityEngine.UI.Image>().sprite = UnmuteIcon;

        muteDetect = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        muteDetect.mute = !muteDetect.mute;

        if (this.GetComponent<UnityEngine.UI.Image>().sprite == UnmuteIcon)
        {
            this.transform.GetComponent<UnityEngine.UI.Image>().sprite = MuteIcon;
        } else
        {
            this.transform.GetComponent<UnityEngine.UI.Image>().sprite = UnmuteIcon;
        }
    }

}
