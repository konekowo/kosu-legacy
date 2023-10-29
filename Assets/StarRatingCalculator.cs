using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
/*
public class StarRatingCalculator : MonoBehaviour
{
    
    private const double difficulty_multiplier = 0.0675;
    
    public static float starCalculate(BeatmapsDB beatmapDiff, Skill[] skills)
    {
        // Most of this code is from https://github.com/ppy/osu/
        
        double aimRating = Math.Sqrt(skills[0].DifficultyValue()) * difficulty_multiplier;
        double speedRating = Math.Sqrt(skills[2].DifficultyValue()) * difficulty_multiplier;
        
        double baseAimPerformance = Math.Pow(5 * Math.Max(1, aimRating / 0.0675) - 4, 3) / 100000;
        double baseSpeedPerformance = Math.Pow(5 * Math.Max(1, speedRating / 0.0675) - 4, 3) / 100000;
        double baseFlashlightPerformance = 0.0;
        
        double basePerformance =
            Math.Pow(
                Math.Pow(baseAimPerformance, 1.1) +
                Math.Pow(baseSpeedPerformance, 1.1) +
                Math.Pow(baseFlashlightPerformance, 1.1), 1.0 / 1.1
            );
        
        double starRating = basePerformance > 0.00001
                        ? Math.Cbrt(1.14) * 0.027 * (Math.Cbrt(100000 / Math.Pow(2, 1 / 1.1) * basePerformance) + 4)
                        : 0;
        return 0f;
    }
}

public abstract class Skill : MonoBehaviour
{
    /// <summary>
    /// Mods for use in skill calculations.
    /// </summary>
    protected IReadOnlyList<Mod> Mods => mods;

    private readonly Mod[] mods;

    protected Skill(Mod[] mods)
    {
        this.mods = mods;
    }

    /// <summary>
    /// Process a <see cref="DifficultyHitObject"/>.
    /// </summary>
    /// <param name="current">The <see cref="DifficultyHitObject"/> to process.</param>
    public abstract void Process(DifficultyHitObject current);

    /// <summary>
    /// Returns the calculated difficulty value representing all <see cref="DifficultyHitObject"/>s that have been processed up to this point.
    /// </summary>
    public abstract double DifficultyValue();
}

public abstract class StrainSkill : Skill
{
    /// <summary>
        /// The weight by which each strain value decays.
        /// </summary>
        protected virtual double DecayWeight => 0.9;

        /// <summary>
        /// The length of each strain section.
        /// </summary>
        protected virtual int SectionLength => 400;

        private double currentSectionPeak; // We also keep track of the peak strain level in the current section.

        private double currentSectionEnd;

        private readonly List<double> strainPeaks = new List<double>();

        protected StrainSkill(Mod[] mods)
            : base(mods)
        {
        }

        /// <summary>
        /// Returns the strain value at <see cref="DifficultyHitObject"/>. This value is calculated with or without respect to previous objects.
        /// </summary>
        protected abstract double StrainValueAt(DifficultyHitObject current);

        /// <summary>
        /// Process a <see cref="DifficultyHitObject"/> and update current strain values accordingly.
        /// </summary>
        public sealed override void Process(DifficultyHitObject current)
        {
            // The first object doesn't generate a strain, so we begin with an incremented section end
            if (current.Index == 0)
                currentSectionEnd = Math.Ceiling(current.StartTime / SectionLength) * SectionLength;

            while (current.StartTime > currentSectionEnd)
            {
                saveCurrentPeak();
                startNewSectionFrom(currentSectionEnd, current);
                currentSectionEnd += SectionLength;
            }

            currentSectionPeak = Math.Max(StrainValueAt(current), currentSectionPeak);
        }

        /// <summary>
        /// Saves the current peak strain level to the list of strain peaks, which will be used to calculate an overall difficulty.
        /// </summary>
        private void saveCurrentPeak()
        {
            strainPeaks.Add(currentSectionPeak);
        }

        /// <summary>
        /// Sets the initial strain level for a new section.
        /// </summary>
        /// <param name="time">The beginning of the new section in milliseconds.</param>
        /// <param name="current">The current hit object.</param>
        private void startNewSectionFrom(double time, DifficultyHitObject current)
        {
            // The maximum strain of the new section is not zero by default
            // This means we need to capture the strain level at the beginning of the new section, and use that as the initial peak level.
            currentSectionPeak = CalculateInitialStrain(time, current);
        }

        /// <summary>
        /// Retrieves the peak strain at a point in time.
        /// </summary>
        /// <param name="time">The time to retrieve the peak strain at.</param>
        /// <param name="current">The current hit object.</param>
        /// <returns>The peak strain.</returns>
        protected abstract double CalculateInitialStrain(double time, DifficultyHitObject current);

        /// <summary>
        /// Returns a live enumerable of the peak strains for each <see cref="SectionLength"/> section of the beatmap,
        /// including the peak of the current section.
        /// </summary>
        public IEnumerable<double> GetCurrentStrainPeaks() => strainPeaks.Append(currentSectionPeak);

        /// <summary>
        /// Returns the calculated difficulty value representing all <see cref="DifficultyHitObject"/>s that have been processed up to this point.
        /// </summary>
        public override double DifficultyValue()
        {
            double difficulty = 0;
            double weight = 1;

            // Sections with 0 strain are excluded to avoid worst-case time complexity of the following sort (e.g. /b/2351871).
            // These sections will not contribute to the difficulty.
            var peaks = GetCurrentStrainPeaks().Where(p => p > 0);

            // Difficulty is the weighted sum of the highest strains from every section.
            // We're sorting from highest to lowest strain.
            foreach (double strain in peaks.OrderByDescending(d => d))
            {
                difficulty += strain * weight;
                weight *= DecayWeight;
            }

            return difficulty;
        }
    }        
}
*/