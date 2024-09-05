using Helpers;
using UnityEngine;
using UnityEngine.AI;

public class ReferenceHolder : MonoBehaviour
{
    private Camera _mainCam;
    public Camera mainCam { get { return _mainCam ? _mainCam : _mainCam = Camera.main; } }

    private CharacterBehaviourStateHandler _charBehaviourStateHandler;
    public CharacterBehaviourStateHandler charBehaviourStateHandler { get { return _charBehaviourStateHandler ? _charBehaviourStateHandler : _charBehaviourStateHandler = GetComponent<CharacterBehaviourStateHandler>(); } }

    //private State.StateHandler<Enums.BehaviourState> _stateHandler;
    //public State.StateHandler<Enums.BehaviourState> stateHandler { get { return _stateHandler != null ? _stateHandler : _stateHandler = GetComponent<State.StateHandler<Enums.BehaviourState>>(); } }

    private CharacterInfoHolder _infoHolder;
    public CharacterInfoHolder infoHolder { get { return _infoHolder ? _infoHolder : _infoHolder = GetComponent<CharacterInfoHolder>(); } }

    private WeaponHandler _weaponHandler;
    public WeaponHandler weaponHandler { get { return _weaponHandler ? _weaponHandler : _weaponHandler = GetComponent<WeaponHandler>(); } }

    private SkillHandler _skillHandler;
    public SkillHandler skillHandler { get { return _skillHandler ? _skillHandler : _skillHandler = GetComponent<SkillHandler>(); } }

    private Animator _animator;
    public Animator animator { get { return _animator ? _animator : _animator = GetComponent<Animator>(); } }

    private CharacterController _charController;
    public CharacterController charController { get { return _charController ? _charController : _charController = GetComponent<CharacterController>(); } }

    private NavMeshAgent _navMeshAgent;
    public NavMeshAgent navMeshAgent { get { return _navMeshAgent ? _navMeshAgent : _navMeshAgent = GetComponent<NavMeshAgent>(); } }

    private CharacterStatHandler _statHandler;
    public CharacterStatHandler statHandler { get { return _statHandler ? _statHandler : _statHandler = GetComponent<CharacterStatHandler>(); } }

    private InputPool _inputPool;
    public InputPool inputPool { get { return _inputPool ? _inputPool : _inputPool = Scripts.InputPool(); } }

    private PoolManager _poolManager;
    public PoolManager poolManager { get { return _poolManager ? _poolManager : _poolManager = Scripts.PoolManager(); } }

}
