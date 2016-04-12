using UnityEngine;
using System.Collections;

namespace Teste
{


    public class PlayerBehaviour : CharacterBase
    {

        public enum TypeCharacter
        {
            Warrior = 0,
            Wizard = 1,
            Archer = 2,
        }
        public TypeCharacter type;

        protected void Start()
        {

            base.Start();
            currentLevel = LevelController.GetCurrentLevel();
            type = LevelController.instance.GetTypeCharacter();
            basicStats = LevelController.instance.GetBasicStats(type); 


        }

        // Update is called once per frame
        void Update()
        {

        }

    }

}