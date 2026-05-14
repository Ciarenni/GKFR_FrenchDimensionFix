using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

namespace GKFR_FrenchDimensionFix
{
    [BepInPlugin("ciarenni.garfieldkartfuriousracing.frenchdimensionfix", "French Dimension Fix", "1.0.0")]
    public class FrenchDimensionFix : BaseUnityPlugin
    {
        private static readonly Type patchType = typeof(FrenchDimensionFix);
        private static List<string> quotesList = new List<string>
        {
            "#1 \"YOU'RE DOING A ME\" - gr3atj0b, 2022",
            "#2 \"You gotta work on your... vibration\" - raysfire, 2022",
            "#3 \"i only do dirty, pure hands... no dirty without dirty hands!\" - rayschat, 2022",
            "#4 \"Easy mode is just hard!\" - raysfire, 2022 PepeNote",
            "#5 \"Let's go, a little ball action!\" - raysfire, 2022",
            "#6 \"be good to have a couple of d's\" - Overclocked2, 2022",
            "#7 \"I need to get up there onto the dudes\" - raysfire, 2022",
            "#8 \"I have no idea how this works lol\" *wins the minigame* - LilyAcedia, 2022",
            "#9 \"Where's the dead guy?\" -raysfire, 2023",
            "#10 \"Wario, can you please die?\" -raysfire, playing Mario Party",
            "#11 \"Never underestimate a good cup of coffee or my wrath.\" - AI Grindel",
            "#12 \"Embrace the power of deez nuts!\" - AI Grindel",
            "#13 \"Double double animal style deez nuts!\" - AI Grindel",
            "#14 \"i think i have filled in most of the holes yall found\" -Ciarenni, on a completely innocent topic",
            "#15 \"Oh my god, I'm pooping!\" -rays, playing F-Zero 99",
            "#16 \"Deez nuts are brave little warriors\" - AI GeorgeWashingtoad",
            "#17 \"Guys, I don't suck balls, okay?\" -rays, November 2023",
            "#18 \"One minute you think you're playing Mario Party, then BOOM! BALLS \" - rays, 2023",
            "#19 \"My eyes went straight to Toad's pants.\" -rays, 2023",
            "#20 \"Dude, hentai plus reformation gives you the Bible raysL \" -rays, Gen 2 Pokemon Infinite Craft challenge",
            "#21 \"its not that hard, i just needed to try\" -rays, SMM2",
            "#22 \"Life is a series of bits\" -rays playing TTYD remake, talking about the bit of claiming the PHP video is coming out soon",
            "#23 \"dragons are hype and so is applebees\" -rays",
            "#24 \"The boobs have won!\" -raysfire 2024 (but really 2025)",
            "#25 \"Everyone die!\" - raysfire 2025",
            "#26 \"Can I kick the baby?\" -raysfire, 2025",
            "#27 \"I'm not trying to invalidate a penis drawing.\" -rays, Feb 2025",
            "#28 \"I think X-Naut Fortress might be one of the best Nintendo songs ever made.\" -raysfire, 2025",
            "#29 \"Dragons are sick, and so is Applebees.\" -raysfire, year unknown, thanks Lily for the quote",
            "#30 \"Trust Spike, win game\" - Spike (green enemy) 2025",
            "#31 \"I need to plunder that guy\" - raysfire, 2025",
            "#32 \"give me the suck\" - raysfire 2025",
            "#33 \"The DONG does have BALLS\" - raysfire 2025",
            "#34 \"I don't want to be behind Bowser while he's farting\" - raysfire 2025",
            "#35 \"It's not like mario wanking or whatever\" - raysfire 2025",
            "#36 \"Wait, I have a great rod\" - raysfire 2025",
            "#37 \"Catch the nip -- or try to\" -raysfire 2025",
            "#38 \"Every achievement in Jamboree is insane. So I did them in 48 hours.\" -rowrow, creating a youtube title for rays",
            "#39 \"Insane D coming out of this guy right now!\" -raysfire 2025, 4-game Mario Kart gauntlet",
            "#40 \"I did a legal dump\" - raysfire, 2025",
            "#41 \"Gooning isn't my hobby, it's my job\" - raysfire 2025",
            "#42 \"He might have PPed himself out\" - raysfire 2025",
            "#43 \"I need to create life\" - raysfire, 2025",
            "#44 \"Guys, it's gonna be alright. Trust me.\" - raysfire, 2025",
            "#45 \"Contrary to popular belief, I am not doing cocaine\" - raysfire 2025",
            "#46 \"I have this game figured out.\" -raysfire, 2025 \"I hate this game, Man. This is the worst game of all time.\" -Also raysfire, 2025 (Two minutes later)",
            "#47 \"I need to go get hit by a car really quick\" - Raysfire 2025",
            "#48 \"Hold on, let me cheat.\" - raysfire 2025",
            "#49 \"I need to get high. Can someone get me high right quick?\" - raysfire 2025",
            "#50 \"You gotta have a crisp stick\" - raysfire 2025",
            "#51 \"'Tax evasion is legal.' - Funky Kong 2013\" - raysfire 2025",
            "#52 \"This just seems too...white.\" - raysfire, 2025",
            "#53 \"even with the curve, it's still a D\" - raysfire 2025",
            "#54 \"Twinks are a kind of snack.\" - raysfire 2025",
            "#55 \"I'm a bit of a cheater, what can I say?\" - raysfire 2025",
            "#56 \"Build your own dong, you know?\" - raysfire 2025",
            "#57 \"Does the orange M&M have a fat hog?\" - raysfire 2025",
            "#58 \"I don't like being on stream all the time.\" -rays, professional streamer, 2025",
            "#59 \"(on youtube) One of the things that got recommended to me was a toilet review.\" - raysfire, 2025",
            "#60 \"we need to find out about luigi's fat hog\" - ciarenni, 2025",
            "#61 \"Boner watch comes to a conclusion.\" -raysfire with redfalcon 2025",
            "#62 \"I want to turn into a meteorite\" - raysfire 2025",
            "#63 \"We just whacked nine off.\" -rays 2025",
            "#64 \"I want to pay $500 for a foxgirl skin. Is that so much to ask for in a game?\" - raysfire, 2025",
            "#65 \"I don't want to have to whack it, but i will if i have to\" - raysfire, 2025",
            "#66 \"I need to get hit by a car\" - raysfire 2025",
            "#67 \"Is this wet bowser?\" - raysfire, 2025",
            "#68 \"It's like, a roguelike, you get perks to make your dong more powerful\" - Raysfire 2025",
            "#69 That dong is powerful - raysfire 2025",
            "#70 \"You are beautiful, loud, and crispy\" - SimpleFlips, 2025",
            "#71 \"Not me, I would never bump my whacka\" - Raysfire 2025",
            "#72 \"what's wrong with my stick, man?\" - raysfire 2025",
            "#73 \"Sure, I'll nut to that.\" -raysfire 2025",
            "#74 \"I'm kind of a moveless freak at the moment\" -rays, October 2025",
            "#75 \"For the record, I have only killed people once... okay, twice, whatever\" -raysfire, Oct 2025",
            "#76 \"when it's time for me to finish, I'm ready\" - raysfire",
            "#77 \"We're doing some type of furries in here!\" -raysfire 2025",
            "#78 \"I will likely be doing a 2.4 hour stream today, don't quote me on that\" -rays 2025",
            "#79 \"Your head is kinda sticking out the top of your balls.\" - Ciarenni, 2025",
            "#80 \"There's nothing wrong with flattening some guys, ya know? We've all done it before.\" -rays 2025",
            "#81 \"That's huge, that's mega huge. Might be the hugest thing you've ever seen in your life. \" - raysfire, 2025",
            "#82 \"Speaking of meth, while my mom was here...\" -rays 2025",
            "#83 \"Is that a baby? I'm going to kill her.\" -raysfire, Nov 2025",
            "#84 \"Gave me that huge tip\" - panga, 2025",
            "#85 \"I sent myself a furry\" -panga 2025",
            "#86 \"What is that... a gay bowling pin?\" -rays 2025",
            "#87 \"That is a 67 party.\" -jeff_markov 2025",
            "#88 \"I just killed a guy, that was sick\" - rays, Nov 2025",
            "#89 \"Yoshi... also loves plundering the booty\" - raysfire",
            "#90 \"That's when the babies will appear, and I will kill them. I will destroy them, actually.\" - rays 2025",
            "#91 rays on giving someone malware: \"that would be sick!\"",
            "#92 \"you'vve got an ad for his OF\" - markov, 2025",
            "#93 \"Am I on the penis ride?\" -rays 2025",
            "#94 \"there's a penis and some balls dude, I see it\" -raysfire 2025",
            "#95 \"'No fun, I'm depressed.' That's the spirit!\" -rays, 34.5 hours into the Kirby Air Riders all checkboxes run",
            "#96 \"I gotta inhale 3 dudes at the same time for this achievement, then hit the cave. Wait, the phrasing on that is really bad actually, hold up\" -rays 2025",
            "#97 \"what, is this game smart?\" - panga, dec 2025",
            "#98 \"I was actually Jigglin the stick a little\" - raysfire, 2025",
            "#99 \"I've been grinding her face\" - panga, 2025",
            "#100 \"I feel like he's very puntable, like I would kick him like a football if I had the opportunity.\" - rays, 2025",
            "#101 \"Dude, you just punched me in the face\" - rays 2026 (to Panga)",
            "#102 \"Mario's got a big penis\" - panga, 2026",
            "#103 \"Daddy is in megadebt\" -raysfire 2026",
            "#104 \"I'm a princess, give me a castle!\" - rays, 2026",
            "#105 \"Oh, he's big!\" -raysfire, 2026",
            "#106 \"Wait you've given me an idea with the poop.\" - raysfire 2026",
            "#107 \"Ewww. Poor people have it so rough. NOPERS \" -dani 2026",
            "#108 \"Does anyone know about crack?\" -raysfire, 2026",
            "#109 \"Have you showed those guys your crack?\" -raysfire, 2026",
            "#110 \"See, look, I'm Diddy.\" - rays 2026",
            "#111 \"The dumpy was too big!\" -rays, lying through his teeth after losing at Mario Kart",
            "#112 \"I'm about to get the D, I think.\" - rays, 2026",
            "#113 Panga: \"You know what? The furries can stay. Whatever man.\" rays: \"Yeah, leave 'em, dude.\"",
            "#114 \"I don't think I'm bottom of the year\" - rays 2026",
            "#115 \"Is this the penis video?\" - Rays, Feb 2026",
            "#116 \"Is it like... a hand sock? Is there a word for that?\" -rays, struggling to think of the word \"glove\"",
            "#117 \"How do I get in the hole? There's got to be a way for me to get in there.\" - raysfire, 2026",
            "#118 \"I'll play with you\" - royarashi 2026",
            "#119 \"There's so many tails... it's like a furry convention\" - rays 2026",
            "#120 \"Why is it so big?\" -rays 2026",
            "#121 Roy: \"Choking on what?\" Rays: \"The balls\" -2026",
            "#122 \"I don't really like nuts either.\" -rays \"Coulda fooled me.\" -roy",
            "#123 \"Yeah, I beat Rawk Hawk, and then I accidentally went back in for round 2 and then that ruined everything.\" -rays",
            "#124 \"Can I do the guy?\" - rays 2026",
            "#125 \"Is this a skill issue? How do I get out of the hole?\" -Rays 2026",
            "#126 \"I AM the hardest!\" -RoyArashi 2026",
            "#127 \"I'll start crankin' a new one\" -rays 2026",
            "#128 \"I want big daddy Bowser to ground pound me into submission\" -rays, with source: https://clips.twitch.tv/AgitatedBreakableGuanacoCoolStoryBob",
            "#129 \"I need to turn the cam on for the piss stream\" - rays 2026",
            "#130 \"It was just so natural. You just like slipped it in there and I didn't notice\" - roy, 2026",
            "#131 \"I put things that are unholy into my body on a daily basis\" -rays 2026",
            "#132 \"I did one guy\" - rays 2026",
            "#133 \"TEXAS HOW MANY INCHES\" - Rays 2026",
            "#134 \"We do a little fraud for fun\" - rays 2026",
            "#135 \"I need to do this lady right now.\" - rays 2026",
            "#136 \"I even showed my fruit, and I don't normally do that. It's a special occasion if the fruit are coming out.\" - rays 2026",
            "#137 \"Even though its in my stream and I control it, I actually don't control it and it's not my responsibility.\" -rays 2026",
            "#138 \"You spawn inside of each other\" - Dawnfinder",
            "#139 \"are a Isa efi RE\" - rays 2026",
            "#140 \"Should i show pickles on stream?\" -rays 2026",
            "#141 \"Being on the moon sucks because you don't have any movement.\"- rays 2026",
            "#142 \"Lady, did I do you already?\" -rays 2026",
            "#143 \"I do occasionally do a little knob twist\" - rays 2026",
            "#144 \"Oh, he's selling weed... Dang, he's got good deals.\" - Rays, 2026",
            "#145 \"Now I can show my fruity pebbles on stream\" - rays 2026",
            "#146 \"I need help getting in the hole... okay, rejected.\" - rays 2026",
            "#147 \"Do you know about those toes, man?\" - rays 2026",
            "#148 \"Oh, you're a professional fox flattener? I'm going to have to enquire about more information about this service in the future.\" -rays, 2026, after roy squished raysQ",
            "#149 \"As a gameplay guy who likes gameplay, it is more fun to play the game.\" - raysfire 2026",
            "#150 \"Do I just do all of these guys?\" - rays, 2026",
            "#151 \"Graphic design is my passion\" -rasy 2026",
            "#152 \"I am getting crushed by massive balls.\" - rays 2026",
            "#153 \"I do love a good bone\" - rays, 2026",
            "#154 \"it's such a perfect length\" -anonymous 2026",
            "#155 \"I'm harder than anything you've ever seen in your life\" -roy, in response to being called \"easy\" in SMW",
            "#156 \"We'll go for the foot sniff\" - rays 2026",
            "#157 \"I hate it in my LOINS.\" - raysfire 2026",
            "#158 \"The edging kept me alive, and that's what matters\" -rays, 2026, SMS",
            "#159 \"couldn't find the hole\" - rays, 2026",
            "#160 \"I've learned the power of the bang in recent times.\" -rays 2026, definitely talking about hair",
            "#161 \"That spider just rejected me, dude, what the heck!\" - rays, 2026",
            "#162 \"No, I can buy a D P. But I'm not gonna, its a little overpriced.\" -rays 2026, TTYD",
            "#163 \"Good evening fellas. We getting penisy in here tonight?\" - sbeve, 2026",
            "#164 \"I think we gotta bang it out\" - rays 2026",
            "#165 \"Watching the sucking technology. I finish it here.\" -rays 2026, Luigi's Mansion",
            "#166 \"I'm definitely not ace, though\" - rays, 2026",
            "#167 \"GC fans LOVE penis music dude\" - Roy, 2026"
        };

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin ciarenni.garfieldkartfuriousracing.frenchdimensionfix is loaded!");

