using UnityEngine;

public class CharacterStatHandler : ReferenceHolder
{
    [SerializeField] private float currentRage;


    private void Update()
    {
        if (currentRage >= infoHolder.characterStat.rage) return;

        if(currentRage > 0)
            currentRage -= (Time.deltaTime * infoHolder.characterStat.rageReduceMul);
            
    }

    public void TakeRage(float _rageAmount)
    {
        currentRage += _rageAmount;
    
        if(currentRage >= infoHolder.characterStat.rage)
        {
            if (charBehaviourStateHandler != null)
                charBehaviourStateHandler.ChangeMainState(Helpers.Enums.BehaviourStates.Death);


        }

    }

}
