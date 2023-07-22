using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuestOutput : MonoBehaviour
{
    public TextMeshProUGUI display_player_name;

    public void Awake()
    {
        display_player_name.text= Sample.sample.player_name;
    }
}
