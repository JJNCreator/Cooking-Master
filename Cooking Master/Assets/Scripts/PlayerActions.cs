// GENERATED AUTOMATICALLY FROM 'Assets/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""BluePlayer"",
            ""id"": ""893ec5e6-3237-4174-b2b3-fd78ff88da4d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""89393815-ec30-470c-9c3b-9c2c0f532920"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""4c609471-9806-466d-ba77-ee813dc07059"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Move"",
                    ""id"": ""c6511ae3-7b15-4ef5-8c14-1521c8c13a64"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cc4f43d7-661a-4b28-a4dd-6cc695814961"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6c3795cf-5065-4d83-9a09-7d5a3cb86697"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cebc7448-1467-4da1-b0a1-c4326ae8f87b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""606b723c-9cf5-4a02-bfdc-077b650d1d0b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f0e4acaa-7846-48d2-baec-c31fc8d4f3c5"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RedPlayer"",
            ""id"": ""3a7872d0-b0c7-40b5-ae03-75cb36680826"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1055b541-6fb5-4a1a-aead-d3475f813c14"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""fbe36e84-c3de-48a7-8fa6-935b6a4627d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Move"",
                    ""id"": ""b8893105-9f53-4cfc-bb6e-75ae4266363d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5012281b-da83-4f98-a72f-e7639e91a1ec"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f34d6020-f7d3-4f16-ba6a-8f4d480f6c8f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fd7a7ed3-b895-4a18-a135-18d7f9ecd54a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""efabc161-fb7b-467d-8f36-f93da885e01b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""006658af-9de0-46be-bb6b-62d30d027081"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
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
            ""devices"": []
        }
    ]
}");
        // BluePlayer
        m_BluePlayer = asset.FindActionMap("BluePlayer", throwIfNotFound: true);
        m_BluePlayer_Movement = m_BluePlayer.FindAction("Movement", throwIfNotFound: true);
        m_BluePlayer_Interact = m_BluePlayer.FindAction("Interact", throwIfNotFound: true);
        // RedPlayer
        m_RedPlayer = asset.FindActionMap("RedPlayer", throwIfNotFound: true);
        m_RedPlayer_Movement = m_RedPlayer.FindAction("Movement", throwIfNotFound: true);
        m_RedPlayer_Interact = m_RedPlayer.FindAction("Interact", throwIfNotFound: true);
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

    // BluePlayer
    private readonly InputActionMap m_BluePlayer;
    private IBluePlayerActions m_BluePlayerActionsCallbackInterface;
    private readonly InputAction m_BluePlayer_Movement;
    private readonly InputAction m_BluePlayer_Interact;
    public struct BluePlayerActions
    {
        private @PlayerActions m_Wrapper;
        public BluePlayerActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_BluePlayer_Movement;
        public InputAction @Interact => m_Wrapper.m_BluePlayer_Interact;
        public InputActionMap Get() { return m_Wrapper.m_BluePlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BluePlayerActions set) { return set.Get(); }
        public void SetCallbacks(IBluePlayerActions instance)
        {
            if (m_Wrapper.m_BluePlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_BluePlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BluePlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BluePlayerActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_BluePlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_BluePlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_BluePlayerActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_BluePlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public BluePlayerActions @BluePlayer => new BluePlayerActions(this);

    // RedPlayer
    private readonly InputActionMap m_RedPlayer;
    private IRedPlayerActions m_RedPlayerActionsCallbackInterface;
    private readonly InputAction m_RedPlayer_Movement;
    private readonly InputAction m_RedPlayer_Interact;
    public struct RedPlayerActions
    {
        private @PlayerActions m_Wrapper;
        public RedPlayerActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_RedPlayer_Movement;
        public InputAction @Interact => m_Wrapper.m_RedPlayer_Interact;
        public InputActionMap Get() { return m_Wrapper.m_RedPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RedPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IRedPlayerActions instance)
        {
            if (m_Wrapper.m_RedPlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_RedPlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_RedPlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_RedPlayerActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_RedPlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_RedPlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_RedPlayerActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_RedPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public RedPlayerActions @RedPlayer => new RedPlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IBluePlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IRedPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
