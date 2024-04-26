using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretSuperJump : MonoBehaviour
{
  
    [SerializeField] private Text _superJumpTxt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          Player player = collision.gameObject.GetComponent<Player>();
            player.ChangemaxTimeBtwSuperjumps(3f);
            if (_superJumpTxt.IsActive())
            {
                _superJumpTxt.text = "press 'E'  to use SUPER jump colldawn is 3 seconds";
            }

        }
    }
}
