//
// using System.Collections.Generic;
// using Terraria;
// using Terraria.ID;
// using Terraria.ModLoader;
//
// namespace prefixtest.Common.Players
// {
// 	public class Accessories : ModPlayer
// 	{
//
//     public float critMultiplier = 1.0f; // Base crit multiplier. Critical damage will be damage * this number + damage type modifier.
//     public float meleeCritMultiplier = 0.0f; // Melee Crit Multiplier, percentage that will be added onto the critical damage.
//     public float rangedCritMultiplier = 0.0f; // Ranged Crit Multiplier, percentage that will be added onto the critical damage.
//     public float magicCritMultiplier = 0.0f; // Magic Crit Multiplier, percentage that will be added onto the critical damage.
//     public float thrownCritMultiplier = 0.0f; // Thrown Crit Multiplier, percentage that will be added onto the critical damage.
//
//     public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
//     {
//         if (crit == true)
//         {
//             if(item.melee == true) // Melee Crit
//             {
//                 damage = (int)(damage * (critMultiplier + meleeCritMultiplier)); // Damage gets amplified by the crit multiplier.
//             }
//             else if (item.ranged == true) // Ranged Crit
//             {
//                 damage = (int)(damage * (critMultiplier + rangedCritMultiplier));
//             }
//             else if (item.magic == true) // Magic Crit
//             {
//                 damage = (int)(damage * (critMultiplier + magicCritMultiplier));
//             }
//             else if (item.thrown == true) // Thrown Crit
//             {
//                 damage = (int)(damage * (critMultiplier + thrownCritMultiplier));
//             }
//             else
//             {
//                 damage = (int)(damage * critMultiplier); // Damage gets amplified by the crit multiplier.
//             }
//         }
//     }
//
//     public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit)
//     {
//         if (crit == true)
//         {
//             if (proj.melee == true) // Melee Crit
//             {
//                 damage = (int)(damage * (critMultiplier + meleeCritMultiplier)); // Damage gets amplified by the crit multiplier.
//             }
//             else if (proj.ranged == true) // Ranged Crit
//             {
//                 damage = (int)(damage * (critMultiplier + rangedCritMultiplier));
//             }
//             else if (proj.magic == true) // Magic Crit
//             {
//                 damage = (int)(damage * (critMultiplier + magicCritMultiplier));
//             }
//             else if (proj.thrown == true) // Thrown Crit
//             {
//                 damage = (int)(damage * (critMultiplier + thrownCritMultiplier));
//             }
//             else
//             {
//                 damage = (int)(damage * critMultiplier); // Damage gets amplified by the crit multiplier.
//             }
//         }
//     }
// 	}
// }
