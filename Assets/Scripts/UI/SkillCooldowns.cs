using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldowns : MonoBehaviour
{
    // Calling variables

    // Dash Var
    public Image dashOverlay;
    private float dashCooldown;
    bool isDashCD = false;
    public KeyCode dashKey = KeyCode.Space;

    // Slowmo vars
    public Image slowmoOverlay;
    private float slowmoCooldown;
    bool isSlowmoCD = false;
    public KeyCode slowmoKey = KeyCode.E;

    // Skill counter vars
    private float dashTime, slowmoTime;
    public Text dashText, slowmoText;
    public GameObject dashTimeGameobject, slowmoTimeGameObject;

    // Start is called before the first frame update
    void Start()
    {
        // Converting cooldowns to string
        dashText.text = dashTime.ToString();
        slowmoText.text = slowmoTime.ToString();

        // Dash cooldown & overlay setup
        dashCooldown = PlayerMovement.dashCD + 0.05f;
        dashOverlay.fillAmount = 0;

        // Slowmotion cooldown & overlay setup
        slowmoCooldown = SlowMotion.slowmotionCD;
        slowmoOverlay.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Calling skills
        dashCDOverlay();
        slowmoCDoverlay();
    }

    void dashCDOverlay()
    {
        // If dash is clicked and there is no cd do...
        if (Input.GetKey(dashKey) && isDashCD == false)
        {
            // Activating timer & overlay
            dashTimeGameobject.SetActive(true);
            dashTime = PlayerMovement.dashCD;
            isDashCD = true;
            dashOverlay.fillAmount = 1;
        }

        if (isDashCD)
        {
            // Moving the overlay clockwise with the time
            dashOverlay.fillAmount -= 1 / dashCooldown * Time.deltaTime;
            dashTime -= Time.deltaTime;
            dashText.text = Mathf.Round(dashTime).ToString();

            // When finish, finish cooldown bla bla
            if (dashOverlay.fillAmount == 0)
            {
                dashOverlay.fillAmount = 0;
                isDashCD = false;
                dashTimeGameobject.SetActive(false);
            }
        }
    }

    void slowmoCDoverlay()
    {
        // If slowmo is clicked and there is no cd do...
        if (Input.GetKey(slowmoKey) && isSlowmoCD == false && PauseMenu.gameIsPaused == false)
        {
            // Activating timer & overlay
            slowmoTime = SlowMotion.slowmotionCD;
            isSlowmoCD = true;
            slowmoOverlay.fillAmount = 1;
        }

        if (isSlowmoCD)
        {
            // Moving the overlay clockwise with the time
            slowmoTimeGameObject.SetActive(true);
            slowmoOverlay.fillAmount -= 1 / slowmoCooldown * Time.deltaTime;
            slowmoTime -= Time.deltaTime;
            slowmoText.text = Mathf.Round(slowmoTime).ToString();

            // When finish, finish cooldown bla bla
            if (slowmoOverlay.fillAmount == 0)
            {
                slowmoOverlay.fillAmount = 0;
                isSlowmoCD = false;
                slowmoTimeGameObject.SetActive(false);
            }
        }
    }
}
