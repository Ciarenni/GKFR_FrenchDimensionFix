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

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin ciarenni.garfieldkartfuriousracing.frenchdimensionfix is loaded!");

            Harmony harmony = new Harmony(id: "ciarenni.garfieldkartfuriousracing.frenchdimensionfix");

            //patch the modified methods as pre- and post-fix as appropriate
            harmony.Patch(AccessTools.Method(typeof(LoadingTips), "DisplayRandomControlsTip"), prefix: new HarmonyMethod(patchType, nameof(PrefixDisplayRandomControlsTip)));
            harmony.Patch(AccessTools.Method(typeof(LoadingTips), "DisplayRandomBonusTip"), prefix: new HarmonyMethod(patchType, nameof(PrefixDisplayRandomBonusTip)));
        }

        public static bool PrefixDisplayRandomControlsTip(LoadingTips __instance, Image ___m_mainIamge, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
        {
            //disable the image on the loading screen tooltip, at least for now
            ___m_mainIamge.transform.parent.gameObject.SetActive(false);
            //int a_index = UnityEngine.Random.Range(0, PlayerGameEntities.TutoControlsItems.Length);
            //TutorialItem tutorialItem = PlayerGameEntities.TutoControlsItems[a_index];

            //hard code the labels, just to indicate the mod is working
            ___m_titleLabel.text = "Former controls tip";
            ___m_descriptionLabel.text = "Former control helpful information";

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

        public static bool PrefixDisplayRandomBonusTip(LoadingTips __instance, Image ___m_mainIamge, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
        {
            //disable the image on the loading screen tooltip, at least for now
            ___m_mainIamge.transform.parent.gameObject.SetActive(false);
            //int a_index = UnityEngine.Random.Range(0, PlayerGameEntities.TutoControlsItems.Length);
            //TutorialItem tutorialItem = PlayerGameEntities.TutoControlsItems[a_index];

            //hard code the labels, just to indicate the mod is working
            ___m_titleLabel.text = "Former bonus tip";
            ___m_descriptionLabel.text = "Former bonus helpful information";

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
    }
    //*************** below is an alternate implementation of patching the methods. these would use harmony.PatchAll(Assembly.GetExecutingAssembly()); to do the patching as opposed to patching individual methods
    //[HarmonyPatch(typeof(LoadingTips), "DisplayRandomControlsTip")]
    //public class LoadingTips_DisplayRandomControlsTip
    //{
    //    static bool Prefix(LoadingTips __instance, Image ___m_mainIamge, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
    //    {
    //        //disable the image on the loading screen tooltip, at least for now
    //        ___m_mainIamge.transform.parent.gameObject.SetActive(false);
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
    //    static bool Prefix(LoadingTips __instance, Image ___m_mainIamge, TextMeshProUGUI ___m_titleLabel, TextMeshProUGUI ___m_descriptionLabel, Image[] ___m_additionalImages, TextMeshProUGUI ___m_counterLabel)
    //    {
    //        //disable the image on the loading screen tooltip, at least for now
    //        ___m_mainIamge.transform.parent.gameObject.SetActive(false);
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
