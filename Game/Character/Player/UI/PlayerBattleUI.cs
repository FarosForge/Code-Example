using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleUI : MonoBehaviour
{
    [SerializeField] private Joystick movement_joystick;
    [SerializeField] private VirtualButton attack_button;
    [SerializeField] private GameObject game_over_panel, game_panel;
    [SerializeField] private Text tanks_count_text;
    [SerializeField] private Sprite[] result_sprites;
    [SerializeField] private Image result_image;
    [SerializeField] private Image attack_auto_slider;
    [SerializeField] private Text game_points_text;
    public Button toLobbyButton;
    public Button restart_button;

    public Joystick GetMovementJoystick { get { return movement_joystick; } }
    public VirtualButton GetAttackButton { get { return attack_button; } }

    public void SetGameOver(GameOverType type)
    {
        game_over_panel.SetActive(true);
        game_panel.SetActive(false);

        switch (type)
        {
            case GameOverType.Win:
                result_image.sprite = result_sprites[0];
                break;
            case GameOverType.Fail:
                result_image.sprite = result_sprites[1];
                break;
        }
    }

    public void SetTextCountTanks(int val)
    {
        tanks_count_text.text = $"{val}";
    }

    public void SetAutoAttackSlider(float val, float max_val)
    {
        attack_auto_slider.fillAmount = val / max_val;
    }

    public void SetGamePointsText(int tanks, int val)
    {
        game_points_text.text = $"{tanks} - {val}";
    }

    public void SetActiveGamePoints(bool val)
    {
        game_points_text.transform.parent.gameObject.SetActive(val);
    }
}
