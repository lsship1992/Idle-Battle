using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
public class DopInfoPerson : MonoBehaviour
{
    public float Attack;
    public float Hp;
    public float Defens;
    public float Speed;
    public int DamageReduction;
    public int CritDamage;
    public int CritChance;
    public int Evasion;
    public int Accuracy;
    public int DamageBonus;
    public int AntiCrit;
    public int Control;
    public int AntiControl;
    public int Treatment;
    public int Recovery;
    public Text AttackText;
    public Text HpText;
    public Text DefenTexts;
    public Text SpeedText;
    public Text DamageReductionText;
    public Text CritDamagTexte;
    public Text CritChanceText;
    public Text EvasionText;
    public Text AccuracyText;
    public Text DamageBonusText;
    public Text AntiCritText;
    public Text ControlText;
    public Text AntiControlText;
    public Text TreatmentText;
    public Text RecoveryText;

    private void Update()
    {
        AttackText.text = Convert.ToString((BigInteger)Attack);
        HpText.text = Convert.ToString((BigInteger)Hp);
        DefenTexts.text = Convert.ToString((BigInteger)Defens);
        SpeedText.text = Convert.ToString((BigInteger)Speed);
        DamageReductionText.text = $"Ум. урона: {DamageReduction.ToString()}";
        CritDamagTexte.text = $"Крит урон: {CritDamage.ToString()}";
        CritChanceText.text = $"Шанс крита: {CritChance.ToString()}";
        EvasionText.text = $"Уклонение: {Evasion.ToString()}";
        AccuracyText.text = $"Точность: {Accuracy.ToString()}";
        DamageBonusText.text = $"Бонус урона: {DamageBonus.ToString()}";
        AntiCritText.text = $"Анти-крит: {AntiCrit.ToString()}";
        ControlText.text = $"Контроль: {Control.ToString()}";
        AntiControlText.text = $"Анти-контроль: {AntiControl.ToString()}";
        TreatmentText.text = $"Лечение: {Treatment.ToString()}";
        RecoveryText.text = $"Восстановление: {Recovery.ToString()}";

    }
}
