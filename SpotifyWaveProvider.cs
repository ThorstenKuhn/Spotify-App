using System;
using System.Net;
using NAudio.Wave;

class SpotifyWaveProvider : IWaveProvider
{
    private readonly string streamUrl;
    private readonly WebClient webClient;

    public SpotifyWaveProvider(string streamUrl)
    {
        this.streamUrl = streamUrl;
        this.webClient = new WebClient();
    }

    public WaveFormat WaveFormat => WaveFormat.CreateIeeeFloatWaveFormat(44100, 2);

    public int Read(byte[] buffer, int offset, int count)
    {
        var audioData = webClient.DownloadData(streamUrl);
        Buffer.BlockCopy(audioData, 0, buffer, offset, count);
        return count;
    }
}