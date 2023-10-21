using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    public List<AudioSource> audioSources = new();
    public bool useBuffer = true;

    private List<float[]> samplesList = new();
    private float[] freqBands = new float[8];
    private float[] freqBandBuffers = new float[8];
    private float[] bufferDecrease = new float[8];

    private float[] freqBandsHighest = new float[8];
    private float[] audioBands = new float[8];
    private float[] audioBandBuffers = new float[8];

    private void Update()
    {
        if (audioSources.Count == 0) return;
        ReadSamples();
        CalculateFrequencyBands();
        if (useBuffer) BufferFrequencyBands();
        CalculateAudioBands();
    }

    private void ReadSamples()
    {
        var sourceIndex = 0;
        foreach (var audioSource in audioSources)
        {
            float[] samples;
            if (samplesList.Count < sourceIndex + 1)
            {
                samples = new float[512];
                samplesList.Add(samples);
            }
            else
            {
                samples = samplesList[sourceIndex];
            }

            sourceIndex++;
            audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        }
    }

    private float GetMaxSampleAtPosition(int sampleIndex)
    {
        float maxSample = 0;
        foreach (var samples in samplesList)
        {
            var sample = samples[sampleIndex];
            if (sample > maxSample) maxSample = sample;
        }

        return maxSample;
    }

    public void CalculateFrequencyBands()
    {
        var totalSampleCount = 0;
        for (var freqIndex = 0; freqIndex < freqBands.Length; freqIndex++)
        {
            float average = 0;
            var sampleCount = (int)Mathf.Pow(2, freqIndex) * 2;

            if (freqIndex == 7) sampleCount += 2;
            for (var sampleIndex = 0; sampleIndex < sampleCount; sampleIndex++)
            {
                average += GetMaxSampleAtPosition(totalSampleCount) * (totalSampleCount + 1);
                totalSampleCount++;
            }

            average /= totalSampleCount;

            freqBands[freqIndex] = average;
        }
    }

    private void BufferFrequencyBands()
    {
        for (var freqIndex = 0; freqIndex < freqBands.Length; freqIndex++)
            // New Maximum reached
            if (freqBands[freqIndex] > freqBandBuffers[freqIndex])
            {
                freqBandBuffers[freqIndex] = freqBands[freqIndex];
                bufferDecrease[freqIndex] = 0.005f;
            }
            else if (freqBands[freqIndex] < freqBandBuffers[freqIndex])
            {
                freqBandBuffers[freqIndex] -= bufferDecrease[freqIndex];
                bufferDecrease[freqIndex] *= 1.2f;
            }
    }

    private void CalculateAudioBands()
    {
        for (var freqIndex = 0; freqIndex < freqBands.Length; freqIndex++)
        {
            if (freqBands[freqIndex] > freqBandsHighest[freqIndex]) freqBandsHighest[freqIndex] = freqBands[freqIndex];
            audioBands[freqIndex] = freqBands[freqIndex] / freqBandsHighest[freqIndex];
            audioBandBuffers[freqIndex] = freqBandBuffers[freqIndex] / freqBandsHighest[freqIndex];
        }
    }

    public float GetSample(int sampleIndex)
    {
        return GetMaxSampleAtPosition(sampleIndex);
    }

    public float GetFrequencyBand(int freqIndex)
    {
        return useBuffer ? freqBandBuffers[freqIndex] : freqBands[freqIndex];
    }

    // Normalized frequency band between 0 and 1
    public float GetAudioBand(int freqIndex)
    {
        return audioBands[freqIndex];
    }
}