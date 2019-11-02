import sys
import grpc
import calculator_pb2
import calculator_pb2_grpc

def convert_to_operation_type(data: str):
    return calculator_pb2.OperationType.Value(data)

def send_requests():
    while True:
        data = input()
        if input == 'stop':
            return
        try:
            yield calculator_pb2.OperationRequest(operand= calculator_pb2.Operand(value= float(data)))
            continue
        except ValueError as error:
            pass

        try:
            yield calculator_pb2.OperationRequest(operation= convert_to_operation_type(data))
            continue
        except Exception as error:
            pass

def run_client(port: str):
    with grpc.insecure_channel(port) as channel:
        stub = calculator_pb2_grpc.CalculatorServiceStub(channel)
        responses = stub.Calculate(send_requests())
        for response in responses:
            print(f'Response: {response}')


def main():
    run_client(port= 'localhost:50051')

if __name__ == "__main__":
    sys.exit(int(main() or 0))