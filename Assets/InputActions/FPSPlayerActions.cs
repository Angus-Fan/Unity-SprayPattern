// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/FPSPlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FPSPlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FPSPlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FPSPlayerActions"",
    ""maps"": [
        {
            ""name"": ""FPSActor"",
            ""id"": ""6ab4752b-d545-45e8-b813-f609d7cb4b4b"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""566f114c-9bb1-4cb9-982a-145920d62a1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""766310cf-0fcf-4169-a769-d9b859d4fb3d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraControls"",
                    ""type"": ""Value"",
                    ""id"": ""b1cfdec8-9ebb-471e-bb3f-7f356192a0c3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""58c1a135-91ca-4ac1-9f13-c72bca427ca8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASDMovement"",
                    ""id"": ""4cff19ad-10dd-4ae8-9b29-a73462ca08c6"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7280e51c-5ae6-4a63-b211-773b78ff6d47"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8620a135-f5b1-48be-bcee-7a2f6518addb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6812619a-7e85-484a-bc1a-deaee8a0a3a0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a4f29c6f-a6a1-4193-a82c-e165025b6bcc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3a180210-33b4-4fa7-92d9-29bd866f8e65"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FPSActor
        m_FPSActor = asset.FindActionMap("FPSActor", throwIfNotFound: true);
        m_FPSActor_Jump = m_FPSActor.FindAction("Jump", throwIfNotFound: true);
        m_FPSActor_Movement = m_FPSActor.FindAction("Movement", throwIfNotFound: true);
        m_FPSActor_CameraControls = m_FPSActor.FindAction("CameraControls", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // FPSActor
    private readonly InputActionMap m_FPSActor;
    private IFPSActorActions m_FPSActorActionsCallbackInterface;
    private readonly InputAction m_FPSActor_Jump;
    private readonly InputAction m_FPSActor_Movement;
    private readonly InputAction m_FPSActor_CameraControls;
    public struct FPSActorActions
    {
        private @FPSPlayerActions m_Wrapper;
        public FPSActorActions(@FPSPlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_FPSActor_Jump;
        public InputAction @Movement => m_Wrapper.m_FPSActor_Movement;
        public InputAction @CameraControls => m_Wrapper.m_FPSActor_CameraControls;
        public InputActionMap Get() { return m_Wrapper.m_FPSActor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPSActorActions set) { return set.Get(); }
        public void SetCallbacks(IFPSActorActions instance)
        {
            if (m_Wrapper.m_FPSActorActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnMovement;
                @CameraControls.started -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnCameraControls;
                @CameraControls.performed -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnCameraControls;
                @CameraControls.canceled -= m_Wrapper.m_FPSActorActionsCallbackInterface.OnCameraControls;
            }
            m_Wrapper.m_FPSActorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CameraControls.started += instance.OnCameraControls;
                @CameraControls.performed += instance.OnCameraControls;
                @CameraControls.canceled += instance.OnCameraControls;
            }
        }
    }
    public FPSActorActions @FPSActor => new FPSActorActions(this);
    public interface IFPSActorActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnCameraControls(InputAction.CallbackContext context);
    }
}
