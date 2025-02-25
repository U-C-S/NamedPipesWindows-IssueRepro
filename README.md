This repo contains project files to reproduce an issue with [System.IO.Pipes.NamedPipeServerStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.pipes.namedpipeserverstream?view=net-9.0). Reported in the [Dotnet/runtime repo at #112912](https://github.com/dotnet/runtime/issues/112912)

## Getting Started
- Make sure to have [Rust](https://www.rust-lang.org/tools/install) and [DotNet 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed in your system
- Open 2 terminals, one for server and other for the client.
- In the `Server`, `dotnet run` to start running the server that opens a server stream using named pipe
- In the `client`, `cargo run` to run the client which sends a message to client and immediately exits. so to send multiple messages, run client multiple times.

## The Issue

![image](https://github.com/user-attachments/assets/f3bf2045-3c69-44e2-a665-d3eb15446581)

In the above image, the named pipe server sometimes fails/doesn't receive the message sent by client. Usually, for the first message recieved after server is started.
