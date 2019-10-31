import sys
import grpc
import greeting_pb2
import greeting_pb2_grpc



def run_client(port: str):
    with grpc.insecure_channel(port) as channel:
        stub = greeting_pb2_grpc.GreetingServiceStub(channel)
        request = greeting_pb2.GreetingRequest(message = 'Hi', sender_name= 'Marius')
        response = stub.Greet(request)
        print(f'Response: {response}')


def main():
    run_client(port= 'localhost:50051')

if __name__ == "__main__":
    sys.exit(int(main() or 0))