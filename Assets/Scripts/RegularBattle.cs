using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class RegularBattle : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public GameObject attackMenu;
    public GameObject targetMenu;
    public GameObject itemMenu;

    public GameManager gm;

    PlayerBattle playerUnit;

    MoldController moldUnitOne;
    MoldController moldUnitTwo;
    MoldController moldUnitThree;
    MoldController moldUnitFour;
    
    //more controllers go here

    public Transform playerPos;
    public Transform firstEnemyPos;
    public Transform secondEnemyPos;
    public Transform thirdEnemyPos;
    public Transform forthEnemyPos;

    public TextMeshProUGUI dialogueText;

    private bool firstFight = true;

    private int target;
    private int numEnemies;

    private float experienceGained;

    private List<string> loot;

    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
    public BattleState state;

    public void Begin()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    { 
        GameObject playerGO = Instantiate(player, playerPos);
        playerUnit = playerGO.GetComponent<PlayerBattle>();
        //playerUnit.inBattle = true;

        if(gm.GetLevel() == 1)
        {
            if (firstFight)
            {
                GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                moldUnitOne = enemy1.GetComponent<MoldController>();
                moldUnitOne.SetLevel(1);
                numEnemies = 1;
                firstFight = false;
            }

            else
            {
                int moldSpawnChance = Random.Range(1, 100);

                if(gm.GetExperience() >= 3.0f)
                {
                    if(moldSpawnChance >= 75)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        moldUnitOne.SetLevel(3);
                        numEnemies = 1;
                    }

                    else if(moldSpawnChance >= 50)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(3);
                        moldUnitTwo.SetLevel(3);
                        numEnemies = 2;
                    }

                    else if(moldSpawnChance >= 25)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();
                        GameObject enemy3 = Instantiate(enemy, firstEnemyPos);
                        moldUnitThree = enemy3.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(3);
                        moldUnitTwo.SetLevel(3);
                        moldUnitThree.SetLevel(3);
                        numEnemies = 3;
                    }

                    else
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();
                        GameObject enemy3 = Instantiate(enemy, firstEnemyPos);
                        moldUnitThree = enemy3.GetComponent<MoldController>();
                        GameObject enemy4 = Instantiate(enemy, firstEnemyPos);
                        moldUnitFour = enemy4.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(3);
                        moldUnitTwo.SetLevel(3);
                        moldUnitThree.SetLevel(3);
                        moldUnitFour.SetLevel(3);
                        numEnemies = 4;
                    }
                }
                
                else if(gm.GetExperience() >= 2.0f)
                {
                    if (moldSpawnChance >= 67)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        moldUnitOne.SetLevel(2);
                        numEnemies = 1;
                    }

                    else if (moldSpawnChance >= 37)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(2);
                        moldUnitTwo.SetLevel(2);
                        numEnemies = 2;
                    }

                    else if (moldSpawnChance >= 17)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();
                        GameObject enemy3 = Instantiate(enemy, firstEnemyPos);
                        moldUnitThree = enemy3.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(2);
                        moldUnitTwo.SetLevel(2);
                        moldUnitThree.SetLevel(2);
                        numEnemies = 3;
                    }

                    else
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();
                        GameObject enemy3 = Instantiate(enemy, firstEnemyPos);
                        moldUnitThree = enemy3.GetComponent<MoldController>();
                        GameObject enemy4 = Instantiate(enemy, firstEnemyPos);
                        moldUnitFour = enemy4.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(2);
                        moldUnitTwo.SetLevel(2);
                        moldUnitThree.SetLevel(2);
                        moldUnitFour.SetLevel(2);
                        numEnemies = 4;
                    }
                }

                else if(gm.GetExperience() >= 1.0f)
                {
                    if (moldSpawnChance >= 50)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        moldUnitOne.SetLevel(1);
                        numEnemies = 1;
                    }

                    else if (moldSpawnChance >= 25)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(1);
                        moldUnitTwo.SetLevel(1);
                        numEnemies = 2;
                    }

                    else if (moldSpawnChance >= 5)
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();
                        GameObject enemy3 = Instantiate(enemy, firstEnemyPos);
                        moldUnitThree = enemy3.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(1);
                        moldUnitTwo.SetLevel(1);
                        moldUnitThree.SetLevel(1);
                        numEnemies = 3;
                    }

                    else
                    {
                        GameObject enemy1 = Instantiate(enemy, firstEnemyPos);
                        moldUnitOne = enemy1.GetComponent<MoldController>();
                        GameObject enemy2 = Instantiate(enemy, firstEnemyPos);
                        moldUnitTwo = enemy2.GetComponent<MoldController>();
                        GameObject enemy3 = Instantiate(enemy, firstEnemyPos);
                        moldUnitThree = enemy3.GetComponent<MoldController>();
                        GameObject enemy4 = Instantiate(enemy, firstEnemyPos);
                        moldUnitFour = enemy4.GetComponent<MoldController>();

                        moldUnitOne.SetLevel(1);
                        moldUnitTwo.SetLevel(1);
                        moldUnitThree.SetLevel(1);
                        moldUnitFour.SetLevel(1);
                        numEnemies = 4;
                    }
                }
            }

            dialogueText.text = "MOLD has sensed your presence...";
            AdjustAttack();
            PopulateItems();
        }

        yield return new WaitForSeconds(4f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void AdjustAttack()
    {
        if (gm.GetLevel() == 1)
        {
            RectTransform[] attacks = attackMenu.GetComponentsInChildren<RectTransform>();

            foreach (RectTransform rt in attackMenu.GetComponentsInChildren<RectTransform>())
            {
                rt.gameObject.SetActive(true);
            }

            for (int i = 3; i < 9; i++)
            {
                attacks[i].gameObject.SetActive(false);
            }

            attacks[0].gameObject.SetActive(false);

            RectTransform[] targets = targetMenu.GetComponentsInChildren<RectTransform>();

            foreach (RectTransform rt in targetMenu.GetComponentsInChildren<RectTransform>())
            {
                rt.gameObject.SetActive(true);
            }
            
            for (int i = 8; numEnemies * 2 < i; i--)
            {
                targets[i].gameObject.SetActive(false);
            }

            targets[0].gameObject.SetActive(false);
        }
    }

    void PopulateItems()
    {
        RectTransform[] items = itemMenu.GetComponentsInChildren<RectTransform>();

        foreach (RectTransform rt in itemMenu.GetComponentsInChildren<RectTransform>())
        {
            rt.gameObject.SetActive(true);
        }

        items[0].gameObject.SetActive(false);

        if (gm.GetInventory().Count == 0)
        {
            for (int i = 1; i < 17; i++)
            {
                items[i].gameObject.SetActive(false);
            }

            items[17].gameObject.SetActive(true);
            items[18].gameObject.SetActive(true);
        }

        else
        {
            for (int i = 18; i > gm.GetInventory().Count * 2; i--)
            {
                items[i].gameObject.SetActive(false);
            }
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "What will you do?";
    }

    void EnemyTurn()
    {
        if(state != BattleState.ENEMYTURN)
        {
            return;
        }

        Debug.Log("Enemy's turn");

        if(numEnemies == 1)
        {
            if(moldUnitOne.AttemptAttack(playerUnit.GetSpeed(), playerUnit.GetIntimidation(), playerUnit.GetDefense(false)))
            {
                dialogueText.text = "MOLD uses SPORES";
                StartCoroutine(EnemyAttack(moldUnitOne.ReturnDamage()));
            }

            else
            {
                dialogueText.text = "MOLD misses attack";
                state = BattleState.PLAYERTURN;
            }
        }
    }

    IEnumerator EnemyAttack(float damage)
    {
        yield return new WaitForSeconds(2f);
        playerUnit.TakeDamage(damage);
        Debug.Log("Back to player");

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public void OnAttackButton()
    {
        /*
        if(gm.GetLevel() == 1)
        {
            RectTransform[] attacks = attackMenu.GetComponentsInChildren<RectTransform>();
            for(int i = 3; i < 9; i++)
            {
                attacks[i].gameObject.SetActive(false);
            }

            RectTransform[] targets = targetMenu.GetComponentsInChildren<RectTransform>();
            for(int i = 8; numEnemies * 2 < i; i--)
            {
                targets[i].gameObject.SetActive(false);
            }
        }
        */
    }

    public void OnAttackMoveButton(int moveNum)
    {
        //later
    }

    public void OnTargetButton(int tarNum)
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

        target = tarNum;

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        if(target == 1)
        {
            if (playerUnit.AttemptAttack())
            {
                moldUnitOne.TakeDamage(2.0f);


                if (moldUnitOne.currHealth <= 0.0f)
                {
                    numEnemies--;
                    experienceGained += moldUnitOne.GetLevel() * 0.2f;
                    StartCoroutine(RemoveEnemy(moldUnitOne, 2f));
                }
            }
        }

        else if(target == 2)
        {
            if (playerUnit.AttemptAttack())
            {
                moldUnitTwo.TakeDamage(2.0f);

                if (moldUnitTwo.currHealth <= 0.0f)
                {
                    numEnemies--;
                    experienceGained += moldUnitTwo.GetLevel() * 0.2f;
                    StartCoroutine(RemoveEnemy(moldUnitTwo, 2f));
                }
            }
        }

        else if(target == 3)
        {
            if (playerUnit.AttemptAttack())
            {
                moldUnitThree.TakeDamage(2.0f);

                if (moldUnitThree.currHealth <= 0.0f)
                {
                    numEnemies--;
                    experienceGained += moldUnitThree.GetLevel() * 0.2f;
                    StartCoroutine(RemoveEnemy(moldUnitThree, 2f));
                }
            }
        }

        else if(target == 4)
        {
            if (playerUnit.AttemptAttack())
            {
                moldUnitFour.TakeDamage(2.0f);

                if (moldUnitFour.currHealth <= 0.0f)
                {
                    numEnemies--;
                    experienceGained += moldUnitFour.GetLevel() * 0.2f;
                    StartCoroutine(RemoveEnemy(moldUnitFour, 2f));
                }
            }
        }

        if (numEnemies == 0)
        {

            yield return new WaitForSeconds(3f);

            dialogueText.text = "You recieved " + experienceGained * 10 + " XP";

            if (gm.GetLevel() == 1)
            {
                int chanceGlue = Random.Range(1, 100);

                if(chanceGlue == 42)
                {
                    loot.Add("Glue");
                    dialogueText.text += "\nMOLD dropped some glue. Strange. How did it get a chunk of glue?";
                }

                int chanceSoap = Random.Range(1, 100);

                if(chanceSoap <= 10)
                {
                    loot.Add("Soap");
                    dialogueText.text += "\nMOLD dropped a bit of soap. Could be useful.";
                }
            }

            gm.AddLoot(loot);
            gm.SetExperiencePoints(experienceGained); 
            state = BattleState.WON;
            FreeRoam();
        }

        else
        {
            yield return new WaitForSeconds(3f);

            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }
    }

    IEnumerator RemoveEnemy(MoldController defeated, float wait)
    {
        yield return new WaitForSeconds(wait);

        defeated.gameObject.SetActive(false); 
    }

    public void OnItemButton(int item)
    {
        dialogueText.text = "You used " + gm.GetInventory()[item];

        foreach(string it in gm.GetInventory())
        {
            Debug.Log(it);
        }

        gm.UseItem(gm.GetInventory()[item]);
        //PopulateItems();
        //TO-DO fix adjusting item and button list size
    }

    public void OnDefendButton()
    {
        dialogueText.text = "Coward";
    }

    public void OnFleeButton()
    {
        FreeRoam();
        //TO-DO enemy checks
    }

    void FreeRoam()
    {
        Destroy(playerUnit.gameObject);

        for (int i = 0; i < numEnemies; i++)
        {
            if (i + 1 == 1)
            {
                Destroy(moldUnitOne.gameObject);
            }

            else if (i + 1 == 2)
            {
                Destroy(moldUnitTwo.gameObject);
            }

            else if (i + 1 == 3)
            {
                Destroy(moldUnitThree.gameObject);
            }

            else if (i + 1 == 4)
            {
                Destroy(moldUnitFour.gameObject);
            }
        }

        gm.EndRegularBattle();
    }
}
