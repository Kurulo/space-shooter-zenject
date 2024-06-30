using System;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _gun;
    
    public void SetGun(GameObject gun) => _gun = gun; 

    private IInputController _inputController;
    private IWeaponFactory _weaponFactory;
    private PlayerSettings _playerSettings;

    private Action<Vector3> MovingAction;
    private Action<bool> ShootAction;

    [Inject]
    public void Construct(IInputController inputController, PlayerSettings playerSettings, IWeaponFactory weaponFactory) {
        _inputController = inputController;
        _playerSettings = playerSettings;
        _weaponFactory = weaponFactory;
    }

    private void Start() {
       CreateAndSubscribeToActions();
       TryCreateWeapon();
    }

    public void Moving(Vector3 mousePosition) {
        transform.position = mousePosition;
    }

    public void Shoot(bool state) {
        Debug.Log($"Shoot state: {state.ToString()}");
        if (_gun != null) 
            _gun.SetActive(state);
    }

    private void OnDestroy() {
        _inputController.Move -= Moving;
        _inputController.Shoot -= Shoot;  
    }

    private void CreateAndSubscribeToActions() {
        if (MovingAction == null) {
            MovingAction = Moving;
        }

        if (ShootAction == null) {
            ShootAction = Shoot;
        }

        _inputController.Shoot += ShootAction;
        _inputController.Move += MovingAction;
    }

    private void TryCreateWeapon() {
        if (_gun.GetComponentInChildren<PlayerWeapon>() == null) {
            _weaponFactory.Create(
                _playerSettings.selectedWeapon,
                WeaponOwner.Player, 
                _gun.transform);
        }
    }
}
