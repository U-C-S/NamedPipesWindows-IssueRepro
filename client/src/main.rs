use chrono;
use tokio::net::windows::named_pipe;

static PIPE_NAME: &str = r"\\.\pipe\NamedTest000x";

#[tokio::main]
async fn main() {
    let fmt = "%H:%M:%S:%3f";

    let message = "Hello from the client!";

    let pipe_conn = named_pipe::ClientOptions::new().open(PIPE_NAME);
    match pipe_conn {
        Ok(client) => {
            client.writable().await.unwrap();
            let write_result = client.try_write(message.as_bytes());
            let time = chrono::Local::now().format(fmt).to_string();

            match write_result {
                Ok(res) => {
                    println!("[{:?}] Sent {:?} bytes - {:?}", time, res, message);
                }
                Err(e) => {
                    println!("Failed to send message: {:?}", e);
                }
            }
        }
        Err(_) => {
            panic!("Failed to connect to the server");
        }
    }
}