            Harmony harmony = new Harmony(id: "ciarenni.garfieldkartfuriousracing.frenchdimensionfix");

            //patch the modified methods as pre- and post-fix as appropriate
            
            //harmony.Patch(AccessTools.Method(typeof(LoadingTips), "DisplayRandomTip"), prefix: new HarmonyMethod(patchType, nameof(PrefixDisplayRandomTip)));
            harmony.Patch(AccessTools.Method(typeof(LoadingTips), "DisplayRandomControlsTip"), prefix: new HarmonyMethod(patchType, nameof(PrefixDisplayRandomControlsTip)));
            harmony.Patch(AccessTools.Method(typeof(LoadingTips), "DisplayRandomBonusTip"), prefix: new HarmonyMethod(patchType, nameof(PrefixDisplayRandomBonusTip)));
        }

        public static bool PrefixDisplayRandomTip(LoadingTips __instance, Localization ___m_localization, Image ___m_mainImage, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
        {
            //set the localization like the original method
            ___m_localization = Localization.instance;

            //i dont know what this does, but the original method disables it unless it display a bonus tip, which we wont be doing, so continue disabling it
            ___m_counterLabel.transform.parent.gameObject.SetActive(true);

            //ensure the additonal images are not active, like the original method
            for (int i = 0; i < ___m_additionalImages.Length; i++)
            {
                //___m_additionalImages[i].gameObject.SetActive(false);
            }

            //the original method checks to see if the game object is active before trying to set the title and description, so i do too
            //if (__instance.gameObject.activeSelf)
            //{
                //disable the image on the loading screen tooltip, at least for now
                ___m_mainImage.transform.parent.gameObject.SetActive(true);

                //hard code the labels, just to indicate the mod is working
                ___m_titleLabel.text = "Former controls tip";
                ___m_descriptionLabel.text = "Former control helpful information";
            //}
            
            //return false to skip the original method
            return false;
        }

        public static bool PrefixDisplayRandomControlsTip(LoadingTips __instance, Image ___m_mainImage, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
        {
            //disable the image on the loading screen tooltip, at least for now
            ___m_mainImage.transform.parent.gameObject.SetActive(false);
            //int a_index = UnityEngine.Random.Range(0, PlayerGameEntities.TutoControlsItems.Length);
            //TutorialItem tutorialItem = PlayerGameEntities.TutoControlsItems[a_index];

            //hard code the labels, just to indicate the mod is working
            ___m_titleLabel.text = "Former controls tip";
            ___m_descriptionLabel.text = GetRandomQuote();

            //ensure the additonal images are not active, as they could also be causing the issue
            for (int i = 0; i < ___m_additionalImages.Length; i++)
            {
                ___m_additionalImages[i].gameObject.SetActive(false);
            }

            //i dont know what this does, but we're gonna disable it to prevent it cause problems. it SHOULD be just text
            ___m_counterLabel.transform.parent.gameObject.SetActive(false);

            //return false to skip the original method
            return false;
        }

        public static bool PrefixDisplayRandomBonusTip(LoadingTips __instance, Image ___m_mainImage, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
        {
            //disable the image on the loading screen tooltip, at least for now
            ___m_mainImage.transform.parent.gameObject.SetActive(false);
            //int a_index = UnityEngine.Random.Range(0, PlayerGameEntities.TutoControlsItems.Length);
            //TutorialItem tutorialItem = PlayerGameEntities.TutoControlsItems[a_index];

            //hard code the labels, just to indicate the mod is working
            ___m_titleLabel.text = "Former bonus tip";
            ___m_descriptionLabel.text = GetRandomQuote();

            //ensure the additonal images are not active, as they could also be causing the issue
            for (int i = 0; i < ___m_additionalImages.Length; i++)
            {
                ___m_additionalImages[i].gameObject.SetActive(false);
            }

            //i dont know what this does, but we're gonna disable it to prevent it cause problems. it SHOULD be just text
            ___m_counterLabel.transform.parent.gameObject.SetActive(false);

            //return false to skip the original method
            return false;
        }

        private static string GetRandomQuote()
        {
            return quotesList[UnityEngine.Random.Range(0, quotesList.Count)];
        }
    }
    //*************** below is an alternate implementation of patching the methods. these would use harmony.PatchAll(Assembly.GetExecutingAssembly()); to do the patching as opposed to patching individual methods
    //[HarmonyPatch(typeof(LoadingTips), "DisplayRandomControlsTip")]
    //public class LoadingTips_DisplayRandomControlsTip
    //{
    //    static bool Prefix(LoadingTips __instance, Image ___m_mainImage, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
    //    {
    //        //disable the image on the loading screen tooltip, at least for now
    //        ___m_mainImage.transform.parent.gameObject.SetActive(false);
    //        //int a_index = UnityEngine.Random.Range(0, PlayerGameEntities.TutoControlsItems.Length);
    //        //TutorialItem tutorialItem = PlayerGameEntities.TutoControlsItems[a_index];

    //        //hard code the labels, just to indicate the mod is working
    //        ___m_titleLabel.text = "Former controls tip";
    //        ___m_descriptionLabel.text = "Former control helpful information";

    //        //ensure the additonal images are not active, as they could also be causing the issue
    //        for (int i = 0; i < ___m_additionalImages.Length; i++)
    //        {
    //            ___m_additionalImages[i].gameObject.SetActive(false);
    //        }

    //        //i dont know what this does, but we're gonna disable it to prevent it cause problems. it SHOULD be just text
    //        ___m_counterLabel.transform.parent.gameObject.SetActive(false);

    //        //return false to skip the original method
    //        return false;
    //    }
    //}

    //[HarmonyPatch(typeof(LoadingTips), "DisplayRandomBonusTip")]
    //public class LoadingTips_DisplayRandomBonusTip
    //{
    //    static bool Prefix(LoadingTips __instance, Image ___m_mainImage, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
    //    {
    //        //disable the image on the loading screen tooltip, at least for now
    //        ___m_mainImage.transform.parent.gameObject.SetActive(false);
    //        //int a_index = UnityEngine.Random.Range(0, PlayerGameEntities.TutoControlsItems.Length);
    //        //TutorialItem tutorialItem = PlayerGameEntities.TutoControlsItems[a_index];

    //        //hard code the labels, just to indicate the mod is working
    //        ___m_titleLabel.text = "Former bonus tip";
    //        ___m_descriptionLabel.text = "Former bonus helpful information";

    //        //ensure the additonal images are not active, as they could also be causing the issue
    //        for (int i = 0; i < ___m_additionalImages.Length; i++)
    //        {
    //            ___m_additionalImages[i].gameObject.SetActive(false);
    //        }

    //        //i dont know what this does, but we're gonna disable it to prevent it cause problems. it SHOULD be just text
    //        ___m_counterLabel.transform.parent.gameObject.SetActive(false);

    //        //return false to skip the original method
    //        return false;
    //    }
    //}
}
