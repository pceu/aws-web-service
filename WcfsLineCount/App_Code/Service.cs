using System;
using System.IO;
using System.Net;

public class Service : IService
{
    public int LineCount(string filename)
    {
        int count = 0;

        WebClient webClient = new WebClient();
        Stream stream = webClient.OpenRead(filename);
        StreamReader streamReader = new StreamReader(stream);

        while (!streamReader.EndOfStream)
        {
            streamReader.ReadLine();
            count++;
        }

        return (count);
    }
}
