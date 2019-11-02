import sys
import grpc
import time
from concurrent import futures
import calculator_pb2
import calculator_pb2_grpc
from Services.CalculatorService import CalculatorService

_ONE_DAY_IN_SECONDS = 60 * 60 * 24


def open_server(port: str):
  print(f'Server started at: {port}')
  print('Press Ctrl + C to close.')
  server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
  calculator_pb2_grpc.add_CalculatorServiceServicer_to_server(CalculatorService(), server)
  server.add_insecure_port(port)
  server.start()
  try:
      while True:
          time.sleep(_ONE_DAY_IN_SECONDS)
  except KeyboardInterrupt:
      print(f'Server closed.')
      server.stop(0)

def main():
    open_server(port= 'localhost:50051')

if __name__ == "__main__":
    sys.exit(int(main() or 0))