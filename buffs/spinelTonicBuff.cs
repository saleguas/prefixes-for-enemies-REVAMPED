using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace prefixtest.buffs
{
    public class spinelTonicBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spinel Tonic Buff");
            Description.SetDefault("Massive Boost to all stats, at a cost...");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 10;
            player.GetDamage(DamageClass.Magic) *= 1.20f;
            // also increase the damage of all weapons by 20%
            player.GetDamage(DamageClass.Ranged) *= 1.20f;
            player.GetDamage(DamageClass.Melee) *= 1.20f;
            player.GetCritChance(DamageClass.Magic) *= 1.20f;
            player.GetCritChance(DamageClass.Ranged) *= 1.20f;
            player.GetCritChance(DamageClass.Melee) *= 1.20f;
            player.manaRegen += 10;
            player.statDefense += 20;
            player.maxMinions += 1;
            player.maxRunSpeed += 1f;
            player.moveSpeed += 1f;
            player.statLifeMax2 = 50;
            player.statManaMax2 += 100;


        }
    }
}