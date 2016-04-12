using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace Teste
{
    public class LevelController : MonoBehaviour
    {

        public static LevelController instance;


        // -- MULTIPLICADOR DE EXP --
        public int xpMultiply = 1;

        // -- EXP POR LEVEL --
        public float xpFirstLevel = 100;

        // -- EXP NECESSARIA PARA O PROXIMO LEVEL --

        private float xpNextLevel;

        // -- FATOR DIFICULDADE DE UP --

        public float difficultFactor = 1.5f;

        
        [System.Serializable]
        public class BasicInfoChar
        {
            public PlayerBehaviour.BasicStats baseInfo;
            public PlayerBehaviour.TypeCharacter typeChar;
        }

        // -- TIPOS DE PERSONAGEM --

        public List<BasicInfoChar> baseInfoChars;
        // -- AQUI INICIA O JOGO --
        void Start()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
           // Application.LoadLevel("GamePlay");



        }

        // -- AQUI ATUALIZA A CADA FRAME --
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddXp(100);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerPrefs.DeleteAll();
            }
        }

        // -- METODO XP PROXIMO LEVEL --

        public static void AddXp(float xpAdd)
        {
            float newXp = (GetCurrentXp() + xpAdd) * LevelController.instance.xpMultiply;
            while (newXp >= GetNextXp())
            {
                newXp -= GetNextXp();
                AddLevel();
                PlayerPrefs.SetFloat("currentXp", newXp);
            }
            PlayerPrefs.SetFloat("currentXp", newXp);
        }

        // -- METODO PEGAR XP --

        public static float GetCurrentXp()
        {
            return PlayerPrefs.GetFloat("currentXp");
        }

        // -- METODO PEGAR LEVEL --

        public static int GetCurrentLevel()
        {
            return PlayerPrefs.GetInt("currentLevel");
        }


        // -- METODO ADICIONAR LEVEL --
        public static void AddLevel()
        {
            int newLevel = GetCurrentLevel() + 1;
            PlayerPrefs.SetInt("currentLevel", newLevel);
        }


        public static float GetNextXp()
        {
            return LevelController.instance.xpFirstLevel * (GetCurrentLevel() + 1) * LevelController.instance.difficultFactor;
        }

        // -- TIPOS DE CHAR --
        public PlayerBehaviour.TypeCharacter GetTypeCharacter()
        {
            int typeId = PlayerPrefs.GetInt("TypeCharacter");

            if (typeId == 0)
            {
                return PlayerBehaviour.TypeCharacter.Warrior;
            }
            else if (typeId == 1)
            {
                return PlayerBehaviour.TypeCharacter.Wizard;
            }
            else if (typeId == 2)
            {
                return PlayerBehaviour.TypeCharacter.Archer;
            }

            return PlayerBehaviour.TypeCharacter.Warrior;
        }

        public static void SetTypeCharacter(PlayerBehaviour.TypeCharacter newType)
        {
            PlayerPrefs.SetInt("TypeCharacter", (int)newType);
        }

        public PlayerBehaviour.BasicStats GetBasicStats(PlayerBehaviour.TypeCharacter type)
        {
            foreach(BasicInfoChar info in baseInfoChars)
            {
              if (info.typeChar == type)
                {
                    return info.baseInfo;
                }
            }
            return baseInfoChars[0].baseInfo;
        }

        void OnGUI()
        {
            GUI.Label(new Rect(0, 0, 200, 50), "Current Xp = " + GetCurrentXp());
            GUI.Label(new Rect(0, 15, 200, 50), "Current Level = " + GetCurrentLevel());
            GUI.Label(new Rect(0, 30, 200, 50), "XP Next Level = " + GetNextXp());
        }

    }

}