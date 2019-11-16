using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    #region References
    [SerializeField] private Image healthbar;
    [SerializeField] Gradient healthGradient;
    #endregion
    #region Variables

    #endregion
    private void Start()
    {
        References.playerStatSystem.AddCallBack(StatSystem.StatType.Heat, UpdateHealthBar);
        UpdateHealthBar(StatSystem.StatType.Heat, References.playerStatSystem.GetValue(StatSystem.StatType.Heat));
    }
    private void UpdateHealthBar(StatSystem.StatType aStat, float aValue)
    {
        Vector3 sca;
        sca = healthbar.transform.localScale;
        sca.x = aValue / References.playerStatSystem.GetMaxValue(StatSystem.StatType.Heat);
        healthbar.color = healthGradient.Evaluate(sca.x);
        healthbar.transform.localScale = sca;
    }
}
