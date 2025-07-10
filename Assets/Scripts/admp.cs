using Services.CurrencyService;
using Services.DataStorageService;
using Services.SaveLoad;
using UnityEngine;
using Zenject;
using System.IO;

public class admp : MonoBehaviour
{
    [Inject] private IPersistenceProgressService _progressService;
    [Inject] private ISaveLoadService _saveLoadService;
    [Inject] private ICurrencyService _currencyService;

    public int _coefficient = 5;

    void Start()
    {
        Time.timeScale = _coefficient;

        int currentMoney = _currencyService.Money;
        
        if (currentMoney == 0)
        {
            LoadDefaultData();
        }
        
        //_saveLoadService.ResetProgress();

    }

    private void LoadDefaultData()
    {
        string jsonData = @"{
            ""ProgressData"": {
                ""Staff"": {
                    ""Chef"": {
                        ""Speed"": 3.5,
                        ""FoodSearchingTimeDelay"": 0.0,
                        ""CookingTimeDelay"": 0.0
                    },
                    ""Waiter"": {
                        ""Speed"": 3.5
                    }
                },
                ""Meals"": {
                    ""PriceMultiplier"": 1.0
                },
                ""Customers"": {
                    ""EatingTimeDelay"": 0.0
                },
                ""Upgrades"": [
                    {
                        ""UpgradeType"": ""Meal"",
                        ""Description"": ""Raising prices by 5%"",
                        ""Prices"": [1000, 2000, 3000, 5000]
                    },
                    {
                        ""UpgradeType"": ""Customers"",
                        ""Description"": ""Reduce eating time by 2sec"",
                        ""Prices"": [1500, 2500, 4500, 6500, 8000]
                    },
                    {
                        ""UpgradeType"": ""Chef"",
                        ""Description"": ""Reduce food searching time by 2sec"",
                        ""Prices"": [2000, 2500, 3000]
                    },
                    {
                        ""UpgradeType"": ""Chef"",
                        ""Description"": ""Reduce cooking time by 2sec"",
                        ""Prices"": [2500, 3000, 3500]
                    },
                    {
                        ""UpgradeType"": ""Chef"",
                        ""Description"": ""Increase speed by 10%"",
                        ""Prices"": [500, 750, 1000, 1250, 1500]
                    },
                    {
                        ""UpgradeType"": ""Waiter"",
                        ""Description"": ""Increase speed by 10%"",
                        ""Prices"": [500, 750, 1000, 1250, 1500]
                    }
                ],
                ""PurchasedHallItems"": [
                    {
                        ""TypeId"": 1,
                        ""PurchaseOrder"": 1,
                        ""Position"": {""x"": -9.0, ""y"": 0.0, ""z"": 8.0},
                        ""Rotation"": {""x"": 0.0000025044780613825425, ""y"": 0.0, ""z"": 0.0}
                    },
                    {
                        ""TypeId"": 2,
                        ""PurchaseOrder"": 1,
                        ""Position"": {""x"": -9.0, ""y"": 0.0, ""z"": 6.48},
                        ""Rotation"": {""x"": 0.0, ""y"": 0.0, ""z"": 0.0}
                    },
                    {
                        ""TypeId"": 2,
                        ""PurchaseOrder"": 2,
                        ""Position"": {""x"": -9.0, ""y"": 0.0, ""z"": 9.52},
                        ""Rotation"": {""x"": -0.0000025044780613825425, ""y"": 180.0, ""z"": 0.0}
                    },
                    {
                        ""TypeId"": 2,
                        ""PurchaseOrder"": 3,
                        ""Position"": {""x"": -7.48, ""y"": 0.0, ""z"": 8.0},
                        ""Rotation"": {""x"": 0.0, ""y"": 270.0, ""z"": -0.0000025044780613825425}
                    },
                    {
                        ""TypeId"": 2,
                        ""PurchaseOrder"": 4,
                        ""Position"": {""x"": -10.52, ""y"": 0.0, ""z"": 8.0},
                        ""Rotation"": {""x"": 0.0, ""y"": 90.0, ""z"": 0.0000025044780613825425}
                    }
                ],
                ""PurchasedKitchenItems"": [
                    {
                        ""TypeId"": 2,
                        ""PurchaseOrder"": 1,
                        ""Position"": {""x"": 6.0, ""y"": 0.0, ""z"": 0.0},
                        ""Rotation"": {""x"": 0.0, ""y"": 0.0, ""z"": 0.0}
                    },
                    {
                        ""TypeId"": 4,
                        ""PurchaseOrder"": 1,
                        ""Position"": {""x"": -3.8, ""y"": 0.0, ""z"": -1.0},
                        ""Rotation"": {""x"": 0.0000025044780613825425, ""y"": 0.0, ""z"": 0.0}
                    },
                    {
                        ""TypeId"": 2,
                        ""PurchaseOrder"": 2,
                        ""Position"": {""x"": 8.0, ""y"": 0.0, ""z"": -5.0},
                        ""Rotation"": {""x"": 0.0, ""y"": 0.0, ""z"": 0.0}
                    },
                    {
                        ""TypeId"": 1,
                        ""PurchaseOrder"": 1,
                        ""Position"": {""x"": 1.5, ""y"": 0.0, ""z"": -5.0},
                        ""Rotation"": {""x"": 0.0, ""y"": 0.0, ""z"": 0.0}
                    },
                    {
                        ""TypeId"": 3,
                        ""PurchaseOrder"": 1,
                        ""Position"": {""x"": 15.5, ""y"": 0.0, ""z"": -25.0},
                        ""Rotation"": {""x"": 0.0, ""y"": 180.0, ""z"": 0.0}
                    }
                ],
                ""PurchasedStuff"": [
                    {
                        ""TypeId"": 2,
                        ""PurchaseOrder"": 0,
                        ""Position"": {""x"": -4.5, ""y"": 0.0, ""z"": -17.0},
                        ""Rotation"": {""x"": 0.0, ""y"": 0.0, ""z"": 0.0}
                    },
                    {
                        ""TypeId"": 3,
                        ""PurchaseOrder"": 0,
                        ""Position"": {""x"": -8.5, ""y"": 0.0, ""z"": -5.0},
                        ""Rotation"": {""x"": 0.0, ""y"": 0.0, ""z"": 0.0}
                    }
                ],
                ""Money"": 1000,
                ""Stars"": 0
            }
        }";


        var wrapper = JsonUtility.FromJson<PlayerDataWrapper>(jsonData);

        _progressService.PlayerData.ProgressData = wrapper.ProgressData;



        _saveLoadService.SaveProgress();
    }
}

// JSON yapýsýna uygun wrapper sýnýfý
[System.Serializable]
public class PlayerDataWrapper
{
    public PlayerProgressData ProgressData;
}