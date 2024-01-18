using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    [SerializeField] private Player player;

    private int normalDamage = 1;
    private int zombieDamage = 0;
    private int demonDamage = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy_Necrofago>() != null && player.anim.GetCurrentAnimatorStateInfo(0).IsName("Heavy_Attack") ||
            player.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_01") || player.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_02") ||
            player.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_03"))
        {
            if (other.GetComponent<Enemy_Necrofago>() == null)
                return;
            else
                other.GetComponent<Enemy_Necrofago>().ReciveDamage(normalDamage, zombieDamage);
        }
    }
}
