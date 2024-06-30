using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WeaponChoosing : MonoBehaviour
{
   [SerializeField] private GameObject _choosePanel;
   [SerializeField] private Transform _containerForSpawn;
   
   [SerializeField] private Button _singleWeaponBtn;
   [SerializeField] private Button _doubleWeaponBtn;
   [SerializeField] private Button _tripleWeaponBtn;
 
   private PlayerSettings _playerSettings;
   private PlayerFactory _playerFactory;
   
   [Inject]
   private void Construct(PlayerSettings playerSettings, PlayerFactory playerFactory)
   {
      _playerSettings = playerSettings;
      _playerFactory = playerFactory;
   }

   private void Awake()
   {
      ShowChoosePanel();

      InitButtons();
      
      Settings();
   }

   private void ShowChoosePanel()
   {
      _choosePanel.SetActive(true);
      Time.timeScale = 0;
   }
   
   private void ChooseWeapon(WeaponType weaponType)
   {
      Time.timeScale = 1;
      _choosePanel.SetActive(false);
      
      _playerSettings.selectedWeapon = weaponType;

      _playerFactory.Create();
   }

   private void InitButtons()
   {
      _singleWeaponBtn.onClick.AddListener(()=> ChooseWeapon(WeaponType.SingleLaser));
      _doubleWeaponBtn.onClick.AddListener(()=> ChooseWeapon(WeaponType.DoubleLaser));
      _tripleWeaponBtn.onClick.AddListener(()=> ChooseWeapon(WeaponType.TripleLaser));
   }
   
   private void Settings()
   {
        
   }
}
