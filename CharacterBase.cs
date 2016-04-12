using UnityEngine;
using System.Collections;

namespace Teste
{

    public abstract class CharacterBase : MonoBehaviour
    {

        // -- ATRIBUTOS --

        public int currentLevel;

        public BasicStats basicStats;
        [System.Serializable]
        public class BasicStats { 
        public float startLife;
        public float startMana;
        public int strenght;
        public int inteligence;
        public int agility;
        public int baseDefense;
        public int baseAttack;

    }
        // Use this for initialization
        protected void Start()
        {

        }

        // Update is called once per frame
        protected void Update()
        {

        }
    }
}