using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    #region References
    [SerializeField] private Image healthbar;
    [SerializeField] private Image torchbar;
    [SerializeField] private Text matchesTxt;
    [SerializeField] Gradient healthGradient;
    [SerializeField] private StatSystem torchStatSystem;
    #endregion
    #region Variables

    #endregion
    private void Start()
    {
        torchStatSystem = GameObject.FindWithTag("Torch").GetComponent<StatSystem>();
        References.playerStatSystem.AddCallBack(StatSystem.StatType.Heat, UpdateHealthBar);
        References.playerStatSystem.AddCallBack(StatSystem.StatType.Matches, UpdateMatches);
        torchStatSystem.AddCallBack(StatSystem.StatType.Heat, UpdateTorchBar);
        UpdateHealthBar(StatSystem.StatType.Heat, References.playerStatSystem.GetValue(StatSystem.StatType.Heat));

        References.playerStatSystem.Callback(StatSystem.StatType.Heat);
        References.playerStatSystem.Callback(StatSystem.StatType.Matches);
        torchStatSystem.Callback(StatSystem.StatType.Heat);
    }
    private void UpdateHealthBar(StatSystem.StatType aStat, float aValue)
    {
        Vector3 sca;
        sca = healthbar.transform.localScale;
        sca.x = aValue / References.playerStatSystem.GetMaxValue(StatSystem.StatType.Heat);
        healthbar.color = healthGradient.Evaluate(sca.x);
        healthbar.transform.localScale = sca;
    }
    private void UpdateTorchBar(StatSystem.StatType aStat, float aValue)
    {
        Vector3 sca;
        sca = torchbar.transform.localScale;
        sca.y = aValue / 10f;
        torchbar.color = healthGradient.Evaluate(sca.y);
        torchbar.transform.localScale = sca;
    }
    private void UpdateMatches(StatSystem.StatType aStat, float aValue)
    {
        matchesTxt.text = (aValue + "/" + References.playerStatSystem.GetMaxValue(aStat));
    }

}
