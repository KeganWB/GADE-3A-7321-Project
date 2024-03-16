//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Game Objects/Player Input.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input"",
    ""maps"": [
        {
            ""name"": ""walking"",
            ""id"": ""1f28d12b-0872-4eea-b2c5-2887f5633f69"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""Value"",
                    ""id"": ""9b900a73-74dd-4964-9c03-beb5e34fa999"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jumping"",
                    ""type"": ""Button"",
                    ""id"": ""14500eec-ad6d-43bb-bbfb-fb3378f9f9bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""7309f592-5b80-437d-9b00-4ebfda494a0e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9e890152-36fc-4493-8b4e-85daee6fd8c8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1dfaf80a-ca18-42b0-9a35-f1eff69deaf4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""085b9b6e-5c40-428c-8125-ff857317da56"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7c65f9e3-b426-4644-a9fc-5e0155a82a34"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2b5743bc-0936-4e65-b8ff-7422d5311785"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""61bd227e-37a7-4c43-9dc0-f7bae683bb0f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jumping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76b9e864-8ed0-49c1-91a0-c5a8579a6571"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e131cf1-8d94-486a-b80b-971e56b63a46"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // walking
        m_walking = asset.FindActionMap("walking", throwIfNotFound: true);
        m_walking_Moving = m_walking.FindAction("Moving", throwIfNotFound: true);
        m_walking_Jumping = m_walking.FindAction("Jumping", throwIfNotFound: true);
        m_walking_Look = m_walking.FindAction("Look", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // walking
    private readonly InputActionMap m_walking;
    private List<IWalkingActions> m_WalkingActionsCallbackInterfaces = new List<IWalkingActions>();
    private readonly InputAction m_walking_Moving;
    private readonly InputAction m_walking_Jumping;
    private readonly InputAction m_walking_Look;
    public struct WalkingActions
    {
        private @PlayerInput m_Wrapper;
        public WalkingActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moving => m_Wrapper.m_walking_Moving;
        public InputAction @Jumping => m_Wrapper.m_walking_Jumping;
        public InputAction @Look => m_Wrapper.m_walking_Look;
        public InputActionMap Get() { return m_Wrapper.m_walking; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WalkingActions set) { return set.Get(); }
        public void AddCallbacks(IWalkingActions instance)
        {
            if (instance == null || m_Wrapper.m_WalkingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WalkingActionsCallbackInterfaces.Add(instance);
            @Moving.started += instance.OnMoving;
            @Moving.performed += instance.OnMoving;
            @Moving.canceled += instance.OnMoving;
            @Jumping.started += instance.OnJumping;
            @Jumping.performed += instance.OnJumping;
            @Jumping.canceled += instance.OnJumping;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
        }

        private void UnregisterCallbacks(IWalkingActions instance)
        {
            @Moving.started -= instance.OnMoving;
            @Moving.performed -= instance.OnMoving;
            @Moving.canceled -= instance.OnMoving;
            @Jumping.started -= instance.OnJumping;
            @Jumping.performed -= instance.OnJumping;
            @Jumping.canceled -= instance.OnJumping;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
        }

        public void RemoveCallbacks(IWalkingActions instance)
        {
            if (m_Wrapper.m_WalkingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWalkingActions instance)
        {
            foreach (var item in m_Wrapper.m_WalkingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WalkingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WalkingActions @walking => new WalkingActions(this);
    public interface IWalkingActions
    {
        void OnMoving(InputAction.CallbackContext context);
        void OnJumping(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}