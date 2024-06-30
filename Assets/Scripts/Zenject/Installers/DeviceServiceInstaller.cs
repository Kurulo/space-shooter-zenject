using System;
using UnityEngine;
using Zenject;

public class DeviceServiceInstaller : MonoInstaller
{
    [Header("Container")]
    [SerializeField] private Transform _inputContainer;
    
    [Header("Input Types")]
    [SerializeField] private DesktopInput _desktopInput;
    [SerializeField] private HandheldInput _handheldInput;
    
    public override void InstallBindings()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        { 
            BindDesktop();
        }
        
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            BindDesktop();
        }
    }
    
    private void BindDesktop()
    {
        DesktopInput desktopInput = Container.InstantiatePrefabForComponent<DesktopInput>(
            _desktopInput, _desktopInput.transform.position, Quaternion.identity, _inputContainer);
            
        Container.Bind<IInputController>().To<DesktopInput>().FromInstance(desktopInput).AsSingle();
    }
    
    private void BindHandheld()
    {
        HandheldInput handheldInput = Container.InstantiatePrefabForComponent<HandheldInput>(
            _handheldInput, _handheldInput.transform.position, Quaternion.identity, _inputContainer);
            
        Container.Bind<IInputController>().To<HandheldInput>().FromInstance(handheldInput).AsSingle();
    }
}