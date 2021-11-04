// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerController/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Tetrimino"",
            ""id"": ""2562166a-b545-4ee9-8fae-8c5e7cda9b03"",
            ""actions"": [
                {
                    ""name"": ""RotateClockwise"",
                    ""type"": ""Button"",
                    ""id"": ""78ad9cfd-ff34-4cd4-a348-5edbf845398a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""367eed8d-39f4-4733-ae47-4e6d1095ad09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""b1a4c4d8-4e07-41e6-ad0e-66b1f96ffbca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HardDrop"",
                    ""type"": ""Button"",
                    ""id"": ""81f26550-bf39-4c3b-9fb5-f1e60f73bd3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SoftDrop"",
                    ""type"": ""Button"",
                    ""id"": ""18fb11e9-0ae0-45f1-a3b1-b76e7dd7d0e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7aa26aee-6b9e-4f92-b8ed-4c94d22494a5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""408846ef-b579-4eec-8ff3-6786eee09519"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc474a14-0e95-424b-bef6-0c918e4a16b1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3751bc14-c885-4cfe-a95e-00a20ba270a2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f83e1206-a44a-4e4b-91ca-786d20f7fdd6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HardDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fb7b282-0f1b-46ad-b173-385523572517"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoftDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Tetrimino
        m_Tetrimino = asset.FindActionMap("Tetrimino", throwIfNotFound: true);
        m_Tetrimino_RotateClockwise = m_Tetrimino.FindAction("RotateClockwise", throwIfNotFound: true);
        m_Tetrimino_MoveLeft = m_Tetrimino.FindAction("MoveLeft", throwIfNotFound: true);
        m_Tetrimino_MoveRight = m_Tetrimino.FindAction("MoveRight", throwIfNotFound: true);
        m_Tetrimino_HardDrop = m_Tetrimino.FindAction("HardDrop", throwIfNotFound: true);
        m_Tetrimino_SoftDrop = m_Tetrimino.FindAction("SoftDrop", throwIfNotFound: true);
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

    // Tetrimino
    private readonly InputActionMap m_Tetrimino;
    private ITetriminoActions m_TetriminoActionsCallbackInterface;
    private readonly InputAction m_Tetrimino_RotateClockwise;
    private readonly InputAction m_Tetrimino_MoveLeft;
    private readonly InputAction m_Tetrimino_MoveRight;
    private readonly InputAction m_Tetrimino_HardDrop;
    private readonly InputAction m_Tetrimino_SoftDrop;
    public struct TetriminoActions
    {
        private @PlayerControls m_Wrapper;
        public TetriminoActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotateClockwise => m_Wrapper.m_Tetrimino_RotateClockwise;
        public InputAction @MoveLeft => m_Wrapper.m_Tetrimino_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Tetrimino_MoveRight;
        public InputAction @HardDrop => m_Wrapper.m_Tetrimino_HardDrop;
        public InputAction @SoftDrop => m_Wrapper.m_Tetrimino_SoftDrop;
        public InputActionMap Get() { return m_Wrapper.m_Tetrimino; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TetriminoActions set) { return set.Get(); }
        public void SetCallbacks(ITetriminoActions instance)
        {
            if (m_Wrapper.m_TetriminoActionsCallbackInterface != null)
            {
                @RotateClockwise.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnRotateClockwise;
                @RotateClockwise.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnRotateClockwise;
                @RotateClockwise.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnRotateClockwise;
                @MoveLeft.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMoveRight;
                @HardDrop.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnHardDrop;
                @HardDrop.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnHardDrop;
                @HardDrop.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnHardDrop;
                @SoftDrop.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnSoftDrop;
                @SoftDrop.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnSoftDrop;
                @SoftDrop.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnSoftDrop;
            }
            m_Wrapper.m_TetriminoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotateClockwise.started += instance.OnRotateClockwise;
                @RotateClockwise.performed += instance.OnRotateClockwise;
                @RotateClockwise.canceled += instance.OnRotateClockwise;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @HardDrop.started += instance.OnHardDrop;
                @HardDrop.performed += instance.OnHardDrop;
                @HardDrop.canceled += instance.OnHardDrop;
                @SoftDrop.started += instance.OnSoftDrop;
                @SoftDrop.performed += instance.OnSoftDrop;
                @SoftDrop.canceled += instance.OnSoftDrop;
            }
        }
    }
    public TetriminoActions @Tetrimino => new TetriminoActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface ITetriminoActions
    {
        void OnRotateClockwise(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnHardDrop(InputAction.CallbackContext context);
        void OnSoftDrop(InputAction.CallbackContext context);
    }
}
