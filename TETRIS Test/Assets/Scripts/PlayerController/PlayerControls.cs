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
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""367eed8d-39f4-4733-ae47-4e6d1095ad09"",
                    ""expectedControlType"": ""Vector2"",
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
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""a43d5709-4642-4a90-ae8e-3cd2d860f935"",
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
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3c9ba829-adf5-452b-9db0-b2f3f16cfc4c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b6ca1995-945f-4707-8366-4c677f02f890"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d5e94b3d-b536-41dd-8167-4d62053f646f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1048f94c-4ee2-4330-820a-24c30010cd49"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""771ea0f6-17bb-4c01-9491-b2679a6dbc40"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8f507e26-30db-492c-89c5-5b87bbc0f405"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""52d78844-f6b7-477d-bcd6-e72625603d8b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f102064e-ef47-4299-b1b9-8cdd422a5eff"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""87282a6f-6567-419e-8330-36712893da15"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eb8c6dc5-c976-482c-9458-e3bdc6506840"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                },
                {
                    ""name"": """",
                    ""id"": ""e2939106-299f-4a98-89b3-31e31bf4f264"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoftDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""030d0c0f-b444-45e2-ac78-9d66834390de"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""1b264a22-44b1-4acf-8cf1-8f4756feb039"",
            ""actions"": [
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""e7fc709a-9e0f-420e-b2eb-9566936a236f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""6c427dee-4962-4642-a169-4875c4edaab5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""77455235-b928-4bcb-8196-fe4cb4b46e46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""63dcb043-7322-492b-b27b-979640715c16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a78337ee-4d34-4200-ae77-064facd47ed7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""707b3c52-2f95-4fdf-983b-6f7cc60c73e0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20163e0c-b61c-4864-bc27-d130f17c1c94"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b5294aa-cfa1-4aea-83f6-4909b3d5bd91"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d0b7a08-28a9-440d-b359-aad448768969"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf606161-2ffb-4242-811a-6c18e1c93dc0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""235f03bd-3e24-440b-872e-2a0b2c979175"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36f2df4a-9f6f-473c-9de2-ab54b627e77f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
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
        m_Tetrimino_Move = m_Tetrimino.FindAction("Move", throwIfNotFound: true);
        m_Tetrimino_HardDrop = m_Tetrimino.FindAction("HardDrop", throwIfNotFound: true);
        m_Tetrimino_SoftDrop = m_Tetrimino.FindAction("SoftDrop", throwIfNotFound: true);
        m_Tetrimino_Pause = m_Tetrimino.FindAction("Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_MoveUp = m_UI.FindAction("MoveUp", throwIfNotFound: true);
        m_UI_MoveDown = m_UI.FindAction("MoveDown", throwIfNotFound: true);
        m_UI_Confirm = m_UI.FindAction("Confirm", throwIfNotFound: true);
        m_UI_Exit = m_UI.FindAction("Exit", throwIfNotFound: true);
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
    private readonly InputAction m_Tetrimino_Move;
    private readonly InputAction m_Tetrimino_HardDrop;
    private readonly InputAction m_Tetrimino_SoftDrop;
    private readonly InputAction m_Tetrimino_Pause;
    public struct TetriminoActions
    {
        private @PlayerControls m_Wrapper;
        public TetriminoActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotateClockwise => m_Wrapper.m_Tetrimino_RotateClockwise;
        public InputAction @Move => m_Wrapper.m_Tetrimino_Move;
        public InputAction @HardDrop => m_Wrapper.m_Tetrimino_HardDrop;
        public InputAction @SoftDrop => m_Wrapper.m_Tetrimino_SoftDrop;
        public InputAction @Pause => m_Wrapper.m_Tetrimino_Pause;
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
                @Move.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnMove;
                @HardDrop.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnHardDrop;
                @HardDrop.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnHardDrop;
                @HardDrop.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnHardDrop;
                @SoftDrop.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnSoftDrop;
                @SoftDrop.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnSoftDrop;
                @SoftDrop.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnSoftDrop;
                @Pause.started -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_TetriminoActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_TetriminoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotateClockwise.started += instance.OnRotateClockwise;
                @RotateClockwise.performed += instance.OnRotateClockwise;
                @RotateClockwise.canceled += instance.OnRotateClockwise;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @HardDrop.started += instance.OnHardDrop;
                @HardDrop.performed += instance.OnHardDrop;
                @HardDrop.canceled += instance.OnHardDrop;
                @SoftDrop.started += instance.OnSoftDrop;
                @SoftDrop.performed += instance.OnSoftDrop;
                @SoftDrop.canceled += instance.OnSoftDrop;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public TetriminoActions @Tetrimino => new TetriminoActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_MoveUp;
    private readonly InputAction m_UI_MoveDown;
    private readonly InputAction m_UI_Confirm;
    private readonly InputAction m_UI_Exit;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_UI_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_UI_MoveDown;
        public InputAction @Confirm => m_Wrapper.m_UI_Confirm;
        public InputAction @Exit => m_Wrapper.m_UI_Exit;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @MoveUp.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveDown;
                @Confirm.started -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
                @Exit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
        void OnMove(InputAction.CallbackContext context);
        void OnHardDrop(InputAction.CallbackContext context);
        void OnSoftDrop(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}
