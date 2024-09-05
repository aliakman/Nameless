using State;
using Helpers;

public class CharacterBehaviourStateHandler : StateHandler<Enums.BehaviourStates>
{
    #region States
    #region CommonStates
    private MoveState _moveState;
    public MoveState moveState { get { return _moveState != null ? _moveState : _moveState = new MoveState(Enums.BehaviourStates.Move, this); } }

    private SpawnState _spawnState;
    public SpawnState spawnState { get { return _spawnState != null ? _spawnState : _spawnState = new SpawnState(Enums.BehaviourStates.Spawn, this); } }
    #endregion

    #region PlayerStates
    private JumpState _jumpState;
    public JumpState jumpState { get { return _jumpState != null ? _jumpState : _jumpState = new JumpState(Enums.BehaviourStates.Jump, this); } }

    private DashState _dashState;
    public DashState dashState { get { return _dashState != null ? _dashState : _dashState = new DashState(Enums.BehaviourStates.Dash, this); } }

    private BasicAttackState _basicAttackState;
    public BasicAttackState basicAttackState { get { return _basicAttackState != null ? _basicAttackState : _basicAttackState = new BasicAttackState(Enums.BehaviourStates.BasicAttack, this); } }

    private AdvancedAttackState _advancedAttackState;
    public AdvancedAttackState advancedAttackState { get { return _advancedAttackState != null ? _advancedAttackState : _advancedAttackState = new AdvancedAttackState(Enums.BehaviourStates.AdvancedAttack, this); } }
    #endregion

    #region EnemyStates
    private PatrolState _patrolState;
    public PatrolState patrolState { get { return _patrolState != null ? _patrolState : _patrolState = new PatrolState(Enums.BehaviourStates.Patrol, this); } }

    private AttackState _attackState;
    public AttackState attackState { get { return _attackState != null ? _attackState : _attackState = new AttackState(Enums.BehaviourStates.Attack, this); } }

    private IdleState _idleState;
    public IdleState idleState { get { return _idleState != null ? _idleState : _idleState = new IdleState(Enums.BehaviourStates.Idle, this); } }
    #endregion
    #endregion

    private void OnEnable()
    {
        if (infoHolder.characterStat.characterType == Enums.CharacterTypes.Player)
            EventManager.Scripts.PlayerBehaviourStateHandler += () => this;
    }
    private void OnDisable()
    {
        if (infoHolder.characterStat.characterType == Enums.CharacterTypes.Player)
            EventManager.Scripts.PlayerBehaviourStateHandler -= () => this;
    }

    private void Start()
    {
        SetStateDictionary();
        if (infoHolder.characterStat.characterType == Enums.CharacterTypes.Player)
            ChangeMainState(Enums.BehaviourStates.Move);
        else
            ChangeMainState(Enums.BehaviourStates.Idle);
        //ChangeMainState(Enums.BehaviourStates.Spawn);
    }

    public void SetStateDictionary()
    {
        StateDictionary.Add(Enums.BehaviourStates.Move, moveState);
        StateDictionary.Add(Enums.BehaviourStates.Jump, jumpState);
        StateDictionary.Add(Enums.BehaviourStates.Dash, dashState);
        StateDictionary.Add(Enums.BehaviourStates.BasicAttack, basicAttackState);
        StateDictionary.Add(Enums.BehaviourStates.AdvancedAttack, advancedAttackState);
        StateDictionary.Add(Enums.BehaviourStates.Patrol, patrolState);
        StateDictionary.Add(Enums.BehaviourStates.Attack, attackState);
        StateDictionary.Add(Enums.BehaviourStates.Idle, idleState);
        StateDictionary.Add(Enums.BehaviourStates.Spawn, spawnState);
    
    }

    public override void SetMainStateNone()
    {
        base.SetMainStateNone();
        mainState = Enums.BehaviourStates.None;
        isTransitioningMainState = false;
    }

    public override void SetSubStateNone()
    {
        base.SetSubStateNone();
        subState = Enums.BehaviourStates.None;
        
        if(infoHolder.characterStat.characterType == Enums.CharacterTypes.Enemy)
        {
            if(mainState == Enums.BehaviourStates.Attack)
            {
                currentMainState.EnterState();
            }
        }
        
        isTransitioningSubState = false;
    }

}