using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinks : MonoBehaviour
{

    // Opening links when button is clicked
    public void EvanYoutubeLink()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCT1ZkP03V18LmOj8zbyP-Dw?");
    }
    public void EvanOpenWeb()
    {
        Application.OpenURL("https://contextsensitive.bandcamp.com/");
    }
    public void FontDownload()
    {
        Application.OpenURL("https://www.dafont.com/manuel-viergutz.d2029");
    }
}
