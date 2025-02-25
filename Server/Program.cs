using System.IO.Pipes;

namespace Server;

internal class Program
{
  static void Main(string[] _)
  {
    Console.WriteLine("Server started");
    PipeServer();
  }

  static void PipeServer()
  {
    NamedPipeServerStream? _pipeserver = null;
    while (true)
    {
      try
      {
        _pipeserver = new("NamedTest000x", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        _pipeserver.WaitForConnection();

        Console.WriteLine("- PipeServer Connected");

        using StreamReader sr = new(_pipeserver);
        string message = sr.ReadToEnd();

        Console.WriteLine($"-- [{DateTime.Now:HH:mm:ss:fff}] Message recieved: \"{message}\"");
      }
      catch (Exception e)
      {
        Console.WriteLine($"-- Error in PipeServer: {e}");
      }
      finally
      {
        _pipeserver?.Dispose();
        Console.WriteLine("-- PipeServer Connection disconnected, waiting for new connection...");
      }
    }
  }
}
