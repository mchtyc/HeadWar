using System.Collections.Generic;
using UnityEngine;

public static class EnemyNames
{
    private static readonly string names1 = " Aspect Kraken Bender Lynch BigPapa MadDog Bowser O'Doyle Bruise Psycho Cannon Ranger Clink Ratchet Cobra Reaper Colt Rigs Crank Ripley Creep Roadkill Daemon Ronin Decay Rubble Diablo Sasquatch Doom Scar Dracula Shiver Dragon Skinner Fender SkullCrusher Fester Slasher Fisheye Steelshot Flack Surge Gargoyle Sythe Grave Trip Gunner Trooper Hash Tweek Hashtag Vein Indominus Void Ironclad Wardon Killer Wraith Knuckles Katar FlyingClaw Espada Machet Volt Osmium Earth Metal X-Ray Fox Nightshade Immortal Coyote Mercury";
    private static readonly string names2 = " Steel Kevlar Lightning Tito Bullet-Proof Fire-Bred Titanium Hurricane Ironsides Iron-Cut Tempest IronHeart SteelForge Pursuit SteelFoil Upsurge Uprising Overthrow Breaker Sabotage Dissent Subversion Rebellion Insurgent Loch Golem Wendigo Rex Hydra Behemoth Balrog Manticore Gorgon Basilisk Minotaur Leviathan Cerberus Mothman Sylla Charybdis Orthros Baal Cyclops Satyr Azrael Gash Scalp Blood Scab Torque Soleus Aspis Saber Cutlass Blade Gladius Brass Camden Baltimore CrownHeights Detroit McKinley Seraphim Remington";
    private static readonly string names3 = " Ballistic Furor Uproar Fury Ire Demented Wrath Madness Schizo Rage Savage Manic Frenzy Mania Derange Atilla Darko Terminator Conqueror MadMax Siddhartha Suleiman BillytheButcher Thor Napoleon Maximus Khan Geronimo Leon Leonidas Dutch Cyrus Hannibal Dux Mr.Blonde Agrippa JesseJames Matrix Bleed X-Skull Gut Nail Jawbone Socket Fist Skeleton Footslam Tooth Craniax Head-Knocker K-9 Bone Razor Kneecap Cut Slaughter Spear Dagger Slungshot Katana Atalanta Sekhmet Colestah Athena Ishtar Temptress She-Devil Revenant Diviner";
    private static readonly string names4 = " Wracker Annihilator Finisher Wrecker Destroyer Overtaker Clencher Stabber Saboteur Masher Hitter Rebel Crusher Obliterator Eliminator Slammer Exterminator Hell-Raiser Thrasher Ruiner Mutant Torpedo Wildcat Automatic Cannon Hellcat Glock Mortar Tomcat Sniper Siege Panther Carbine Bullet Jaguar Javelin Aero Bomber Howitzer Albatross StrikeEagle Gatling Arsenal Rimfire Avenger Hornet Centerfire Hazzard Zero Broadsword Scimitar Lockback Claymoree Spirit Spellbinder Goblin Kelpie Jezebel Oracle Vamp Sorceress Soul Hellcat";
    private static readonly string names5 = " Terror Demise Phantom Freak Grim Sepulcher Axe Menace Damned Axe-man Dementor Kafka Executioner Nightshade Phantasm Hollowman Venom Scream Garrot TheUnholy Shriek Abyss Rot Wraith Chasm Omen Bodybag Ghoul Midnight Morgue Mace Falchion Montante Battleaxe Zweihander Hatchet Billhook Club Hammer Caltrop Maul Sledgehammer Longbow Bludgeon Harpoon Crossbow Lance Angon Pike TigerClaw FireLance Poleaxe Matchlock Quarterstaff Gauntlet Bullwhip WarHammer CalamityJane Enyo Ashtart PearlHeart Bellona Juno BelleStarr Tanita Glock";
    private static readonly string names6 = " Grizzly Wolverine Deathstalker Snake Wolf Scorpion Vulture Claw Boomslang Falcon Fang Viper Ram Grip Sting Boar BlackMamba Lash Tusk Goshawk Gnaw Satyr Orb Hypernova Oleander Astor Stratosphere Hemlock Mortal Supernova Snake Eyes Militant Blackjack High Roller Lock Baccarat PocketRocket The Money RedDog Mojave Dice Poker Bellagio Rocks Keno Nevada Watchface TheHouse Reno BigTime Bookie Steppe TwoFace Arbitrage Fishnet DeepPockets DoubleDouble Dagger Poltergeist Exorcist Zombie Seer Madcap Armor Blaser Savage Benelli";
    private static readonly string names7 = " RealDeal Explosive Grenade Pyro BlackCat RomanCandle Gunpowder M-80 BabylonCandle Mortar SmokeBomb Missile Firebringer Amaretto Dom Noir Bacardi Don Scotch Cognac Joose Whiskey Forever Revolution Berserk Unstoppable Sever Bitten Eternity Die-hard Corybantic Fanatic Zealot Crazed X-Treme Alien Delirious Rabid Predator Agitator Radical Barbarian Maniac Cyanide Comet Spider Toxin Protostar Bat Virus Medium Serpent Arsenic DarkMatter Crow Meteor Valkyrie Selkie Cleo Venus Madam Empress Marquess Duchess Baroness Herzogint";
    private static readonly string names8 = " Ruger Winchester AeonTank Hawkeye Kiddo Torchy Medusa Buffy Trinity Irons Coffy Zoe Storm Eowyn Zen JubileeCroft Alyx Dazzler Leeloo Katniss Aeryn Mathilda Linh Arya Padme Polgara Ygritte Ramona Elektra Bayonetta Silk Spectre Catwoman Sindel Helium Mercury Entropy Beryllium Radon Radioactive Neon Radium Radiate Phosphorus Element Ion Phosphorescent Elemental Eon Illumine Lab Rat Photon Chromium Acid Redox Arsenic Atom Redux Zinc Electron HotSalt Selenium Atomic Vapor Xenon Nuclear HuaMulan Shieldmaiden Devi Boudic";
    private static readonly string names9 = " Illusion Crafty Variance Delusion Deceit Caprice Deception Waylay Aberr Myth Ambush Variant Daydream Feint Hero NightTerror Catch-22 Villain Figment Puzzler Daredevil Virtual Curio Mercenary Chicanery Prodigy Voyager Trick Breach Wanderer Vile MissFortune Audacity Horror Vex Dismay Grudge Nerve Phobia Enmity Egomania Fright Animus Scheme Panic Hostility Paramour Agony Rancor X-hibit Inferno Malevolence Charade Blaze Poison Hauteur Crucible Spite Vainglory Haunter Spitefulness Narcissus Bane Venom Fate Beguile Devian";
    private static readonly string names10 = " Amazon Majesty Anomoly Malice Banshee Mannequin Belladonna Minx Beretta Mirage BlackBeauty Nightmare Calypso Nova Carbon Pumps Cascade Raven Colada Resin Cosma Riveter Cougar Rogue Countess Roulette Enchantress Shadow Enigma Siren FemmeFatale Stiletto Firecracker Tattoo Geisha T-Back Goddess Temperance Half Pint Tequila Harlem Terror Heroin Thunderbird Infinity Ultra Insomnia Vanity Ivy Velvet Legacy Vixen Lithium Lolita Wicked Lotus Widow Mademoiselle Xenon Kahina Teuta Dihya Artemis Nefertiti RunningEagle";

    public static string CreateName(List<Enemy> enemies)
    {
        List<string> allNames = new List<string> { names1, names2, names3, names4, names5, names6, names7, names8, names9, names10};
        string names = allNames[Random.Range(0, allNames.Count)];
        
        int startIndex = Random.Range(0, (1 + names.LastIndexOf(" ")));
        startIndex = names.IndexOf(" ", startIndex) + 1;
        
        int lastIndex = names.IndexOf(" ", startIndex);
        if (lastIndex == -1)
        {
            lastIndex = names.Length;
        }

        string randomName = names.Substring((startIndex), lastIndex - startIndex);

        foreach (Enemy enemy in enemies)
        {
            if (enemy.name == randomName)
            {
                CreateName(enemies);
                break;
            }
        }
        return randomName;
    }
}
