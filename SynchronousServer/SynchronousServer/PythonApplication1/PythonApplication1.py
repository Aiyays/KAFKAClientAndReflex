import socket
from multiprocessing import Process


def handle_clent(client_socket):
    request_data = client_socket.recv(1024)
    print("Request data:", request_data)
    response_start_line = "HTTP/1.1 200 OK\r\n"
    response_headers = "Server: My server\r\n"
    response_body = "Hello 王舒婷"
    response = response_start_line + response_headers + "Request Method: POST\r\n" + "\r\n" + response_body
    client_socket.send(bytes(response, "utf-8"))
    client_socket.close()



if __name__ == "__main__":
    sk = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sk.bind(("127.0.0.1", 8000))
    sk.listen(128)
    while True:
        client_socket, client_address = sk.accept()
        print("[%s, %s]用户连接上了" % client_address)
        handle_process = Process(target=handle_clent, args=(client_socket,))
        handle_process.start()
        client_socket.close()

