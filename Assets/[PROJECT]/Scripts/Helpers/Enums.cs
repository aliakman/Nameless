namespace Helpers
{
    public struct Enums
    {
        public enum InputActionMaps
        {
            None,
            Player,
            UI,
        }

        public enum CharacterTypes
        {
            None,
            Player,
            Enemy,
        }

        public enum AttackTypes
        {
            None,
            Melee,
            Ranged,
        }

        public enum Weapons
        {
            None,
            Glock,
            ShortSword,
        }

        public enum Skills
        {
            None,
            Idle,
            Patrol,
            PatrolMove,
            BasicAttackDash,
            DashOne,
            InputMove,
            JumpOne,
            Shoot,
            Sword,
            MoveToAttack,
            Spawn
        }

        public enum BehaviourStates
        {
            /* Common */
            None,
            Move,
            Death,
            TakeRage,
            /* Player */
            BasicAttack,
            AdvancedAttack,
            SpecialAttak,
            Jump,
            Dash,
            Repulse,
            DeadEye,
            /* Enemy */
            Patrol,
            Idle,
            Attack,
            Defence,
            Spawn,
        }

        //#region Skills
        //public enum Skills
        //{
        //    /*Common Skills*/
        //    None,
        //    /*Player Skills*/
        //    InputMoveLvlOne,
        //    JumpLvlOne,
        //    JumpLvlTwo,
        //    JumpLvlThree,
        //    DashLvlOne,
        //    DashLvlTwo,
        //    DashLvlThree,
        //    /*Enemy Skills*/
        //    PatrolLvlOne,
        //    IdleLvlOne,
        //    PatrolMoveLvlOne,
        //}
        //#endregion

    }
}
