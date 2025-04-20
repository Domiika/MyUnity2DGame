using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DebugPanel : MonoBehaviour
{
    public TextMeshProUGUI debugText;

    private Aura aura;
    private EnemySpawner enemySpawner;
    private SpellShotManager spellManager;
    private Player player;

    void Update()
    {
        if (aura == null)
            aura = FindObjectOfType<Aura>();

        if (enemySpawner == null)
            enemySpawner = FindObjectOfType<EnemySpawner>();

        if (spellManager == null)
            spellManager = FindObjectOfType<SpellShotManager>();

        if (player == null)
            player = FindObjectOfType<Player>();

        string debugInfo = "";

        if (aura != null)
        {
            debugInfo += $"<b>Aura</b>\n";
            debugInfo += $"Damage: {aura.damage}\n";
            debugInfo += $"Spell Level: {aura.spellLevel}\n\n";
        }

        if (enemySpawner != null)
        {
            debugInfo += $"<b>Enemy Spawner</b>\n";
            debugInfo += $"Interval: {enemySpawner.timeToSpawn}\n\n";
        }

        if (spellManager != null)
        {
            debugInfo += $"<b>Spell Manager</b>\n";
            debugInfo += $"Damage: {spellManager.damage}\n";
            debugInfo += $"Time To Spawn: {spellManager.timeToSpawn}\n\n";
        }

        if (player != null)
        {
            debugInfo += $"<b>Player Stats</b>\n";
            debugInfo += $"Health: {player.currentHealth}/{player.maxHealth}\n";
            debugInfo += $"XP: {player.currentXP}/{player.maxXP}\n";
            debugInfo += $"Level: {player.level}\n";
        }

        debugText.text = debugInfo;
    }
}
