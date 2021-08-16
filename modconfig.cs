using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace prefixtest {

  public class modconfig: ModConfig {
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [DefaultValue(10)]
    [Increment(1)]
    [Range(0, 100)]
    [Slider]
    [ReloadRequired]
    [Label("Chance for Enemies to have stat changes (%)")]
    public int StatChangeChance;

    [DefaultValue(10)]
    [Increment(1)]
    [Range(0, 100)]
    [Slider]
    [ReloadRequired]
    [Label("Chance for Enemies to have special effects (%)")]

    public int SpecialEffectChance;

    [DefaultValue(10)]
    [Increment(1)]
    [Range(0, 100)]
    [Slider]
    [ReloadRequired]
    [Label("Chance for Enemies to have extra projectiles (%)")]

    public int ProjectileChance;

    [DefaultValue(1)]
    [Increment(1)]
    [Range(0, 100)]
    [Slider]
    [ReloadRequired]
    [Label("Chance for rare enemies to spawn (%)")]

    public int RareChance;

    [DefaultValue(5)]
    [Increment(1)]
    [Range(0, 100)]
    [Slider]
    [ReloadRequired]
    [Label("Chance for enemies with suffixes to spawn (%)")]

    public int SuffixChance;




    // A method annotated with OnDeserialized will run after deserialization. You can use it for enforcing things like ranges, since Range and Increment are UI suggestions.

  }
}
