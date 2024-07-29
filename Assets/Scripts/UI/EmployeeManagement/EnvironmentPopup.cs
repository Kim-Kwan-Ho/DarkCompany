using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentPopup : UIPopup
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _buyFlowerButton;
    [SerializeField] private TextMeshProUGUI _flowerCostText;
    [SerializeField] private Button _buyLoyaltyButton;
    [SerializeField] private TextMeshProUGUI _loyaltyCostText;
    [SerializeField] private Button _buyLuckButton;
    [SerializeField] private TextMeshProUGUI _luckCostText;

    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(ClosePopup);
        _buyFlowerButton.onClick.AddListener(BuyFlower);
        _buyLoyaltyButton.onClick.AddListener(BuyLoyalty);
        _buyLuckButton.onClick.AddListener(BuyLuck);
    }

    private void BuyFlower()
    {
        if (GameSceneManager.Instance.CurrentMoney >= EnvironmentsCost.FLOWER_COST)
        {
            UpgradeManager.Instance.FlowerCount += 1;
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-EnvironmentsCost.FLOWER_COST);
            UpgradeManager.Instance.EventUpgrade.CallBuyFlower();
        }
    }
    private void BuyLoyalty()
    {
        if (GameSceneManager.Instance.CurrentMoney >= EnvironmentsCost.LOYALTY_COST)
        {
            UpgradeManager.Instance.Loyalty += 1;
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-EnvironmentsCost.LOYALTY_COST);
        }
    }
    private void BuyLuck()
    {
        if (GameSceneManager.Instance.CurrentMoney >= EnvironmentsCost.LUCK_COST)
        {
            UpgradeManager.Instance.Luck += 1;
            GameSceneManager.Instance.EventGameScene.CallMoneyChanged(-EnvironmentsCost.LUCK_COST);
        }
    }

    private void Update()
    {
        if (UpgradeManager.Instance.FlowerCount >= 5)
        {
            _buyFlowerButton.interactable = false;
            _flowerCostText.text = "Max";
        }

    }

#if UNITY_EDITOR

    protected override void OnBindField()
    {
        base.OnBindField();
        _closeButton = FindGameObjectInChildren<Button>("CloseButton");
        _buyFlowerButton = FindGameObjectInChildren<Button>("BuyFlowerButton");
        _flowerCostText = FindGameObjectInChildren<TextMeshProUGUI>("FlowerCostText");
        _buyLoyaltyButton = FindGameObjectInChildren<Button>("BuyLoyaltyButton");
        _loyaltyCostText = FindGameObjectInChildren<TextMeshProUGUI>("LoyaltyCostText");
        _buyLuckButton = FindGameObjectInChildren<Button>("BuyLuckButton");
        _luckCostText = FindGameObjectInChildren<TextMeshProUGUI>("LuckCostText");

    }
#endif


}
